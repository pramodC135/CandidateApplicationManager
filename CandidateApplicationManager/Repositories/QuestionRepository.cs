using CandidateApplicationManager.Api.Core;
using CandidateApplicationManager.Api.Entities;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System;
using static System.Net.Mime.MediaTypeNames;

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

        public async Task DeleteQuestionAsync(string questionId)
        {
            await _questionContainer.DeleteItemAsync<Question>(questionId, new PartitionKey(questionId));
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            FeedIterator<Question>? query = _questionContainer.GetItemLinqQueryable<Question>()
                .ToFeedIterator();

            List<Question> questions = new List<Question>();
            while (query.HasMoreResults)
            {
                FeedResponse<Question> response = await query.ReadNextAsync();
                questions.AddRange(response);
            }

            return questions;
        }

        public async Task<Question> GetQuestionAsync(string questionId)
        {
            QueryDefinition query = _questionContainer.GetItemLinqQueryable<Question>()
                .Where(r => r.QueastionId.Equals(questionId)).Take(1).ToQueryDefinition();

            string? sqlQuery = query.QueryText;

            FeedResponse<Question> response = await _questionContainer.GetItemQueryIterator<Question>(query).ReadNextAsync();
            return response.FirstOrDefault();
        }

        public async Task<Question> UpdateQuestionAsync(Question question)
        {
            ItemResponse<Question>? response = await _questionContainer.ReplaceItemAsync(question, question.Id.ToString());
            return response.Resource;
        }
    }
}
