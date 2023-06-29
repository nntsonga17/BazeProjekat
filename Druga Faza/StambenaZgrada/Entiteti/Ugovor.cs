using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StambenaZgrada.Entiteti
{
    public class Ugovor

    {
        public virtual int Sifra { get; protected set; }
        public virtual DateTime Datum_potpisivanja { get; set; }
        public virtual int Vazenje_ugovora { get; set; }

        //veza 1:1 sa Zgradom
        public virtual Zgrada Zgrada { get; set;  }
    }
}