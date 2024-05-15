using CandidateApplicationManager.Api.Core;
using CandidateApplicationManager.Api.Entities;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace CandidateApplicationManager.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly Container _questionContainer;
        private readonly IConfiguration configuration;
        public QuestionRepository(CosmosClient cosmosClient, IConfiguration configuration)
        {
            this.configuration = configuration;

            string? databaseName = configuration["CosmosDbSettings:DatabaseName"];
            string? queastionsContainerName = "Queastions";
            _questionContainer = cosmosClient.GetContainer(databaseName, queastionsContainerName);
        }

        public async Task<Question> CreateQuestionAsync(Question question)
        {
            ItemResponse<Question>? response = await _questionContainer.CreateItemAsync(question);
            return response.Resource;
        }

        public Task<Question> DeleteQuestionAsync(string questionId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Question> GetQuestionAsync(string questionId)
        {
            QueryDefinition query = _questionContainer.GetItemLinqQueryable<Question>()
                .Where(r => r.QueastionId.Equals(questionId)).Take(1).ToQueryDefinition();

            string? sqlQuery = query.QueryText;

            FeedResponse<Question> response = await _questionContainer.GetItemQueryIterator<Question>(query).ReadNextAsync();
            return response.FirstOrDefault();
        }

        public Task<Question> UpdateQuestionAsync(Question question)
        {
            throw new NotImplementedException();
        }
    }
}
