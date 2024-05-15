using CandidateApplicationManager.Api.Entities;

namespace CandidateApplicationManager.Dtos
{
    public class ApplicationDto
    {
        public string? ApplicationId { get; set; }
        public string ApplicationTitle { get; set; }
        public string ApplicationDescription { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public FormOptionsDto PhoneNumber { get; set; }
        public FormOptionsDto Nationality { get; set; }
        public FormOptionsDto CurrentResidence { get; set; }
        public FormOptionsDto IDNumber { get; set; }
        public FormOptionsDto DateOfBirth { get; set; }
        public FormOptionsDto Gender { get; set; }
        public List<CustomQuestionsDto>? CustomQuestions { get; set; }
    }

    public class FormOptionsDto
    {
        public bool IsInternal { get; set; } = false;
        public bool IsHide { get; set; } = false;
    }

    public class CustomQuestionsDto
    {
        public QuestionType QuestionType { get; set; }
        public string QuestionId { get; set; }
        public bool IsPersonalInformation { get; set; }
    }
}
