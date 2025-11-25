/*Bu dosya uygulamayı başlatan yerdir. ASP.NET Core’da her şey Program.cs üzerinden “başlar, 
yapılandırılır ve çalıştırılır.”*/
using BlogApp.Data.Concrete;
using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args); /*Bu satır uygulama için bir builder (yapılandırıcı) oluşturur. 
Builder, ayarları (configuration), dependency injection sistemini ve servisleri hazırlar.*/

builder.Services.AddControllersWithViews();//Controller'ların, view'ler ile ilişkilendirilmesi

builder.Services.AddDbContext<BlogContext>(options =>
{
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("sql_connection");
    options.UseSqlite(connectionString);
});/*Ne oluyor burada?
Bu kısım EF Core’u uygulamaya tanıtıyor.

Satır satır açıklayalım 👇

builder.Services.AddDbContext<BlogContext>(...)
“BlogContext adında bir veritabanı bağlantı sınıfım var, bunu uygulamanın servis sistemine ekle.” demek.
ASP.NET Core’da her şey Dependency Injection (bağımlılık enjeksiyonu) ile yönetilir.
Bu, nesneleri elle newlemek yerine otomatik oluşturup yönetmeyi sağlar.

var config = builder.Configuration;
appsettings.json ve appsettings.Development.json dosyalarını okur.
Buradaki ayarlara config üzerinden erişebilirsin.

var connectionString = config.GetConnectionString("sql_connection");
appsettings.Development.json içindeki "ConnectionStrings" kısmından "sql_connection" anahtarını bulur.
Yani "Data Source=blog.db" değerini alır.

options.UseSqlite(connectionString);
EF Core’a hangi veritabanını kullanacağını söyler.
Yani “SQLite kullan, dosya olarak blog.db’ye bağlan” der.*/

builder.Services.AddScoped<IPostRepository, EfPostRepository>();
builder.Services.AddScoped<ITagRepository, EfTagRepository>();
builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();
builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Users/Login";
});

var app = builder.Build(); //Bu, yapılandırılan uygulamayı oluşturur (builder’dan gerçek bir app nesnesi üretir).

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


SeedData.TestVerileriniDoldur(app);//Bu satır “Uygulama çalışmadan önce test verilerini doldur” demek. (Veritabanı boşsa otomatik olarak örnek kullanıcı, tag ve post ekliyor.)

app.MapControllerRoute(
    name: "post_details",
    pattern: "posts/details/{url}",
    defaults: new { controller = "Posts", action = "Details" }
);

app.MapControllerRoute(
    name: "posts_by_tag",
    pattern: "posts/tag/{tag}",
    defaults: new { controller = "Posts", action = "Index" }
);

app.MapControllerRoute(
    name: "user_profile",
    pattern: "profile/{username}",
    defaults: new { controller = "Users", action = "Profile" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=posts}/{action=index}/{id?}"
);

app.Run();//app.Run() uygulamayı başlatır ve sonsuza kadar dinlemeye alır.
