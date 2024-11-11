using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Olimpiaaa.Models;
using static Olimpiaaa.Models.DTOs;

namespace Olimpiaaa.Controllers
{
    [Route("Player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Player> post(createPlayerDTO createPlayerDTO)
        {
            var newPlayer = new Player
            {
                Id = Guid.NewGuid(),
                Name=createPlayerDTO.name,
                Age=createPlayerDTO.age,
                Weight=createPlayerDTO.weight,
                Height=createPlayerDTO.height,
                CreatedTime=DateTime.Now,
            };
            if (newPlayer != null)
            {
                using (var context = new OlimpiaContext())
                {
                    context.Players.Add(newPlayer);
                    context.SaveChanges();
                    return StatusCode(201, newPlayer);
                }
                
            }
            return BadRequest();
        }
        [HttpGet]
        public ActionResult<Player> get()
        {
            using (var context = new OlimpiaContext())
            {
                return Ok(context.Players.Include(x => x.Data).ToList());
            }
        }

    }
}
