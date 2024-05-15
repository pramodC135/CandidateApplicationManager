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

        public async Task DeleteCandidateApplicationAsync(string candidateApplicationId)
        {
            await _candidateApplicationContainer.DeleteItemAsync<CandidateApplication>(candidateApplicationId, new PartitionKey(candidateApplicationId));
        }

        public async Task<IEnumerable<CandidateApplication>> GetAllCandidateApplicationAsync()
        {
            FeedIterator<CandidateApplication>? query = _candidateApplicationContainer.GetItemLinqQueryable<CandidateApplication>()
                .ToFeedIterator();

            List<CandidateApplication> candidateApplications = new List<CandidateApplication>();
            while (query.HasMoreResults)
            {
                FeedResponse<CandidateApplication> response = await query.ReadNextAsync();
                candidateApplications.AddRange(response);
            }

            return candidateApplications;
        }

        public async Task<CandidateApplication> GetCandidateApplicationAsync(string candidateApplicationId)
        {
            QueryDefinition query = _candidateApplicationContainer.GetItemLinqQueryable<CandidateApplication>()
                .Where(r => r.CandidateApplicationId.Equals(candidateApplicationId)).Take(1).ToQueryDefinition();

            string? sqlQuery = query.QueryText;

            FeedResponse<CandidateApplication> response = await _candidateApplicationContainer.GetItemQueryIterator<CandidateApplication>(query).ReadNextAsync();
            return response.FirstOrDefault();
        }

        public async Task<CandidateApplication> UpdateCandidateApplicationAsync(CandidateApplication candidateApplication)
        {
            ItemResponse<CandidateApplication>? response = await _candidateApplicationContainer.ReplaceItemAsync(candidateApplication, candidateApplication.Id.ToString());
            return response.Resource;
        }
    }
}
