using DersAnaProje.Models.Relationships;

namespace DersAnaProje.Models
{
    public class Ders
    {
        public int Dersid { get; set; }

        public string? DersAd { get; set; }

        public string? DersKodu { get; set; }

        public int Kredi { get; set; }

        public ICollection<OgrenciDers>? OgrenciDersler { get; set; }
    }
}
