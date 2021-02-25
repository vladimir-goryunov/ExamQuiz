# Предметная область .
Респондент проходит анкетирование, отвечая последовательно на ряд вопросов. При
каждом ответе клиент (фронт) отправляет на сервер ответ респондента на текущий
вопрос. Некоторые вопросы требуют приложить к ответу файлы (например, скриншот
или ещё что-то). Приложенные файлы сохраняются вызовом отдельного метода.
В процессе тестирования логика собирает информацию о действиях пользователя в
виде событий. Данные события сохраняются вызовом отдельного метода (до 1000
событий за раз ).

# Нужно разработать два REST API метода.

1. POST answers/<answerId>/attachments/
Метод принимает на вход:
	answerId - Guid, определяет к какому ответу относятся приложения.
	Файлы - IEnumerable<HttpPostedFileBase>, массив приложенных к ответу файлов в
	теле запроса.

Метод сохраняет файлы в виде блобов в хранилище Azure Storage в контейнере 
attachments и делает соответствующие записи в SQL базе в таблице AnswerAttachments

2. POST answers/<answerId>/events/
	Метод принимает на вход:
	answerId - Guid, определяет к какому ответу относятся приложения.
	События - AnswerEvent[], массив событий передаётся в теле запроса в виде строки
	JSON
Метод сохраняет события в SQL базе в таблице AnswerEvents.

# Модель.
Модель для базы
public class AnswerAttachment
{
	public Guid Id {get; set;}
	public Guid AnswerId { get; set; }
	public DateTime Created { get; set; }
	public String FileName { get; set; }
	public String MimeType { get; set; }
	public Int32 Size { get; set; }
}

Модель для входных данных REST метода. Модель для базы нужно сделать самостоятельно.

public class AnswerEvent
{
	String Value { get; set;}
	AnswerEventTypeEnum Type { get; set; }
	DateTime ClientTime { get; set; }
}
public enum AnswerEventTypeEnum
{
	Click,
	Move,
	Drag,
	Press,
	Other
}

# Дополнительно.
- Код на C#.
- Проект ASP.Net 4.7 или ASP.Net Core
- Работу с базой сделать через EntityFramework.
- Фронт часть не важна.
- Постараться сделать с использованием принципов DI и SOLID.
- Качество важнее чем скорость.
- Для работы с Azure Storage использовать эмулятор.
- Для работы с базой MS SQL Express.

# В качестве решения предоставить:
1. Исходный код приложения.
2. Экспорт схемы SQL базы.