var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 🔥 Configurar la sesión
builder.Services.AddDistributedMemoryCache(); // Necesario para usar sesión en memoria
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tiempo de inactividad antes de expirar
    options.Cookie.HttpOnly = true;                 // Evita acceso desde JS
    options.Cookie.IsEssential = true;              // Necesario para GDPR / cookies esenciales
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();  // <-- no olvides esto para servir CSS/JS si no usas MapStaticAssets()

app.UseRouting();

app.UseSession(); // 👈 tiene que ir ANTES de Authorization

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
