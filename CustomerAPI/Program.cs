using Customer.MigrationService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var server = builder.Configuration["DbServer"] ?? "localhost";
var port = builder.Configuration["DbPort"] ?? "1433"; // Default SQL Server port
var user = builder.Configuration["DbUser"] ?? "SA"; // Warning do not use the SA account
var password = builder.Configuration["Password"] ?? "krian@123";
var database = builder.Configuration["Database"] ?? "CustomerDB";

var connectionString = $"Server={server}, {port};Initial Catalog={database};User ID={user};Password={password}";

builder.Services.AddDbContext<Customer.BL.CustomerContext>(options =>
    options.UseSqlServer(connectionString ?? throw new InvalidOperationException("Connection string 'CustomerContext' not found."),
    options => options.MigrationsAssembly("CustomerAPI")
     ));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

DbMigrationService.MigrationInit(app);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
