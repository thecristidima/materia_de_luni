#pragma checksum "/Users/cristidima/Documents/GitHub/Random/Politehnica/Master/DAI/Crossref/Views/Profile/Articles.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f2e3cd227970c3bf9c624c7a8ff11571e9e8ff36"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profile_Articles), @"mvc.1.0.view", @"/Views/Profile/Articles.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Profile/Articles.cshtml", typeof(AspNetCore.Views_Profile_Articles))]
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
#line 1 "/Users/cristidima/Documents/GitHub/Random/Politehnica/Master/DAI/Crossref/Views/_ViewImports.cshtml"
using CrossRef;

#line default
#line hidden
#line 2 "/Users/cristidima/Documents/GitHub/Random/Politehnica/Master/DAI/Crossref/Views/_ViewImports.cshtml"
using CrossRef.Models;

#line default
#line hidden
#line 1 "/Users/cristidima/Documents/GitHub/Random/Politehnica/Master/DAI/Crossref/Views/Profile/Articles.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f2e3cd227970c3bf9c624c7a8ff11571e9e8ff36", @"/Views/Profile/Articles.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf6c8f1ad4f4335977c08d213370b33fff65b47c", @"/Views/_ViewImports.cshtml")]
    public class Views_Profile_Articles : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CrossRef.Models.ViewModels.ArticlesViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Profile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "FetchArticles", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "/Users/cristidima/Documents/GitHub/Random/Politehnica/Master/DAI/Crossref/Views/Profile/Articles.cshtml"
  
    var data = "";
    if (Model != null && Model.Articles != null && Model.Articles.Count > 0)
    {
        var years = Model.Articles.Select(a => a.YearOfPublication).Distinct().ToList();
        years.Sort();

        data = JsonConvert.SerializeObject(years.Select(year =>
            new[] {year, Model.Articles.Count(article => article.YearOfPublication == year)}));
    }

#line default
#line hidden
            BeginContext(460, 224, true);
            WriteLiteral("\n<div class=\"article-list-container\">\n    <div class=\"article-chart-container\">\n        <div id=\"article-chart\" class=\"article-chart\"></div>\n    </div>\n    <div class=\"article-count-container\">\n        <i>You currently have ");
            EndContext();
            BeginContext(685, 20, false);
#line 20 "/Users/cristidima/Documents/GitHub/Random/Politehnica/Master/DAI/Crossref/Views/Profile/Articles.cshtml"
                         Write(Model.Articles.Count);

