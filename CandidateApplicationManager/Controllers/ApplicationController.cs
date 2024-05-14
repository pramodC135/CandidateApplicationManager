using Microsoft.AspNetCore.Mvc;
using CandidateApplicationManager.Api.Core;
using CandidateApplicationManager.Api.Entities;

namespace CandidateApplicationManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationRepository _applicationRepository;
        public ApplicationController( IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        [HttpGet("fetchById")]
        public async Task<ActionResult<Application>> GetApplicationById(string applicationId)
        {
            Application? application = await _applicationRepository.GetApplicationAsync(applicationId);
            if(application == null)
            {
                return NotFound();
            }
            return Ok(application); 
        }

        [HttpPost("add")]
        public async Task<ActionResult<Application>> CreateApplication(Application application)
        {
            application.Id = Guid.NewGuid();
            application.ApplicationId = application.Id.ToString();
            /*application.CustomQuestions.ForEach(CustomQuestion =>
            {


            });*/

            Application? createdApplication = await _applicationRepository.CreateApplicationAsync(application);
            return CreatedAtAction(nameof(GetApplicationById), new { applicationId = createdApplication.ApplicationId.ToString() }, createdApplication);
        }
    }
}
