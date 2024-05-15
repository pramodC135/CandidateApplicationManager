using Microsoft.AspNetCore.Mvc;
using CandidateApplicationManager.Api.Core;
using CandidateApplicationManager.Api.Entities;
using CandidateApplicationManager.Dtos;
using CandidateApplicationManager.ExtensionsDto;
using CandidateApplicationManager.Api.Repository;

namespace CandidateApplicationManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly ILogger<ApplicationController> _logger;
        public ApplicationController( IApplicationRepository applicationRepository, ILogger<ApplicationController> logger)
        {
            _applicationRepository = applicationRepository;
            _logger = logger;
        }

        [HttpGet("fetchById")]
        public async Task<ActionResult<ApplicationDto>> GetApplicationById(string applicationId)
        {
            Application? application = await _applicationRepository.GetApplicationAsync(applicationId);
            if(application == null)
            {
                return NotFound();
            }
            return Ok(application.AsDto()); 
        }

        [HttpPost("add")]
        public async Task<ActionResult<ApplicationDto>> CreateApplication(Application application)
        {
            application.Id = Guid.NewGuid();
            application.ApplicationId = application.Id.ToString();

            Application? createdApplication = await _applicationRepository.CreateApplicationAsync(application);
            return CreatedAtAction(nameof(GetApplicationById), new { applicationId = createdApplication?.ApplicationId?.ToString() }, createdApplication);
        }
    }
}
