# BlogApp 📰

BlogApp, ASP.NET Core MVC ile geliştirilmiş bir blog yönetim sistemi. Kullanıcılar blog yazıları oluşturabilir, düzenleyebilir, silebilir; admin üzerinden kullanıcı ve içerik yönetimi yapılabilir. Kimlik doğrulama **cookie tabanlı ASP.NET Core Authorization** ile yapılmaktadır.

## 🚀 Özellikler
- **Kullanıcı Sistemi**
  - Kayıt, giriş, çıkış
  - Cookie tabanlı kimlik doğrulama
  - `[Authorize]` attribute ile erişim kontrolü
- **Blog Yönetimi**
  - Yazı oluşturma, düzenleme, silme (CRUD)
  - Yazıların kullanıcıya bağlı olması
  - Detay sayfası ile içerik görüntüleme
- **Admin Paneli**
  - Kullanıcı yönetimi (listeleme, silme)
  - Blog yazılarını yönetme
  - Yetki kontrolü (sadece admin rolü erişebilir)
- **Veritabanı**
  - SQLite kullanımı
  - Entity Framework Core ile migration ve sorgular
- **Arayüz**
  - Razor View Engine
  - Bootstrap / klasik CSS

## 🛠️ Teknolojiler
- ASP.NET Core MVC
- Entity Framework Core
- SQLite
- Razor Views
- Cookie Authentication & Authorization
- Bootstrap / CSS
  
