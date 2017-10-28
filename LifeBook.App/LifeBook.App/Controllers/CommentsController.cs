namespace LifeBook.App.Controllers
{
    using LifeBook.Models.BindingModels.CommentsBms;
    using LifeBook.Services.Interfaces;
    using Microsoft.AspNet.Identity;
    using System.Net;
    using System.Web.Http;

    [RoutePrefix("api/articles")]
    public class CommentsController : ApiController
    {
        private ICommentsService service;

        public CommentsController()
        {
            this.service = service;
        }

        // GET: api/Articles/5/Comments
        /// <summary>
        /// This get all comments in the selected article by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/comments")]
        public IHttpActionResult GetAllComments(int id)
        {
            var commentsVm = this.service.GetAllComments(id);
            if (commentsVm == null)
            {
                return this.StatusCode(HttpStatusCode.NotFound);
            }
            return this.Ok(commentsVm);
        }

        // POST: api/Articles/5/Comments
        /// <summary>
        /// This create comment in selected article by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bindComment"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}/comments")]
        public IHttpActionResult Post(int id, [FromBody]CommentBm bindComment)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            bindComment.AuthorId = this.User.Identity.GetUserId();
            this.service.CreateComment(id, bindComment);

            return this.StatusCode(HttpStatusCode.Created);
        }

        // PUT: api/Articles/5/Comments/3
        /// <summary>
        /// This edit the comment with Id (CommentId) in selected article by Id if the user is autorized(author or admin role)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="CommentId"></param>
        /// <param name="bindComment"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}/Comments/{CommentId}")]
        public IHttpActionResult Put(int id, int CommentId, [FromBody]CommentBm bindComment)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            if (!this.service.containsComment(CommentId))
            {
                return this.StatusCode(HttpStatusCode.NotFound);
            }

            string currentAuthorId = this.User.Identity.GetUserId();
            if (!this.service.IsAuthor(id,currentAuthorId, CommentId))
            {
                return this.StatusCode(HttpStatusCode.Unauthorized);
            }

            this.service.EditComment(CommentId, bindComment);

            return this.StatusCode(HttpStatusCode.Accepted);
        }

        // DELETE: api/Comments/5
        /// <summary>
        /// This delete comment with Id (CommentId) in selected article by Id id the user is in releant role(author or admin)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="CommentId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}/Comments/{CommentId}")]
        public IHttpActionResult Delete(int id, int CommentId)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            if (!this.service.containsComment(CommentId))
            {
                return this.StatusCode(HttpStatusCode.NotFound);
            }

            string currentAuthorId = this.User.Identity.GetUserId();
            if (!this.service.IsAuthor(id, currentAuthorId, CommentId))
            {
                return this.StatusCode(HttpStatusCode.Unauthorized);
            }

            this.service.DeleteComment(CommentId);

            return this.StatusCode(HttpStatusCode.Accepted);
        }
    }
}
