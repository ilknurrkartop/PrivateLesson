
using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PrivateLesson.Business.Abstract;
using PrivateLesson.Business.Concrete;
using PrivateLesson.Data.Abstract;
using PrivateLesson.Data.Concrete.EfCore;
using PrivateLesson.Data.Concrete.EfCore.Context;
using PrivateLesson.Entity.Concrete.Identity;
using PrivateLesson.WebUI.IEmailServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PrivateLessonContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<PrivateLessonContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = true;

    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/Accessdenied";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(10);
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        Name = ".PrivateLessonApp.Security.Cookie"
    };
});
builder.Services.AddScoped<IBranchService, BranchManager>();
builder.Services.AddScoped<IImageService, ImageManager>();
builder.Services.AddScoped<IStudentService, StudentManager>();
builder.Services.AddScoped<ITeacherService, TeacherManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();
builder.Services.AddScoped<ICartService, CartManager>();
builder.Services.AddScoped<ICartItemService, CartItemManager>();
builder.Services.AddScoped<IAdvertService, AdvertManager>();

builder.Services.AddScoped<IBranchRepository, EfCoreBranchRepository>();
builder.Services.AddScoped<IImageRepository, EfCoreImageRepository>();
builder.Services.AddScoped<IStudentRepository, EfCoreStudentRepository>();
builder.Services.AddScoped<ITeacherRepository, EfCoreTeacherRepository>();
builder.Services.AddScoped<IOrderRepository, EfCoreOrderRepository>();
builder.Services.AddScoped<ICartRepository, EfCoreCartRepository>();
builder.Services.AddScoped<ICartItemRepository, EfCoreCartItemRepository>();
builder.Services.AddScoped<IAdvertRepository, EfCoreAdvertRepository>();


builder.Services.AddScoped<IEmailSender, SmtpEmailSender>(options => new SmtpEmailSender(
    builder.Configuration["EmailSender:Host"],
    builder.Configuration.GetValue<int>("EmailSender:Port"),
    builder.Configuration.GetValue<bool>("EmailSender:EnableSSL"),
    builder.Configuration["EmailSender:UserName"],
    builder.Configuration["EmailSender:Password"]
  ));

builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 5;
    config.IsDismissable = true;
    config.Position = NotyfPosition.TopRight;
});

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
    name: "teacherdetails",
    pattern: "teacherdetails/{id}"
    );

app.MapControllerRoute(
    name: "advertdetails",
    pattern: "advertdetails/{url}",
    defaults: new { controller = "Home", action = "AdvertDetails" }
    );

app.MapControllerRoute(
    name: "branches",
    pattern: "teachers/{branchurl?}",
    defaults: new { controller = "Home", action = "Index" }
    );


app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "admin/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
