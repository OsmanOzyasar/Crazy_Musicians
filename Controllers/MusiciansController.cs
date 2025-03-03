using Crazy_Musicians.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crazy_Musicians.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {
        private static List<Musicians> _musicians = new List<Musicians>
        {
            new Musicians {  Id = 1,  Name = "Ahmet Çalgı", Expertise = "Ünlü Çalgı Çalar", FunnyFeature = "Her Zaman Yanlış Nota Çalar Ama Çok Eğlenceli"},
            new Musicians { Id = 2, Name = "Zeynep Melodi", Expertise = "Popüler Melodi Yazarı", FunnyFeature = "Şarkıları Yanlış Anlaşılır Ama Çok Popüler"}
        };

        [HttpGet("musician-list")]
        public IActionResult List()
        {
            var musicians = _musicians.Select(x => new MusiciansListResponse
            {
                Id = x.Id,
                Name = x.Name,
                Expertise = x.Expertise,
                FunnyFeature = x.FunnyFeature
            }).ToList();
            return Ok(musicians);
        }

        [HttpGet("{id:int:min(1)}")]
        public IActionResult Get([FromQuery]int id) // [FromQuery] kullanımı ve amacını tam anlamadım o yüzden yanlışsa çok da takılmayın
        {
            var musician = _musicians.FirstOrDefault(x => x.Id == id);

            if (musician == null)
                return NotFound();

            new MusiciansListResponse
            {
                Id = id,
                Name = musician.Name,
                Expertise = musician.Expertise,
                FunnyFeature = musician.FunnyFeature
            };

            return Ok(musician);
        }

        [HttpPost("create-musician")]
        public IActionResult Create(MusiciansAddRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var musician = new Musicians
            {
                Id = _musicians.Max(x => x.Id) + 1,
                Name = request.Name,
                Expertise = request.Expertise,
                FunnyFeature = request.FunnyFeature
            };

            _musicians.Add(musician);

            return CreatedAtAction(nameof(Get), new { id = musician.Id }, musician);
        }

        [HttpPatch("update/{id:int:min(1)}")]
        public IActionResult Update(int id, MusiciansPatchRequest request)
        {
            var musician = _musicians.FirstOrDefault(x => x.Id == id);

            if (musician == null)
                return NotFound();

            musician.Expertise = request.Expertise;
            musician.FunnyFeature = request.FunnyFeature;

            return CreatedAtAction(nameof(Get), new { id = musician.Id }, musician);

        }

        [HttpPut("change/{id:int:min(1)}")]
        public IActionResult Change(int id, MusiciansPutRequest request)
        {
            var musician = _musicians.FirstOrDefault(x => x.Id == id);

            if (musician == null)
                return NotFound();

            musician.Name = request.Name;
            musician.Expertise = request.Expertise;
            musician.FunnyFeature = request.FunnyFeature;

            return CreatedAtAction(nameof(Get), new { id = musician.Id }, musician);
        }

        [HttpDelete("delete/{id:int:min(1)}")]
        public IActionResult Delete(int id)
        {
            var musician = _musicians.FirstOrDefault(x =>x.Id == id);

            if (musician == null)
                return NotFound();

            _musicians.Remove(musician);

            return Ok(_musicians);
        }
    }
}
