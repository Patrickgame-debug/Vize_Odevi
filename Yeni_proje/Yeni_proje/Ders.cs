using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yeni_proje
{
    internal class Ders
    {
        public string Ad { get; set; }
        public int Kredi { get; set; }
        public OgretimGorevlisi OgretimGorevlisi { get; set; }
        public List<Ogrenci> Ogrenciler { get; set; } = new List<Ogrenci>();

        public void BilgileriGoster()
        {
            Console.WriteLine($"Ders Adı: {Ad}, Kredi: {Kredi}, Öğretim Görevlisi: {OgretimGorevlisi.Ad} {OgretimGorevlisi.Soyad}");
            Console.WriteLine("Kayıtlı Öğrenciler:");
            foreach (var ogrenci in Ogrenciler)
            {
                Console.WriteLine($"{ogrenci.Ad} {ogrenci.Soyad}");
            }
        }
    }
}
