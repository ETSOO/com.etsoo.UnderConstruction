using Microsoft.Extensions.WebEncoders;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddRazorPages();

// Default path is Resources
services.AddLocalization(options => options.ResourcesPath = "Resources");

// Configure to avoid Chinese being unicodes
services.Configure<WebEncoderOptions>(options =>
{
    options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

// Cultrues
var cultures = new[] { "en-US", "zh-CN" };
app.UseRequestLocalization(new RequestLocalizationOptions()
    .AddSupportedCultures(cultures)
    .AddSupportedUICultures(cultures));

app.UseAuthorization();

app.MapRazorPages();

app.Run();
