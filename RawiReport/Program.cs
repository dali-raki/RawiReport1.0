using RawiReport.Apps.Apps.BreackdownsApps;
using RawiReport.Apps.Apps.MachinesApps;
using RawiReport.Apps.Apps.ReportApps;
using RawiReport.Components;
using RawiReport.Implementations.Services.BreackdownServices;
using RawiReport.Implementations.Services.MachinesServices;
using RawiReport.Implementations.Services.ReportsServices;
using RawiReport.Infrastructures.Storages.BreackdownStorages;
using RawiReport.Infrastructures.Storages.MachinesStorages;
using RawiReport.Infrastructures.Storages.ReportsStorages;

var builder = WebApplication.CreateBuilder(args);
// Storages Build
builder.Services.AddScoped<IMachinesStorage,MachinesStorage>();
builder.Services.AddScoped<IReportStorages, ReportStorages>();
builder.Services.AddScoped<IBreackdownStorage, BreackdownStorage>();
// Services Build
builder.Services.AddScoped<IMachinesServices, MachinesService>();
builder.Services.AddScoped<IReportsServices, ReportsService>();
builder.Services.AddScoped<IBreackdownService, BreackdownService>();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
