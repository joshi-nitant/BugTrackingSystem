using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Controllers
{
  
    [Route("Admin/Employee")]
    public class Home : Controller
    {
        [Route("")]
        [Route("Index")]
        public string Index()
        {
            return "Hello World";
        }
    }
}
