namespace DersAnaProje.Models.Relationships
{
    public class OgrenciDers
    {
        public int Ogrenciid { get; set; }
        public Ogrenci? Ogrenci { get; set; }

        public int Dersid { get; set; }
        public Ders? Ders { get; set; }
    }
}
