using Microsoft.EntityFrameworkCore;
using ssoUM.BAL;
using ssoUM.DAL;
using ssoUM.DAL.Interfaces;
using ssoUM.BAL.Interface;
using Asp.Versioning;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerUI;
using Newtonsoft.Json;
using ssoUM.Middlewares;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using ssoUM.Utils;
using static Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary;
using System.Text.Json.Serialization;
// using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

/*------Database Connection------*/
builder.Services.AddDbContext<ssoUMDBContext>(options =>
	options.UseNpgsql(
		builder.Configuration.GetConnectionString("ssoUMDBConnection__PG"),
		////options => options.CommandTimeout(999)
		options => options.EnableRetryOnFailure(10, TimeSpan.FromSeconds(5), null)
	),
	ServiceLifetime.Transient
);

/*--------------AAA-------------*/
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.
//Repositories
builder.Services.AddTransient<IUserRepo, UserRepo>();
builder.Services.AddTransient<IRoleRepo, RoleRepo>();
builder.Services.AddTransient<IKeyRepo, KeyRepo>();
builder.Services.AddTransient<IJwtRepo, JwtRepo>();
builder.Services.AddTransient<IAppRepo, AppRepo>();
//Services
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<IKeyService, KeyService>();
builder.Services.AddTransient<IJwtService, JwtService>();
builder.Services.AddTransient<IAppService, AppService>();
// builder.Services.AddTransient<ITransactionRepo, TransactionRepo>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
var apiVersioningBuilder = builder.Services.AddApiVersioning(x =>
{
	x.DefaultApiVersion = new ApiVersion(1, 0);
	x.AssumeDefaultVersionWhenUnspecified = true;
	x.ReportApiVersions = true;
	x.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
									new HeaderApiVersionReader("x-api-version"),
									new MediaTypeApiVersionReader("x-api-version"));
});
apiVersioningBuilder.AddApiExplorer(options =>
{
	// add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
	// note: the specified format code will format the version as "'v'major[.minor][-status]"
	options.GroupNameFormat = "'v'VVV";

	// note: this option is only necessary when versioning by url segment. the SubstitutionFormat
	// can also be used to control the format of the API version in route templates
	options.SubstituteApiVersionInUrl = true;
}); // Nuget Package: Asp.Versioning.Mvc.ApiExplorer
builder.Services.AddEndpointsApiExplorer();
// builder.Services.Configure<RouteOptions>(options => { options.LowercaseUrls = true; });
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(options =>
{
	// Add a custom operation filter which sets default values
	options.OperationFilter<SwaggerDefaultValues>();
	var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

	options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
	{
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer",
		BearerFormat = "JWT",
		In = ParameterLocation.Header,
		Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
	});
	options.AddSecurityRequirement(new OpenApiSecurityRequirement {
		{
			new OpenApiSecurityScheme {
				Reference = new OpenApiReference {
					Type = ReferenceType.SecurityScheme,
						Id = "Bearer"
				}
			},
			new string[] {}
		}
	});
});
// DTO validation response override
builder.Services.Configure<ApiBehaviorOptions>(config =>
{
	config.InvalidModelStateResponseFactory =
		ctx => new BadRequestObjectResult(
			new RestResponse<ValueEnumerable>()
			{
				Success = false,
				RespCode = ResponseCode.Invalid_DTO,
				Data = ctx.ModelState.Values,
				Message = "DTO validation error :: Data field specifies error location.",
				// Errors = new List<object>()
			}
		);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
	// app.UseSwagger();
	// app.UseSwaggerUI();
	app.UseSwagger(options =>
	{
		options.SerializeAsV2 = true;
	});
	app.UseSwaggerUI(options =>
	{
		options.InjectStylesheet("/swagger-ui/swagger.css");
		options.InjectJavascript("/swagger-ui/jquery-3.7.1.min.js");
		options.InjectJavascript("/swagger-ui/swagger.js");
		options.EnableFilter();
		options.EnablePersistAuthorization();
		options.EnableValidator();
		options.EnableDeepLinking();
		options.DisplayRequestDuration();
		options.ShowExtensions();
		options.DocumentTitle = "ssoUM API";
		options.DocExpansion(DocExpansion.None);

		// Build a swagger endpoint for each discovered API version
		foreach (var description in app.DescribeApiVersions())
		{
			var url = $"/swagger/{description.GroupName}/swagger.json";
			var name = $"Version {description.GroupName.ToLowerInvariant()}";
			options.SwaggerEndpoint(url, name);
		}
	});
}

app.MapGet("/buildId", () => JsonConvert.SerializeObject(
				new
				{
					buildid = Assembly.GetExecutingAssembly().ManifestModule.ModuleVersionId.ToString()
				})
			);

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseDefaultFiles();

app.UseFileServer();

app.UseHttpsRedirection();

app.UseAuthorization();

// app.UseAuthTokenMiddleware();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapControllers();

app.Run();
