#pragma checksum "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\Customerdata\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c487463dac164cbd6af51712b1bc478f056851d6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customerdata_Details), @"mvc.1.0.view", @"/Views/Customerdata/Details.cshtml")]
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
#line 1 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\_ViewImports.cshtml"
using project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\_ViewImports.cshtml"
using project.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c487463dac164cbd6af51712b1bc478f056851d6", @"/Views/Customerdata/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d6489460591dedbaaa7ef634782f0f12b0f7a4e7", @"/Views/_ViewImports.cshtml")]
    public class Views_Customerdata_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<project.Models.Customer>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/userMain.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\Customerdata\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout_user1.cshtml";

#line default
#line hidden
#nullable disable
            DefineSection("css", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c487463dac164cbd6af51712b1bc478f056851d64986", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("<h4>訂單詳細管理</h4>\r\n\r\n<div>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-6\">\r\n            ");
#nullable restore
#line 16 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\Customerdata\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 19 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\Customerdata\Details.cshtml"
       Write(Html.DisplayFor(model => model.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-6\">\r\n            ");
#nullable restore
#line 22 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\Customerdata\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.RoomType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 25 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\Customerdata\Details.cshtml"
       Write(Html.DisplayFor(model => model.RoomType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-6\">\r\n            ");
#nullable restore
#line 28 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\Customerdata\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.RoomName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 31 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\Customerdata\Details.cshtml"
       Write(Html.DisplayFor(model => model.RoomName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-6\">\r\n            ");
#nullable restore
#line 34 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\Customerdata\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.RoomNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 37 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\Customerdata\Details.cshtml"
       Write(Html.DisplayFor(model => model.RoomNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-6\">\r\n            ");
#nullable restore
#line 40 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\Customerdata\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CustomerName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 43 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\Customerdata\Details.cshtml"
       Write(Html.DisplayFor(model => model.CustomerName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-6\">\r\n            ");
#nullable restore
#line 46 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\Customerdata\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CustomerPhone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 49 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\Customerdata\Details.cshtml"
       Write(Html.DisplayFor(model => model.CustomerPhone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-6\">\r\n            ");
#nullable restore
#line 52 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\Customerdata\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CustomerEmail));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 55 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\Customerdata\Details.cshtml"
       Write(Html.DisplayFor(model => model.CustomerEmail));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-6\">\r\n            ");
#nullable restore
#line 58 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\Customerdata\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ArrivalDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 61 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\Customerdata\Details.cshtml"
       Write(Html.DisplayFor(model => model.ArrivalDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-6\">\r\n            ");
#nullable restore
#line 64 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\Customerdata\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.EstimatedArrvialTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 67 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\Customerdata\Details.cshtml"
       Write(Html.DisplayFor(model => model.EstimatedArrvialTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-6\">\r\n            ");
#nullable restore
#line 70 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\Customerdata\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DepartureDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 73 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\Customerdata\Details.cshtml"
       Write(Html.DisplayFor(model => model.DepartureDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-6\">\r\n            ");
#nullable restore
#line 76 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\Customerdata\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Nights));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 79 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\Customerdata\Details.cshtml"
       Write(Html.DisplayFor(model => model.Nights));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c487463dac164cbd6af51712b1bc478f056851d613841", async() => {
                WriteLiteral("編輯");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 84 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\Customerdata\Details.cshtml"
                           WriteLiteral(Model.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 84 "C:\Users\loveu\OneDrive\桌面\0527-3project\0527-new 應該最後一版了 project\Views\Customerdata\Details.cshtml"
                                                            WriteLiteral(Model.RoomNumber);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["roomnumber"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-roomnumber", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["roomnumber"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c487463dac164cbd6af51712b1bc478f056851d616773", async() => {
                WriteLiteral("返回");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n<br />");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<project.Models.Customer> Html { get; private set; }
    }
}
#pragma warning restore 1591
