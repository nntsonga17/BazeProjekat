using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StambenaZgrada.Entiteti
{
   public class Zaposlen
    {
        public virtual long JMBG { get;   set; }
        public virtual string Licno_ime { get; set; }
        public virtual string Ime_roditelja { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Br_telefona1 { get; set; }
        public virtual string Br_telefona2 { get; set; }

        public virtual string Mesto_stanovanja { get; set; }
        public virtual string Ulica { get; set; }
        public virtual string Broj { get; set; }

        public virtual int Broj_licne_karte { get; set; }
        public virtual string Mesto_izdavanja { get; set; }
        public virtual DateTime Datum_rodjenja { get; set; }
    }
}
