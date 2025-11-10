using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniversityBack.Application;
using UniversityBack.Business.Interfaces;
using UniversityBack.Business.Mapping;
using UniversityBack.Business.Services;
using UniversityBack.Data.DataContext;
using UniversityBack.Data.Interfaces;
using UniversityBack.Data.Repository;
using UniversityBack.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Add dbcontext with SQl provider
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Add service
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IBaseService<Empresa, EmpresaDto>, BaseService<Empresa, EmpresaDto>>();

// Add repository
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IBaseRepository<int, Empresa>, BaseRespository<int, Empresa>>();


// add identity services
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationContext>();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
