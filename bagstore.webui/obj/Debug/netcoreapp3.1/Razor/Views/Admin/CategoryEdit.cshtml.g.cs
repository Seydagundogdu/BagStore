#pragma checksum "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e0542caf1236988b026ff72777490cbd56e82438"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_CategoryEdit), @"mvc.1.0.view", @"/Views/Admin/CategoryEdit.cshtml")]
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
#line 6 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\_ViewImports.cshtml"
using bagstore.webui.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\_ViewImports.cshtml"
using bagstore.entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\_ViewImports.cshtml"
using bagstore.webui.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0542caf1236988b026ff72777490cbd56e82438", @"/Views/Admin/CategoryEdit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dfa161aef454dc85e24b4b2bb611d73cdc317079", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_CategoryEdit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CategoryModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-sm-2 col-form-label"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CategoryEdit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/admin/deletefromcategory"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display: inline;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1 class=\"h3\">Edit category...</h1>\r\n<hr>\r\n<div class=\"row\">\r\n    <div class=\"col-md-4\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e0542caf1236988b026ff72777490cbd56e824387068", async() => {
                WriteLiteral("\r\n            <input type=\"hidden\"name=\"CategoryId\"");
                BeginWriteAttribute("value", " value=\"", 243, "\"", 268, 1);
#nullable restore
#line 8 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
WriteAttributeValue("", 251, Model.CategoryId, 251, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n            <div class=\"form-group row\">\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e0542caf1236988b026ff72777490cbd56e824387826", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 10 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Name);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            <div class=\"col-sm-10\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e0542caf1236988b026ff72777490cbd56e824389466", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 12 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Name);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e0542caf1236988b026ff72777490cbd56e8243811060", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 13 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Name);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group row\">\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e0542caf1236988b026ff72777490cbd56e8243812808", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 17 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Url);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            <div class=\"col-sm-10\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e0542caf1236988b026ff72777490cbd56e8243814448", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 19 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Url);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e0542caf1236988b026ff72777490cbd56e8243816042", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 20 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Url);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
            </div>
        </div>
        <div class=""form-group row"">
            <div class=""col-sm-10 offset-sm-2"">
                <button type=""submit"" class=""btn btn-primary"">Update</button>
            </div>
        </div>
        <div id=""products"">

            <!-- kategori bilgileri hatalı girildiğinde product bilgilerini sayfa üstünde yedekleme -->
");
#nullable restore
#line 31 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
             for(int i = 0; i < Model.Products.Count; i++)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <input type=\"hidden\"");
                BeginWriteAttribute("name", " name=\"", 1372, "\"", 1401, 3);
                WriteAttributeValue("", 1379, "Products[", 1379, 9, true);
#nullable restore
#line 33 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
WriteAttributeValue("", 1388, i, 1388, 2, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1390, "].ProductId", 1390, 11, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1402, "\"", 1439, 1);
#nullable restore
#line 33 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
WriteAttributeValue("", 1410, Model.Products[@i].ProductId, 1410, 29, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                <input type=\"hidden\"");
                BeginWriteAttribute("name", " name=\"", 1479, "\"", 1507, 3);
                WriteAttributeValue("", 1486, "Products[", 1486, 9, true);
#nullable restore
#line 34 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
WriteAttributeValue("", 1495, i, 1495, 2, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1497, "].ImageUrl", 1497, 10, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1508, "\"", 1544, 1);
#nullable restore
#line 34 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
WriteAttributeValue("", 1516, Model.Products[@i].ImageUrl, 1516, 28, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                <input type=\"hidden\"");
                BeginWriteAttribute("name", " name=\"", 1584, "\"", 1608, 3);
                WriteAttributeValue("", 1591, "Products[", 1591, 9, true);
#nullable restore
#line 35 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
WriteAttributeValue("", 1600, i, 1600, 2, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1602, "].Name", 1602, 6, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1609, "\"", 1641, 1);
#nullable restore
#line 35 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
WriteAttributeValue("", 1617, Model.Products[@i].Name, 1617, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                <input type=\"hidden\"");
                BeginWriteAttribute("name", " name=\"", 1681, "\"", 1706, 3);
                WriteAttributeValue("", 1688, "Products[", 1688, 9, true);
