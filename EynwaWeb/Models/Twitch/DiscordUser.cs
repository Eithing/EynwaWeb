using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EynwaWeb.Models.Twitch
{
    public class DiscordUser
    {
        public string NickName { get; set; }

        [Key]
        public ulong UserId { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
