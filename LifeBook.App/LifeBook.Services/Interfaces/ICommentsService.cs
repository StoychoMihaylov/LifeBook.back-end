namespace LifeBook.Services.Interfaces
{
    using LifeBook.Models.BindingModels.CommentsBms;
    using LifeBook.Models.ViewModels.CommentsVms;
    using System.Collections.Generic;

    public interface ICommentsService
    {
        IEnumerable<CommentsVm> GetAllComments(int ArticleId);

        void CreateComment(int articleId, CommentBm bindComment);

        bool containsComment(int commentId);

        bool IsAuthor(int articleId, string currentAuthorId, int id);

        void EditComment(int commentId, CommentBm bindComment);

        void DeleteComment(int commentId);
    }
}
