using CandidateApplicationManager.Api.Entities;
using CandidateApplicationManager.Core;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace CandidateApplicationManager.Repositories
{
    public class CandidateApplicationRepository : ICandidateApplicationRepository
    {
        public readonly Container _candidateApplicationContainer;
        private readonly IConfiguration configuration;
        public CandidateApplicationRepository(CosmosClient cosmosClient, IConfiguration configuration)
        {
            this.configuration = configuration;

            string? databaseName = configuration["CosmosDbSettings:DatabaseName"];
            string? candidateApplicationsContainerName = "CandidateApplications";
            _candidateApplicationContainer = cosmosClient.GetContainer(databaseName, candidateApplicationsContainerName);
        }

        public async Task<CandidateApplication> CreateCandidateApplicationAsync(CandidateApplication candidateApplication)
        {
            ItemResponse<CandidateApplication>? response = await _candidateApplicationContainer.CreateItemAsync(candidateApplication);
            return response.Resource;
        }

        public Task DeleteCandidateApplicationAsync(string candidateApplicationId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CandidateApplication>> GetAllCandidateApplicationAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CandidateApplication> GetCandidateApplicationAsync(string candidateApplicationId)
        {
            QueryDefinition query = _candidateApplicationContainer.GetItemLinqQueryable<CandidateApplication>()
                .Where(r => r.CandidateApplicationId.Equals(candidateApplicationId)).Take(1).ToQueryDefinition();

            string? sqlQuery = query.QueryText;

            FeedResponse<CandidateApplication> response = await _candidateApplicationContainer.GetItemQueryIterator<CandidateApplication>(query).ReadNextAsync();
            return response.FirstOrDefault();
        }

        public Task<CandidateApplication> UpdateCandidateApplicationAsync(CandidateApplication candidateApplication)
        {
            throw new NotImplementedException();
        }
    }
}
