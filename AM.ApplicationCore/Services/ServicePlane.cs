using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    //heritage 9bal sinn ne compile pas
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void DeletePlanes()
        {
            Delete(p=>(DateTime.Now-p.ManufactureDate).TotalDays>3650);
        }

        public IEnumerable<Flight> GetFlights(int n)
        {
            //return GetMany().OrderByDescending(p=>p.PlaneId).Take(n).SelectMany(p=>p.Flights).OrderBy(f=>f.FlightDate);
            //meme question mais pour les avions de type Boing
            return GetMany(p=>p.PlaneType==PlaneType.Boing).OrderByDescending(p => p.PlaneId).Take(n).SelectMany(p => p.Flights).OrderBy(f => f.FlightDate);
        }

        public IEnumerable<Passenger> GetPassenger(Plane p)
        {
            return p.Flights.SelectMany(f=>f.Tickets).Select(t=>t.Passenger);
        }

        public bool isAvailablePlane(Flight f, int n)
        {
            return f.Plane.Capacity > n + f.Tickets.Count();
        }
    }
}
