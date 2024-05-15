using CandidateApplicationManager.Api.Entities;

namespace CandidateApplicationManager.Dtos
{
    public class CandidateApplicationDto
    {
        public string? CandidateApplicationId { get; set; }
        public string ApplicationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Nationality { get; set; }
        public string CurrentResidence { get; set; }
        public string IDNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public List<CustomQuestionsAnswersDto>? CustomQuestionsAnswers { get; set; }
    }

    public class CustomQuestionsAnswersDto
    {
        public Guid QueastionId { get; set; }
        public QuestionType QuestionType { get; set; }
        public string? Answer { get; set; }
        public bool IsMultiChoice { get; set; } = false;
        public List<string?>? Answers { get; set; }


    }
}
