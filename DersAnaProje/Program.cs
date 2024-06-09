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



// request --> DNS --> SUNUCU (Server) --> Controller --> Model --> V�EW

//Controller:Requestleri kar��larlar.

//IIS: INTERNET INFORMAT�ON SERV�CES:
//Gelen istekleri kar��lar ve y�nlendirmeleri yapar. Javadaki Tomcatin yapt��� i�i yapar. 

//Render:IIS C# dilinde yaz�lanlar� derler ve taray�c�n�n anlayaca�� dillere d�n��t�r�r. Buna Render denir.

//Razor: Html ve C# birlikte �al��mas�

//Ctrl+M+G : Models ve view aras�nda gidip gelmemizi sa�layan k�sayol tu�lar�.

//Controller --> view Veri ta��mada
//--- ViewData: Bir koleksiyon yap�s�d�r. ViewData bir dictionary yap�s�d�r. Anahtar ve de�er �iftlerinden olu�ur.
//--- ViewBag:  Arka planda viewData koleksiyonunu kullanan, dynamic yap�da bir veri ta��ma yap�s�d�r. Dynamic yap�lar sadece �al��ma zaman�nda hata verirler.
//--- ViewModel:

//ORM: Object Relational Mapping
//Entity FrameWork First

//Entity ->
//Modal Class ->
//DBContext->DB i�lemleri i�in gerekli class
//DBSet -> DB'deki tablolar�n ram'deki kar��l���. Generic yap�d�r.

//Modal -> DBSet -> SaveChanges(); -> DB