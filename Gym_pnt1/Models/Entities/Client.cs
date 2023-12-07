using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gym_pnt1.Models.Entities
{
    public class Client : User
    {
        public DateTime StartDate { get; set; }
        public int MembershipId { get; set; } // Atributo Id de Membership
        public  Membership Membership { get; set; }


        /* public Client(string name, string lastName, DateTime birthDate, int membershipId)
             : base(name, lastName, birthDate)
         {
             this.MembershipId = membershipId;
         }*/
        /*public Client(string name, string lastName, DateTime birthDate, bool status, DateTime startDate, Membership membership) : base(name, lastName, birthDate, status)
        {
            this.StartDate = startDate;
            this.Membership = membership;
        }*/

        public string getCategory()
        {
            Context context = new Context();
            Membership mem = context.Membership.Find(this.MembershipId);
            string category = mem.Category.ToString();

            return category;
        }
        public int getActivity()
        {
            Context context = new Context();
            Membership mem = context.Membership.Find(this.MembershipId);
            return mem.NumberOfEntries;
        }
        public int getId()
        {
            return this.Membership.MembershipId;
        }
        public String getStr()
        {  
            return "Membresia: " + this.Membership.getCategory();
        }

        public int getPrice()
        {
            return this.Membership.getPrice();
        }
       


    }

   
  




    /*public class Client : User
    {
        public DateTime StartDate { get; set; }
        public Membership Membership { get; set; }

        public Client(string name, string lastName, DateTime birthDate, bool status, DateTime startDate, Membership membership) :  base( name,  lastName,  birthDate,  status)
        {
           this.StartDate = startDate;
           this.Membership = membership;
        }
    }*/
}

