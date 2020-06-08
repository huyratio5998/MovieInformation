#pragma checksum "C:\Project\PTIT\ThayKhanh\MovieInformation\MovieInformation\Views\Movies\ListMoviePopular.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a10c0b83acd530cbcf671774a6f5ebed5250b6a3"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a10c0b83acd530cbcf671774a6f5ebed5250b6a3", @"/Views/Movies/ListMoviePopular.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"adfe0b13ffdddc7915a22d62ef835c12fbadc48f", @"/Views/_ViewImports.cshtml")]
    public class Views_Movies_ListMoviePopular : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MovieInformation.Services.ApiModels.Responses.MoviePopularResponse>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<h1>Top Population Movies</h1>
<div class=""container"">
    <br />
    <div style=""width:90%; margin:0 auto;"">
        <table id=""demoGrid"" class=""table table-striped table-bordered dt-responsive nowrap"" width=""100%"" cellspacing=""0"">
            <thead>
                <tr>
                    <th>Rating</th>
                    <th>Movie</th>
                    <th>Image</th>
");
            WriteLiteral("                    <th>Date Release</th>\r\n                    <th>Vote Numbers</th>\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 20 "C:\Project\PTIT\ThayKhanh\MovieInformation\MovieInformation\Views\Movies\ListMoviePopular.cshtml"
                 foreach (var item in Model.Results)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 23 "C:\Project\PTIT\ThayKhanh\MovieInformation\MovieInformation\Views\Movies\ListMoviePopular.cshtml"
                       Write(item.VoteAverage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 24 "C:\Project\PTIT\ThayKhanh\MovieInformation\MovieInformation\Views\Movies\ListMoviePopular.cshtml"
                       Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td><img");
            BeginWriteAttribute("src", " src=\"", 946, "\"", 1006, 2);
            WriteAttributeValue("", 952, "https://image.tmdb.org/t/p/original/", 952, 36, true);
#nullable restore
#line 25 "C:\Project\PTIT\ThayKhanh\MovieInformation\MovieInformation\Views\Movies\ListMoviePopular.cshtml"
WriteAttributeValue("", 988, item.PosterPath, 988, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width: 100px; height: auto\" /></td>\r\n");
            WriteLiteral("                        <td>");
#nullable restore
#line 27 "C:\Project\PTIT\ThayKhanh\MovieInformation\MovieInformation\Views\Movies\ListMoviePopular.cshtml"
                       Write(item.ReleaseDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 28 "C:\Project\PTIT\ThayKhanh\MovieInformation\MovieInformation\Views\Movies\ListMoviePopular.cshtml"
                       Write(item.VoteCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 29 "C:\Project\PTIT\ThayKhanh\MovieInformation\MovieInformation\Views\Movies\ListMoviePopular.cshtml"
                       Write(Html.ActionLink("Detail","Detail","Movies",new {movieId=item.Id.ToString() }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                    </tr>\r\n");
#nullable restore
#line 31 "C:\Project\PTIT\ThayKhanh\MovieInformation\MovieInformation\Views\Movies\ListMoviePopular.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tbody>\r\n            <tfoot>\r\n                <tr>\r\n                    <th>Rating</th>\r\n                    <th>Movie</th>\r\n                    <th>Image</th>\r\n");
            WriteLiteral(@"                    <th>Date Release</th>
                    <th>Vote Numbers</th>
                    <th></th>
                </tr>
            </tfoot>
        </table>
    </div>
</div>

<script>
    $('#demoGrid').dataTable({        
    });
</script>  ");
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
