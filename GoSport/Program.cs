using GoSportData;
using GoSportData.IRepository;
using GoSportData.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<GoDbContext>(config =>
{
    config.UseMySQL("server=localhost;user=root;password=;database=gosport", c => c.MigrationsAssembly("GoSportData"));
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
    options.LoginPath = "/login"
);
builder.Services.AddAntiforgery(options => options.HeaderName = "XSRF-TOKEN");
builder.Services.AddTransient<IGendersRepository, GendersRepository>();
builder.Services.AddTransient<ILoginTokenRepository, LoginTokenRepository>();
builder.Services.AddTransient<IRegistrationsRepository, RegistrationsRepository>();
builder.Services.AddTransient<IResultsRepository, ResultsRepository>();
builder.Services.AddTransient<ISportsRepository, SportsRepository>();
builder.Services.AddTransient<ITournamentsRepository, TournamentRepository>();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddResponseCaching();
builder.Services.AddLogging();
builder.Services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(15));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
