using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using School.Context;
using School.Models;
using School.Repo.Implementaion;
using School.Repo.Interface;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));


builder.Services.AddScoped<IGenericRepo<Department>,GenericRepo<Department>>();
builder.Services.AddScoped<IGenericRepo<Student>,GenericRepo<Student>>();
builder.Services.AddScoped<IGenericRepo<ClassRoom>,GenericRepo<ClassRoom>>();
builder.Services.AddScoped<IGenericRepo<Teacher>,GenericRepo<Teacher>>();
builder.Services.AddScoped<IGenericRepo<Subject>,GenericRepo<Subject>>();
builder.Services.AddScoped<IGenericRepo<Enrollment>,GenericRepo<Enrollment>>();


builder.Services.AddScoped<ITeacherRepo,TeacherRepo>();
builder.Services.AddScoped<ISubjectRepo,SubjectRepo>();
builder.Services.AddScoped<IClassRoom,ClassRoomRepo>();
builder.Services.AddScoped<IUserRepo,UserRepo>();

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();


var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:key"]));
builder.Services.AddAuthentication(options =>
{

    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}
).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["jwt:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["jwt:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = key
    };
});
    









var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
