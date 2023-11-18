using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Plane = AM.ApplicationCore.Domain.Plane;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods :IFlightMethods
    {
        //delegues pointeur sur une méthode
        //methode sans retour delegue de type action
        //methode avec type de retour delegue de type func
        public Action<Plane> FlightDetailsDel { get; set; }
        public Func<string, double> DurationAverageDel { get; set; }
        public List<Flight> Flights { get; set; }=new List<Flight>();
        public FlightMethods()
        {
            //FlightDetailsDel = ShowFlightDetails;
            FlightDetailsDel = pl =>
            {
                var flights = from f in Flights
                              where f.Plane == pl
                              select new { f.FlightDate, f.Destination };
                foreach (var flight in flights)
                {
                    Console.WriteLine(flight.FlightDate + " " + flight.Destination);
                }
            };
            //DurationAverageDel = DurationAverage;
            DurationAverageDel = dest =>
            {
                var req = (from f in Flights
                           where f.Destination == dest
                           select f.EstimatedDuration);
                return req.Average();
            };
        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            //var req = from f in Flights
            //          group f by f.Destination;
            var req2 = Flights.GroupBy(f => f.Destination);
            foreach (var g in req2) {
                Console.WriteLine(g.Key);
                foreach (Flight f in g)
                    Console.WriteLine(f);
            }
                
            return req2;
        }

        public double DurationAverage(string destination)
        {
            //var req = (from f in Flights
            //           where f.Destination == destination
            //           select f.EstimatedDuration);
            var req2= Flights.Where(f => f.Destination == destination).Average(f=>f.EstimatedDuration);
            //return req.Average();
            return req2;
        }

        public List<DateTime> GetFlightDates(string destination)
        {
            //List<DateTime> dates= new List<DateTime>();
            //foreach (var flight in Flights)
            //{
            //    if (flight.Destination.Equals(destination))
            //    {
            //        dates.Add(flight.FlightDate);
            //    }

            //}
            //List<DateTime> dates =(from f in Flights
            //                      where f.Destination == destination
            //                      select f.FlightDate).ToList();
            //return dates;
            var req= Flights.Where(f=>f.Destination== destination).Select(f=>f.FlightDate);
            return req.ToList();
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType) {
                case "Departure":
                    foreach (var flight in Flights)
                    {
                        if(flight.Departure.Equals(filterValue)) {
                            Console.WriteLine(flight);
                        }

                    }
                    break;
                case "Destination":
                    foreach (var flight in Flights)
                    {
                        if (flight.Destination.Equals(filterValue))
                        {
                            Console.WriteLine(flight);
                        }

                    }
                    break;
                case "EstimatedDuration":
                    foreach (var flight in Flights)
                    {
                        if (flight.EstimatedDuration==(int.Parse(filterValue)))
                        {
                            Console.WriteLine(flight);
                        }

                    }
                    break;
                case "FlightDate":
                    foreach (var flight in Flights)
                    {
                        if (flight.FlightDate==(DateTime.Parse(filterValue)))
                        {
                            Console.WriteLine(flight);
                        }

                    }
                    break;
                default: Console.WriteLine("valeur incorrecte");
                    break;
            }
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            //var req = from f in Flights
            //          orderby f.EstimatedDuration descending
            //          select f;
            //return req;
            var req= Flights.OrderByDescending(f=>f.EstimatedDuration);
            return req;
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //var req = from f in Flights
            //          where (f.FlightDate - startDate).TotalDays<7 && (f.FlightDate- startDate).TotalDays >0
            //          select f;
            //return req.Count();
            var req = Flights.Where(f => (f.FlightDate - startDate).TotalDays < 7 && (f.FlightDate - startDate).TotalDays > 0).Count();
            return req;
        }

        //public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        //{
        //    //var req= from t in flight.Passengers.OfType<Traveller>()
        //    //         orderby t.BirthDate ascending 
        //    //         select t;
        //    //return req.Take(3);
        //    //req.Skip(3) pour ignorer 3 
        //    //return flight.Passengers.OfType<Traveller>().OrderBy(t=>t.BirthDate).Take(3);
        //}

        public void ShowFlightDetails(Plane plane)
        {
            //var flights = from f in Flights
            //                              where f.Plane == plane
            //                              select new {f.FlightDate, f.Destination};
            var flights = Flights.Where(f => f.Plane==plane).Select(f =>  new { f.FlightDate, f.Destination });
            foreach (var flight in flights) {
                Console.WriteLine(flight.FlightDate+" "+flight.Destination);
            }
            
        }
    }
}
