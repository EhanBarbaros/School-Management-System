namespace DersAnaProje.Models
{
    public class Ogretmen
    {
        public int OgretmenId { get; set; }

        public string? Ad { get; set; }

        public string? Soyad { get; set; }

        //public override string ToString() => $"Ad:{this.Ad} Soyad:{this.Soyad}";
    }
}
