using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StambenaZgrada.Entiteti
{
    public class VlasnikStana
    {
        public virtual long JMBG { get;  set; }
        public virtual string Licno_ime { get; set; }
        public virtual string Ime_roditelja { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Br_telefona1 { get; set; }
        public virtual string Br_telefona2 { get; set; }
        public virtual string Mesto_stanovanja { get; set; }
        public virtual int Tip_u_skupstini { get; set; }

        public virtual string Ulica { get; set; }
        public virtual string Broj { get; set; }

        public virtual IList<Stan> Ima_stan { get; set; }

        public VlasnikStana()
        {
            Ima_stan = new List<Stan>();
        }

    }
}
