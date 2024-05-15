using CandidateApplicationManager.Api.Entities;
using CandidateApplicationManager.Dtos;

namespace CandidateApplicationManager.ExtensionsDto
{
    public static class ApplicationDtoExtension
    {
        public static ApplicationDto AsDto(this Application application)
        {
            return new ApplicationDto
            {
                ApplicationId = application.ApplicationId,
                ApplicationTitle = application.ApplicationTitle,
                ApplicationDescription = application.ApplicationDescription,
                FirstName = application.FirstName,
                LastName = application.LastName,
                Email = application.Email,
                PhoneNumber = new FormOptionsDto
                {
                    IsHide = application.PhoneNumber.IsHide,
                    IsInternal = application.PhoneNumber.IsInternal
                },
                Nationality = new FormOptionsDto
                {
                    IsHide = application.PhoneNumber.IsHide,
                    IsInternal = application.PhoneNumber.IsInternal
                },
                CurrentResidence = new FormOptionsDto
                {
                    IsHide = application.PhoneNumber.IsHide,
                    IsInternal = application.PhoneNumber.IsInternal
                },
                IDNumber = new FormOptionsDto
                {
                    IsHide = application.PhoneNumber.IsHide,
                    IsInternal = application.PhoneNumber.IsInternal
                },
                DateOfBirth = new FormOptionsDto
                {
                    IsHide = application.PhoneNumber.IsHide,
                    IsInternal = application.PhoneNumber.IsInternal
                },
                Gender = new FormOptionsDto
                {
                    IsHide = application.PhoneNumber.IsHide,
                    IsInternal = application.PhoneNumber.IsInternal
                },
                CustomQuestions = application.CustomQuestions?.Select(customQuestionnew => new CustomQuestionsDto
                {
                    QuestionType = customQuestionnew.QuestionType,
                    QuestionId = customQuestionnew.QuestionId,
                    IsPersonalInformation = customQuestionnew.IsPersonalInformation
                }).ToList()
            };
        }
    }
}
