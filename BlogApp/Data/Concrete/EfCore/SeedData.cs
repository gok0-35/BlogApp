//Bu sınıfın görevi, uygulama ilk çalıştığında veritabanı boşsa birkaç test kaydı eklemektir.

using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();/*app.ApplicationServices uygulamanın servis listesini (Dependency Injection konteyneri) getirir.
            CreateScope() ile bir scope (geçici çalışma alanı) oluşturulur.
            GetService<BlogContext>() ile EF Core’un veritabanı nesnesi (BlogContext) alınır.*/
            //Yani: “Veritabanı bağlantısını al, şimdi veri ekleyebilirim” demek.

            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())/*“Henüz uygulanmamış migration (veritabanı yapısı değişiklikleri) varsa uygula.” demek.
                                                                  EF Core bu sayede tablo yapısını güncel tutar.*/
                {
                    context.Database.Migrate();
                }

                if (!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Tag { Text = "Spor", Url = "spor", Color = TagColors.warning },
                        new Tag { Text = "Türkiye", Url = "turkiye", Color = TagColors.success },
                        new Tag { Text = "Teknoloji", Url = "teknoloji", Color = TagColors.info },
                        new Tag { Text = "Yapay Zeka", Url = "yapay-zeka", Color = TagColors.warning },
                        new Tag { Text = "Arabalar", Url = "arabalar", Color = TagColors.primary }
                    );
                    context.SaveChanges();
                    /*AddRange() → birden fazla kayıt ekler.
                    SaveChanges() → yapılan değişiklikleri (ekleme, silme, güncelleme) veritabanına yazar.
                    Aynı mantık Users ve Posts için de geçerli.*/
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { UserName = "gokmen35", Name = "Gökmen Soysal", Email = "gokmensoysal@gmail.com", Password = "123456", Image = "imgUser1.jpg" },
                        new User { UserName = "ElOau", Name = "Elis Aydın", Email = "elisaydinxo@gmail.com", Password = "654321", Image = "imgUser2.jpg" }
                    );
                    context.SaveChanges();
                }

                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post
                        {
                            Title = "Yeni Türk Yazılımcı",
                            Description = "Yeni Türk Yazılımcı, İzmirden Tüm Dünyaya Açılıyor",
                            Content = "İzmirde Yeni Uygulamalar geliştiren isimsiz yazılımcı, ilk kez genel bütün uygulamaları için 1.000.000 indirme aldı",
                            Url = "yeni-turk-yazilimci",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-25),
                            Tags = context.Tags.Take(3).ToList(),
                            UserId = 1,
                            Image = "img1.jpg",
                            Comments = new List<Comment> {
                                new Comment { Text = "Müthiş, bu kişi kimse eline sağlık", PublishedOn = DateTime.Now.AddDays(-20), UserId = 1},
                                new Comment { Text = "Galiba Aşık oldum", PublishedOn = DateTime.Now.AddDays(-10), UserId = 2},
                            }
                            /*Tags = context.Tags.Take(3) → mevcut Tag’lerden ilk 3 tanesini iliştirir.
                            UserId = 1 → bu postu hangi kullanıcının yazdığını belirtir.
                            Comments = ... → postun altına yorumları da iliştirir.
                            Yani burası küçük bir örnek veri tabanı kurar.*/
                        },
                        new Post
                        {
                            Title = "Alperen Ve Kd",
                            Description = "Houston Rockets Fırtınası",
                            Content = "Alperen Ve Kd rockets'ı tekrar galibiyete taşıdı. Ligin korkutucu ikilisi yargı dağıtıyor. Ne düşünüyrsunuz?",
                            Url = "alpi-ve-kd",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-20),
                            Tags = context.Tags.Take(2).ToList(),
                            Image = "img2.jpg",
                            UserId = 1,
                            Comments = new List<Comment> {
                                new Comment { Text = "Lets Go Rocketsssss", PublishedOn = DateTime.Now.AddDays(-10), UserId = 2}
                            }
                        },
                        new Post
                        {
                            Title = "911 GTS",
                            Description = "Porsche 911 GTS Tanıtıldı",
                            Content = "Porsche geçtiğimiz aylarda yeni hybrid motorlu 911 Carrera GTS modelini tanıttı, Beğendiniz mi?",
                            Url = "911-gts",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "img3.jpg",
                            UserId = 2,
                            Comments = new List<Comment> {
                                new Comment { Text = "Baba almanlar bu işi yapıyor yaaaa:)", PublishedOn = DateTime.Now.AddDays(-20), UserId = 1}
                            }
                        },
                        new Post
                        {
                            Title = "React Dersleri",
                            Description = "React Frontend Geliştirme",
                            Content = "React dersleri verilecektir. Sende frontend ile uğraşmak istiyorsan aramıza bekleriz.",
                            Url = "react",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-40),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "img2.jpg",
                            UserId = 2
                        }
                        ,
                        new Post
                        {
                            Title = "Angular",
                            Description = "Angular öğreniyoruz",
                            Content = "Angular dersleri",
                            Url = "angular",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-50),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "img3.jpg",
                            UserId = 2
                        }
                        ,
                        new Post
                        {
                            Title = "Web Tasarım",
                            Description = "web tasarım prensipleri",
                            Content = "Web tasarım dersleri",
                            Url = "web-tasarim",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-60),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "img1.jpg",
                            UserId = 2
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}