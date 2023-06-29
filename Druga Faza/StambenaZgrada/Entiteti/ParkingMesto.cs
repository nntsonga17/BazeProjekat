using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StambenaZgrada.Entiteti
{
    public class ParkingMesto : Nivo
    {
        public virtual int Rezervisano { get; set; }

    }
}
