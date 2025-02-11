using System.Text.Unicode;
using System.Text.Encodings.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Alert ekran�ndaki T�rk�e karakterleri g�stermek i�in
builder.Services.AddWebEncoders(options =>
{
    options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();