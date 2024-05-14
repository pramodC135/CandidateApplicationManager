using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using CandidateApplicationManager.Api.Core;
using CandidateApplicationManager.Api.Entities;

namespace CandidateApplicationManager.Api.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly Container _applicationContainer;
        private readonly IConfiguration configuration;

        public ApplicationRepository(CosmosClient cosmosClient, IConfiguration configuration)
        {
            this.configuration = configuration;

            string? databaseName = configuration["CosmosDbSettings:DatabaseName"];
            string? taskContainerName = "Applications";
            _applicationContainer = cosmosClient.GetContainer(databaseName, taskContainerName);         
        }

        public async Task<Application> CreateApplicationAsync(Application application)
        {
            ItemResponse<Application>? response = await _applicationContainer.CreateItemAsync(application);
            return response.Resource;
        }

        public Task<Application> DeleteApplicationAsync(string applicationId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Application>> GetAllApplicationsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Application> GetApplicationAsync(string applicationId)
        {
            QueryDefinition query = _applicationContainer.GetItemLinqQueryable<Application>()
                .Where(r => r.ApplicationId.Equals(applicationId)).Take(1).ToQueryDefinition();

            string? sqlQuery = query.QueryText;

            FeedResponse<Application> response = await _applicationContainer.GetItemQueryIterator <Application>(query).ReadNextAsync();
            return response.FirstOrDefault();
        }

        public Task<Application> UpdateApplicationAsync(Application application)
        {
            throw new NotImplementedException();
        }
    }
}
