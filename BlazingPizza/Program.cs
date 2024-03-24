using BlazingPizza.Data;
using BlazingPizza.Extensions;
using BlazingPizza.Orders;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<PizzaStoreContext>(options =>
    options.UseSqlite("Data Source=pizza.db"));
builder.Services.AddScoped<OrderState>();

var app = builder.Build();
// Initialize the database
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
    if (await db.Database.EnsureCreatedAsync())
    {
        await SeedData.InitializeAsync(db);
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.MapPizzaApi();

app.Run();
