using data_layer;
using FirstProject;
using logic_layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLog.Web;


var builder = WebApplication.CreateBuilder(args);
var cs = builder.Configuration.GetConnectionString("home");

// Add services to the container.
builder.Host.UseNLog();
builder.Services.AddControllers();

builder.Services.AddScoped<Idata, data>();
builder.Services.AddScoped<Ilogic, logic>();
builder.Services.AddScoped<IdataProduct, dataProduct>();
builder.Services.AddScoped<IlogicProduct, logicProduct>();
builder.Services.AddScoped<IlogicCategory, logicCategory>();
builder.Services.AddScoped<IdataCategory, dataCategory>();
builder.Services.AddScoped<IdataOrder, dataOrder>();
builder.Services.AddScoped<IlogicOrder, logicOrder>();
builder.Services.AddScoped<IlogicRating, logicRating>();
builder.Services.AddScoped<IdataRating, dataRating>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WebApiProjectContext>(options => options.UseSqlServer(cs));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();
app.UseRating();
//app.Run(async (context) =>
//{
//    //await context.Response.WriteAsync("hello");
//    Console.WriteLine("in run");
//});
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
