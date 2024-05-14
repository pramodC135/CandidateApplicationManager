namespace CandidateApplicationManager.Api.Entities
{
    public class Question
    {
        public Guid QueastionId { get; set; }
        public QuestionType QuestionType { get; set; }
        public string QueastionContent { get; set; }
        public bool IsMultiChoice { get; set; }
        public List<string> Choices { get; set; }
        public bool IsEnableOtherOption { get; set; }
        public int MaxChoiceAllowed { get; set; }
    }

    public enum QuestionType : byte
    {
        ParagraphQueastions = 1,
        YesNoQueastions,
        DropdownQueastions,
        DateQueastions,
        NumberQueastions
    }
}
