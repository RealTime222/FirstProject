using data_layer;
using logic_layer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<Idata, data>();
builder.Services.AddScoped<Ilogic, logic>();
builder.Services.AddScoped<IdataProduct, dataProduct>();
builder.Services.AddScoped<IlogicProduct, logicProduct>();
builder.Services.AddScoped<IlogicCategory, logicCategory>();
builder.Services.AddScoped<IdataCategory, dataCategory>();
builder.Services.AddScoped<IdataOrder, dataOrder>();
builder.Services.AddScoped<IlogicOrder, logicOrder>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WebApiProjectContext>(options => options.UseSqlServer
("Data Source=DESKTOP-UC03848;Initial Catalog=web_api_project;Integrated Security=True;Pooling = false"));


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();



app.Run();
