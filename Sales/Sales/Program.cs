using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Sales.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.AddLog4Net("log4net.config");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<datacontext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("salesdb"));
});
builder.Services.AddCors(options =>
options.AddPolicy(name: "personOrigin",
policy =>
{
    policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();

}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("personOrigin");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
