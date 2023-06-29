using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StambenaZgrada.Entiteti
{
    public class Nivo
    {
        public virtual int ID_nivoa { get;  set; }
        public virtual int Sprat { get; set; }
        public virtual int Redni_broj { get; set; }


        public virtual Zgrada Zgrada { get; set; }

    }

}
