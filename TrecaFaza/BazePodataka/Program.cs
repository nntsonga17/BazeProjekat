var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CORS", options =>
    {
        options.AllowAnyHeader()
               .AllowAnyMethod()
               .WithOrigins("http://127.0.0.1:5555",
                            "https://127.0.0.1:5555",
                            "http://localhost:5555",
                            "https://localhost:5555",
                            "http://127.0.0.1:5500",
                            "https://127.0.0.1:5500",
                            "http://127.0.0.1:5501",
                            "https://127.0.0.1:5501",
                            "http://localhost:5072",
                            "https://localhost:5072",
                            "http://localhost:7153",
                            "https://localhost:7153");
    });
});

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseCors("CORS");

app.UseAuthorization();

app.MapControllers();

app.Run();
