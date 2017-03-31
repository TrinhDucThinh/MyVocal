using MyVocal.Model.Models;
using MyVocal.Service;
using MyVocal.Web.Infrastructure.Core;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyVocal.Web.Api
{
    [RoutePrefix("api/WordCategory")]
    public class WordCategoryController : ApiControllerBase
    {
        IWordCategoryService _wordCategoryService;

        public WordCategoryController(IErrorService errorService, IWordCategoryService wordCategoryService) :
            base(errorService)
        {
            this._wordCategoryService = wordCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            
            return CreateHttpResponse(request, () =>
            {
                var listCategory = _wordCategoryService.GetAll();


                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);

                return response;
            });
        }

        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, WordCategory wordCategory)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _wordCategoryService.Add(wordCategory);
                    _wordCategoryService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.Created, wordCategory);

                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, WordCategory wordCategory)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _wordCategoryService.Update(wordCategory);
                    _wordCategoryService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _wordCategoryService.Delete(id);
                    _wordCategoryService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}