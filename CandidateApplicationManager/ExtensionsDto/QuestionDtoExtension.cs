using CandidateApplicationManager.Api.Entities;
using CandidateApplicationManager.Dtos;

namespace CandidateApplicationManager.ExtensionsDto
{
    public static class QuestionDtoExtension
    {
        public static QuestionDto AsDto(this Question question)
        {
            return new QuestionDto
            {
                QueastionId = question.QueastionId,
                ApplicationId = question.ApplicationId,
                QuestionType = question.QuestionType,
                QueastionContent = question.QueastionContent,
                IsMultiChoice = question.IsMultiChoice,
                Choices = question.Choices,
                IsEnableOtherOption = question.IsEnableOtherOption,
                MaxChoiceAllowed = question.MaxChoiceAllowed
            };
        }

    }
}
