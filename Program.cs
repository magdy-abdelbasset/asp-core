using AspNetCoreDemo.Models.Repositories;
using AspNetCoreDemo.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();
builder.Services.AddScoped<IBookstoreRepository<Author>, AuthorRepository>();
builder.Services.AddScoped<IBookstoreRepository<Book>, BookRepository>();
// builder.Services.AddDbContext<BookstoreDbContext>(options =>
//             {
//                 options.UseSqlServer(configuration.GetConnectionString("SqlCon"));
//             });
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();