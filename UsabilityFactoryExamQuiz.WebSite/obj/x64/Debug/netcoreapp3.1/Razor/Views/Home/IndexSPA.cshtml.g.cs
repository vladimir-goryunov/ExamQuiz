#pragma checksum "D:\Business\_~ПОИСК РАБОТЫ~_\_Собеседования\Фабрика Юзабилити - Обнинск (Тестовое C#.NET)\Source Code\git\ExamQuiz\UsabilityFactoryExamQuiz.WebSite\Views\Home\IndexSPA.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4585967cfa65f9b0de71cfdce00853e63609a0be"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_IndexSPA), @"mvc.1.0.view", @"/Views/Home/IndexSPA.cshtml")]
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
#line 1 "D:\Business\_~ПОИСК РАБОТЫ~_\_Собеседования\Фабрика Юзабилити - Обнинск (Тестовое C#.NET)\Source Code\git\ExamQuiz\UsabilityFactoryExamQuiz.WebSite\Views\_ViewImports.cshtml"
using UsabilityFactoryExamQuiz.WebSite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Business\_~ПОИСК РАБОТЫ~_\_Собеседования\Фабрика Юзабилити - Обнинск (Тестовое C#.NET)\Source Code\git\ExamQuiz\UsabilityFactoryExamQuiz.WebSite\Views\_ViewImports.cshtml"
using UsabilityFactoryExamQuiz.WebSite.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4585967cfa65f9b0de71cfdce00853e63609a0be", @"/Views/Home/IndexSPA.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef395c2198e4c3bab0ea1409b6aaee3a3fa288e6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_IndexSPA : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "{{answer.id}}", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("ng-repeat", new global::Microsoft.AspNetCore.Html.HtmlString("answer in response.answers"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Business\_~ПОИСК РАБОТЫ~_\_Собеседования\Фабрика Юзабилити - Обнинск (Тестовое C#.NET)\Source Code\git\ExamQuiz\UsabilityFactoryExamQuiz.WebSite\Views\Home\IndexSPA.cshtml"
  
    ViewData["Title"] = "REST API";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-left"">
    <h1>REST API</h1>
    <div ng-show=""isObjectEmpty(response.answers)"">
        <button ng-click=""init()"">Загрузить ответы</button>
    </div>
    <div ng-show=""!isObjectEmpty(response.answers)"" style=""display:none;"">
        <div>
            <label for=""answers"">Выбранный ответ:</label>
            <select id=""answers"" name=""answers"" ng-model=""answer.selected"" ng-change=""answerSelected()"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4585967cfa65f9b0de71cfdce00853e63609a0be4836", async() => {
                WriteLiteral("{{answer.id}}&nbsp;&nbsp;&nbsp;{{answer.text}}");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </select>
        </div>
    </div>

    <div ng-show=""!isObjectEmpty(response.answers)"" style=""display:none;"">
        <h2>События&nbsp;&nbsp;&nbsp;<button ng-show=""answer.selected != ''"" ng-click=""saveEvents()"" style=""cursor:pointer;font-weight:bold;font-size:medium;"">Сохранить</button></h2>
        <div ng-show=""answer.selected == ''"">
            Пожалуйста, выберите ответ для создания тестового набора событий...
        </div>
        <div ng-show=""answer.selected != ''"">
            <table style=""background-color:floralwhite;border:2px solid;border-color:gainsboro;"" cellpadding=""5"" cellspacing=""5"">
                <tr>
                    <th>ID</th>
                    <th>Type</th>
                    <th>Value</th>
                    <th>Client Time</th>
                </tr>
                <tr ng-repeat=""event in answer.events"">
                    <td style=""color: blue"">{{event.id}}</td>
                    <td style=""color: blue"">{{event.type}}</td>
           ");
            WriteLiteral(@"         <td style=""color: blue"">{{event.value}}</td>
                    <td style=""color: blue"">{{event.clientTime}}</td>
                </tr>
            </table>
        </div>
        <h2>Файлы вложений</h2>
        <div>
            <span ng-click=""saveAttachments()"" style=""cursor:pointer;"">Сохранить файлы вложений</span>
        </div>
    </div>
</div>

<script>
    /*
    var init = function () {
        $.post(""answers/"", function (data) {
            alert(data.data);
        });
    }
    */

    var app = angular.module(""QuestionaireManagement"", []);

    app.controller(""QuestionaireController"", function ($scope, $http) {

        $scope.response = {
            title: """",
            text: """",
            answers: []
        };

        $scope.init = function () {
            $http({
                method: 'POST',
                url: 'answers/'
            }).then(
                function (res) { // success
                    var response = res.data;
  ");
            WriteLiteral(@"                  $scope.response.title = response.title;
                    $scope.response.text = response.text;
                    $scope.response.answers = response.data;
                },
                function (res) { // error
                    alert(""Error: "" + res.status + "" : "" + res.data);
                }
            );
        }

        $scope.saveEvents = function () {

            var eventsJSON = JSON.stringify($scope.answer.events);

            $http({
                method: 'POST',
                type: 'application/json',
                contentType: 'application/json',
                url: 'answers/' + $(""#answers"").val() + '/events',
                data: { AnswerId: $(""#answers"").val(), AnswerEventJSON: eventsJSON }
            }).then(
                function (res) { // success
                    $scope.response = res.data;
                    alert($scope.response.data);
                },
                function (res) { // error
                 ");
            WriteLiteral(@"   console.log(""Error: "" + res.status + "" : "" + res.data);
                    alert(""Error: "" + res.status + "" : "" + res.data);
                }
            );

            /*
            // Рабочий вариант
            $http({
                method: 'POST',
                type: 'application/json',
                contentType: 'application/json',
                url: 'answers/' + $(""#answers"").val() + '/events',
                data: { AnswerId:'72C02B2A-5814-40FF-9075-B3E8C3CA5D59', AnswerEventJSON:'Value=500' }
            }).then(
                function (res) { // success
                    $scope.response = res.data;
                    alert($scope.response.data);
                },
                function (res) { // error
                    console.log(""Error: "" + res.status + "" : "" + res.data);
                    alert(""Error: "" + res.status + "" : "" + res.data);
                }
            );
            */
        }


        $scope.answer = {
            selecte");
            WriteLiteral(@"d: '',
            events: []
        };

        $scope.answerSelected = function () {

            $http({
                method: 'POST',
                type: 'application/json',
                contentType: 'application/json',
                url: 'answers/' + $(""#answers"").val() + '/randomevents',
                data: { answerId: $(""#answers"").val() }
            }).then(
                function (res) { // success
                    $scope.answer.events = res.data;
                },
                function (res) { // error
                    alert(""Error: "" + res.status + "" : "" + res.data);
                }
            );
        }

        $scope.isObjectEmpty = function (entry) {
            return Object.keys(entry).length === 0;
        }

    });
</script>
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
