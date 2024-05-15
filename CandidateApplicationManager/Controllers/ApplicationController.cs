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

        [HttpPut("edit")]
        public async Task<ActionResult<ApplicationDto>> UpdateApplication(string applicationId, Application application)
        {
            Application? existingApplication = await _applicationRepository.GetApplicationAsync(applicationId);

            if (existingApplication == null)
            {
                return NotFound();
            }

            //Preserve the original ID
            application.Id = existingApplication.Id;
            application.ApplicationId = existingApplication.ApplicationId;

            Application? updatedApplication = await _applicationRepository.UpdateApplicationAsync(application);
            return Ok(updatedApplication.AsDto());
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<ApplicationDto>>> GetAllApplications()
        {
            IEnumerable<Application>? applicatios = await _applicationRepository.GetAllApplicationsAsync();
            return Ok(applicatios?.Select(a => a.AsDto()));
        }
    }
}
