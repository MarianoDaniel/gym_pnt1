using System.ComponentModel.DataAnnotations;

namespace Gym_pnt1.Models.Entities
{
    public class Machine
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }   
        public MachineType Type { get; set; }

        public Machine(  MachineType type, string name)
        {
            Type = type;
            this.name = name;
        }
    }

 
}
