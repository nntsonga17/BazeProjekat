using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StambenaZgrada.Entiteti
{
    public class ProfesionalniUpravnik : Zaposlen
    {
        public virtual string Naziv_institucije { get; set; }
        public virtual string Zvanje { get; set; }
        public virtual DateTime Datum_sticanja_diplome { get; set; }

        public virtual IList<Zgrada> Upravlja { get; set; }

        //1:1  s Licencom
        public virtual Licenca Ima_licencu { get; set; }

        public ProfesionalniUpravnik()
        {
            Upravlja = new List<Zgrada>();
        }

    }
}
