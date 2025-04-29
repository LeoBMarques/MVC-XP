using Microsoft.EntityFrameworkCore;
using MVC_XP.Infra;
using MVC_XP.Model.Interfaces;
using MVC_XP.Model.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configure Context
builder.Services.AddDbContext<MVCXPContext>(options =>
{
    options.UseInMemoryDatabase(typeof(MVCXPContext).Assembly.FullName);
});

// Configure Repository
builder.Services.AddScoped<IRepository, MVCXPRepository>();

// Configure Services
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "api");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
