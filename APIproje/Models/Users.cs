using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIproje.Models {
    public class Users {
        public int id { get; set; }
        public string isim { get; set; }
        public string soyisim{ get; set; }
        public string eposta { get; set; }
        public string sifre { get; set; }
        public int boy { get; set; }
        public int kilo { get; set; }
        public int yas { get; set; }

        public string cinsiyet { get;}

    }
}
