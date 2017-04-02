using AutoMapper;
using MyVocal.Model.Models;
using MyVocal.Service;
using MyVocal.Web.Infrastructure.Core;
using MyVocal.Web.Infrastructure.Extensions;
using MyVocal.Web.Models;
using System.Collections.Generic;
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

                var listCategoryVm = Mapper.Map<List<WordCategoryViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategoryVm);

                return response;
            });
        }

        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, WordCategoryViewModel wordCategoryVm)
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
                    var newWordCategory = new WordCategory();

                    newWordCategory.UpdateWordCategory(wordCategoryVm);

                    var category=_wordCategoryService.Add(newWordCategory);
                    _wordCategoryService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.Created, newWordCategory);

                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, WordCategoryViewModel wordCategoryVm)
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
                    var wordCategoryDb = _wordCategoryService.GetById(wordCategoryVm.WordCategoryId);
                    wordCategoryDb.UpdateWordCategory(wordCategoryVm);
                    _wordCategoryService.Update(wordCategoryDb);

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