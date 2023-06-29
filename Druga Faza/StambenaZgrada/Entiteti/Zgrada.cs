using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StambenaZgrada.Entiteti
{
    public class Zgrada
    {
        public virtual int ID_zgrade { get; protected set; }
        public virtual string Mesto { get; set; }
        public virtual string Ulica { get; set; }
        public virtual string Broj { get; set; }
        public virtual int Broj_jedinica { get; set; }
        public virtual int Godina_izgradnje { get; set; }

        public virtual ProfesionalniUpravnik Upravnik { get; set; }

        //i veza 1:1 sa Ugovor
        public virtual Ugovor Ugovor { get; set; }


        public virtual IList<Lift> Ima_lift { get; set; }
        public virtual IList<Ulaz> Ima_ulaz { get; set; }
        public virtual IList<Nivo> Ima_nivo { get; set; }

        public Zgrada()
        {
            Ima_lift = new List<Lift>();

            Ima_ulaz = new List<Ulaz>();

            Ima_nivo = new List<Nivo>();


        }
    }
}
