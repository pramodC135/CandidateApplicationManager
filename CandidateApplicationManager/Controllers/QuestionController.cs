using CandidateApplicationManager.Api.Core;
using CandidateApplicationManager.Api.Entities;
using CandidateApplicationManager.Dtos;
using CandidateApplicationManager.ExtensionsDto;
using Microsoft.AspNetCore.Mvc;

namespace CandidateApplicationManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        [HttpGet("fetchById")]
        public async Task<ActionResult<QuestionDto>> GetQuestionById(string questionId)
        {
            Question? question = await _questionRepository.GetQuestionAsync(questionId);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question.AsDto());
        }

        [HttpPost("add")]
        public async Task<ActionResult<QuestionDto>> CreateQuestion(Question question)
        {
            question.Id = Guid.NewGuid();
            question.QueastionId = question.Id.ToString();

            Question? createdQuestion = await _questionRepository.CreateQuestionAsync(question);

            return CreatedAtAction(nameof(GetQuestionById), new { questionId = createdQuestion.QueastionId?.ToString() }, createdQuestion);
        }

        [HttpPut("edit")]
        public async Task<ActionResult<QuestionDto>> UpdateQuestion(string questionId, Question question)
        {
            Question? existingQuestion = await _questionRepository.GetQuestionAsync(questionId);

            if (existingQuestion == null)
            {
                return NotFound();
            }

            //Preserve the original ID
            question.Id = existingQuestion.Id;
            question.QueastionId = existingQuestion.ApplicationId;

            Question? updatedQuestion = await _questionRepository.UpdateQuestionAsync(question);
            return Ok(updatedQuestion.AsDto());
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<QuestionDto>>> GetAllQuestions()
        {
            IEnumerable<Question>? questions = await _questionRepository.GetAllQuestionsAsync();
            return Ok(questions?.Select(a => a.AsDto()));
        }
    }
}
