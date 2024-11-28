using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yeni_proje
{
    internal class OgretimGorevlisi:base_class, IBilgiGoster
    {

        
        public string Departman { get; set; }

        public override void BilgiGoster()
        {
            base.BilgiGoster();
            Console.WriteLine($" Departman: {Departman}");
        }
    }
}
