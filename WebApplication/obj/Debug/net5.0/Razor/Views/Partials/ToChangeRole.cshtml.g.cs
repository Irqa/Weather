#pragma checksum "C:\Users\iryna\source\repos\WebApplication\WebApplication\Views\Partials\ToChangeRole.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3d8e655b377146bddfadafc476e269ad5ae49933"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Partials_ToChangeRole), @"mvc.1.0.view", @"/Views/Partials/ToChangeRole.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d8e655b377146bddfadafc476e269ad5ae49933", @"/Views/Partials/ToChangeRole.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa0ef8da47a84ffb33e8bc853509aa4fa5703a26", @"/Views/_ViewImports.cshtml")]
    public class Views_Partials_ToChangeRole : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApplication.Models.UserModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\iryna\source\repos\WebApplication\WebApplication\Views\Partials\ToChangeRole.cshtml"
  Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<button type=\"button\" id=\"Ch_Role\" class=\"btn btn-primary\">Змінити роль</button>\r\n<script>\r\n    var ch_role = document.getElementById(\"Ch_Role\");\r\n    ch_role.addEventListener(\"click\", event => {\r\n        $.get(\'");
#nullable restore
#line 7 "C:\Users\iryna\source\repos\WebApplication\WebApplication\Views\Partials\ToChangeRole.cshtml"
          Write(Url.Action("ChangeRole", "Users", new { userId = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\', function (data) {\r\n            $(\"#Ch_Role\").replaceWith(data);\r\n        });\r\n    })\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication.Models.UserModel> Html { get; private set; }
    }
}
#pragma warning restore 1591