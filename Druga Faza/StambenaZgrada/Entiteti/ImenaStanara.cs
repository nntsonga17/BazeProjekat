using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StambenaZgrada.Entiteti
{
    public class ImenaStanara
    {
        public virtual int ID_stanari { get; set; }

        public virtual String Ime_stanara { get; set; }
        public virtual Nivo Nivo { get; set; }
    }
}

