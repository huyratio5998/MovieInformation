#pragma checksum "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\ListMoviePopular.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "beb7e9a5244ee56a38f61ae25f10a6ed80e31eed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_ListMoviePopular), @"mvc.1.0.view", @"/Views/Shared/ListMoviePopular.cshtml")]
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
#line 1 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\_ViewImports.cshtml"
using MovieInformation;

#line default
#line hidden
#line 2 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\_ViewImports.cshtml"
using MovieInformation.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"beb7e9a5244ee56a38f61ae25f10a6ed80e31eed", @"/Views/Shared/ListMoviePopular.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"adfe0b13ffdddc7915a22d62ef835c12fbadc48f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_ListMoviePopular : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MovieInformation.Services.ApiModels.Responses.MoviePopularResponse>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n    <div class=\"row\">\r\n        <div class=\"slick-multiItem2\">\r\n");
#line 6 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\ListMoviePopular.cshtml"
             foreach (var item in Model.Results)
            {

#line default
#line hidden
            WriteLiteral("                <div class=\"slide-it\">\r\n                    <div class=\"movie-item\">\r\n                        <div class=\"mv-img\">\r\n                            <img");
            BeginWriteAttribute("src", " src=\"", 371, "\"", 431, 2);
            WriteAttributeValue("", 377, "https://image.tmdb.org/t/p/original/", 377, 36, true);
#line 11 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\ListMoviePopular.cshtml"
WriteAttributeValue("", 413, item.PosterPath, 413, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 432, "\"", 438, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        </div>\r\n                        <div class=\"hvr-inner\">\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 555, "\"", 604, 2);
            WriteAttributeValue("", 562, "/Movies/Detail?movieId=", 562, 23, true);
#line 14 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\ListMoviePopular.cshtml"
WriteAttributeValue("", 585, item.Id.ToString(), 585, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            WriteLiteral("> Read more <i class=\"ion-android-arrow-dropright\"></i> </a>\r\n                        </div>\r\n                        <div class=\"title-in\">\r\n                            <h6><a href=\"#\">");
#line 17 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\ListMoviePopular.cshtml"
                                       Write(item.Title);

#line default
#line hidden
            WriteLiteral("</a></h6>\r\n                            <p><i class=\"ion-android-star\"></i><span>");
#line 18 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\ListMoviePopular.cshtml"
                                                                Write(item.VoteAverage);

#line default
#line hidden
            WriteLiteral("</span> /10</p>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#line 22 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\ListMoviePopular.cshtml"
            }

#line default
#line hidden
            WriteLiteral("        </div>\r\n    </div>\r\n");
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