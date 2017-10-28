namespace LifeBook.App.Controllers
{
    using LifeBook.Models.BindingModels.ArticlesBms;
    using LifeBook.Services.Interfaces;
    using Microsoft.AspNet.Identity;
    using System.Net;
    using System.Web.Http;

    [RoutePrefix("api/articles")]
    public class ArticlesController : ApiController
    {
        private IArticlesService service;

        public ArticlesController(IArticlesService service)
        {
            this.service = service;
        }

        //GET: api/Articles
        /// <summary>
        /// This rout gate all articles from database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get()
        {
            var articlesVms = this.service.GetAllArticles();
            if (articlesVms == null)
            {
                return this.StatusCode(HttpStatusCode.NotFound);
            }

            return this.Ok(articlesVms);
        }

        // GET: api/Articles/5
        /// <summary>
        /// This route get the concret article by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var detaildArticleVm = this.service.GetDetailArticleVm(id);
            if (detaildArticleVm == null)
            {
                return this.StatusCode(HttpStatusCode.NotFound);
            }

            return this.Ok(detaildArticleVm);
        }

        // POST: api/Articles
        /// <summary>
        /// This create the article in database.
        /// </summary>
        /// <param name="bindArticle"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Post([FromBody]ArticleBm bindArticle)
        {
            if (! this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            bindArticle.AuthorId = this.User.Identity.GetUserId();
            this.service.GreateArticle(bindArticle);

            return this.StatusCode(HttpStatusCode.Created);
        }

        // PUT: api/Articles/5
        /// <summary>
        /// This edit the article by Id if the the user is the author of the article or is in admin role.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bindArticle"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(int id, [FromBody]ArticleBm bindArticle)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            if (! this.service.containsArticle(id))
            {
                return this.StatusCode(HttpStatusCode.NotFound);
            }

            string currentAuthorId = this.User.Identity.GetUserId();
            if (! this.service.IsAuthor(currentAuthorId, id))
            {
                return this.StatusCode(HttpStatusCode.Unauthorized);
            }

            this.service.EditArticle(id, bindArticle);

            return this.StatusCode(HttpStatusCode.Accepted);
        }

        // DELETE: api/Articles/5
        /// <summary>
        /// This delete the article by Id if the user is author of the article or is in admin role.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (!this.service.containsArticle(id))
            {
                return this.StatusCode(HttpStatusCode.NotFound);
            }

            string currentAuthorId = this.User.Identity.GetUserId();
            if (!this.service.IsAuthor(currentAuthorId, id))
            {
                return this.StatusCode(HttpStatusCode.Unauthorized);
            }

            this.service.DeleteArticle(id);

            return this.StatusCode(HttpStatusCode.Accepted);
        }
    }
}
