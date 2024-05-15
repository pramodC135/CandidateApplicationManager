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
            string? applicationsContainerName = "Applications";
            _applicationContainer = cosmosClient.GetContainer(databaseName, applicationsContainerName);         
        }

        public async Task<Application> CreateApplicationAsync(Application application)
        {
            ItemResponse<Application>? response = await _applicationContainer.CreateItemAsync(application);
            return response.Resource;
        }

        public async Task DeleteApplicationAsync(string applicationId)
        {
            await _applicationContainer.DeleteItemAsync<Application>(applicationId, new PartitionKey(applicationId));
        }

        public async Task<IEnumerable<Application>> GetAllApplicationsAsync()
        {
            FeedIterator <Application>? query = _applicationContainer.GetItemLinqQueryable<Application>()
                .ToFeedIterator();

            List<Application> applications = new List<Application>();
            while (query.HasMoreResults)
            {
                FeedResponse<Application> response = await query.ReadNextAsync();
                applications.AddRange(response);
            }

            return applications;
        }

        public async Task<Application> GetApplicationAsync(string applicationId)
        {
            QueryDefinition query = _applicationContainer.GetItemLinqQueryable<Application>()
                .Where(r => r.ApplicationId.Equals(applicationId)).Take(1).ToQueryDefinition();

            string? sqlQuery = query.QueryText;

            FeedResponse<Application>? response = await _applicationContainer.GetItemQueryIterator <Application>(query).ReadNextAsync();
            return response.FirstOrDefault();
        }

        public async Task<Application> UpdateApplicationAsync(Application application)
        {
            ItemResponse<Application>? response = await _applicationContainer.ReplaceItemAsync(application, application.Id.ToString());          
            return response.Resource;
        }
    }
}
