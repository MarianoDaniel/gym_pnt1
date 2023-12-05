namespace Gym_pnt1.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string MensajeError { get; set; }
        public string MensajeErrorVisible { get; set; } = "none";
    }
}
