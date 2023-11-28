using System.ComponentModel.DataAnnotations;

namespace Gym_pnt1.Models.Entities
{
    public class Membership
    {
        [Key]
        public int MembershipId { get; set; } // Atributo Id de Membership
        public DateTime EndDate { get; set; }
        public MembershipCategory Category { get; set; }

        public Membership(DateTime endDate, MembershipCategory category)
        {
            EndDate = endDate;
            Category = category;
        }

        public MembershipCategory getCategory()
        {
            return Category;
        }



    }
}
