using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Olimpiaaa.Models;
using static Olimpiaaa.Models.DTOs;

namespace Olimpiaaa.Controllers
{
    [Route("Data")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Data> post(createDataDTO createDataDTO)
        {
            var newData = new Data
            {
                Id = Guid.NewGuid(),
                Country = createDataDTO.country,
                County = createDataDTO.county,
                Description = createDataDTO.description,
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now,
                PlayerId = createDataDTO.playerID,
            };
            if (newData != null)
            {
                using (var context = new OlimpiaContext())
                {
                    context.Datas.Add(newData);
                    context.SaveChanges();
                    return StatusCode(201, newData);
                }

            }
            return BadRequest();
        }
    }
}
