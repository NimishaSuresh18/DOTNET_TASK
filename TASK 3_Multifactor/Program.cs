using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using MyApplication.Data;


var builder = WebApplication.CreateBuilder(args);

// public IConfiguration? Configuration{get;}



var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>
(options => options.SignIn.RequireConfirmedAccount = true).
AddEntityFrameworkStores<ApplicationDbContext>();







// Add services to the container.
builder.Services.AddControllersWithViews();

// builder.Services.AddMicrosoftIdentityWebAppAuthentication(builder.Configuration).Services.AddMvc(option =>{
//     var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
//     option.Filters.Add(new AuthorizeFilter(policy));
// }).AddMicrosoftIdentityUI();


builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
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
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();