#nullable restore
#line 36 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
WriteAttributeValue("", 1697, i, 1697, 2, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1699, "].Price", 1699, 7, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1707, "\"", 1740, 1);
#nullable restore
#line 36 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
WriteAttributeValue("", 1715, Model.Products[@i].Price, 1715, 25, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                <input type=\"hidden\"");
                BeginWriteAttribute("name", " name=\"", 1780, "\"", 1810, 3);
                WriteAttributeValue("", 1787, "Products[", 1787, 9, true);
#nullable restore
#line 37 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
WriteAttributeValue("", 1796, i, 1796, 2, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1798, "].IsApproved", 1798, 12, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1811, "\"", 1860, 1);
#nullable restore
#line 37 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
WriteAttributeValue("", 1819, Model.Products[@i].IsApproved.ToString(), 1819, 41, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n");
#nullable restore
#line 38 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </div>
    <div class=""col-md-8"">
        <div class=""row"">
            <div class=""col-md-12"">
                <table class=""table table-bordered table-sm"">
                    <thead>
                        <tr>
                            <td style=""width: 30px;"">Id</td>
                            <td style=""width: 100px;"">Image</td>
                            <td>Name</td>
                            <td style=""width: 20px;"">Price</td>
                            <td style=""width: 20px;"">In Stock</td>
                            <td style=""width: 150px;""></td>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 57 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
                         if (Model.Products.Count > 0)
                        {

                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
                             foreach (var item in Model.Products)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 63 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
                                   Write(item.ProductId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td><img");
            BeginWriteAttribute("src", " src=\"", 2916, "\"", 2941, 2);
            WriteAttributeValue("", 2922, "/img/", 2922, 5, true);
#nullable restore
#line 64 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
WriteAttributeValue("", 2927, item.ImageUrl, 2927, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"80\"></td>\r\n                                    <td>");
#nullable restore
#line 65 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
                                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 66 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
                                   Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n");
#nullable restore
#line 68 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
                                         if(item.IsApproved)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <i class=\"fas fa-check-circle\" style=\"color: green; size:3x;\"></i>\r\n");
#nullable restore
#line 71 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <i class=\"fas fa-times-circle\" style=\"color: red; size:3x;\"></i>\r\n");
#nullable restore
#line 75 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n                                    <td>\r\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 3747, "\"", 3785, 2);
            WriteAttributeValue("", 3754, "/admin/products/", 3754, 16, true);
#nullable restore
#line 78 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
WriteAttributeValue("", 3770, item.ProductId, 3770, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-sm mr-2\">Edit</a>\r\n                                        \r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e0542caf1236988b026ff72777490cbd56e8243829448", async() => {
                WriteLiteral("\r\n                                            <input type=\"hidden\" name=\"ProductId\"");
                BeginWriteAttribute("value", " value=\"", 4078, "\"", 4101, 1);
#nullable restore
#line 81 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
WriteAttributeValue("", 4086, item.ProductId, 4086, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                            <input type=\"hidden\" name=\"CategoryId\"");
                BeginWriteAttribute("value", " value=\"", 4187, "\"", 4212, 1);
#nullable restore
#line 82 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
WriteAttributeValue("", 4195, Model.CategoryId, 4195, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                            <button type=\"submit\" class=\"btn btn-danger btn-sm\">Delete</button>\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        \r\n                                        \r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 89 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 89 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
                             
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"alert alert-warning\">\r\n                                <h3>No Product</h3>\r\n                            </div>\r\n");
#nullable restore
#line 96 "C:\Users\acer\Documents\GitHub\BagStore\bagstore.webui\Views\Admin\CategoryEdit.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script src=\"/modules/jquery-validation/dist/jquery.validate.min.js\"></script>\r\n    <script src=\"/modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js\"></script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CategoryModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
