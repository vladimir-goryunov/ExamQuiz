using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UsabilityFactoryExamQuiz.Utils.Repositories.Interfaces;
using UsabilityFactoryExamQuiz.Utils.Responses;
using UsabilityFactoryExamQuiz.Utils.Exceptions;
using UsabilityFactoryExamQuiz.Model.DataContract;

namespace UsabilityFactoryExamQuiz.WebSite.Controllers
{
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IAnswerRepository _answerRepository;
        public AnswersController(IAnswerRepository answerRepository) {
            _answerRepository = answerRepository;
        }

        [HttpGet]
        [Route("~/answers")]
        public async Task<ResponseMessage> Get()
        {
            try
            {
                //var answers = await _answerRepository.GetAll();
                //var result = _mapper.Map<List<Answer>>(answers);
                //return new ResponseMessage("", string.Join("<br>", answers.Select(x => x.Text).ToList()));
                return await Task.Run(() => Print(null));
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.InnerException ?? ex, $"Ошибка при получении списка ответов.");
                return new ResponseMessage("Ошибка", 
                                            "Ошибка при получении списка ответов.",
                                            (int)HttpStatusCode.InternalServerError);
            }

            
        }

        private ResponseMessage Print(String value) {
            return new ResponseMessage("Information", value);
        }

        /// <summary>
        /// Сохранить файлы вложений в виде блобов в хранилище Azure Storage в контейнере attachments 
        /// и создать соответствующие записи в SQL базе в таблице AnswerAttachments
        /// </summary>
        /// <param name="answerId"></param>
        /// <returns></returns>
        [HttpGet("{answerId}")]
        [Route("~/answers/{answerId}/attachments")]
        public async Task<ResponseMessage> Attachments(AttachmentModel attachmentModel)
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
                return new ResponseMessage("Ошибка",
                                            "Ошибка при сохранении списка вложений.",
                                            ex.ToString(),
                                            (int)HttpStatusCode.InternalServerError);
            }

            return await Task.Run(() => Print($"Имитация метода POST. Сохраним вложения в Azure Storage и SQL Express БД"));
        }

        /// <summary>
        /// Сохранить события в SQL базе данных в таблице AnswerEvents
        /// </summary>
        /// <param name="answerId"></param>
        /// <returns></returns>
        [HttpGet("{answerId}")]
        [Route("~/answers/{answerId}/events")]
        public async Task<ResponseMessage> Events(EventModel eventModel)
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
                return new ResponseMessage("Ошибка",
                                            "Ошибка при сохранении списка событий.",
                                            ex.ToString(),
                                            (int)HttpStatusCode.InternalServerError);
            }

            return await Task.Run(() => Print($"Имитация метода POST. Сохраним входные события в SQL Express БД"));
        }

    }
}
