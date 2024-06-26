﻿using CandidateApplicationManager.Api.Entities;

namespace CandidateApplicationManager.Api.Core
{
    public interface IQuestionRepository
    {
        Task<Question> CreateQuestionAsync(Question question);
        Task<Question> UpdateQuestionAsync(Question question);  
        Task DeleteQuestionAsync(string questionId);
        Task<Question> GetQuestionAsync(string questionId);
        Task<IEnumerable<Question>> GetQuestionByTypeAsync(QuestionType questionType);
        Task<IEnumerable<Question>> GetAllQuestionsAsync();
    }
}
