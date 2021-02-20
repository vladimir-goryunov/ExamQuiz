using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using UsabilityFactoryExamQuiz.Utils.Repositories.Interfaces;
using UsabilityFactoryExamQuiz.Utils.Responses;
using UsabilityFactoryExamQuiz.Utils.Exceptions;
using UsabilityFactoryExamQuiz.Model.DataContract;
using System.Collections.Generic;
using UsabilityFactoryExamQuiz.Model.EF.Models;
using UsabilityFactoryExamQuiz.Model.BusinessLogic;
using UsabilityFactoryExamQuiz.Utils.Helpers;

namespace UsabilityFactoryExamQuiz.WebSite.Controllers
{
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IAnswerRepository _answerRepository;
        public AnswersController(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        [HttpPost]
        [Route("~/answers")]
        public async Task<ResponseMessage<List<AnswerEntity>>> Get()
        {
            try
            {
                var answers = await _answerRepository.GetAll();
                if (!answers.Any())
                {
                    _answerRepository.CreateTestDataSet();
                    answers = await _answerRepository.GetAll();
                }

                return new ResponseMessage<List<AnswerEntity>>("Информация", "Список текстов ответов")
                {
                    Data = answers.ToList()
                };
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.InnerException ?? ex, $"Ошибка при получении списка ответов.");
                return new ResponseMessage<List<AnswerEntity>>("Ошибка",
                                            $"Ошибка при получении списка ответов - {ex.Message}",
                                            ex.ToString(),
                                            (int)HttpStatusCode.InternalServerError);
            }
        }

        private ResponseMessage<String> Print(String value)
        {
            return new ResponseMessage<String>("Information", value);
        }

        /// <summary>
        /// Сохранить файлы вложений в виде блобов в хранилище Azure Storage в контейнере attachments 
        /// и создать соответствующие записи в SQL базе в таблице AnswerAttachments
        /// </summary>
        /// <param name="answerId"></param>
        /// <returns></returns>
        [HttpPost("{answerId}")]
        [Route("~/answers/{answerId}/attachments")]
        public async Task<ResponseMessage<String>> Attachments(AttachmentModel attachmentModel)
        {
            try
            {
                attachmentModel.Files = Request.Form.Files;
                _answerRepository.SaveAnswerAttachments(attachmentModel);
            }
            catch (AnswerNotFoundException ex)
            {
                // Учесть этот кейс
            }
            catch (Exception ex)
            {
                return new ResponseMessage<String>("Ошибка",
                                            $"Ошибка при сохранении списка вложений - {ex.Message}",
                                            ex.ToString(),
                                            (int)HttpStatusCode.InternalServerError);
            }

            return await Task.Run(() => Print("Список вложений успешно сохранён"));
        }

        /// <summary>
        /// Сохранить события в SQL базе данных в таблице AnswerEvents
        /// </summary>
        /// <param name="answerId"></param>
        /// <example>
        /// Для тестирования использовать в PowerShell команду
        /// Invoke-RestMethod http://localhost:22772/answers/2B75C2A4-A691-4706-9B2A-38301B131025/events -Method POST -Body (@{AnswerId = "2B75C2A4-A691-4706-9B2A-38301B131025"; AnswerEventJSON = "Value=500"} | ConvertTo-Json) -ContentType "application/json; charset=utf-8"
        /// </example>
        /// <returns></returns>
        [HttpPost("{answerId}")]
        [Route("~/answers/{answerId}/events")]
        public async Task<ResponseMessage<String>> Events(EventModel eventModel)
        {
            try
            {
                _answerRepository.SaveAnswerEvents(eventModel);
            }
            catch (AnswerNotFoundException ex)
            {
                // Учесть этот кейс
            }
            catch (Exception ex)
            {
                return new ResponseMessage<String>("Ошибка",
                                            $"Ошибка при сохранении списка событий - {ex.Message}",
                                            ex.ToString(),
                                            (int)HttpStatusCode.InternalServerError);
            }

            return await Task.Run(() => Print("Список событий успешно сохранён"));
        }



        [HttpPost("{answerId}")]
        [Route("~/answers/{answerId}/randomevents")]
        public async Task<List<AnswerEventEntity>> RandomEvents(Guid answerId)
        {
            return await Task.Run(() => DataGeneratorHelper.GenerateEvents(answerId));
        }
    }
}
