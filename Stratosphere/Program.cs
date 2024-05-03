using Stratosphere.Data.Postgres.Context;
using Stratosphere.Data.Postgres.Repository;
using Stratosphere.Services.Database;
using Stratosphere.Pages.Monitoring;
using Stratosphere.Services.Http;
using Stratosphere.Pages.Queues.Models;
using Stratosphere.Services.Queues;
using Stratosphere.Pages.Queues;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddHttpClient<IHttpService, HttpService>();

builder.Services.Configure<MessageQueueApiSettings>(builder.Configuration.GetSection("MessageQueueApiSettings"));
builder.Services.AddSingleton<IQueueApiService, QueueApiService>();

builder.Services.AddSingleton<IPostgresContext, PostgresContext>();
builder.Services.AddSingleton<IPostgresRepository, PostgresRepository>();
builder.Services.AddSingleton<IDatabaseService, DatabaseService>();

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

app.Run();
