using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Miclea_Adela_Laboratorul2.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Miclea_Adela_Laboratorul2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Miclea_Adela_Laboratorul2Context") ?? throw new InvalidOperationException("Connection string 'Miclea_Adela_Laboratorul2Context' not found.")));

builder.Services.AddDbContext<LibraryIdentifyContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Miclea_Adela_Laboratorul2Context") ?? throw new InvalidOperationException("Connectionstring 'Miclea_Adela_Laborator2Context' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LibraryIdentifyContext>();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
