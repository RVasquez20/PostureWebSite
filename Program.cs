using Microsoft.EntityFrameworkCore;
using Polly;
using Polly.Extensions.Http;
using PostureWebSite.Models;
using PostureWebSite.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PostureBaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PostureBD"), option => option.EnableRetryOnFailure());
});
builder.Services.AddHttpClient("Base", client =>
{
    client.BaseAddress = new Uri("https://api.openai.com/v1/chat/completions");
    client.Timeout = TimeSpan.FromSeconds(120);
}).AddPolicyHandler(HttpPolicyExtensions.HandleTransientHttpError()
            .RetryAsync(3))
        .AddPolicyHandler(HttpPolicyExtensions.HandleTransientHttpError()
            .CircuitBreakerAsync(5, TimeSpan.FromSeconds(45)));
builder.Services.AddScoped(typeof(IRepositoryAsync<>),typeof(RepositoryAsync<>));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
