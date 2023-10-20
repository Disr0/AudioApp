using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AudioApp.DAL;
using System.Linq;
using AudioApp.Logic.Impl;
using AudioApp.Logic.Contracts;

var spaSrcPath = "ClientApp";
var corsPolicyName = "AllowAll";
var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextFactory<AudioAppContext>(options => options.UseNpgsql(connection));
builder.Services.AddSingleton<IMigrateService, MigrateService>();


builder.Services.AddControllers();
builder.Services.AddSpaStaticFiles(opt => opt.RootPath = $"{spaSrcPath}/dist");


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseResponseCompression();
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseCors(corsPolicyName);
app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.UseSpa(spa =>
{
    spa.Options.SourcePath = spaSrcPath;

    if (app.Environment.IsDevelopment())
        spa.UseReactDevelopmentServer(npmScript: "start");
});

//app.MapGet("/", (AudioAppContext db) => db.Users.ToList());

app.Run();