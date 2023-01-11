using Microsoft.EntityFrameworkCore;
using UserBackend.Data;

var builder = WebApplication.CreateBuilder(args);

string dbEnv = Environment.GetEnvironmentVariable("DATABASE_CONECTION");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddDbContext<UserDbContext>(options => 
{
    if (dbEnv != null)
    {
        options.UseSqlServer(dbEnv);
    }
    else 
    { 
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corspolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
