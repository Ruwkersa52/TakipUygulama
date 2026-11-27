using System;
using System.Collections.Generic;

namespace TakipUygulaması
{
    public class GunlukTakip
    {
        public DisTakipModel? DisTakip { get; set; }
        public KiloTakipModel? KiloTakip { get; set; }
        public List<Yapilacak>? Yapilacaklar { get; set; }
    }

    public class DisTakipModel
    {
        public bool Fircalamanma { get; set; }
    }

    public class KiloTakipModel
    {
        public double Kilo { get; set; }
    }
    public enum OnemDerecesi
    {
        Dusuk,   // Yeşil
        Orta,    // Sarı
        Yuksek   // Kırmızı
    }
    public class Yapilacak
    {
        public string Baslik { get; set; } = string.Empty;
        public string? Icerik { get; set; }
        public bool TamamlandiMi { get; set; } = false;

        public string? Id { get; set; }
        public DateTime EklenmeTarihi { get; set; } = DateTime.Now;
        public DateTime? BitisTarihi { get; set; }

        public OnemDerecesi Onem { get; set; } = OnemDerecesi.Dusuk;
        //public bool AcikMi { get; set; } = true;
        
        // sonra ekle public List<Yapilacak> AltBasliklar { get; set; } = new List<Yapilacak>();
    }
}