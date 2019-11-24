#pragma checksum "/Users/cristidima/Documents/GitHub/Random/Politehnica/Master/DAI/Crossref/Views/Profile/Permissions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "11ffd741e8f2012f5a21f0d45f1ab596ab42e060"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profile_Permissions), @"mvc.1.0.view", @"/Views/Profile/Permissions.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Profile/Permissions.cshtml", typeof(AspNetCore.Views_Profile_Permissions))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11ffd741e8f2012f5a21f0d45f1ab596ab42e060", @"/Views/Profile/Permissions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf6c8f1ad4f4335977c08d213370b33fff65b47c", @"/Views/_ViewImports.cshtml")]
    public class Views_Profile_Permissions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CrossRef.Models.ViewModels.PermissionsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Profile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Permissions", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(55, 86, true);
            WriteLiteral("\n<h1>Set public profile permissions</h1>\n\n<div class=\"permission-list-container\">\n    ");
            EndContext();
            BeginContext(141, 2631, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "11ffd741e8f2012f5a21f0d45f1ab596ab42e0604415", async() => {
                BeginContext(211, 105, true);
                WriteLiteral("\n\n        <div class=\"permission-entry\">\n            <div class=\"permission-entry-name\">\n                ");
                EndContext();
                BeginContext(317, 188, false);
#line 10 "/Users/cristidima/Documents/GitHub/Random/Politehnica/Master/DAI/Crossref/Views/Profile/Permissions.cshtml"
           Write(Html.CheckBoxFor(m => m.ShowBiography, new
                {
                    id = "biography-checkbox",
                    @class = "permission-entry-name-checkbox"
                }));

#line default
#line hidden
                EndContext();
                BeginContext(505, 434, true);
                WriteLiteral(@"
                <label class=""permission-entry-name-label"" for=""biography-checkbox"">Show biography</label>
            </div>
            <div class=""permission-entry-description"">
                <a>Make your biography public so that other users know what you are working on.</a>
            </div>
        </div>
        <hr/>

        <div class=""permission-entry"">
            <div class=""permission-entry-name"">
                ");
                EndContext();
                BeginContext(940, 192, false);
#line 25 "/Users/cristidima/Documents/GitHub/Random/Politehnica/Master/DAI/Crossref/Views/Profile/Permissions.cshtml"
           Write(Html.CheckBoxFor(m => m.ShowAffiliation, new
                {
                    id = "affiliation-checkbox",
                    @class = "permission-entry-name-checkbox"
                }));

#line default
#line hidden
                EndContext();
                BeginContext(1132, 437, true);
                WriteLiteral(@"
                <label class=""permission-entry-name-label"" for=""affiliation-checkbox"">Show affiliation</label>
            </div>
            <div class=""permission-entry-description"">
                <a>Display your affiliation (company, university) on your public profile page.</a>
            </div>
        </div
        ><hr/>

        <div class=""permission-entry"">
            <div class=""permission-entry-name"">
                ");
                EndContext();
                BeginContext(1570, 184, false);
#line 40 "/Users/cristidima/Documents/GitHub/Random/Politehnica/Master/DAI/Crossref/Views/Profile/Permissions.cshtml"
           Write(Html.CheckBoxFor(m => m.ShowDateOfBirth, new
                {
                    id = "dob-checkbox",
                    @class = "permission-entry-name-checkbox"
                }));

#line default
#line hidden
                EndContext();
                BeginContext(1754, 386, true);
                WriteLiteral(@"
                <label class=""permission-entry-name-label"" for=""dob-checkbox"">Show date of birth</label>
            </div>
            <div class=""permission-entry-description"">
                <a>Make your date of birth public</a>
            </div>
        </div>
        <hr/>

        <div class=""permission-entry"">
            <div class=""permission-entry-name"">
                ");
                EndContext();
                BeginContext(2141, 186, false);
#line 55 "/Users/cristidima/Documents/GitHub/Random/Politehnica/Master/DAI/Crossref/Views/Profile/Permissions.cshtml"
           Write(Html.CheckBoxFor(m => m.ShowArticles, new
                {
                    id = "articles-checkbox",
                    @class = "permission-entry-name-checkbox"
                }));

#line default
#line hidden
                EndContext();
                BeginContext(2327, 438, true);
                WriteLiteral(@"
                <label class=""permission-entry-name-label"" for=""articles-checkbox"">Show article statistics</label>
            </div>
            <div class=""permission-entry-description"">
                <a>Display published articles statistics (# of articles published/year) on your profile page.</a>
            </div>
        </div>

        <button class=""btn btn-primary btn-lg permission-save-btn"" type=""submit"">Save</button>
    ");
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
            BeginContext(2772, 7, true);
            WriteLiteral("\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CrossRef.Models.ViewModels.PermissionsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591