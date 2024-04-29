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

var app = builder.Build();
app.UseStaticFiles();
SeedData.TestVerileriniDoldur(app);
app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Index}/{id?}"
);
app.MapControllerRoute(
    name:"post_details",
    pattern:"posts/{url}",
    defaults: new {controller = "Posts", action = "Details"}
);




app.Run();
