
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiscoveryPlants.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscoveryPlants.Controllers
{
    public class Error: Controller
    {
        public IActionResult Plantas()
        {
          //TODO: Implement Realistic Implementation
          return View();
        }
    }
}