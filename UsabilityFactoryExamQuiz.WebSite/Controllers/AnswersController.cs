using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using UsabilityFactoryExamQuiz.Utils.Repositories.Interfaces;
using UsabilityFactoryExamQuiz.Utils.Exceptions;
using UsabilityFactoryExamQuiz.Model.DataContract;
using System.Collections.Generic;
using UsabilityFactoryExamQuiz.Model.EF.Models;


namespace UsabilityFactoryExamQuiz.WebSite.Controllers
{
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private const int InternalServerError = (int)System.Net.HttpStatusCode.InternalServerError;

        private readonly ILogger _logger;
        private readonly IAnswerRepository _answerRepository;
        public AnswersController(IAnswerRepository answerRepository, 
                                ILoggerFactory loggerFactory)
        {
            _answerRepository = answerRepository ?? throw new ArgumentNullException(nameof(answerRepository));
            _logger = loggerFactory?.CreateLogger(nameof(AnswersController)) ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        /// <summary>
        /// Получает список всех ответов
        /// </summary>
        /// <returns>Список ответов</returns>
        [HttpGet]
        [Route("~/answers")]
        public async Task<ActionResult<List<AnswerEntity>>> Get()
        {
            try
            {
                var answers = await _answerRepository.GetAll();
                
                return Ok(answers);
            }
            catch (Exception ex) {
                var errorMessage = $"Ошибка получении списка ответов - {ex.Message}";
                _logger.LogError(ex.InnerException ?? ex, errorMessage);
                return StatusCode(InternalServerError, errorMessage); 
            }
        }

        /// <summary>
        /// Сохраняеть файлы вложений
        /// </summary>
        /// <param name="answerId"></param>
        /// <returns></returns>
        [HttpPost("{answerId}")]
        [Route("~/answers/{answerId}/attachments")]
        public async Task<ActionResult> Attachments(AttachmentModel attachmentModel)
        {
            try
            {
                if (attachmentModel == null) return BadRequest("Список вложений не определён");
                attachmentModel.Files = Request.Form.Files;
                await Task.Run(() => _answerRepository.SaveAnswerAttachments(attachmentModel));

                return Ok(); 
            }
            catch (AnswerNotFoundException)
            {
                var errorMessage = $"Ошибка при сохранении списка вложений. Указанный ответ (answerId={attachmentModel.AnswerId}), к которому относятся вложения, не найден в системе.";
                _logger.LogError(errorMessage);
                return NotFound(errorMessage);
            }
            catch (Exception ex)
            {
                var errorMessage = $"Ошибка при сохранении списка вложений - {ex.Message}";
                _logger.LogError(ex.InnerException ?? ex, errorMessage);
                return StatusCode(InternalServerError, errorMessage);
            }

        }

        /// <summary>
        /// Сохраняет события
        /// </summary>
        /// <param name="answerId"></param>
        /// <returns></returns>
        [HttpPost("{answerId}")]
        [Route("~/answers/{answerId}/events")]
        // [FromForm] EventModel eventModel
        public async Task<ActionResult> Events([FromForm] EventModel eventModel)
        {
            try
            {
                if (eventModel == null) return BadRequest("Список событий не определён");
                await Task.Run(() => _answerRepository.SaveAnswerEvents(eventModel));

                return Ok();
            }
            catch (AnswerNotFoundException)
            {
                var errorMessage = $"Ошибка при сохранении списка событий. Ответ (answerId={eventModel.AnswerId}), к которому относятся события, не найден в системе.";
                _logger.LogError(errorMessage);
                return NotFound(errorMessage);
            }
            catch (Exception ex)
            {
                var errorMessage = $"Ошибка при сохранении списка событий - {ex.Message}";
                _logger.LogError(ex.InnerException ?? ex, errorMessage);
                return StatusCode(InternalServerError, errorMessage);
            }
        }
    }
}
