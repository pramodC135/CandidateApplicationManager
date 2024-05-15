using CandidateApplicationManager.Api.Entities;

namespace CandidateApplicationManager.Core
{
    public interface ICandidateApplicationRepository 
    {
        Task<CandidateApplication> CreateCandidateApplicationAsync(CandidateApplication candidateApplication);
        Task<CandidateApplication> UpdateCandidateApplicationAsync(CandidateApplication candidateApplication);
        Task DeleteCandidateApplicationAsync(string candidateApplicationId);   
        Task<CandidateApplication> GetCandidateApplicationAsync(string id);
        Task<IEnumerable<CandidateApplication>> GetAllCandidateApplicationAsync();
    }
}
