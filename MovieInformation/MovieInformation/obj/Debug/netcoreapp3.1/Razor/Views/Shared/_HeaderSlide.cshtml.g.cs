#pragma checksum "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\_HeaderSlide.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d4d3e48e73226cb45e2576ac1141290f7f400b09"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__HeaderSlide), @"mvc.1.0.view", @"/Views/Shared/_HeaderSlide.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d4d3e48e73226cb45e2576ac1141290f7f400b09", @"/Views/Shared/_HeaderSlide.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"adfe0b13ffdddc7915a22d62ef835c12fbadc48f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__HeaderSlide : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MovieInformation.Services.ApiModels.Responses.MoviePopularResponse>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\_HeaderSlide.cshtml"
   
    MovieInformation.Services.ApiModels.Responses.GenreResponse lstGenres = ViewBag.lstGenres;
     var videos = ViewBag.Videos;
 

#line default
#line hidden
            WriteLiteral("<div>\r\n    <input type=\"hidden\" name=\"movieFavorites\" id=\"currentLoginId\"");
            BeginWriteAttribute("value", " value=\"", 288, "\"", 319, 1);
#line 7 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\_HeaderSlide.cshtml"
WriteAttributeValue("", 296, ViewBag.CurrentLoginId, 296, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            WriteLiteral(" />\r\n</div>\r\n<div class=\"row\">\r\n    <div class=\"slider-single-item\">\r\n");
#line 11 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\_HeaderSlide.cshtml"
         foreach (var item in Model.Results.Take(5))
        {                     

#line default
#line hidden
            WriteLiteral("            <div class=\"movie-item\">\r\n                <div class=\"row\">\r\n                    <div class=\"col-md-8 col-sm-12 col-xs-12\">\r\n                        <div class=\"title-in\">\r\n                            <div class=\"cate\">\r\n");
#line 18 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\_HeaderSlide.cshtml"
                                  
                                    if (item.GenreIds.Count() >= 1)
                                    {

#line default
#line hidden
            WriteLiteral("                                        <span class=\"blue\"><a href=\"#\">");
#line 21 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\_HeaderSlide.cshtml"
                                                                  Write(lstGenres.Genres.FirstOrDefault(x => x.Id == item.GenreIds[0]).Name);

#line default
#line hidden
            WriteLiteral("</a></span>\r\n");
#line 22 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\_HeaderSlide.cshtml"
                                    }
                                    if (item.GenreIds.Count() >= 2)
                                    {

#line default
#line hidden
            WriteLiteral("                                        <span class=\"yell\"><a href=\"#\">");
#line 25 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\_HeaderSlide.cshtml"
                                                                  Write(lstGenres.Genres.FirstOrDefault(x => x.Id == item.GenreIds[1]).Name);

#line default
#line hidden
            WriteLiteral("</a></span>\r\n");
#line 26 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\_HeaderSlide.cshtml"
                                    }
                                    if (item.GenreIds.Count() >= 3)
                                    {

#line default
#line hidden
            WriteLiteral("                                        <span class=\"orange\"><a href=\"#\">");
#line 29 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\_HeaderSlide.cshtml"
                                                                    Write(lstGenres.Genres.FirstOrDefault(x => x.Id == item.GenreIds[2]).Name);

#line default
#line hidden
            WriteLiteral("</a></span>\r\n");
#line 30 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\_HeaderSlide.cshtml"
                                    }
                                

#line default
#line hidden
            WriteLiteral("                            </div>\r\n                            <h1>\r\n                                <a href=\"#\">\r\n                                    ");
#line 35 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\_HeaderSlide.cshtml"
                               Write(item.Title);

#line default
#line hidden
            WriteLiteral("<br>\r\n                                    <span>");
#line 36 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\_HeaderSlide.cshtml"
                                     Write(item.ReleaseDate.Year);

#line default
#line hidden
            WriteLiteral(@"</span>
                                </a>
                            </h1>
                            <div class=""social-btn"">
                                <a href=""https://www.youtube.com/embed/DSCKfXpAGHc"" class=""parent-btn""><i class=""ion-play""></i> Watch Trailer</a>
");
#line 41 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\_HeaderSlide.cshtml"
                                 if (!string.IsNullOrEmpty(ViewBag.CurrentLoginId))
                                {
                                    

#line default
#line hidden
#line 43 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\_HeaderSlide.cshtml"
                                     if (item.isMovieFavorites)
                                    {

#line default
#line hidden
            WriteLiteral("                                        <a href=\"#\" id=\"delete-favorite\" class=\"parent-btn\"><i class=\"ion-heart\" style=\"background-color:yellow\" id=\"favorite-icon\"></i>Favorited</a>\r\n");
#line 46 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\_HeaderSlide.cshtml"
                                    }
                                    else
                                    {
                                        

#line default
#line hidden
#line 49 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\_HeaderSlide.cshtml"
                                                                                                                                                             
                                    }

#line default
#line hidden
#line 50 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\_HeaderSlide.cshtml"
                                     
                                }

#line default
#line hidden
            WriteLiteral(@"                                <div class=""hover-bnt"">
                                    <a href=""#"" class=""parent-btn""><i class=""ion-android-share-alt""></i>share</a>
                                    <div class=""hvr-item"">
                                        <a href=""#"" class=""hvr-grow""><i class=""ion-social-facebook""></i></a>
                                        <a href=""#"" class=""hvr-grow""><i class=""ion-social-twitter""></i></a>
                                        <a href=""#"" class=""hvr-grow""><i class=""ion-social-googleplus""></i></a>
                                        <a href=""#"" class=""hvr-grow""><i class=""ion-social-youtube""></i></a>
                                    </div>
                                </div>
                            </div>
                            <div class=""mv-details"">
                                <p><i class=""ion-android-star""></i><span>");
#line 63 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\_HeaderSlide.cshtml"
                                                                    Write(item.VoteAverage);

#line default
#line hidden
            WriteLiteral("</span> /10</p>\r\n                                <ul class=\"mv-infor\">\r\n                                    <li>  Rated: ");
#line 65 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\_HeaderSlide.cshtml"
                                            Write(item.VoteCount);

#line default
#line hidden
            WriteLiteral("  </li>\r\n                                    <li>  Release: ");
#line 66 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\_HeaderSlide.cshtml"
                                              Write(item.ReleaseDate.ToString("MM/dd/yyyy"));

#line default
#line hidden
            WriteLiteral("</li>\r\n                                </ul>\r\n                            </div>\r\n                            <div class=\"btn-transform transform-vertical\">\r\n                                <div>");
#line 70 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\_HeaderSlide.cshtml"
                                Write(Html.ActionLink("more detail", "Detail", "Movies", new { movieId = item.Id }, new { @class = "item item-1 redbtn" }));

#line default
#line hidden
            WriteLiteral("</div>\r\n                                <div>");
#line 71 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\_HeaderSlide.cshtml"
                                Write(Html.ActionLink("more detail", "Detail", "Movies", new { movieId = item.Id }, new { @class = "item item-2 redbtn hvrbtn" }));

#line default
#line hidden
            WriteLiteral("</div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"col-md-4 col-sm-12 col-xs-12\">\r\n                        <div class=\"mv-img-2\">\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 4854, "\"", 4891, 2);
            WriteAttributeValue("", 4861, "Movies/Detail?movieId=", 4861, 22, true);
#line 77 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\_HeaderSlide.cshtml"
WriteAttributeValue("", 4883, item.Id, 4883, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            WriteLiteral("><img");
            BeginWriteAttribute("src", " src=\"", 4897, "\"", 4957, 2);
            WriteAttributeValue("", 4903, "https://image.tmdb.org/t/p/original/", 4903, 36, true);
#line 77 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\_HeaderSlide.cshtml"
WriteAttributeValue("", 4939, item.PosterPath, 4939, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 4958, "\"", 4964, 0);
            EndWriteAttribute();
            WriteLiteral("></a>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#line 82 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Shared\_HeaderSlide.cshtml"
        }

#line default
#line hidden
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
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
