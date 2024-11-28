using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yeni_proje
{
    internal class base_class: IBilgiGoster
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Id { get; set; }

        public virtual void BilgiGoster()
        {
            Console.WriteLine($"Ad: {Ad}, Soyad: {Soyad}, ID: {Id}");
        }
    }
}
