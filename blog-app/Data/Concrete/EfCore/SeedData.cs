using blog_app.Entity;
using Microsoft.EntityFrameworkCore;

namespace blog_app.Data.Concrete.EfCore
{
    public static class SeedData 
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();
            if(context != null)
            {
                if(context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
                if(!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Tag{Text = "web programlama" ,Url="web-programlama", Color=TagColors.warning},
                        new Tag{Text = "backend" , Url="backend",Color=TagColors.info},
                        new Tag{Text = "frontend" , Url="frontend",Color=TagColors.success},
                        new Tag{Text = "php",Url="php",Color=TagColors.secondary},
                        new Tag{Text = "fullstack",Url="fullstack",Color=TagColors.primary}
                    );
                    context.SaveChanges();
                }
                if( !context.Users.Any())
                {
                    context.Users.AddRange(
                        new User{UserName = "Mert Aydin",Image="p1.jpg"},
                        new User{UserName = "Merve Aydin",Image="p2.jpg"}
                    );
                    context.SaveChanges();
                }
                if( !context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post{ 
                            Title = "Asp.net core",
                            Content = "Asp.net core dersleri",
                            Url="aspnet-core",
                            IsActive = true,
                            PublishedOn =DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            Image="1.jpg",
                            UserId = 1,
                            Comments = new  List<Comment>{
                                new Comment{ CommentText= "Iyi bir kurs" , PublishedOn=new DateTime(),UserId=1},
                                new Comment{ CommentText= "Cok faydalandigim bir kurs" , PublishedOn=new DateTime(),UserId=2}
                                }
                        },
                        new Post{ 
                            Title = "PHP",
                            Content = "PHP dersleri",
                            Url="php",
                            IsActive = true,
                            PublishedOn =DateTime.Now.AddDays(-20),
                            Tags = context.Tags.Take(2).ToList(),
                            Image="2.jpg",
                            UserId = 1
                        },
                        new Post{ 
                            Title = "Django ",
                            Content = "Django dersleri",
                            Url="django",
                            IsActive = true,
                            PublishedOn =DateTime.Now.AddDays(-5),
                            Tags = context.Tags.Take(4).ToList(),
                            Image="3.jpg",
                            UserId = 2
                        }
                        
                    );
                    context.SaveChanges();
                }

            }
        }
        
    }
}