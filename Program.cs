using Microsoft.EntityFrameworkCore;
using ssoUM.BAL;
using ssoUM.DAL;
using ssoUM.DAL.Interfaces;
using ssoUM.BAL.Interface;

var builder = WebApplication.CreateBuilder(args);

/*------Database Connection------*/
builder.Services.AddDbContext<ssoUMDBContext>(options =>
    options.UseSqlServer(
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
