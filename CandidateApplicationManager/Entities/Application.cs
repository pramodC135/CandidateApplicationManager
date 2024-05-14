using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CandidateApplicationManager.Api.Entities
{
    public class Application
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("applicationId")]
        public string? ApplicationId { get; set; }

        [Required]
        [JsonProperty("applicationTitle")]
        public string ApplicationTitle { get; set; }

        [Required]
        [JsonProperty("applicationDescription")]
        public string ApplicationDescription { get; set; }

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
        public FormOptions PhoneNumber { get; set; }
        [JsonProperty("nationality")]
        public FormOptions Nationality { get; set;}
        [JsonProperty("currentResidence")]
        public FormOptions CurrentResidence { get; set;}
        [JsonProperty("idNumber")]
        public FormOptions IDNumber { get; set;}
        [JsonProperty("dateOfBirth")]
        public FormOptions DateOfBirth { get; set; }
        [JsonProperty("gender")]
        public FormOptions Gender { get; set; }
        [JsonProperty("customQuestions")]
        public List<CustomQuestions> CustomQuestions { get; set; }
    }

    public class FormOptions
    {
        [JsonProperty("isInternal")]
        public bool IsInternal { get; set;} = false;
        [JsonProperty("isHide")]
        public bool IsHide { get; set;} = false ;
    }

    public class CustomQuestions
    {
        [JsonProperty("questionType")]
        public QuestionType QuestionType { get; set;}
        [JsonProperty("questionId")]
        public string QuestionId { get; set;}
        [JsonProperty("isPersonalInformation")]
        public bool IsPersonalInformation { get; set;}
    }
}
