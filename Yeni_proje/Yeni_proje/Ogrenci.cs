using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yeni_proje
{
    internal class Ogrenci:base_class, IBilgiGoster
    {
        public string Bolum { get; set; }
        public List<Ders> KayıtlıDersler { get; set; } = new List<Ders>();

        public override void BilgiGoster()
        {
            base.BilgiGoster();
            Console.WriteLine($"Bölüm: {Bolum}");
        }

        public void DersKaydet(Ders ders)
        {
            KayıtlıDersler.Add(ders);
            ders.Ogrenciler.Add(this);  
        }
    }
}
