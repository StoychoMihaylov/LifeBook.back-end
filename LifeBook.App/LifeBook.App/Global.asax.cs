using AutoMapper;
using LifeBook.Models.BindingModels;
using LifeBook.Models.BindingModels.ArticlesBms;
using LifeBook.Models.BindingModels.CommentsBms;
using LifeBook.Models.EntityModels;
using LifeBook.Models.ViewModels;
using LifeBook.Models.ViewModels.ArticlesVms;
using LifeBook.Models.ViewModels.CommentsVms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LifeBook.App
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureMapper();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.Indent = true;
        }

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Article, ArticlesVm>();
                expression.CreateMap<Article, DetailedArticleVm>()
                    .ForMember(vm => vm.Author, configExpression => 
                    configExpression.MapFrom( article => article.Author.FirstName));
                expression.CreateMap<ArticleBm, Article>();
                expression.CreateMap<Comment, CommentsVm>();
                //.ForMember(vm => vm.Author, configExpression =>
                //configExpression.MapFrom(comment => comment.Author.FirstName));
                expression.CreateMap<CommentBm, Comment>();
            });
        }
    }
}
