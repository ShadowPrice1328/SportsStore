using SportsStore.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreDbContext>(opts => {
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:SportsStoreConnection"]
    );
});

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();
app.UseStaticFiles();

app.MapControllerRoute(
    "catpage",
    "{category}/Page{productPage:int}",
    new {Controller = "Home", action = "Index"}
);

app.MapControllerRoute(
    "page",
    "Page{productPage:int}",
    new {Controller = "Home", action = "Index", productPage = 1}
);

app.MapControllerRoute(
    "category",
    "{category}",
    new {Controller = "Home", action = "Index", productPage = 1}
);

app.MapControllerRoute(
    "pagination",
    "Products/Page{productPage}",
    new {Controller = "Home", action = "Index", productPage = 1}
);

app.MapDefaultControllerRoute();
app.MapRazorPages();
app.UseSession();

SeedData.EnsurePopulated(app);

app.Run();
