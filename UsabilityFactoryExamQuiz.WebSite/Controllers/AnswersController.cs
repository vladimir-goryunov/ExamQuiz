﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using UsabilityFactoryExamQuiz.Utils.Repositories.Interfaces;
using UsabilityFactoryExamQuiz.Utils.Exceptions;
using UsabilityFactoryExamQuiz.Model.DataContract;
using System.Collections.Generic;
using UsabilityFactoryExamQuiz.Model.EF.Models;
using System.Linq;
using UsabilityFactoryExamQuiz.Utils.Helpers;
using Microsoft.AspNetCore.Http;

namespace UsabilityFactoryExamQuiz.WebSite.Controllers
{

    /// <summary>
    /// REST API контроллер ответов
    /// </summary>
    /// <remarks>
    /// Подключение Swagger
    /// PM -> Swashbuckle.AspNetCore
    /// PM> Install-Package Swashbuckle.AspNetCore.Newtonsoft
    /// </remarks>
    [Route("~/api/v1")]
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
        [Route("[controller]")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IQueryable<AnswerEntity>>> Get()
        {
            try
            {
                var answers = await _answerRepository.GetAll();

                return Ok(answers);
            }
            catch (Exception ex)
            {
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
        /// <response code="200">Список вложений успешно сохранён </response>
        /// <response code="400">Ошибка при сохранении списка вложений. Список вложений не определён</response>  
        /// <response code="404">Ошибка при сохранении списка вложений. Указанный ответ, к которому относятся вложения, не найден в системе</response>  
        /// <response code="500">Ошибка при сохранении списка вложений. Внутренняя ошибка на сервере</response>  
        [HttpPost, DisableRequestSizeLimit]
        [Route("[controller]/{answerId}/attachments")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Attachments([FromForm] AttachmentModel attachmentModel)
        {
            try
            {
                if (attachmentModel.Files ==null || !attachmentModel.Files.ToList().Any()) return BadRequest("Список вложений не определён");
                await Task.Run(() => _answerRepository.SaveAnswerAttachments(attachmentModel));

                return Ok("Список вложений успешно сохранён");
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
        /// <response code="200">Список событий успешно сохранён </response>
        /// <response code="400">Ошибка при сохранении списка событий. Список событий не определён</response>  
        /// <response code="404">Ошибка при сохранении списка событий. Указанный ответ, к которому относятся события, не найден в системе</response>  
        /// <response code="500">Ошибка при сохранении списка событий. Внутренняя ошибка на сервере</response>  
        [HttpPost()]
        [Route("[controller]/{answerId}/events")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> Events([FromForm] EventModel eventModel)
        {
            try
            {
                if (string.IsNullOrEmpty(eventModel.EventsJson)) return BadRequest("Список событий не определён");
                eventModel.Events = JsonHelper<List<AnswerEventEntity>>.CreateFromJSON(eventModel.EventsJson);
                
                if (!eventModel.Events.Any()) return BadRequest("Список событий не определён");
                await Task.Run(() => _answerRepository.SaveAnswerEvents(eventModel));

                return Ok("Список событий успешно сохранён");
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

        /// <summary>
        /// Получает список случайных событий
        /// </summary>
        /// <returns>Список случайных событий</returns>
        [HttpGet]
        [Route("[controller]/{answerId}/random-events")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<AnswerEventEntity>>> RandomEvents([FromQuery] string answerId)
        {
            try
            {
                var results = await Task.Run(() => DataGeneratorHelper.GenerateEvents(Guid.Parse(answerId)));

                return Ok(results);
            }
            catch (Exception ex)
            {
                var errorMessage = $"Ошибка получении списка случайных событий - {ex.Message}";
                _logger.LogError(ex.InnerException ?? ex, errorMessage);
                return StatusCode(InternalServerError, errorMessage);
            }
        }
    }
}
