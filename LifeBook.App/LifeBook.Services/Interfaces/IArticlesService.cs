namespace LifeBook.Services.Interfaces
{
    using LifeBook.Models.ViewModels.ArticlesVms;
    using System.Collections.Generic;
    using LifeBook.Models.BindingModels.ArticlesBms;

    public interface IArticlesService
    {
        List<ArticlesVm> GetAllArticles();

        DetailedArticleVm GetDetailArticleVm(int id);

        void GreateArticle(ArticleBm bindArticle);

        void EditArticle(int id, ArticleBm bindArticle);

        bool containsArticle(int id);

        void DeleteArticle(int id);

        bool IsAuthor(string currentAuthorId, int id);
    }
}
