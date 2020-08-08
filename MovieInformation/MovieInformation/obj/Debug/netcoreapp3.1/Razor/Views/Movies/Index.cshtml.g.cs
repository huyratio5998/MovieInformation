#pragma checksum "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Movies\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5cb607b62315630fa33e0bfbd3dde8f5f444f749"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movies_Index), @"mvc.1.0.view", @"/Views/Movies/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5cb607b62315630fa33e0bfbd3dde8f5f444f749", @"/Views/Movies/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"adfe0b13ffdddc7915a22d62ef835c12fbadc48f", @"/Views/_ViewImports.cshtml")]
    public class Views_Movies_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MovieInformation.Services.ApiModels.Responses.MoviePopularResponse>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "popularityDes", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "popularityAsc", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "ratingDes", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "ratingAsc", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "releaseDes", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "releaseAsc", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "range", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "saab", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#line 3 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Movies\Index.cshtml"
  
    ViewData["Title"] = "Index";

    Layout = "~/Views/Shared/_LayoutMovieInfor.cshtml";

#line default
#line hidden
            WriteLiteral(@"
<div class=""hero common-hero"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""hero-ct"">
                    <h1>Movie Listing</h1>
                    <ul class=""breadcumb"">
                        <li class=""active""><a href=""/Home/Index"">Home</a></li>
                        <li> <span class=""ion-ios-arrow-right""></span> movie listing</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</div>

<div class=""page-single"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12 col-sm-12 col-xs-12"">
                <div class=""topbar-filter fw"">
                    <p>Found <span>");
#line 30 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Movies\Index.cshtml"
                              Write(Model.TotalResults);

#line default
#line hidden
            WriteLiteral(" movies</span> in total</p>\r\n                    <label>Sort by:</label>\r\n                    <select id=\"movie-sort\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5cb607b62315630fa33e0bfbd3dde8f5f444f7497039", async() => {
                WriteLiteral("Popularity Descending");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5cb607b62315630fa33e0bfbd3dde8f5f444f7498237", async() => {
                WriteLiteral("Popularity Ascending");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5cb607b62315630fa33e0bfbd3dde8f5f444f7499434", async() => {
                WriteLiteral("Rating Descending");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5cb607b62315630fa33e0bfbd3dde8f5f444f74910628", async() => {
                WriteLiteral("Rating Ascending");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5cb607b62315630fa33e0bfbd3dde8f5f444f74911822", async() => {
                WriteLiteral("Release date Descending");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5cb607b62315630fa33e0bfbd3dde8f5f444f74913023", async() => {
                WriteLiteral("Release date Ascending");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </select>
                    <a href=""movielist.html"" class=""list""><i class=""ion-ios-list-outline ""></i></a>
                    <a href=""moviegridfw.html"" class=""grid""><i class=""ion-grid active""></i></a>
                </div>
                <div class=""flex-wrap-movielist mv-grid-fw"">
");
#line 44 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Movies\Index.cshtml"
                     foreach (var item in Model.Results)
                    {

#line default
#line hidden
            WriteLiteral("                    <div class=\"movie-item-style-2 movie-item-style-1\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 2065, "\"", 2125, 2);
            WriteAttributeValue("", 2071, "https://image.tmdb.org/t/p/original/", 2071, 36, true);
#line 47 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Movies\Index.cshtml"
WriteAttributeValue("", 2107, item.PosterPath, 2107, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 2126, "\"", 2132, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        <div class=\"hvr-inner\">\r\n                           ");
#line 49 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Movies\Index.cshtml"
                      Write(Html.ActionLink("Read more","Detail","Movies",new { movieId=item.Id.ToString()}));

#line default
#line hidden
            WriteLiteral(" <i class=\"ion-android-arrow-dropright\"></i>\r\n                        </div>\r\n                        <div class=\"mv-item-infor\">\r\n                            <h6><a");
            BeginWriteAttribute("href", " href=\"", 2460, "\"", 2498, 2);
            WriteAttributeValue("", 2467, "/Movies/Detail?movieId=", 2467, 23, true);
#line 52 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Movies\Index.cshtml"
WriteAttributeValue("", 2490, item.Id, 2490, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            WriteLiteral(">");
#line 52 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Movies\Index.cshtml"
                                                                     Write(item.Title);

#line default
#line hidden
            WriteLiteral("</a></h6>\r\n                            <p class=\"rate\"><i class=\"ion-android-star\"></i><span>");
#line 53 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Movies\Index.cshtml"
                                                                             Write(item.VoteAverage);

#line default
#line hidden
            WriteLiteral("</span> /10</p>\r\n                        </div>\r\n                    </div>\r\n");
#line 56 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Movies\Index.cshtml"
                    }

#line default
#line hidden
            WriteLiteral("                </div>\r\n                <div class=\"topbar-filter\">\r\n                    <label>Movies per page:</label>\r\n                    <select>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5cb607b62315630fa33e0bfbd3dde8f5f444f74917634", async() => {
                WriteLiteral("20 Movies");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5cb607b62315630fa33e0bfbd3dde8f5f444f74918821", async() => {
                WriteLiteral("10 Movies");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </select>\r\n\r\n                    <div class=\"pagination2\">\r\n                        <span>Page 1 of ");
#line 66 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Movies\Index.cshtml"
                                   Write(Model.TotalPages);

#line default
#line hidden
            WriteLiteral(":</span>\r\n");
#line 67 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Movies\Index.cshtml"
                         for (int i = 1; i <= 6; i++)
                        {                            

#line default
#line hidden
            WriteLiteral("                            <a");
            BeginWriteAttribute("href", " href=\"", 3291, "\"", 3319, 2);
            WriteAttributeValue("", 3298, "/Movies/Index?page=", 3298, 19, true);
#line 69 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Movies\Index.cshtml"
WriteAttributeValue("", 3317, i, 3317, 2, false);

#line default
#line hidden
            EndWriteAttribute();
            WriteLiteral(">");
#line 69 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Movies\Index.cshtml"
                                                       Write(i);

#line default
#line hidden
            WriteLiteral("</a>\r\n");
#line 70 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Movies\Index.cshtml"
                        }

#line default
#line hidden
            WriteLiteral("                        <a href=\"#\">...</a>\r\n");
#line 72 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Movies\Index.cshtml"
                         for (int i = (int)Model.TotalPages-1; i <=(int)Model.TotalPages; i++)
                        {

#line default
#line hidden
            WriteLiteral("                            <a");
            BeginWriteAttribute("href", " href=\"", 3554, "\"", 3582, 2);
            WriteAttributeValue("", 3561, "/Movies/Index?page=", 3561, 19, true);
#line 74 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Movies\Index.cshtml"
WriteAttributeValue("", 3580, i, 3580, 2, false);

#line default
#line hidden
            EndWriteAttribute();
            WriteLiteral(">");
#line 74 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Movies\Index.cshtml"
                                                       Write(i);

#line default
#line hidden
            WriteLiteral("</a>\r\n");
#line 75 "C:\Projects\Sermester4_2\PhatTrienPhanMemDichVu\Project\MovieInformation\MovieInformation\Views\Movies\Index.cshtml"
                        }

#line default
#line hidden
            WriteLiteral(@"
                       
                        <a href=""#""><i class=""ion-arrow-right-b""></i></a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script type=""text/javascript"">    
      let searchParams = new URL(window.location).searchParams;
    let option = searchParams.get('option');    
    let page = searchParams.get('page');    
    if (option!=null) {        
        $(""#movie-sort option[value="" + option + ""]"").prop(""selected"", ""selected"");        
    }  
    $(""#movie-sort"").change(function () {
        var selectedSort = $(this).children(""option:selected"").val();
        window.location.href = 'https://localhost:44369/movies?page='+page+'&option=' + selectedSort;
    });        
    
</script>");
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
