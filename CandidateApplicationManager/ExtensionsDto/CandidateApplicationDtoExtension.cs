using CandidateApplicationManager.Api.Entities;
using CandidateApplicationManager.Dtos;

namespace CandidateApplicationManager.ExtensionsDto
{
    public static class CandidateApplicationDtoExtension
    {
        public static CandidateApplicationDto AsDto(this CandidateApplication candidateApplication)
        {
            return new CandidateApplicationDto
            {
                CandidateApplicationId = candidateApplication.CandidateApplicationId,
                ApplicationId = candidateApplication.ApplicationId,
                FirstName = candidateApplication.FirstName, 
                LastName = candidateApplication.LastName,  
                Email = candidateApplication.Email,
                PhoneNumber = candidateApplication.PhoneNumber,
                Nationality = candidateApplication.Nationality, 
                CurrentResidence = candidateApplication.CurrentResidence,
                IDNumber = candidateApplication.IDNumber,
                DateOfBirth = candidateApplication.DateOfBirth,
                Gender = candidateApplication.Gender,
                CustomQuestionsAnswers = candidateApplication.CustomQuestionsAnswers?.Select(customQuestions => new CustomQuestionsAnswersDto
                {
                    QueastionId = customQuestions.QueastionId,
                    QuestionType = customQuestions.QuestionType,
                    Answer = customQuestions.Answer,
                    IsMultiChoice = customQuestions.IsMultiChoice,
                    Answers = customQuestions.Answers,
                }).ToList()
            };
        }
    }
}
