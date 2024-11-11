using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Olimpiaaa.Models;
using static Olimpiaaa.Models.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                Name = createPlayerDTO.name,
                Age = createPlayerDTO.age,
                Weight = createPlayerDTO.weight,
                Height = createPlayerDTO.height,
                CreatedTime = DateTime.Now,
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
        [HttpGet("byId")]
        public ActionResult<Player> getById(Guid id)
        {
            using (var context = new OlimpiaContext())
            {
                return Ok(context.Players.Where(x => x.Id == id).Include(x => x.Data).ToList());
            }
        }
        [HttpPut]
        public ActionResult<Player> put(Guid id, updatePlayerDTO player)
        {
            using (var context = new OlimpiaContext())
            {
                var existingPlayer = context.Players.FirstOrDefault(x => x.Id == id);
                if (existingPlayer != null)
                {
                    existingPlayer.Name = player.name;
                    existingPlayer.Age = player.age;
                    existingPlayer.Weight = player.weight;
                    existingPlayer.Height = player.height;

                    context.Players.Update(existingPlayer);
                    context.SaveChanges();
                    return StatusCode(200, existingPlayer);
                }
                return NotFound();
            }
        }
        [HttpDelete]
        public ActionResult<Player> delete(Guid id)
        {
            using (var context = new OlimpiaContext())
            {
                var deletingPlayer=context.Players.FirstOrDefault(x=>x.Id==id);
                if (deletingPlayer!=null)
                {
                    context.Players.Remove(deletingPlayer);
                    context.SaveChanges();
                    return StatusCode(200, new { message = "Sikeres törlés!" });
                }
                return NotFound(new { message = "Sikertelen törlés" });
            }
        }
        [HttpGet("playerData/{id}")]
        public ActionResult<limitedClass> get(Guid id)
        {
            using (var context = new OlimpiaContext())
            {
                var player = context.Players.Include(x=>x.Data).FirstOrDefault(x=> x.Id==id);
                var data = context.Datas.FirstOrDefault(x => x.PlayerId == id); 
                List<string> jegyzetek = new List<string>();
                foreach (var item in context.Datas)
                {
                    if (item.PlayerId == id)
                    {
                        jegyzetek.Add(item.Description);
                    }
                }

                var limitedPlayerOutput = new limitedClass
                {
                    Name = player.Name,
                    Country = data.Country,
                    county = data.County,
                    descriptions = jegyzetek
                };
                
                if (player != null)
                {
                    return Ok(limitedPlayerOutput);
                }
                return NotFound();
            }
        }
    }
}
