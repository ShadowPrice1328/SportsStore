using SportsStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreDbContext>(opts => {
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:SportsStoreConnection"]
    );
});
builder.Services.AddDbContext<AppIdentityDbContext>(opts => {
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:IdentityConnection"]
    );
});
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();
builder.Services.AddScoped<IOrderRepository, EFOrderRepository>();

builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddScoped<Cart>(SessionCart.GetCart);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddServerSideBlazor();

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
app.MapBlazorHub();
app.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");
app.UseSession();

SeedData.EnsurePopulated(app);
IdentitySeedData.EnsurePopulated(app);

app.Run();
