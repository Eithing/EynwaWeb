using EynwaWeb.Rest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EynwaWeb.Controllers
{
    public class TwitchController : Controller
    {
        private readonly TwitchDbContext _myTwitchContext = new TwitchDbContext();
        public IActionResult ApiToken()
        {
            return View();
        }

        public IActionResult UpdateStatusEditor()
        {
            var gameInfos = _myTwitchContext.DiscordUsers.First();
            return View(gameInfos);
        }
    }
}
