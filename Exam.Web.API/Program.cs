using Exam.Business.Interface;
using Exam.Business.Services;
using Exam.Data.EntityModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", policy =>
                      {
                          policy.AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowAnyOrigin();
                      });
});

// Add services to the container.
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ExamProductDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Exam_DBConn"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();
app.UseHttpsRedirection();
app.Run();