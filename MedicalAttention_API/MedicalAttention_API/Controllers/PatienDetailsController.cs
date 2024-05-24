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
    public class PatientDetailsController : ControllerBase
    {
        private readonly IPatientDetailRepository PatientDetailsRepository;

        public PatientDetailsController(IPatientDetailRepository PatientDetailsRepository)
        {
            this.PatientDetailsRepository = PatientDetailsRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<PatientDetailsDTO>>> Get()
        {
            var patientDetails = await PatientDetailsRepository.GetPatientDetails();

            return Ok(patientDetails);
        }

    }

}
