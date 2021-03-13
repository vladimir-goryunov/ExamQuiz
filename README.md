# Проект - Вопросник (тестовое задание)

## Предметная область
Респондент проходит анкетирование, отвечая последовательно на ряд вопросов. При
каждом ответе клиент (фронт) отправляет на сервер ответ респондента на текущий
вопрос. Некоторые вопросы требуют приложить к ответу файлы (например, скриншот
или ещё что-то). Приложенные файлы сохраняются вызовом отдельного метода.
В процессе тестирования логика собирает информацию о действиях пользователя в
виде событий. Данные события сохраняются вызовом отдельного метода (до 1000
событий за раз).

## Реализовать следующие REST API методы
1. POST answers/\<answerId\>/attachments/

Метод принимает на вход:
- answerId - Guid, определяет к какому ответу относятся приложения.
- Файлы - IEnumerable<HttpPostedFileBase>, массив приложенных к ответу файлов в теле запроса.

Метод сохраняет файлы в виде блобов в хранилище Azure Storage в контейнере 
attachments и делает соответствующие записи в SQL базе в таблице AnswerAttachments

2. POST answers/\<answerId\>/events/

Метод принимает на вход:
- answerId - Guid, определяет к какому ответу относятся приложения.
- События - AnswerEvent[], массив событий передаётся в теле запроса в виде строки JSON

Метод сохраняет события в SQL базе в таблице AnswerEvents.

## Требования к реализации
- Код на C#.
- Проект ASP.Net 4.7 или ASP.Net Core
- Работу с базой сделать через EntityFramework.
- Фронт часть не важна.
- Постараться сделать с использованием принципов DI и SOLID.
- Для работы с Azure Storage использовать эмулятор.
- Для работы с базой MS SQL Express.

## В качестве решения предоставить
1. Исходный код приложения в Git
2. Экспорт схемы SQL базы.

# Реализация

Предварительные условия
 
1) Экспорт схемы SQL базы расположен в проекте по следующему пути:
...\UsabilityFactoryExamQuiz.Model.EF\Scripts\20210225184444_Questionaire.sql
 
2) Файл log4net.config - конфигурация протоколирования приложения.
Путь к лог файлу сейчас задан такой - C:\UsabilityFactoryExamQuiz. Папка создастся автоматически при старте приложения
 
3) Файл appsettings.json - настройки приложения
Там указаны подключения к БД SQL Express и к Azure Storage
 
4) Предполагается, что до запуска приложения Azure Storage эмулятор запущен, чтобы можно было сохранять загружаемые файлы в блобы
 
## Структура проекта
 
Решение содержит 4 проекта:
 
### 1. UsabilityFactoryExamQuiz.Model
Проект содержит бизнес модель приложения и модели дата контрактов для входных данных методов веб сервиса.
В реальных приложениях, работающих через REST API, мы обычно делаем три модели:
- Модели дата контрактов для сервисов. Их отдаём клиенту и по схемам он формирует запросы к API
- Модели бизнес логики. Их использует BL уровень приложения
- Модели-сущности для работы с Entity Framework. 

Такое разделение удобно из-за гибкости архитектуры и удобства тестирования. Например, если будет принято решение не использовать веб сервисы или если использование EF для работы с БД не предполагается. Хотя напрямую модели бизнес логики сейчас нигде не используются, всё-таки решил оставить их в проекте.
 
### 2. UsabilityFactoryExamQuiz.Model.EF
Проект содержит функционал для работы с репозиторием БД:
- Модели-сущности для работы с БД через Entity Framework и классы их конфигураций
- Классы миграции и скрипт для экспорта схемы SQL базы
- Основной БД контекст для стандартного доступа к базовым сущностям
 
### 3. UsabilityFactoryExamQuiz.Utils
Проект содержит служебные утилиты
 
### 4. UsabilityFactoryExamQuiz.WebSite
Проект содержит базовый код веб приложения с REST API контроллерами, swagger и GUI для выполнения методов тестового задания.
Реализованные в проекте методы возвращают 4 возможные варианта ответа:
- 200 – если всё Ок
- 400 – если обнаружены не валидные данные
- 404 – если данные не найдены
- 500 – если случилась ошибка на стороне сервера

Дополнительно, при работе ведётся лог приложения и при ошибках информация сохраняется туда.
В планах, поместить тексты сообщений в ресурсы.
 
### Дополнительно
- Код написан на C#.
- Проект ASP.Net Core 3.1
- Работа с базой сделана через Entity Framework.
- Фронт реализован через страницу GUI. Для тестирования запросов подключен Swagger
- Серверная часть реализована с учётом принципов DI и SOLID.
- Для работы с Azure Storage использован стандартный Microsoft Azure Storage Emulator.
- Для работы с базой - MS SQL Express.
- При старте приложения создастся тестовый набор данных.
