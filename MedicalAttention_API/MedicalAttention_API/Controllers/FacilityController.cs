using Dapper;
using MedicalAttention_API.Data;
using MedicalAttention_API.Entities;
using MedicalAttention_API.Entities.DTO;
using MedicalAttention_API.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAttention_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacilityController : ControllerBase
    {
        private readonly IFacilityRepository facilityRepository;

        public FacilityController(IFacilityRepository facilityRepository)
        {
            this.facilityRepository = facilityRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<FacilityDTO>>> Get()
        {
            var facilities = await facilityRepository.GetFacilities();

            var facilitiesDTO = facilities.Select(f => new FacilityDTO { Name = f.Name, City = f.City }).ToList();

            return Ok(facilities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Facility>>> GetByID(int id)
        {
            var facility = await facilityRepository.GetFacilityById(id);
            if (facility == null)
            {
                return NotFound();
            }

            var facilityDTO = new FacilityDTO() { Name = facility.Name, City = facility.City };

            return Ok(facilityDTO);
        }

        [HttpPost]
        public async Task<ActionResult> CreateFacility([FromBody] FacilityDTO facility)
        {
            var facilityID = await facilityRepository.AddFacility(facility);

            if (facilityID == 0) { return BadRequest(); }

            return CreatedAtAction(nameof(CreateFacility), new { id = facilityID }, facility);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFacility(int id)
        {
            var delete = await facilityRepository.DeleteFacility(id);
            if (!delete) { return NotFound(); }

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFacility(int id, [FromBody] Facility facility)
        {
            if (id != facility.Id)
            {
                return BadRequest();
            }

            var updated = await facilityRepository.UpdateFacility(facility);

            if (!updated) { return NotFound(); }

            return NoContent();
        }

    }

}
