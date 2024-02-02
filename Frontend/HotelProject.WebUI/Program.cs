using FluentValidation;
using FluentValidation.AspNetCore;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.GuestDtos;
using HotelProject.WebUI.ValidationRules.GuestValidationRules;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer("Server=DESKTOP-BFFKA5K;Database=hotelDB;Trusted_Connection=True;");
});

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();

builder.Services.AddHttpClient();
// Add services to the container.
builder.Services.AddTransient<IValidator<AddGuestDto>, AddGuestValidator>();
builder.Services.AddTransient<IValidator<UpdateGuestDto>, UpdateGuestValidator>();
builder.Services.AddControllersWithViews().AddFluentValidation();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
