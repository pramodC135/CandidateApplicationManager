using CandidateApplicationManager.Api.Entities;
using CandidateApplicationManager.Core;
using CandidateApplicationManager.Dtos;
using CandidateApplicationManager.ExtensionsDto;
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
        public async Task<ActionResult<CandidateApplicationDto>> GetCandidateApplicationById(string candidateApplicationId)
        {
            CandidateApplication? question = await _candidateApplicationRepository.GetCandidateApplicationAsync(candidateApplicationId);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question.AsDto());
        }

        [HttpPost("add")]
        public async Task<ActionResult<CandidateApplicationDto>> CreateCandidateApplication(CandidateApplication candidateApplication)
        {
            candidateApplication.Id = Guid.NewGuid();
            candidateApplication.CandidateApplicationId = candidateApplication.Id.ToString();

            CandidateApplication? createdCandidateApplication = await _candidateApplicationRepository.CreateCandidateApplicationAsync(candidateApplication);

            return CreatedAtAction(nameof(GetCandidateApplicationById), new { candidateApplicationId = createdCandidateApplication?.CandidateApplicationId?.ToString() }, createdCandidateApplication);
        }

        [HttpPut("edit")]
        public async Task<ActionResult<CandidateApplicationDto>> UpdateQuestion(string candidateApplicationId, CandidateApplication candidateApplication)
        {
            CandidateApplication? existingCandidateApplication = await _candidateApplicationRepository.GetCandidateApplicationAsync(candidateApplicationId);

            if (existingCandidateApplication == null)
            {
                return NotFound();
            }

            //Preserve the original ID
            candidateApplication.Id = existingCandidateApplication.Id;
            candidateApplication.CandidateApplicationId = existingCandidateApplication.CandidateApplicationId;

            CandidateApplication? updatedCandidateApplication = await _candidateApplicationRepository.UpdateCandidateApplicationAsync(candidateApplication);
            return Ok(updatedCandidateApplication?.AsDto());
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<CandidateApplicationDto>>> GetAllCandidateApplications()
        {
            IEnumerable<CandidateApplication>? candidateApplications = await _candidateApplicationRepository.GetAllCandidateApplicationAsync();
            return Ok(candidateApplications?.Select(a => a.AsDto()));
        }
    }
}
