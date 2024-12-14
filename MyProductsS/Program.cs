using Microsoft.EntityFrameworkCore;
using MyProductsS.Models;
using MyProductsS.Data;
using MyProductsS.Mapper;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllers();
//builder.Services.AddAutoMapper(typeof(MappingProfile));
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//var app = builder.Build();
//app.MapControllers();
//app.Run();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add services to the container.
builder.Services.AddControllers();

// Add DbContext with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure middleware pipeline

// Middleware for handling errors (exception handling in development)
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Displays detailed error pages
    app.UseSwagger(); // Enable Swagger UI
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRUDExample API v1"));
}
else
{
    // Use a custom exception handler in production
    app.UseExceptionHandler("/error");
    app.UseHsts(); // Enforces HTTPS in production
}

// Redirect HTTP to HTTPS
app.UseHttpsRedirection();

// Middleware for routing
app.UseRouting();

// Middleware for authentication (if implemented)
app.UseAuthentication();

// Middleware for authorization
app.UseAuthorization();

// Middleware for static files (if applicable)
app.UseStaticFiles();

// Map the controllers to endpoints
app.MapControllers();

// Run the application
app.Run();
