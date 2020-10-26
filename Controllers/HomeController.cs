using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAppProj1.Models;

namespace WebAppProj1.Controllers
{
    public class HomeController : Controller
    {

    public IActionResult Index(){
        GuestInventory guestInventory = new GuestInventory();
        guestInventory.setupData();
        return View(guestInventory);
    }
      public IActionResult SubmitEntry_Controller(GuestInventory guestInventory){
          guestInventory.submitEntry();
          guestInventory.setupData();
          return View("Index", guestInventory);
      }  
    }
}
