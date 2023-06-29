using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StambenaZgrada.Entiteti
{
    public abstract class Lift
    {
        public virtual int Serijski_broj { get;  set; }
        public virtual string Naziv_proizvodjaca { get; set; }
        public virtual DateTime Datum_poslednjeg_kvara { get; set; }
        public virtual DateTime Datum_poslednjeg_servisa { get; set; }
        public virtual int TipLifta { get; set; }
        public virtual Zgrada Ima_lift { get; set; }

    }

    public class PutnickiLift : Lift
    {
        public virtual int Max_broj_osoba { get; set; }

    }

    public class TeretniLift : Lift
    {
        public virtual double Nosivost { get; set; }
    }

}

