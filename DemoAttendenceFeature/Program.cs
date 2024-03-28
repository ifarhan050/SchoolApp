using DemoAttendenceFeature.Data;
using DemoAttendenceFeature.Extension;
using DemoAttendenceFeature.Helper;
using DemoAttendenceFeature.Helper.Interface;
using DemoAttendenceFeature.Infrastructure;
using DemoAttendenceFeature.Infrastructure.Interface;
using DemoAttendenceFeature.Mapping;
using DemoAttendenceFeature.Service;
using DemoAttendenceFeature.Setting_Models;
using DemoAttendenceFeature.Utility;
using DemoAttendenceFeature.Utility.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IStudentRepository,StudentRepository>();
builder.Services.AddScoped<IAttendenceRepository, AttendenceRepository>();
builder.Services.AddScoped<IGuardianRepository, GuardianRepository>();
builder.Services.AddScoped<IAdmissionStudentStatusRepository,AdmissionStudentStatusRepository>();
builder.Services.AddScoped<IEmail, Email>();
builder.Services.AddScoped<IImageTransaction, ImgaeTransaction>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<GuardianService>();
builder.Services.AddScoped<GuardianStudentService>();
builder.Services.AddScoped<AttendenceService>();
builder.Services.AddScoped<AdmissionService>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<RegistrationEmailService>();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddCors(options=>options.AddDefaultPolicy(x=>x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));


//builder.Services.Configure<EmailSettings>(c => builder.Configuration.GetSection("EmailSettings"));
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MigrateDatabase<AppDbContext>();
//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors();
app.Run();
