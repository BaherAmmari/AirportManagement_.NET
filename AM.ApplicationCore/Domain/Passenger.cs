using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        [Key] //annotation
 
        public string PassportNumber { get; set; }
        [StringLength(100)]
        public string Photo { get; set; }
        [Display(Name ="Date of birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage ="email invalide")]
        public string EmailAddress { get; set; }
        public FullName FullName { get; set; }
        [RegularExpression("@[0-9]{8}")]
        public string TelNumber { get; set; }
        //public ICollection<Flight> Flights { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        //public bool CheckProfile(string prenom, string nom)
        //{
        //    return prenom.Equals(FirstName) && nom.Equals(LastName);
        //}
        public bool CheckProfile(string prenom, string nom, string email=null)
        {
            if(email != null)
            {
                return prenom.Equals(FullName.FirstName) && nom.Equals(FullName.LastName) && email.Equals(EmailAddress);
            }
            else
            {
                return prenom.Equals(FullName.FirstName) && nom.Equals(FullName.LastName);
            }
            
        }
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }

    }
}
