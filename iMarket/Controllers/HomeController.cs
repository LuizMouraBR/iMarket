using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using iMarket.Models;
using Microsoft.AspNetCore.Http;

namespace iMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly iMarketDatabaseContext _context;

        public HomeController(iMarketDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> LoginConfirm(string Email, string Senha)
        {

            var emailToConfirm = Email;
            var passwordToConfirm = Senha;

            IQueryable<Usuario> user = _context.Usuario.Where(u => u.Email == emailToConfirm).Where(u => u.Senha == passwordToConfirm);
            Usuario usuario = user.FirstOrDefault();

            if (usuario != null)
            {
                ISession["userId"] = usuario.Id;
            }
                return View("About");


            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
