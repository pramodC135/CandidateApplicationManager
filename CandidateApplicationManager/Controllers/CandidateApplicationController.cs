using CandidateApplicationManager.Api.Entities;
using CandidateApplicationManager.Core;
using Microsoft.AspNetCore.Mvc;

namespace CandidateApplicationManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateApplicationController : ControllerBase
    {
        private readonly ICandidateApplicationRepository _candidateApplicationRepository;

        public CandidateApplicationController(ICandidateApplicationRepository candidateApplicationRepository)
        {
            _candidateApplicationRepository = candidateApplicationRepository;
        }

        [HttpGet("fetchById")]
        public async Task<ActionResult<CandidateApplication>> GetCandidateApplicationById(string candidateApplicationId)
        {
            CandidateApplication? question = await _candidateApplicationRepository.GetCandidateApplicationAsync(candidateApplicationId);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        [HttpPost("add")]
        public async Task<ActionResult<CandidateApplication>> CreateCandidateApplication(CandidateApplication candidateApplication)
        {
            candidateApplication.Id = Guid.NewGuid();
            candidateApplication.CandidateApplicationId = candidateApplication.Id.ToString();

            CandidateApplication? createdCandidateApplication = await _candidateApplicationRepository.CreateCandidateApplicationAsync(candidateApplication);

            return CreatedAtAction(nameof(GetCandidateApplicationById), new { candidateApplicationId = createdCandidateApplication.CandidateApplicationId.ToString() }, createdCandidateApplication);
        }
    }
}
