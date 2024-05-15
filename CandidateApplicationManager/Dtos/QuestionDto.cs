using CandidateApplicationManager.Api.Entities;

namespace CandidateApplicationManager.Dtos
{
    public class QuestionDto
    {
        public string? QueastionId { get; set; }
        public string ApplicationId { get; set; }
        public QuestionType QuestionType { get; set; }
        public string QueastionContent { get; set; }
        public bool IsMultiChoice { get; set; }
        public List<string?>? Choices { get; set; }
        public bool IsEnableOtherOption { get; set; }
        public int? MaxChoiceAllowed { get; set; }
    }
}
