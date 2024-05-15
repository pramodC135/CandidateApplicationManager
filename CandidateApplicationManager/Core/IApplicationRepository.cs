using CandidateApplicationManager.Api.Entities;

namespace CandidateApplicationManager.Api.Core
{
    public interface IApplicationRepository
    {
        Task<Application> CreateApplicationAsync(Application application);
        Task<Application> UpdateApplicationAsync(Application application);
        Task DeleteApplicationAsync(string applicationId);
        Task<Application> GetApplicationAsync(string applicationId);
        Task<IEnumerable<Application>> GetAllApplicationsAsync();
    }
}
