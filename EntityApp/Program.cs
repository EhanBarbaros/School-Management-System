// See https://aka.ms/new-console-template for more information

using DersAnaProje;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

internal class Program
{
    static void Main(string[] args)
    {
        //İnsert işlemelri

        //var ogr = new Ogrenci { Ad = "Yusuf", Soyad = "Yıldız", Numara = 437 };
        //using (var ctx = new OkulDBContext())
        //{
        //    ctx.Ogrenciler.Add(ogr);
        //    int sonuc = ctx.SaveChanges();
        //    Console.WriteLine(sonuc > 0 ? "Ekleme işlemi Başarılı" : "Ekleme işlemi Başarısız");
        //}


        //Update işlmeleri
        //using (var ctx = new OkulDBContext())
        //{
        //   var ogr = ctx.Ogrenciler.Find(1);

        //    if (ogr!=null)
        //    {
        //        ogr.Numara = 4151;
        //        Console.WriteLine(ctx.SaveChanges() > 0 ? "Güncelleme işlemi Başarılı" : "Güncelleme işlemi Başarısız");
        //    }
        //    else { Console.WriteLine("Öğrenci Bulunamadı"); }

        //}



        //Delete işlmeleri
        //using (var ctx = new OkulDBContext())
        //{
        //    var ogr = ctx.Ogrenciler.Find(4);
        //    if (ogr != null)
        //    {
        //        ctx.Ogrenciler.Remove(ogr);
        //        Console.WriteLine(ctx.SaveChanges() > 0 ? "Silme işlemi Başarılı" : "Silme işlemi Başarısız");
        //    }
        //    else { Console.WriteLine("Öğrenci Bulunamadı"); }
        //}



        //Listeleme işlmeleri
        using (var ctx = new OkulDBContext())
        {
            var lst= ctx.Ogrenciler.ToList();

                foreach (var item in lst)
                {
                Console.WriteLine(item.Ad);
                }
        }
    }
}


//Change Tracking db set üzerinde insert update gibi işlemelri izeler ve added updated gibi state ayarlar.

//Solid prensiplerine bak 
//Dependency injection   -----

//Clean arcitehcture
//Web api lere bak

//Öğrenci işlemelri için menü ekleyelim
//Ders entitysi ekleyelim
//Öğrenciye ders ataması yapalım
//Tüm ekranlarda bootsrap kullanalım

//Öğrenci listesinde düzenle sil yanında aldığı dersler bölümü olacak.
//Ders entitysi olacak
//FLUENT APİ ile bu işlem yapılacak ders ve öğrenci arasında ilişki olacak