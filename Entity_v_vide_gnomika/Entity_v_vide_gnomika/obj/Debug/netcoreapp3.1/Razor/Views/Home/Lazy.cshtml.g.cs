#pragma checksum "C:\Users\NUTA\RiderProjects\Entity_v_vide_gnomika\Entity_v_vide_gnomika\Views\Home\Lazy.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a743ff4075aeb5979257a468714edb06c6aabfcf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Lazy), @"mvc.1.0.view", @"/Views/Home/Lazy.cshtml")]
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
#line 1 "C:\Users\NUTA\RiderProjects\Entity_v_vide_gnomika\Entity_v_vide_gnomika\Views\_ViewImports.cshtml"
using Entity_v_vide_gnomika;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\NUTA\RiderProjects\Entity_v_vide_gnomika\Entity_v_vide_gnomika\Views\_ViewImports.cshtml"
using Entity_v_vide_gnomika.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a743ff4075aeb5979257a468714edb06c6aabfcf", @"/Views/Home/Lazy.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d92445bb3a447d2b18b542692a3bad3252ad32d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Lazy : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\NUTA\RiderProjects\Entity_v_vide_gnomika\Entity_v_vide_gnomika\Views\Home\Lazy.cshtml"
  
    ViewData["Title"] = "Hotel";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Lazy</h2>\r\n\r\n<table width=\"100%\" class=\"table table-striped table-bordered table-hover\">\r\n    <tr>\r\n        <th>Name</th>\r\n        <th>Age</th>\r\n        <th>Room</th>\r\n    </tr>\r\n\r\n");
#nullable restore
#line 15 "C:\Users\NUTA\RiderProjects\Entity_v_vide_gnomika\Entity_v_vide_gnomika\Views\Home\Lazy.cshtml"
     foreach (var u in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 18 "C:\Users\NUTA\RiderProjects\Entity_v_vide_gnomika\Entity_v_vide_gnomika\Views\Home\Lazy.cshtml"
           Write(u.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 19 "C:\Users\NUTA\RiderProjects\Entity_v_vide_gnomika\Entity_v_vide_gnomika\Views\Home\Lazy.cshtml"
           Write(u.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 20 "C:\Users\NUTA\RiderProjects\Entity_v_vide_gnomika\Entity_v_vide_gnomika\Views\Home\Lazy.cshtml"
           Write(u.Room.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 22 "C:\Users\NUTA\RiderProjects\Entity_v_vide_gnomika\Entity_v_vide_gnomika\Views\Home\Lazy.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>");
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
