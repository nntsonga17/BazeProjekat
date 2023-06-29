using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StambenaZgrada.Entiteti
{
    public class Ulaz
    {

        public virtual int ID_ulaza { get; protected set; }
        public virtual int Redni_broj { get; set; }
        public virtual int Postojanje_kamere { get; set; }
        public virtual string Vreme_otvaranja { get; set; }
        public virtual string Vreme_zatvaranja { get; set; }

        public virtual Zgrada Zgrada { get; set; }
    }

}
