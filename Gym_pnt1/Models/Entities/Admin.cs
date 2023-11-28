namespace Gym_pnt1.Models.Entities
{
    public class Admin : User
    {
        public double Salary { get; set; }

        /*public Admin(double Salary, string name, string lastName, DateTime birthDate, bool status) : base (name, lastName, birthDate)
        {
          this.Salary = Salary; 
        }*/
    }
}
