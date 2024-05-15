using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CandidateApplicationManager.Api.Entities
{
    public class CandidateApplication
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("candidateApplicationId")]
        public string? CandidateApplicationId { get; set; }

        [Required]
        [JsonProperty("applicationId")]
        public string ApplicationId { get; set; }

        [Required]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [Required]
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [Required]
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonProperty("nationality")]
        public string Nationality { get; set; }
        [JsonProperty("currentResidence")]
        public string CurrentResidence { get; set; }
        [JsonProperty("idNumber")]
        public string IDNumber { get; set; }
        [JsonProperty("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("customQuestionsAnswers")]
        public List<CustomQuestionsAnswers>? CustomQuestionsAnswers { get; set; }
    }

    public class CustomQuestionsAnswers
    {
        public Guid QueastionId { get; set; }
        public QuestionType QuestionType { get; set; }
        public string? Answer { get; set; }
        public bool IsMultiChoice { get; set; } = false;
        public List<string?>? Answers { get; set; }


    }
}
