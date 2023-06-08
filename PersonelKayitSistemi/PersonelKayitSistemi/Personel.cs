using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelKayitSistemi
{
    public class Personel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public string City { get; set; }
        public int Wage { get; set; }//Maaş
        public bool Status { get; set; }//durum
        public string Job { get; set; }//meslek
   
    
    }
}
