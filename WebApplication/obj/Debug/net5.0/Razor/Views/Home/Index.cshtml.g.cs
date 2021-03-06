#pragma checksum "C:\Users\iryna\source\repos\WebApplication\WebApplication\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8514d6c7b90a498b5c57fdcf3c1e3bff3a7dd30c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\iryna\source\repos\WebApplication\WebApplication\Views\_ViewImports.cshtml"
using WebApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\iryna\source\repos\WebApplication\WebApplication\Views\_ViewImports.cshtml"
using WebApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8514d6c7b90a498b5c57fdcf3c1e3bff3a7dd30c", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa0ef8da47a84ffb33e8bc853509aa4fa5703a26", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<UserModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\iryna\source\repos\WebApplication\WebApplication\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    if (User.IsInRole(WebApplication.Data.Constants.Admin))
        Layout = "_Admin";
    else
        Layout = "_User";

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\iryna\source\repos\WebApplication\WebApplication\Views\Home\Index.cshtml"
 if (User.IsInRole(WebApplication.Data.Constants.User))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"jumbotron\">\r\n        <p>??????????:</p>\r\n        <input id=\"City\" type=\"text\" />\r\n        <button id=\"Submit\">Get Weather Forecast</button>\r\n    </div>\r\n");
            WriteLiteral(@"    <div class=""row"">
        <div class=""col-md-12"">
            <table>
                <tr>
                    <td>max t:</td>
                    <td><p id=""max_temp""></p></td>
                </tr>
                <tr>
                    <td>t:</td>
                    <td><p id=""temp""></p></td>
                </tr>
                <tr>
                    <td>min t:</td>
                    <td><p id=""min_temp""></p></td>
                </tr>
                <tr>
                    <td>??????????????????:</td>
                    <td><p id=""humid""></p></td>
                </tr>
                <tr>
                    <td>????????:</td>
                    <td><p id=""pres""></p></td>
                </tr>
                <tr>
                    <td>????. ??????????:</td>
                    <td><p id=""sp_wind""></p></td>
                </tr>
            </table>
        </div>
    </div>
");
            WriteLiteral(@"    <script type=""text/javascript"">
        var but = document.getElementById(""Submit"");
        var i = 0;
        but.addEventListener(""click"", event => {
            var city = document.getElementById(""City"").value;

            console.log(city);
            if (city.length > 0) {
                $.ajax({
                    url: ""https://localhost:5001/Home/Weather?City="" + city,
                    type: ""GET"",
                    success: function (rsltval) {
                        var data = rsltval;
                        console.log(data);
                        $(""#humid"").text(data.humidity);
                        $(""#temp"").text(data.temp);
                        $(""#max_temp"").text(data.tempMax);
                        $(""#min_temp"").text(data.tempMin);
                        $(""#sp_wind"").text(data.windSpeed);
                        $(""#pres"").text(data.pressure);

                    },
                    error: function () {
                        alert(""some");
            WriteLiteral("thing happened\");\r\n                    }\r\n                });\r\n\r\n            }\r\n            else {\r\n                alert(\"not found\");\r\n            }\r\n        });\r\n    </script>\r\n");
#nullable restore
#line 80 "C:\Users\iryna\source\repos\WebApplication\WebApplication\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 81 "C:\Users\iryna\source\repos\WebApplication\WebApplication\Views\Home\Index.cshtml"
 if (User.IsInRole(WebApplication.Data.Constants.Admin))
{
    

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"jumbotron\">\r\n        ");
#nullable restore
#line 85 "C:\Users\iryna\source\repos\WebApplication\WebApplication\Views\Home\Index.cshtml"
   Write(Html.ActionLink("????????????????","Create", "Users", new { }, new {@class="float-right"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        <p >?????????? ???? email:</p>
        <input id=""Email"" type=""text"" />
        <button id=""Submit"">??????????</button>
    </div>
    <div class=""row"">
        <div class=""col-md-12"">
            <table class=""col-12"">
                <thead>
                    <tr>
                        <th>
                            <p>Email</p>
                        </th>
                        <th>
                            <p>??????????????</p>
                        </th>
                        <th colspan=""2"">
                            <p>??????????????????????</p>
                        </th>
                    </tr>
                </thead>
                <tbody>

");
#nullable restore
#line 108 "C:\Users\iryna\source\repos\WebApplication\WebApplication\Views\Home\Index.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
#nullable restore
#line 112 "C:\Users\iryna\source\repos\WebApplication\WebApplication\Views\Home\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                <a>");
#nullable restore
#line 115 "C:\Users\iryna\source\repos\WebApplication\WebApplication\Views\Home\Index.cshtml"
                              Write(item.Weathers.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ????????????????????</a>\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 118 "C:\Users\iryna\source\repos\WebApplication\WebApplication\Views\Home\Index.cshtml"
                           Write(Html.ActionLink("????????????????????","History", "Users", new { userId = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 121 "C:\Users\iryna\source\repos\WebApplication\WebApplication\Views\Home\Index.cshtml"
                           Write(Html.ActionLink("????????????????", "Delete", "Users", new { userId = item.Id }, new { @onclick = "return confirm(\"?????????????? ???????????????? ???????????????????????\")"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 124 "C:\Users\iryna\source\repos\WebApplication\WebApplication\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 130 "C:\Users\iryna\source\repos\WebApplication\WebApplication\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<UserModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
