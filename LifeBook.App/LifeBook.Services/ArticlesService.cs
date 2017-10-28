namespace LifeBook.Services
{
    using AutoMapper;
    using LifeBook.Models.EntityModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using LifeBook.Models.ViewModels.ArticlesVms;
    using LifeBook.Models.BindingModels.ArticlesBms;
    using LifeBook.Services.Interfaces;
    using LifeBook.Data.Interfaces;

    public class ArticlesService : Service, IArticlesService
    {
        public ArticlesService(ILifeBookDBContext articles)
            : base(articles)
        {
        }

        public List<ArticlesVm> GetAllArticles()
        {
            IEnumerable<Article> articles = this.Context.Articles;
            IEnumerable<ArticlesVm> vms = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticlesVm>>(articles);

            var sortedVms = vms.OrderBy(d => d.Date).ToList();

            return sortedVms;
        }

        public DetailedArticleVm GetDetailArticleVm(int id)
        {
            Article article = this.Context.Articles.Find(id);
            DetailedArticleVm vm = Mapper.Instance.Map<Article, DetailedArticleVm>(article);

            return vm;
        }

        public void GreateArticle(ArticleBm bindArticle)
        {
            Article article = Mapper.Instance.Map<ArticleBm, Article>(bindArticle);
            article.Date = DateTime.Now;
            this.Context.Articles.Add(article);
            this.Context.SaveChanges();
        }

        public void EditArticle(int id, ArticleBm bindArticle)
        {
            Article currentArticle = this.Context.Articles.Find(id);
            currentArticle.Date = DateTime.Now;
            currentArticle.Title = bindArticle.Title;
            currentArticle.Content = bindArticle.Content;
            currentArticle.Images = bindArticle.Images;
            this.Context.SaveChanges();
        }

        public bool containsArticle(int id)
        {
            var article = this.Context.Articles.Find(id);
            if (article == null)
            {
                return false;
            }

            return true;
        }

        public void DeleteArticle(int id)
        {
            var article = this.Context.Articles.Find(id);
            this.Context.Articles.Remove(article);
            this.Context.SaveChanges();
        }

        public bool IsAuthor(string currentAuthorId, int id)
        {
            var article = this.Context.Articles.Find(id);
            if (article.AuthorId == currentAuthorId)
            {
                return true;
            }

            return false;
        }
    }
}
