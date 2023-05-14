using Microsoft.EntityFrameworkCore;
using SirmaBE.DB;
using SirmaBE.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ConectionDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseStaticFiles();


app.UseAuthorization();

app.MapControllers();

app.Run();
