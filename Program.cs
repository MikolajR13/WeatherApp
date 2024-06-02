using Instrukcja.Components;
using Instrukcja.Data;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.EntityFrameworkCore;
using Instrukcja.Services;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme)
    .AddCertificate();
// Serwis do Blazorise
builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
        options.ProductToken = "CjxRBHF4NQo+UQJyfjc1BlEAc3o1DzxRAnF8NAw6bjoNJ2ZdYhBVCCo/CTVWBExERldhE1EvN0xcNm46FD1gSkUHCkxESVFvBl4yK1FBfAYKFTxsWWBuOh4RQXlYIncTB0FnUy5xGRFaakM0Yx4RP3ZDPHwIA0xsX246HhFEbVgscw4DVXRJN3UeEUh5VDxvEwFSa1M8Cg8BWnRFLnkVHQgyUzxzCQ9XbF88bwwPXWdTMX8WHVpnNi1/HgJMdUU3Y0xEWmdAKmMVGEx9WzxvDA9dZ1MxfxYdWmc2LX8eAkx1RTdjTERaZ1gxdQQYTH1bPG8MD11nUzF/Fh1aZzYtfx4CTHVFN2NMREkKTRB5MwBfSUQ2ZXh4SX5+KwM1IFNIexlzJR5mWURWZg94QFZoJXE4DFVAYQ4ECHdrS2URCA4+YllgB2I3OHwKZTR+EQR8DG8HfjUKR2xZMVkbICoXPVJgeQFpT00mVys6N3B9Fnt3IjdhQipJDClKW34pfxIfRE9WL1omADB5NCFEIgRxSE9RRSYkLkt8L3wZOC5gPRF4FXhgXmYydQ13f3Y4EEEqHEBzRV4=";
    })
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons();
//Serwis do API
builder.Services.AddScoped<HttpClient>();
//Rejsetrowanie serwisu do bazy danych
builder.Services.AddDbContext<WeatherDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("WeatherDb")));
//Rejestrowanie w³asnych serwisów
builder.Services.AddScoped<WeatherService>();
builder.Services.AddScoped<ReadDataBaseService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
