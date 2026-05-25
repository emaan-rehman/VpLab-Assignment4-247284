using Application08.Components;
using Microsoft.EntityFrameworkCore;
using VpLabAssignment.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
// 1. REGISTER THE SQL CONNECTION PIPELINE STRING CONFIGURATION HERE
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LabTodoPortalDb;Trusted_Connection=True;TrustServerCertificate=True;"));
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
