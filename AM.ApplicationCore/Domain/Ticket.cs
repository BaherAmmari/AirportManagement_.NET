using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Ticket
    {
        public string Siege { get; set; }
        public float Price { get; set; }
        public bool VIP { get; set; }
        public virtual Flight Flight { get; set; }

        [ForeignKey("Flight")]
        public int FlightFk { get; set; }
        public  virtual Passenger Passenger { get; set; }

        [ForeignKey("Passenger")]
        public string PassengerFk { get; set; }
    }
}
