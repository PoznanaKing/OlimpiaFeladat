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
        [HttpGet]
        public ActionResult<Data> get()
        {
            using (var context = new OlimpiaContext())
            {
                return Ok(context.Datas.ToList());
            }
        }
        [HttpGet("byId")]
        public ActionResult<Data> getById(Guid id)
        {
            using (var context = new OlimpiaContext())
            {
                return Ok(context.Datas.Where(x=>x.Id == id).ToList());
            }
        }
        [HttpPut]
        public ActionResult<Data> put(Guid id,updateDataDto updateDataDTO)
        {
            using (var context = new OlimpiaContext())
            {
                var existingData= context.Datas.FirstOrDefault(x=>x.Id==id);
                if(existingData != null)
                {

                    existingData.Country = updateDataDTO.country;
                    existingData.County = updateDataDTO.county;
                    existingData.Description = updateDataDTO.description;
                    existingData.UpdatedTime = DateTime.Now;

                    context.Datas.Update(existingData);
                    context.SaveChanges();
                    return StatusCode(200, existingData);
                }
                return NotFound();
            }
        }
        [HttpDelete]
        public ActionResult<Data> delete(Guid id)
        {
            using (var context = new OlimpiaContext())
            {
                var deletingData= context.Datas.FirstOrDefault(x=>x.Id == id);
                if(deletingData != null)
                {
                    context.Datas.Remove(deletingData);
                    context.SaveChanges();
                    return StatusCode(200, new { message = "Sikeres törlés!" });
                }
                return NotFound(new { message = "Sikertelen törlés!" });
            }
            
        }

    }

}
