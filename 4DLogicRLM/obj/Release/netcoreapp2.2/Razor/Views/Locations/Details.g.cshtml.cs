#pragma checksum "C:\Users\U257\source\repos\4DLogicRLM\4DLogicRLM\Views\Locations\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6d4e51ed680b0cc376c79c30c2a6c145c12bb943"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Locations_Details), @"mvc.1.0.view", @"/Views/Locations/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Locations/Details.cshtml", typeof(AspNetCore.Views_Locations_Details))]
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
#line 1 "C:\Users\U257\source\repos\4DLogicRLM\4DLogicRLM\Views\_ViewImports.cshtml"
using _4DLogicRLM;

#line default
#line hidden
#line 2 "C:\Users\U257\source\repos\4DLogicRLM\4DLogicRLM\Views\_ViewImports.cshtml"
using _4DLogicRLM.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d4e51ed680b0cc376c79c30c2a6c145c12bb943", @"/Views/Locations/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47c1690e17d491f00cf0cee6a44eefc6f2fae30e", @"/Views/_ViewImports.cshtml")]
    public class Views_Locations_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<_4DLogicRLM.Models.Locations>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(37, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\U257\source\repos\4DLogicRLM\4DLogicRLM\Views\Locations\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(82, 123, true);
            WriteLiteral("\r\n<h2>Details</h2>\r\n\r\n<div>\r\n    <h4>Locations</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(206, 48, false);
#line 14 "C:\Users\U257\source\repos\4DLogicRLM\4DLogicRLM\Views\Locations\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LocationName));

#line default
#line hidden
            EndContext();
            BeginContext(254, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(298, 44, false);
#line 17 "C:\Users\U257\source\repos\4DLogicRLM\4DLogicRLM\Views\Locations\Details.cshtml"
       Write(Html.DisplayFor(model => model.LocationName));

#line default
#line hidden
            EndContext();
            BeginContext(342, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(386, 48, false);
#line 20 "C:\Users\U257\source\repos\4DLogicRLM\4DLogicRLM\Views\Locations\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LocationType));

#line default
#line hidden
            EndContext();
            BeginContext(434, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(478, 44, false);
#line 23 "C:\Users\U257\source\repos\4DLogicRLM\4DLogicRLM\Views\Locations\Details.cshtml"
       Write(Html.DisplayFor(model => model.LocationType));

#line default
#line hidden
            EndContext();
            BeginContext(522, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(566, 44, false);
#line 26 "C:\Users\U257\source\repos\4DLogicRLM\4DLogicRLM\Views\Locations\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Location));

#line default
#line hidden
            EndContext();
            BeginContext(610, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(654, 40, false);
#line 29 "C:\Users\U257\source\repos\4DLogicRLM\4DLogicRLM\Views\Locations\Details.cshtml"
       Write(Html.DisplayFor(model => model.Location));

#line default
#line hidden
            EndContext();
            BeginContext(694, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(738, 42, false);
#line 32 "C:\Users\U257\source\repos\4DLogicRLM\4DLogicRLM\Views\Locations\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LatLon));

#line default
#line hidden
            EndContext();
            BeginContext(780, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(824, 38, false);
#line 35 "C:\Users\U257\source\repos\4DLogicRLM\4DLogicRLM\Views\Locations\Details.cshtml"
       Write(Html.DisplayFor(model => model.LatLon));

#line default
#line hidden
            EndContext();
            BeginContext(862, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(906, 46, false);
#line 38 "C:\Users\U257\source\repos\4DLogicRLM\4DLogicRLM\Views\Locations\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ProvinceID));

#line default
#line hidden
            EndContext();
            BeginContext(952, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(996, 42, false);
#line 41 "C:\Users\U257\source\repos\4DLogicRLM\4DLogicRLM\Views\Locations\Details.cshtml"
       Write(Html.DisplayFor(model => model.ProvinceID));

#line default
#line hidden
            EndContext();
            BeginContext(1038, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1082, 45, false);
#line 44 "C:\Users\U257\source\repos\4DLogicRLM\4DLogicRLM\Views\Locations\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CountryID));

#line default
#line hidden
            EndContext();
            BeginContext(1127, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1171, 41, false);
#line 47 "C:\Users\U257\source\repos\4DLogicRLM\4DLogicRLM\Views\Locations\Details.cshtml"
       Write(Html.DisplayFor(model => model.CountryID));

#line default
#line hidden
            EndContext();
            BeginContext(1212, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1256, 51, false);
#line 50 "C:\Users\U257\source\repos\4DLogicRLM\4DLogicRLM\Views\Locations\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ConvertedLatLon));

#line default
#line hidden
            EndContext();
            BeginContext(1307, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1351, 47, false);
#line 53 "C:\Users\U257\source\repos\4DLogicRLM\4DLogicRLM\Views\Locations\Details.cshtml"
       Write(Html.DisplayFor(model => model.ConvertedLatLon));

#line default
#line hidden
            EndContext();
            BeginContext(1398, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1445, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6d4e51ed680b0cc376c79c30c2a6c145c12bb9439890", async() => {
                BeginContext(1499, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 58 "C:\Users\U257\source\repos\4DLogicRLM\4DLogicRLM\Views\Locations\Details.cshtml"
                           WriteLiteral(Model.LocationID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1507, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1515, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6d4e51ed680b0cc376c79c30c2a6c145c12bb94312219", async() => {
                BeginContext(1537, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1553, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<_4DLogicRLM.Models.Locations> Html { get; private set; }
    }
}
#pragma warning restore 1591
