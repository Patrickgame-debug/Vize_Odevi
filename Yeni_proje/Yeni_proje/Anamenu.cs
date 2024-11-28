using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Yeni_proje
{
    internal class Anamenu
    {
        private static int ogrenciEklemeSayisi = 0;
        private static int dersEklemeSayisi = 0;
        private static int ogretimGorevlisiEklemeSayisi = 0;
        private static int derseKayitSayisi = 0;
        private static List<Ogrenci> ogrenciler = new List<Ogrenci>();
        private static List<OgretimGorevlisi> ogretimGorevlileri = new List<OgretimGorevlisi>();
        private static List<Ders> dersler = new List<Ders>();
        static int gecersizdeneme_hakki = 3;

        static void Main(string[] args)
        {
        
           string secim;
            do
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("   Öğrenci ve Ders Yönetim Sistemi");
                Console.WriteLine("====================================");
                Console.WriteLine("\nLütfen yapmak istediğiniz işlemi seçin:");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("1-  Öğrenci ve Ders Bilgilerini Görüntüle");
                Console.WriteLine("2-  Yeni Öğrenci Ekle");
                Console.WriteLine("3-  Yeni Ders Ekle");
                Console.WriteLine("4-  Öğretim Görevlisi Ekle");
                Console.WriteLine("5-  Öğrenciyi Derse Kaydet");
                Console.WriteLine("6-  Sistemden Çıkış");
                Console.WriteLine("------------------------------------");

                bool gecerliIslem = true;
                Console.Write("Seçiminizi yapınız: ");
                secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        BilgileriGoruntule();
                        
                        break;
                    case "2":
                        OgrenciEkle();
                        Thread.Sleep(1000);
                        break;
                    case "3":
                        DersEkle();
                        Thread.Sleep(1000);
                        break;
                    case "4":
                        OgretimGorevlisiEkle();
                        Thread.Sleep(1000);
                        break;
                    case "6":
                        Console.WriteLine("Çıkılıyor...");
                        Thread.Sleep(1000);
                        break;
                    case "5":
                        DersKaydet();
                        break;
                    default:
                        gecerliIslem = false; // Geçersiz seçim için flag değişir
                        Console.WriteLine("Geçersiz seçenek. 1 ile 6 arasında bir değer giriniz.");
                        Thread.Sleep(1500);
                        gecersizdeneme_hakki--;

                        if (gecersizdeneme_hakki == 0)
                        {
                            Console.WriteLine("Çok fazla geçersiz deneme yaptınız. Çıkış yapılıyor...");
                            Thread.Sleep(1500);
                            secim = "6"; // Döngüyü sonlandırmak için
                        }
                        break;
                }

                if (secim != "6" && gecerliIslem)
                {
                    Console.WriteLine("Ana Menüye Aktarılıyorsunuz...");
                    Thread.Sleep(2000);
                }

            } while (secim != "6");
        }

        // Öğrenci, ders ve öğretim görevlisi bilgilerini görüntüleme fonksiyonu
        private static void BilgileriGoruntule()
        {
            Console.Clear();
            Console.WriteLine("\n---- Kayıtlı Öğrenciler ----");
            if (ogrenciler.Count > 0)
            {
                foreach (var ogrenci in ogrenciler)
                {
                    ogrenci.BilgiGoster();
                    Console.WriteLine("Kayıtlı Dersler:");
                    foreach (var ders in ogrenci.KayıtlıDersler)
                    {
                        Console.WriteLine($"- {ders.Ad}");
                    }

                }
            }
            else
            {
                Console.WriteLine("Hiç öğrenci kaydedilmemiş.\n");

            }
            Console.WriteLine("\n\n");

            Console.WriteLine("\n---- Kayıtlı Öğretim Görevlileri ----");
            if (ogretimGorevlileri.Count > 0)
            {
                foreach (var ogretimGorevlisi in ogretimGorevlileri)
                {
                    ogretimGorevlisi.BilgiGoster();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Hiç öğretim görevlisi kaydedilmemiş.\n");
            }
            Console.WriteLine("\n");
            Console.WriteLine("\n---- Kayıtlı Dersler ----");
            if (dersler.Count > 0)
            {
                foreach (var ders in dersler)
                {
                    ders.BilgileriGoster();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Hiç ders kaydedilmemiş.\n");
            }
            Console.WriteLine("\n");

            Console.WriteLine("Ana menüye dönmek icin herhangi bir tuşa basınız");
            Console.ReadLine();
            
            Thread.Sleep(1000);
        }

        // Öğrenci ekleme fonksiyonu
        private static void OgrenciEkle()
        { 
            Console.Clear();
            string ad, soyad, bolum;
            int id; 
            Console.WriteLine($"Toplam {ogrenciEklemeSayisi} öğrenci var.");

            // Öğrenci adı
            while (true)
            {
                Console.Write("\nÖğrenci Adı: ");
                ad = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(ad))
                {
                    break;
                }
                Console.WriteLine("Hatalı giriş! Öğrenci adı boş bırakılamaz.");
            }

            // Öğrenci soyadı
            while (true)
            {
                Console.Write("Öğrenci Soyadı: ");
                soyad = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(soyad))
                {
                    break;
                }
                Console.WriteLine("Hatalı giriş! Öğrenci soyadı boş bırakılamaz.");
            }

            // Öğrenci bölümü
            while (true)
            {
                Console.Write("Öğrenci Bölümü: ");
                bolum = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(bolum))
                {
                    break;
                }
                Console.WriteLine("Hatalı giriş! Öğrenci bölümü boş bırakılamaz.");
            }

            // Öğrenci ID
            while (true)
            {
                Console.Write("Öğrenci ID: ");
                if (int.TryParse(Console.ReadLine(), out id) && id > 0)
                {
                    break;
                }
                Console.WriteLine("Hatalı giriş! Geçerli bir sayı giriniz (pozitif bir tamsayı).");
            }
            Console.WriteLine("\n\n");

            // Yeni öğrenci oluşturma ve listeye ekleme
            Ogrenci ogrenci = new Ogrenci { Ad = ad, Soyad = soyad, Id = id, Bolum = bolum };
            ogrenciler.Add(ogrenci);
            Console.WriteLine("Öğrenci başarıyla eklendi.");
            ogrenciEklemeSayisi++;
            


        }


        private static void DersKaydet()
        {
            Console.Clear();
            bool kontrol_derssayisi=true;
            Console.WriteLine($"Toplam {derseKayitSayisi} öğrenci derse kaydedildi.");

            Console.WriteLine("\n---- Kayıtlı Dersler ----");
            if (dersler.Count > 0)
            {
                for (int i = 0; i < dersler.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {dersler[i].Ad}");
                }

                Console.Write("Bir ders seçin (numara): ");
                int dersSecim = int.Parse(Console.ReadLine()) - 1;

                Console.WriteLine("\n---- Kayıtlı Öğrenciler ----");
                if (ogrenciler.Count > 0)
                {
                    for (int i = 0; i < ogrenciler.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {ogrenciler[i].Ad} {ogrenciler[i].Soyad}");
                    }

                    Console.Write("Bir öğrenci seçin (numara): ");
                    int ogrenciSecim = int.Parse(Console.ReadLine()) - 1;

                    Ogrenci ogrenci = ogrenciler[ogrenciSecim];
                    Ders ders = dersler[dersSecim];

                    kontrol_derssayisi = true;
                    ogrenci.DersKaydet(ders);  // Öğrencinin ders kaydını yap
                    Console.WriteLine($"{ogrenci.Ad} {ogrenci.Soyad} adlı öğrenci, {ders.Ad} dersine kaydedildi.");
                    
                }
                else
                {
                    Console.WriteLine("Hiç öğrenci bulunmamaktadır.");
                    kontrol_derssayisi = false;
                }
                
            }
            else
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("Hiç ders bulunmamaktadır.");
                kontrol_derssayisi = false;
            }
            if(kontrol_derssayisi)
                derseKayitSayisi++;
        }

        // Ders ekleme fonksiyonu
        private static void DersEkle()
        {
            Console.Clear();
            bool kontrol_ders = true;
            Console.WriteLine($"Toplam listeye eklenmiş ders sayısı:{dersEklemeSayisi} .");
            if (ogretimGorevlileri.Count == 0)
            {
                Console.WriteLine("Öğretim görevlisi bulunamadı! Lütfen önce bir öğretim görevlisi ekleyin.");
                Console.WriteLine("Ana menüye dönülüyor...");
                System.Threading.Thread.Sleep(2000); 
                return;
            }

            Console.Write("Ders Adı: ");
            string dersAd = Console.ReadLine();

            int kredi;
            while (true)
            {
                Console.Write("Ders Kredisi: ");
                if (int.TryParse(Console.ReadLine(), out kredi) && kredi > 0)
                {
                    kontrol_ders=true;
                    break;
                }
                Console.WriteLine("Geçerli bir kredi değeri girin (pozitif bir sayı).");
            }

            Console.WriteLine("Öğretim Görevlisi Seçin:");
            for (int i = 0; i < ogretimGorevlileri.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ogretimGorevlileri[i].Ad} {ogretimGorevlileri[i].Soyad}");
            }

            int ogretimSecim;
            while (true)
            {
                Console.Write("Seçiminiz (sayı): ");
                if (int.TryParse(Console.ReadLine(), out ogretimSecim) && ogretimSecim > 0 && ogretimSecim <= ogretimGorevlileri.Count)
                {
                    kontrol_ders = true;
                    ogretimSecim--; 
                    break;
                }
                Console.WriteLine("Gçerli bir seçim yapın.");
                kontrol_ders = false;
            }

            OgretimGorevlisi ogretimGorevlisi = ogretimGorevlileri[ogretimSecim];

            Ders ders = new Ders { Ad = dersAd, Kredi = kredi, OgretimGorevlisi = ogretimGorevlisi };
            dersler.Add(ders);
            Console.WriteLine("Ders başarıyla eklendi!");
            if (kontrol_ders)
                dersEklemeSayisi++;
        }


        // Öğretim görevlisi ekleme fonksiyonu
        private static void OgretimGorevlisiEkle()
        {
            Console.Clear();
            bool kontrol_Ogrentim;
            
            Console.WriteLine($"Toplam {ogretimGorevlisiEklemeSayisi} öğretim görevlisi eklendi.");
            string ad, soyad, departman;
            int id;

            // Öğretim Görevlisi Adı
            while (true)
            {
                Console.Write("Öğretim Görevlisi Adı: ");
                ad = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(ad))
                {
                    
                    break;
                }
                Console.WriteLine("Hatalı giriş! Öğretim görevlisi adı boş bırakılamaz.");
            }

            // Öğretim Görevlisi Soyadı
            while (true)
            {
                Console.Write("Öğretim Görevlisi Soyadı: ");
                soyad = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(soyad))
                {
                    break;
                }
                Console.WriteLine("Hatalı giriş! Öğretim görevlisi soyadı boş bırakılamaz.");
            }

            

            // Öğretim Görevlisi Departmanı
            while (true)
            {
                Console.Write("Öğretim Görevlisi Departmanı: ");
                departman = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(departman))
                {
                    break;
                }
                Console.WriteLine("Hatalı giriş! Öğretim görevlisi departmanı boş bırakılamaz.");
            }

            // Öğretim Görevlisi ID
            while (true)
            {
                Console.Write("Öğretim Görevlisi ID: ");
                if (int.TryParse(Console.ReadLine(), out id) && id > 0)
                {
                    kontrol_Ogrentim = true; // bilerek en sona koydum zaten diğer  koşullardan geçmesi lazım diğer while lara koymama gerek yok
                    break;
                }
                Console.WriteLine("Hatalı giriş! Geçerli bir pozitif ID değeri giriniz.");
                kontrol_Ogrentim=false;
            }

            // Yeni öğretim görevlisi oluşturma ve listeye ekleme
            OgretimGorevlisi ogretimGorevlisi = new OgretimGorevlisi
            {
                Ad = ad,
                Soyad = soyad,  
                Departman = departman,
                Id = id
            };
            ogretimGorevlileri.Add(ogretimGorevlisi);
            Console.WriteLine("Öğretim Görevlisi başarıyla eklendi!");
            if(kontrol_Ogrentim) 
                ogretimGorevlisiEklemeSayisi++;
        }

    }
}