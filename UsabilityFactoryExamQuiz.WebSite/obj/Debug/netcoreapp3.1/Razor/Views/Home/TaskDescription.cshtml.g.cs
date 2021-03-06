#pragma checksum "D:\_Net.TestTask\UsabilityFactoryExamQuiz\UsabilityFactoryExamQuiz.WebSite\Views\Home\TaskDescription.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4dcf9263e3f5bc524ce5550f2296484e6c2d6914"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_TaskDescription), @"mvc.1.0.view", @"/Views/Home/TaskDescription.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\_Net.TestTask\UsabilityFactoryExamQuiz\UsabilityFactoryExamQuiz.WebSite\Views\_ViewImports.cshtml"
using UsabilityFactoryExamQuiz.WebSite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\_Net.TestTask\UsabilityFactoryExamQuiz\UsabilityFactoryExamQuiz.WebSite\Views\_ViewImports.cshtml"
using UsabilityFactoryExamQuiz.WebSite.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4dcf9263e3f5bc524ce5550f2296484e6c2d6914", @"/Views/Home/TaskDescription.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef395c2198e4c3bab0ea1409b6aaee3a3fa288e6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_TaskDescription : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\_Net.TestTask\UsabilityFactoryExamQuiz\UsabilityFactoryExamQuiz.WebSite\Views\Home\TaskDescription.cshtml"
  
    ViewData["Title"] = "REST API";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<style type=""text/css"">
    
    span.cls_002 {
        font-family: Arial,serif;
        font-size: 11.1px;
        color: rgb(0,0,0);
        font-weight: bold;
        font-style: normal;
        text-decoration: none
    }

    div.cls_002 {
        font-family: Arial,serif;
        font-size: 11.1px;
        color: rgb(0,0,0);
        font-weight: bold;
        font-style: normal;
        text-decoration: none
    }

    span.cls_004 {
        font-family: Arial,serif;
        font-size: 11.1px;
        color: rgb(0,0,0);
        font-weight: normal;
        font-style: normal;
        text-decoration: none
    }

    div.cls_004 {
        font-family: Arial,serif;
        font-size: 11.1px;
        color: rgb(0,0,0);
        font-weight: normal;
        font-style: normal;
        text-decoration: none
    }
