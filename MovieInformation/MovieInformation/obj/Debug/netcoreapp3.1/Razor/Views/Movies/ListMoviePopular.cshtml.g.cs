#pragma checksum "C:\Project\PTIT\ThayKhanh\MovieInformation\MovieInformation\Views\Movies\ListMoviePopular.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c1079ca55f3610f6de5d14c3cb2151e52426dbe0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movies_ListMoviePopular), @"mvc.1.0.view", @"/Views/Movies/ListMoviePopular.cshtml")]
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
#line 1 "C:\Project\PTIT\ThayKhanh\MovieInformation\MovieInformation\Views\_ViewImports.cshtml"
using MovieInformation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Project\PTIT\ThayKhanh\MovieInformation\MovieInformation\Views\_ViewImports.cshtml"
using MovieInformation.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1079ca55f3610f6de5d14c3cb2151e52426dbe0", @"/Views/Movies/ListMoviePopular.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"adfe0b13ffdddc7915a22d62ef835c12fbadc48f", @"/Views/_ViewImports.cshtml")]
    public class Views_Movies_ListMoviePopular : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MovieInformation.Services.ApiModels.Responses.MoviePopularResponse>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <div>\r\n        <h1>Top Population Movies</h1>\r\n        <ul>\r\n");
#nullable restore
#line 6 "C:\Project\PTIT\ThayKhanh\MovieInformation\MovieInformation\Views\Movies\ListMoviePopular.cshtml"
             foreach (var item in Model.Results)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li>\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 253, "\"", 313, 2);
            WriteAttributeValue("", 259, "https://image.tmdb.org/t/p/original/", 259, 36, true);
#nullable restore
#line 9 "C:\Project\PTIT\ThayKhanh\MovieInformation\MovieInformation\Views\Movies\ListMoviePopular.cshtml"
WriteAttributeValue("", 295, item.PosterPath, 295, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width: 100px; height: auto\" />\r\n                    <dl>\r\n                        <dt>");
#nullable restore
#line 11 "C:\Project\PTIT\ThayKhanh\MovieInformation\MovieInformation\Views\Movies\ListMoviePopular.cshtml"
                       Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n                        <dd>");
#nullable restore
#line 12 "C:\Project\PTIT\ThayKhanh\MovieInformation\MovieInformation\Views\Movies\ListMoviePopular.cshtml"
                       Write(item.Overview);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n                    </dl>\r\n                </li>\r\n");
#nullable restore
#line 15 "C:\Project\PTIT\ThayKhanh\MovieInformation\MovieInformation\Views\Movies\ListMoviePopular.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </ul>\r\n    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MovieInformation.Services.ApiModels.Responses.MoviePopularResponse> Html { get; private set; }
    }
}
#pragma warning restore 1591