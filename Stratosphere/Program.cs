using Microsoft.EntityFrameworkCore;
using Stratosphere.Data;
using Stratosphere.Pages.Monitoring;
using Stratosphere.Pages.Queues;
using Stratosphere.Pages.Queues.Models;
using Stratosphere.Services.Http;
using Stratosphere.Services.Queues;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddHttpClient<IHttpService, HttpService>();

builder.Services.Configure<MessageQueueApiSettings>(builder.Configuration.GetSection("MessageQueueApiSettings"));
builder.Services.AddSingleton<IQueueApiService, QueueApiService>();

builder.Services.AddDbContext<StratosphereContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"))
        .UseSnakeCaseNamingConvention();
});

//add services for each page using extension methods
builder.Services.AddMonitoringServices();
builder.Services.AddQueueServices();

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

app.UseAuthorization();

app.MapRazorPages();

//lol, figure out migrations instead of this
using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<StratosphereContext>();
    await ctx.Database.EnsureDeletedAsync();
    await ctx.Database.EnsureCreatedAsync();
}

app.Run();
