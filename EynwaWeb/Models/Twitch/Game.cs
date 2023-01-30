using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EynwaWeb.Models.Twitch
{
    public class Game
    {
        public string Name { get; set; }
        public string StreamTitle { get; set; }
        public ulong Id { get; set; }
        public ulong UserId { get; set; }
    }
}
