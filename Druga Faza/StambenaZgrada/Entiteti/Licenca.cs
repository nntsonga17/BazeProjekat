using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StambenaZgrada.Entiteti
{
    public class Licenca
    {
        public virtual int ID_licence { get; protected set; }
        public virtual long Broj_licence { get; set; }
        public virtual DateTime Datum_sticanja_obnavljanja { get; set; }
        public virtual String Naziv_insitucije { get; set; }

        public virtual ProfesionalniUpravnik Upravnik { get; set; }
    }
}
