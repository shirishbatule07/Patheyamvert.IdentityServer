#pragma checksum "D:\PROJECTS\SHIRISH\Vinay\Working\Patheyamvert.IdentityServer\IdentityServer\Views\Diagnostics\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f242bdecbbd197107afe6aa252256ef1a355e96"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Diagnostics_Index), @"mvc.1.0.view", @"/Views/Diagnostics/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Diagnostics/Index.cshtml", typeof(AspNetCore.Views_Diagnostics_Index))]
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
#line 1 "D:\PROJECTS\SHIRISH\Vinay\Working\Patheyamvert.IdentityServer\IdentityServer\Views\_ViewImports.cshtml"
using IdentityServer4.Quickstart.UI;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f242bdecbbd197107afe6aa252256ef1a355e96", @"/Views/Diagnostics/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57b49bb18fbe88f2fb7e20eb130e64338d7f2c37", @"/Views/_ViewImports.cshtml")]
    public class Views_Diagnostics_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DiagnosticsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(29, 59, true);
            WriteLiteral("\r\n<h1>Authentication cookie</h1>\r\n\r\n<h3>Claims</h3>\r\n<dl>\r\n");
            EndContext();
#line 7 "D:\PROJECTS\SHIRISH\Vinay\Working\Patheyamvert.IdentityServer\IdentityServer\Views\Diagnostics\Index.cshtml"
     foreach (var claim in Model.AuthenticateResult.Principal.Claims)
    {

#line default
#line hidden
            BeginContext(166, 12, true);
            WriteLiteral("        <dt>");
            EndContext();
            BeginContext(179, 10, false);
#line 9 "D:\PROJECTS\SHIRISH\Vinay\Working\Patheyamvert.IdentityServer\IdentityServer\Views\Diagnostics\Index.cshtml"
       Write(claim.Type);

#line default
#line hidden
            EndContext();
            BeginContext(189, 19, true);
            WriteLiteral("</dt>\r\n        <dd>");
            EndContext();
            BeginContext(209, 11, false);
#line 10 "D:\PROJECTS\SHIRISH\Vinay\Working\Patheyamvert.IdentityServer\IdentityServer\Views\Diagnostics\Index.cshtml"
       Write(claim.Value);

#line default
#line hidden
            EndContext();
            BeginContext(220, 7, true);
            WriteLiteral("</dd>\r\n");
            EndContext();
#line 11 "D:\PROJECTS\SHIRISH\Vinay\Working\Patheyamvert.IdentityServer\IdentityServer\Views\Diagnostics\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(234, 36, true);
            WriteLiteral("</dl>\r\n\r\n<h3>Properties</h3>\r\n<dl>\r\n");
            EndContext();
#line 16 "D:\PROJECTS\SHIRISH\Vinay\Working\Patheyamvert.IdentityServer\IdentityServer\Views\Diagnostics\Index.cshtml"
     foreach (var prop in Model.AuthenticateResult.Properties.Items)
    {

#line default
#line hidden
            BeginContext(347, 12, true);
            WriteLiteral("        <dt>");
            EndContext();
            BeginContext(360, 8, false);
#line 18 "D:\PROJECTS\SHIRISH\Vinay\Working\Patheyamvert.IdentityServer\IdentityServer\Views\Diagnostics\Index.cshtml"
       Write(prop.Key);

#line default
#line hidden
            EndContext();
            BeginContext(368, 19, true);
            WriteLiteral("</dt>\r\n        <dd>");
            EndContext();
            BeginContext(388, 10, false);
#line 19 "D:\PROJECTS\SHIRISH\Vinay\Working\Patheyamvert.IdentityServer\IdentityServer\Views\Diagnostics\Index.cshtml"
       Write(prop.Value);

#line default
#line hidden
            EndContext();
            BeginContext(398, 7, true);
            WriteLiteral("</dd>\r\n");
            EndContext();
#line 20 "D:\PROJECTS\SHIRISH\Vinay\Working\Patheyamvert.IdentityServer\IdentityServer\Views\Diagnostics\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(412, 9, true);
            WriteLiteral("</dl>\r\n\r\n");
            EndContext();
#line 23 "D:\PROJECTS\SHIRISH\Vinay\Working\Patheyamvert.IdentityServer\IdentityServer\Views\Diagnostics\Index.cshtml"
 if (Model.Clients.Any())
{

#line default
#line hidden
            BeginContext(451, 32, true);
            WriteLiteral("    <h3>Clients</h3>\r\n    <ul>\r\n");
            EndContext();
#line 27 "D:\PROJECTS\SHIRISH\Vinay\Working\Patheyamvert.IdentityServer\IdentityServer\Views\Diagnostics\Index.cshtml"
         foreach (var client in Model.Clients)
        {

#line default
#line hidden
            BeginContext(542, 16, true);
            WriteLiteral("            <li>");
            EndContext();
            BeginContext(559, 6, false);
#line 29 "D:\PROJECTS\SHIRISH\Vinay\Working\Patheyamvert.IdentityServer\IdentityServer\Views\Diagnostics\Index.cshtml"
           Write(client);

#line default
#line hidden
            EndContext();
            BeginContext(565, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 30 "D:\PROJECTS\SHIRISH\Vinay\Working\Patheyamvert.IdentityServer\IdentityServer\Views\Diagnostics\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(583, 11, true);
            WriteLiteral("    </ul>\r\n");
            EndContext();
#line 32 "D:\PROJECTS\SHIRISH\Vinay\Working\Patheyamvert.IdentityServer\IdentityServer\Views\Diagnostics\Index.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DiagnosticsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
