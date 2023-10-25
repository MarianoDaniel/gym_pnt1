using System.ComponentModel.DataAnnotations;

namespace Gym_pnt1.Models.Entities
{
    public class Gym
    {
        [Key]
        public int Id { get; set; }
        public const double GOLD_PARTNER_PRICE = 1000;
        public const double SILVER_PARTNER_PRICE = 750;
        public const double BRONZE_PARTNER_PRICE = 450;
        public List<User> users;
        public List<Machine> machines;
        public Gym()
        {
            this.users = new List<User>();
            this.machines = new List<Machine>();
        }

    }
}