</style>
    <div style=""position:absolute;left:50%;margin-left:-298px;top:0px;width:596px;height:843px;overflow:hidden"">
        <div style=""position:abso");
            WriteLiteral(@"lute;left:72.06px;top:70.81px"" class=""cls_002""><span class=""cls_002"">Задание.</span></div>
        <div style=""position:absolute;left:72.06px;top:85.83px"" class=""cls_002""><span class=""cls_002"">Предметная область</span><span class=""cls_004"">.</span></div>
        <div style=""position:absolute;left:72.06px;top:100.09px"" class=""cls_004""><span class=""cls_004"">Респондент проходит анкетирование, отвечая последовательно на ряд вопросов. При</span></div>
        <div style=""position:absolute;left:72.06px;top:115.10px"" class=""cls_004""><span class=""cls_004"">каждом ответе клиент (фронт) отправляет на сервер ответ респондента на текущий</span></div>
        <div style=""position:absolute;left:72.06px;top:129.36px"" class=""cls_004""><span class=""cls_004"">вопрос. Некоторые вопросы требуют приложить к ответу файлы (например, скриншот</span></div>
        <div style=""position:absolute;left:72.06px;top:143.63px"" class=""cls_004""><span class=""cls_004"">или ещё что-то). Приложенные файлы сохраняются вызовом отдельного метода.</");
            WriteLiteral(@"span></div>
        <div style=""position:absolute;left:72.06px;top:158.64px"" class=""cls_004""><span class=""cls_004"">В процессе тестирования логика собирает информацию о действиях пользователя в</span></div>
        <div style=""position:absolute;left:72.06px;top:172.90px"" class=""cls_004""><span class=""cls_004"">виде событий. Данные события сохраняются вызовом отдельного метода (до 1000</span></div>
        <div style=""position:absolute;left:72.06px;top:187.91px"" class=""cls_004""><span class=""cls_004"">событий за раз ).</span></div>
        <div style=""position:absolute;left:72.06px;top:216.44px"" class=""cls_004""><span class=""cls_004"">Нужно разработать два REST API метода.</span></div>
        <div style=""position:absolute;left:72.06px;top:231.45px"" class=""cls_002""><span class=""cls_002"">1. POST answers/&lt;answerId>/attachments/</span></div>
        <div style=""position:absolute;left:72.06px;top:245.71px"" class=""cls_004""><span class=""cls_004"">Метод принимает на вход:</span></div>
        <div style=""position:a");
            WriteLiteral(@"bsolute;left:72.06px;top:260.72px"" class=""cls_004""><span class=""cls_004"">answerId - Guid, определяет к какому ответу относятся приложения.</span></div>
        <div style=""position:absolute;left:72.06px;top:274.99px"" class=""cls_004""><span class=""cls_004"">Файлы - IEnumerable&lt;HttpPostedFileBase>, массив приложенных к ответу файлов в</span></div>
        <div style=""position:absolute;left:72.06px;top:289.25px"" class=""cls_004""><span class=""cls_004"">теле запроса.</span></div>
        <div style=""position:absolute;left:72.06px;top:318.52px"" class=""cls_004""><span class=""cls_004"">Метод сохраняет файлы в виде блобов в хранилище Azure Storage в контейнере</span></div>
        <div style=""position:absolute;left:72.06px;top:333.53px"" class=""cls_004""><span class=""cls_004"">attachments и делает соответствующие записи в SQL базе в таблице</span></div>
        <div style=""position:absolute;left:72.06px;top:347.80px"" class=""cls_004""><span class=""cls_004"">AnswerAttachments</span></div>
        <div style=""position:abso");
            WriteLiteral(@"lute;left:72.06px;top:377.07px"" class=""cls_002""><span class=""cls_002"">2. POST answers/&lt;answerId>/events/</span></div>
        <div style=""position:absolute;left:72.06px;top:391.33px"" class=""cls_004""><span class=""cls_004"">Метод принимает на вход:</span></div>
        <div style=""position:absolute;left:72.06px;top:405.60px"" class=""cls_004""><span class=""cls_004"">answerId - Guid, определяет к какому ответу относятся приложения.</span></div>
        <div style=""position:absolute;left:72.06px;top:420.61px"" class=""cls_004""><span class=""cls_004"">События - AnswerEvent[], массив событий передаётся в теле запроса в виде строки</span></div>
        <div style=""position:absolute;left:72.06px;top:434.87px"" class=""cls_004""><span class=""cls_004"">JSON</span></div>
        <div style=""position:absolute;left:72.06px;top:464.14px"" class=""cls_004""><span class=""cls_004"">Метод сохраняет события в SQL базе в таблице AnswerEvents.</span></div>
        <div style=""position:absolute;left:72.06px;top:493.42px"" class=""cls_002""><");
            WriteLiteral(@"span class=""cls_002"">Модель.</span></div>
        <div style=""position:absolute;left:72.06px;top:507.68px"" class=""cls_004""><span class=""cls_004"">Модель для базы</span></div>
        <div style=""position:absolute;left:72.06px;top:522.69px"" class=""cls_004""><span class=""cls_004"">public class AnswerAttachment</span></div>
        <div style=""position:absolute;left:84.29px;top:536.96px"" class=""cls_004""><span class=""cls_004"">{</span></div>
        <div style=""position:absolute;left:96.51px;top:551.22px"" class=""cls_004""><span class=""cls_004"">public Guid Id {get; set;}</span></div>
        <div style=""position:absolute;left:96.51px;top:566.23px"" class=""cls_004""><span class=""cls_004"">public Guid AnswerId { get; set; }</span></div>
        <div style=""position:absolute;left:96.51px;top:580.49px"" class=""cls_004""><span class=""cls_004"">public DateTime Created { get; set; }</span></div>
        <div style=""position:absolute;left:96.51px;top:595.50px"" class=""cls_004""><span class=""cls_004"">public String FileName { get");
            WriteLiteral(@"; set; }</span></div>
        <div style=""position:absolute;left:96.51px;top:609.77px"" class=""cls_004""><span class=""cls_004"">public String MimeType { get; set; }</span></div>
        <div style=""position:absolute;left:96.51px;top:624.03px"" class=""cls_004""><span class=""cls_004"">public Int32 Size { get; set; }</span></div>
        <div style=""position:absolute;left:84.29px;top:639.04px"" class=""cls_004""><span class=""cls_004"">}</span></div>
        <div style=""position:absolute;left:72.06px;top:668.32px"" class=""cls_004""><span class=""cls_004"">Модель для входных данных REST метода. </span><span class=""cls_002"">Модель для базы нужно сделать</span></div>
        <div style=""position:absolute;left:72.06px;top:682.58px"" class=""cls_002""><span class=""cls_002"">самостоятельно.</span></div>
        <div style=""position:absolute;left:72.06px;top:696.84px"" class=""cls_004""><span class=""cls_004"">public class AnswerEvent</span></div>
        <div style=""position:absolute;left:84.29px;top:711.85px"" class=""cls_004""><span cl");
            WriteLiteral(@"ass=""cls_004"">{</span></div>
        <div style=""position:absolute;left:96.51px;top:726.11px"" class=""cls_004""><span class=""cls_004"">String Value { get; set;}</span></div>
        <div style=""position:absolute;left:96.51px;top:741.13px"" class=""cls_004""><span class=""cls_004"">AnswerEventTypeEnum Type { get; set; }</span></div>
        <div style=""position:absolute;left:96.51px;top:755.39px"" class=""cls_004""><span class=""cls_004"">DateTime ClientTime { get; set; }</span></div>
    </div>
    <div style=""position: absolute; left: 50%; margin-left: -298px; top: 853px; width: 596px; height: 843px; overflow: hidden"">
        <!--<div style=""position:absolute;left:84.29px;top:70.81px"" class=""cls_004""><span class=""cls_004"">}</span></div>
        -->
        <div style=""position:absolute;left:72.06px;top:100.09px"" class=""cls_004""><span class=""cls_004"">public enum AnswerEventTypeEnum</span></div>
        <div style=""position:absolute;left:84.29px;top:115.10px"" class=""cls_004""><span class=""cls_004"">{</span></div>
");
            WriteLiteral(@"        <div style=""position:absolute;left:96.51px;top:129.36px"" class=""cls_004""><span class=""cls_004"">Click,</span></div>
        <div style=""position:absolute;left:96.51px;top:143.63px"" class=""cls_004""><span class=""cls_004"">Move,</span></div>
        <div style=""position:absolute;left:96.51px;top:158.64px"" class=""cls_004""><span class=""cls_004"">Drag,</span></div>
        <div style=""position:absolute;left:96.51px;top:172.90px"" class=""cls_004""><span class=""cls_004"">Press,</span></div>
        <div style=""position:absolute;left:96.51px;top:187.91px"" class=""cls_004""><span class=""cls_004"">Other</span></div>
        <div style=""position:absolute;left:84.29px;top:202.17px"" class=""cls_004""><span class=""cls_004"">}</span></div>
        <div style=""position:absolute;left:72.06px;top:231.45px"" class=""cls_002""><span class=""cls_002"">Дополнительно.</span></div>
        <div style=""position:absolute;left:72.06px;top:245.71px"" class=""cls_004""><span class=""cls_004"">Код на C#.</span></div>
        <div style=""position");
            WriteLiteral(@":absolute;left:72.06px;top:260.72px"" class=""cls_004""><span class=""cls_004"">Проект ASP.Net 4.7 или ASP.Net Core</span></div>
        <div style=""position:absolute;left:72.06px;top:274.99px"" class=""cls_004""><span class=""cls_004"">Работу с базой сделать через EntityFramework.</span></div>
        <div style=""position:absolute;left:72.06px;top:289.25px"" class=""cls_004""><span class=""cls_004"">Фронт часть не важна.</span></div>
        <div style=""position:absolute;left:72.06px;top:304.26px"" class=""cls_004""><span class=""cls_004"">Постараться сделать с использованием принципов DI и SOLID.</span></div>
        <div style=""position:absolute;left:72.06px;top:318.52px"" class=""cls_004""><span class=""cls_004"">Качество важнее чем скорость.</span></div>
        <div style=""position:absolute;left:72.06px;top:333.53px"" class=""cls_004""><span class=""cls_004"">Для работы с Azure Storage использовать эмулятор.</span></div>
        <div style=""position:absolute;left:72.06px;top:347.80px"" class=""cls_004""><span class=""cls_004"">Для ");
            WriteLiteral(@"работы с базой MS SQL Express.</span></div>
        <div style=""position:absolute;left:72.06px;top:377.07px"" class=""cls_002""><span class=""cls_002"">В качестве решения предоставить:</span></div>
        <div style=""position:absolute;left:90.08px;top:391.33px"" class=""cls_004""><span class=""cls_004"">1.  Исходный код приложения.</span></div>
        <div style=""position:absolute;left:90.08px;top:405.60px"" class=""cls_004""><span class=""cls_004"">2.  Экспорт схемы SQL базы.</span></div>
    </div>
");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
