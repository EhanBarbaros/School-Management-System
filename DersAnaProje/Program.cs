using DersAnaProje.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<OkulDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();



// request --> DNS --> SUNUCU (Server) --> Controller --> Model --> VÝEW

//Controller:Requestleri karþýlarlar.

//IIS: INTERNET INFORMATÝON SERVÝCES:
//Gelen istekleri karþýlar ve yönlendirmeleri yapar. Javadaki Tomcatin yaptýðý iþi yapar. 

//Render:IIS C# dilinde yazýlanlarý derler ve tarayýcýnýn anlayacaðý dillere dönüþtürür. Buna Render denir.

//Razor: Html ve C# birlikte çalýþmasý

//Ctrl+M+G : Models ve view arasýnda gidip gelmemizi saðlayan kýsayol tuþlarý.

//Controller --> view Veri taþýmada
//--- ViewData: Bir koleksiyon yapýsýdýr. ViewData bir dictionary yapýsýdýr. Anahtar ve deðer çiftlerinden oluþur.
//--- ViewBag:  Arka planda viewData koleksiyonunu kullanan, dynamic yapýda bir veri taþýma yapýsýdýr. Dynamic yapýlar sadece çalýþma zamanýnda hata verirler.
//--- ViewModel:

//ORM: Object Relational Mapping
//Entity FrameWork First

//Entity ->
//Modal Class ->
//DBContext->DB iþlemleri için gerekli class
//DBSet -> DB'deki tablolarýn ram'deki karþýlýðý. Generic yapýdýr.

//Modal -> DBSet -> SaveChanges(); -> DB