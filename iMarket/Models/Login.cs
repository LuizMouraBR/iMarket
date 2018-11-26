using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMarket.Models
{
    public class Login
    {

        [BindProperty]
        public static string Email { get; set; }

        [BindProperty]
        public static string Senha { get; set; }

    }
}
