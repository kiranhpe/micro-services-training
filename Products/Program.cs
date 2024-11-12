using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Products.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var server = builder.Configuration["DbServer"] ?? "localhost";
var port = builder.Configuration["DbPort"] ?? "1433"; // Default SQL Server port
var user = builder.Configuration["DbUser"] ?? "SA"; // Warning do not use the SA account
var password = builder.Configuration["Password"] ?? "krian@123";
var database = builder.Configuration["Database"] ?? "ProductDb";

var connectionString = $"Server={server}, {port};Initial Catalog={database};User ID={user};Password={password}";

builder.Services.AddDbContext<ProductsContext>(options =>
    options.UseSqlServer(connectionString ?? throw new InvalidOperationException("Connection string 'ProductsContext' not found.")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// enable CORS


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

DbMigrationService.MigrationInit(app);


app.UseAuthorization();

app.MapControllers();

app.Run();
