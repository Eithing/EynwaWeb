using EynwaWeb.Models.Twitch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EynwaWeb.Rest
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwitchUpdateStatusController : ControllerBase
    {
        private TwitchDbContext context = new TwitchDbContext();
        // GET: api/<TwitchUpdateStatusController>
        [HttpGet]
        public IEnumerable<DiscordUser> Get()
        {
            return context.DiscordUsers;
        }

        // GET api/<TwitchUpdateStatusController>/5
        [HttpGet("{id}")]
        public DiscordUser Get(ulong id)
        {
            return context.DiscordUsers.Where(u => u.UserId == id).FirstOrDefault();
        }

        // POST api/<TwitchUpdateStatusController>
        [HttpPost]
        public void Post(ulong userId, string title, ulong gameId, string gameName)
        {
            context.Database.EnsureCreated();

            var user = context.DiscordUsers?.Where(u => u.UserId == userId).FirstOrDefault();
            if (user.Games == null)
                user.Games = new List<Game>();
            var selectedGame = user?.Games?.Where(g => g.Id == gameId).FirstOrDefault();
            if (selectedGame != null)
            {
                selectedGame.StreamTitle = title;
            }
            else
            {
                user?.Games?.Add(new Game { Id = gameId, Name = gameName, StreamTitle = title, UserId = userId });
                context.DiscordUsers.Update(user);
                context.SaveChanges();
            }
            context.Games.Add(user?.Games?.Where(g => g.Id == gameId).FirstOrDefault());
            context.Games.Update(user?.Games?.Where(g => g.Id == gameId).FirstOrDefault());
            context.SaveChanges();
        }

        // DELETE api/<TwitchUpdateStatusController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
