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
    public class PayerController : ControllerBase
    {
        private readonly IPayerRepository PayerRepository;

        public PayerController(IPayerRepository PayerRepository)
        {
            this.PayerRepository = PayerRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<PayerDTO>>> Get()
        {
            var payer = await PayerRepository.GetPayer();

            var payerDTO = payer.Select(f => new PayerDTO { Name = f.Name, City = f.City }).ToList();

            return Ok(payerDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Payer>>> GetByID(int id)
        {
            var Payer = await PayerRepository.GetPayerById(id);
            if (Payer == null)
            {
                return NotFound();
            }

            var PayerDTO = new PayerDTO() { Name = Payer.Name, City = Payer.City };

            return Ok(PayerDTO);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePayer([FromBody] PayerDTO Payer)
        {
            var PayerID = await PayerRepository.AddPayer(Payer);

            if (PayerID == 0) { return BadRequest(); }

            return CreatedAtAction(nameof(CreatePayer), new { id = PayerID }, Payer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePayer(int id)
        {
            var delete = await PayerRepository.DeletePayer(id);
            if (!delete) { return NotFound(); }

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePayer(int id, [FromBody] Payer Payer)
        {
            if (id != Payer.Id)
            {
                return BadRequest();
            }

            var updated = await PayerRepository.UpdatePayer(Payer);

            if (!updated) { return NotFound(); }

            return NoContent();
        }

    }

}
