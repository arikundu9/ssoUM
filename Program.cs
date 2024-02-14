using Microsoft.EntityFrameworkCore;
using ssoUM.BAL;
using ssoUM.DAL;
using ssoUM.DAL.Interfaces;
using ssoUM.BAL.Interface;
using Asp.Versioning;
// using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

/*------Database Connection------*/
builder.Services.AddDbContext<ssoUMDBContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("ssoUMDBConnection"),
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

builder.Services.AddControllers();
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
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
