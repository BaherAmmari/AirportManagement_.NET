using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{public enum PlaneType
    {
        Boing, Airbus
    }
    public class Plane
    {
        public int PlaneId { get; set; }
        [Range(0,int.MaxValue)]
        public int Capacity  { get; set; }
        public DateTime ManufactureDate { get; set; }
        public PlaneType PlaneType { get; set; }
        [NotMapped]
        public string Information { get { return PlaneId + " " + Capacity + " " + PlaneType + " " + ManufactureDate; } }
        public virtual ICollection<Flight> Flights { get; set;}
        public override string ToString()
        {
            return " capacity:" + Capacity + " manufacturedate:" + ManufactureDate+ " plane type:"+PlaneType;
        }

        /* public Plane(int capacity, DateTime manuFactureDate, PlaneType planeType)
         {
             Capacity = capacity;
             ManuFactureDate = manuFactureDate;
             PlaneType = planeType;
         }

         public Plane()
         {
         }*/
    }
}
