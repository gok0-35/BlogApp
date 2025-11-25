using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    //DbContext, EF Core’un veritabanıyla konuşan beynidir. Entity Framework Core (EF Core) kütüphanesinin en önemli sınıfıdır.
    //Veritabanına bağlanmayı, Veritabanındaki tabloları (DbSet’ler) temsil etmeyi, Yeni kayıt ekleme, silme, güncelleme, listeleme gibi işlemleri yapmayı, Değişiklikleri takip etmeyi (SaveChanges()) sağlar.
    public class BlogContext : DbContext
    //“Ben DbContext’ten türetilen bir sınıfım, EF Core’un kurallarına göre çalışırım.” demek.
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)/*ASP.NET Core bu options’ı (örneğin SQLite bağlantısı) otomatik olarak verir. base(options) kısmı bu ayarları EF Core’un DbContext sınıfına ileti*/
        {

        }
        public DbSet<Post> Posts => Set<Post>();//Bu satır EF Core’a “veritabanında Posts adında bir tablo olacak ve bu tablo Post sınıfıyla eşleşecek” der.
        /*DbSet bir tablonun temsilcisidir. Yani:
        context.Posts.Add(...) → tabloya satır ekler
        context.Posts.ToList() → tüm satırları getirir
        context.Posts.Remove(...) → siler*/
        //Aynısı Comments, Tags, Users için de geçerli.
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<User> Users => Set<User>();
    }
}