using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleApp.Application.Features.Client.Queries;
using SampleApp.Core.Repositories;
using SampleApp.Infrastructure.Contexts;
using SampleApp.Infrastructure.Repositories;
using SampleApp.Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextFactory<SampleDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddMediatR(typeof(AllClientsQuery));

builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();