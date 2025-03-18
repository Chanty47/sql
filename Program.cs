using Microsoft.EntityFrameworkCore;
 // Make sure you include this namespace for your DataContext

var builder = WebApplication.CreateBuilder(args);

// Register the DataContext with SQLite
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite("Data Source=app.db"));

// Add services to the container.
builder.Services.AddControllers();

// Add Swagger support for API documentation
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure middleware
app.UseAuthorization();
app.MapControllers();

app.Run();
