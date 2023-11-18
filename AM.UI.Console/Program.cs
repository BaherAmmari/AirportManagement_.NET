// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infrastructure;

Console.WriteLine("Hello, World!");
Plane p = new Plane();
p.Capacity = 100;
p.ManufactureDate = new DateTime(2023, 01, 31);
p.PlaneType = PlaneType.Boing;
//Plane plane= new Plane(100, DateTime.Now, PlaneType.Airbus);
Console.WriteLine(p);
Plane p2 = new Plane
{
    Capacity = 100,
    ManufactureDate = DateTime.Now
};
Console.WriteLine(p2);
Passenger passenger = new Passenger
{
    FullName=new FullName {
        FirstName = "amani",
        LastName = "hadda"
    }
    ,
    EmailAddress = "amani@gmail.com"
};
Console.WriteLine(passenger.CheckProfile("amani","hadda"));
Console.WriteLine(passenger.CheckProfile("amani", "hadda","hhhh"));
Staff staff=new Staff();
Traveller traveller=new Traveller();
passenger.PassengerType();
traveller.PassengerType();
staff.PassengerType();
Console.WriteLine("***********************************TP2******************************************");
FlightMethods fm = new FlightMethods();
fm.Flights = TestData.listFlights;
Console.WriteLine("-------------------getFlightsDate-------------------------");
foreach (DateTime item in fm.GetFlightDates("Madrid"))
{
    Console.WriteLine(item);
}
Console.WriteLine("-------------------getFlights-------------------------");
fm.GetFlights("Destination", "Paris");
Console.WriteLine("-------------------ShowFlightDetails(Plane plane)-------------------------");
//fm.ShowFlightDetails(TestData.Airbusplane);
fm.FlightDetailsDel(TestData.Airbusplane);
Console.WriteLine("-------------------Duration Average-------------------------");
//Console.WriteLine(fm.DurationAverage("Paris"));
Console.WriteLine(fm.DurationAverageDel("Paris"));
Console.WriteLine("-------------------OrderedDurationFlights-------------------------");
foreach(var f in fm.OrderedDurationFlights())
    Console.WriteLine(f);
Console.WriteLine("-------------------SeniorTravellers-------------------------");
//foreach (var f in fm.SeniorTravellers(TestData.flight1))
//    Console.WriteLine(f.BirthDate);
Console.WriteLine("-------------------ProgrammedFlightNumber-------------------------");
Console.WriteLine(fm.ProgrammedFlightNumber(new DateTime(2022, 01, 29, 21, 10, 10)));
Console.WriteLine("-------------------DestinationGroupedFlights-------------------------");
Console.WriteLine(fm.DestinationGroupedFlights());
Console.WriteLine("-------------------Methode d'extension-------------------------");
passenger.UpperFullName();
Console.WriteLine(passenger.FullName.FirstName +" "+ passenger.FullName.LastName);
//insertion dans la bd
AMContext ctx=new AMContext();
UnitOfWork uow = new UnitOfWork(ctx);
ServicePlane sp = new ServicePlane(uow);
sp.Add(TestData.BoingPlane);
sp.Add(TestData.Airbusplane);
//ctx.Planes.Add(TestData.BoingPlane);
//ctx.Planes.Add(TestData.Airbusplane);
//ctx.Flights.Add(TestData.flight1);
//ctx.SaveChanges();
ServiceFlight sf = new ServiceFlight(uow);
sf.Add(TestData.flight1);
sp.Commit(); //remplace ctx.saveChanges();
//afficher le contenu de la table flight
foreach (Flight f in ctx.Flights)
{
    Console.WriteLine("FlightDate: "+f.FlightDate+ " Date fabricration d'avion"+ f.Plane.ManufactureDate);
}