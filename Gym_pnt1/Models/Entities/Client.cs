namespace Gym_pnt1.Models.Entities
{
    public class Client : User
    {
        public DateTime StartDate { get; set; }
        public int MembershipId { get; set; } // Atributo Id de Membership
        public virtual Membership Membership { get; set; }

        public Client(string name, string lastName, DateTime birthDate, bool status, DateTime startDate, int membershipId)
            : base(name, lastName, birthDate, status)
        {
            this.StartDate = startDate;
            this.MembershipId = membershipId;
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

