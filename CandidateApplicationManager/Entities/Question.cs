using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CandidateApplicationManager.Api.Entities
{
    public class Question
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("queastionId")]
        public string? QueastionId { get; set; }

        [Required]
        [JsonProperty("applicationId")]
        public string ApplicationId { get; set; }
        [JsonProperty("questionType")]
        public QuestionType QuestionType { get; set; }
        [JsonProperty("queastionContent")]
        public string QueastionContent { get; set; }
        [JsonProperty("isMultiChoice")]
        public bool IsMultiChoice { get; set; }
        [JsonProperty("choices")]
        public List<string?>? Choices { get; set; }
        [JsonProperty("isEnableOtherOption")]
        public bool IsEnableOtherOption { get; set; }
        [JsonProperty("maxChoiceAllowed")]
        public int? MaxChoiceAllowed { get; set; }
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
