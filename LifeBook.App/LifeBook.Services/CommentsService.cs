namespace LifeBook.Services
{
    using AutoMapper;
    using LifeBook.Models.EntityModels;
    using LifeBook.Models.ViewModels.CommentsVms;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using LifeBook.Models.BindingModels.CommentsBms;
    using LifeBook.Services.Interfaces;
    using LifeBook.Data.Interfaces;


    public class CommentsService : Service, ICommentsService
    {
        public CommentsService(ILifeBookDBContext comments)
            : base(comments)
        {
        }

        public IEnumerable<CommentsVm> GetAllComments(int ArticleId)
        {
            IEnumerable<Comment> comments = this.Context.Comments.Where(comment => comment.ArticleId == ArticleId);
            IEnumerable<CommentsVm> vms = Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentsVm>>(comments);

            var sortedVms = vms.OrderBy(d => d.Date).ToList();
            return sortedVms;
        }

        public void CreateComment(int articleId, CommentBm bindComment)
        {
            Comment comment = Mapper.Instance.Map<CommentBm, Comment>(bindComment);
            comment.Date = DateTime.Now;
            comment.ArticleId = articleId;
            this.Context.Comments.Add(comment);
            this.Context.SaveChanges();
        }

        public bool containsComment(int commentId)
        {
            var isContains = this.Context.Comments.Find(commentId);
            if (isContains == null)
            {
                return false;
            }
            return true;
        }

        public bool IsAuthor(int articleId,string currentAuthorId, int id)
        {
            var authorIDOfTheArticle = this.Context.Articles.Find(articleId).AuthorId;
            var comment = this.Context.Comments.Find(id);
            if (comment.AuthorId == currentAuthorId || authorIDOfTheArticle == currentAuthorId)
            {
                return true;
            }

            return false;
        }

        public void EditComment(int commentId, CommentBm bindComment)
        {
            Comment comment = this.Context.Comments.Find(commentId);
            comment.Content = bindComment.Content;
            this.Context.SaveChanges();
        }

        public void DeleteComment(int commentId)
        {
            Comment comment = this.Context.Comments.Find(commentId);
            this.Context.Comments.Remove(comment);
            this.Context.SaveChanges();
        }
    }
}
