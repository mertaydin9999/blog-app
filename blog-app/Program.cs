using blog_app.Data.Abstract;
using blog_app.Data.Concrete;
using blog_app.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogContext>(options =>{
    options.UseSqlite(builder.Configuration["ConnectionStrings:Sql_connection"]);
} );

builder.Services.AddScoped<IPostRepository, EfPostRepository>();
builder.Services.AddScoped<ITagRepository, EfTagRepository>();
builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();

var app = builder.Build();
app.UseStaticFiles();
SeedData.TestVerileriniDoldur(app);

app.MapControllerRoute(
    name:"post_details",
    pattern:"posts/details/{url}",
    defaults: new {controller = "Posts", action = "Details"}
);
app.MapControllerRoute(
    name:"posts_by_tag",
    pattern:"posts/tag/{url}",
    defaults: new {controller = "Posts", action = "Index"}
);
app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Index}/{id?}"
);





app.Run();
