using System.ComponentModel.DataAnnotations;

namespace Gym_pnt1.Models.Entities
{
    public abstract class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool status { get; set; }

        /*public User( string name, string lastName, DateTime birthDate)
        {
            Name = name;
            LastName = lastName;
            BirthDate = birthDate;
            this.status = true;
        }*/
    }


}