#line default
#line hidden
            EndContext();
            BeginContext(705, 34, true);
            WriteLiteral(" articles registered.</i>\n        ");
            EndContext();
            BeginContext(739, 170, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f2e3cd227970c3bf9c624c7a8ff11571e9e8ff365629", async() => {
                BeginContext(811, 91, true);
                WriteLiteral("\n            <button class=\"btn btn-primary\" type=\"submit\">Fetch articles</button>\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(909, 12, true);
            WriteLiteral("\n    </div>\n");
            EndContext();
#line 25 "/Users/cristidima/Documents/GitHub/Random/Politehnica/Master/DAI/Crossref/Views/Profile/Articles.cshtml"
     if (Model.Articles.Count > 0)
    {

#line default
#line hidden
            BeginContext(962, 383, true);
            WriteLiteral(@"        <div class=""article-table-container"">
            <table id=""article-table"" class=""table table-striped table-bordered table-sm"" cellspacing=""0"" width=""100%"">
                <thead>
                <th class=""th-sm"">Title</th>
                <th class=""th-sm"">Publication year</th>
                <th class=""th-sm"">DOI</th>
                </thead>
                <tbody>
");
            EndContext();
#line 35 "/Users/cristidima/Documents/GitHub/Random/Politehnica/Master/DAI/Crossref/Views/Profile/Articles.cshtml"
                     foreach (var article in Model.Articles)
                    {

#line default
#line hidden
            BeginContext(1428, 61, true);
            WriteLiteral("                        <tr>\n                            <td>");
            EndContext();
            BeginContext(1490, 13, false);
#line 38 "/Users/cristidima/Documents/GitHub/Random/Politehnica/Master/DAI/Crossref/Views/Profile/Articles.cshtml"
                           Write(article.Title);

#line default
#line hidden
            EndContext();
            BeginContext(1503, 38, true);
            WriteLiteral("</td>\n                            <td>");
            EndContext();
            BeginContext(1542, 25, false);
#line 39 "/Users/cristidima/Documents/GitHub/Random/Politehnica/Master/DAI/Crossref/Views/Profile/Articles.cshtml"
                           Write(article.YearOfPublication);

#line default
#line hidden
            EndContext();
            BeginContext(1567, 73, true);
            WriteLiteral("</td>\n                            <td>\n                                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1640, "\"", 1679, 2);
            WriteAttributeValue("", 1647, "https://www.doi.org/", 1647, 20, true);
#line 41 "/Users/cristidima/Documents/GitHub/Random/Politehnica/Master/DAI/Crossref/Views/Profile/Articles.cshtml"
WriteAttributeValue("", 1667, article.DOI, 1667, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1680, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1682, 11, false);
#line 41 "/Users/cristidima/Documents/GitHub/Random/Politehnica/Master/DAI/Crossref/Views/Profile/Articles.cshtml"
                                                                      Write(article.DOI);

#line default
#line hidden
            EndContext();
            BeginContext(1693, 69, true);
            WriteLiteral("</a>\n                            </td>\n                        </tr>\n");
            EndContext();
#line 44 "/Users/cristidima/Documents/GitHub/Random/Politehnica/Master/DAI/Crossref/Views/Profile/Articles.cshtml"
                    }

#line default
#line hidden
            BeginContext(1784, 65, true);
            WriteLiteral("                </tbody>\n            </table>\n        </div>    \n");
            EndContext();
#line 48 "/Users/cristidima/Documents/GitHub/Random/Politehnica/Master/DAI/Crossref/Views/Profile/Articles.cshtml"
    }

#line default
#line hidden
            BeginContext(1855, 13, true);
            WriteLiteral("    \n</div>\n\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(1886, 163, true);
                WriteLiteral("\n\n    <script>\n        google.charts.load(\"current\", { \"packages\": [\"bar\"] });\n        google.charts.setOnLoadCallback(function() {\n            \n            if (!(");
                EndContext();
                BeginContext(2050, 4, false);
#line 58 "/Users/cristidima/Documents/GitHub/Random/Politehnica/Master/DAI/Crossref/Views/Profile/Articles.cshtml"
             Write(data);

#line default
#line hidden
                EndContext();
                BeginContext(2054, 47, true);
                WriteLiteral(").length) return;\n\n\n            var dataArr = (");
                EndContext();
                BeginContext(2102, 4, false);
#line 61 "/Users/cristidima/Documents/GitHub/Random/Politehnica/Master/DAI/Crossref/Views/Profile/Articles.cshtml"
                      Write(data);

#line default
#line hidden
                EndContext();
                BeginContext(2106, 1166, true);
                WriteLiteral(@").map(data => [data[0].toString(), data[1]]);
            var arr = [[""Year"", ""Published Articles""]].concat(dataArr);
            
           var data = new google.visualization.arrayToDataTable(arr);

           var options = {
               title: ""Published articles per year"",
               width: document.getElementById(""article-chart"").offsetWidth,
               legend: {
                   position: ""none""
               },
               chart: {
                   title: ""Published articles per year""
               },
               bars: ""vertical"",
               axes: {
                   x: {
                       0: {
                           side: ""bottom"",
                           label: ""# of articles""
                       }
                   }
               },
               bar: {
                   groupWidth: ""90%""
               }
           };

           var chart = new google.charts.Bar(document.getElementById(""article-chart""));
           chart.draw(data, options);
       ");
                WriteLiteral(" });\n    </script>\n    <script>\n        $(\"#article-table\").DataTable();\n        $(\".dataTables_length\").addClass(\"bs-select\");\n    </script>\n");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CrossRef.Models.ViewModels.ArticlesViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
