using Gym_pnt1.Models;
using Gym_pnt1.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Gym_pnt1.Controllers
{
    public class UserController : Controller
    {
        private Context context = new Context();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            bool UserExists = !string.IsNullOrEmpty(HttpContext.Session.GetString("username"));
            if (!UserExists)
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(Client client)
        {
            if (client != null)
            {
                MembershipCategory membership = MembershipCategory.BRONZE;
                switch (client.MembershipId)
                {
                        case 0: membership = MembershipCategory.GOLD; break;
                        case 1: membership = MembershipCategory.SILVER; break;
                        case 2: membership = MembershipCategory.BRONZE; break;
                }
                client.Membership = new Membership(DateTime.Now.AddMonths(1), membership);
                Console.WriteLine(client.MembershipId);
                client.StartDate = DateTime.Now;
                context.Clients.Add(client);
                context.SaveChanges();
            }
            return RedirectToAction(nameof(ListClient));
        }
        
        public IActionResult ListClient()
        {
            bool UserExists = !string.IsNullOrEmpty(HttpContext.Session.GetString("username"));
            if (!UserExists)
            {
                return RedirectToAction("Login", "User");
            }
            List<Client> Clients = context.Clients.ToList();
            Console.WriteLine(Clients);
           // var elemento = context.Membership.Find(client);
            return View(Clients);
        }

        public IActionResult EditClient(int id)
        {
            Console.WriteLine(id);
            Client client = context.Clients.Find(id);
            Membership mem = context.Membership.Find(client.MembershipId);
            client.Membership = mem;
            return View(client);
        }

        public IActionResult SubmitClientToDb(Client client, int i, int a)
        {
            MembershipCategory membership = MembershipCategory.BRONZE;
            switch (client.MembershipId)
            {
                case 0: membership = MembershipCategory.GOLD; break;
                case 1: membership = MembershipCategory.SILVER; break;
                case 2: membership = MembershipCategory.BRONZE; break;
            }
            Membership mem = context.Membership.Find(i);
            mem.Category = membership;
            Client cliente = context.Clients.Find(a);
            cliente.Name = client.Name;
            cliente.LastName = client.LastName;
            cliente.BirthDate = client.BirthDate;
            context.SaveChanges();
            return RedirectToAction(nameof(ListClient));
        }

        public IActionResult DeleteClient(int id)
        {
            Client client = context.Clients.Find(id);
            context.Clients.Remove(client);
            context.SaveChanges();
            return RedirectToAction(nameof(ListClient));
        }
        /*public IActionResult SubmitClientToDb(Client client)
        {
            Membership mem = context.Membership.Find(client.MembershipId);
            client.MembershipId = 1002;
            Console.WriteLine(mem);
            context.Update(client);
            context.Update(client.Membership);
            context.SaveChanges();
            return RedirectToAction(nameof(ListClient));
        }*/


        public IActionResult GetSearchClientByNameForm(string name)
        {
            bool UserExists = !string.IsNullOrEmpty(HttpContext.Session.GetString("username"));
            if (!UserExists)
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }

        public IActionResult GetClientByName(Client client)
        {
            string NameToFind = client.Name.ToLower().Trim();
            List<Client> ClientsFound = context.Clients.Where(c => c.Name.ToLower().Contains(NameToFind)).ToList();
            return View(ClientsFound);
        }

        [HttpGet]
        public IActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (login.Username == "admin" && login.Password == "admin")
            {
                HttpContext.Session.SetString("username", login.Username);
                return RedirectToAction("Index","Home");
            }
            else
            {
                login.MensajeError = "Credenciales incorrectas. Por favor, inténtalo de nuevo.";
                login.MensajeErrorVisible = "block";
                return View(login);
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Login");
        }

        public IActionResult EditClientActivity(int id)
        {
            Console.WriteLine(id);
            Client client = context.Clients.Find(id);
            Membership mem = context.Membership.Find(client.MembershipId);
            client.Membership = mem;
            return View(mem);
        }
        public IActionResult SubmitClientActivityToDb(Membership mem)
        {
            Console.WriteLine(mem);
            Membership oldMemberhsip = context.Membership.Find(mem.MembershipId);
            oldMemberhsip.NumberOfEntries = mem.NumberOfEntries;
            context.SaveChanges();
            return RedirectToAction(nameof(ListClient));
        }


    }
    
}


