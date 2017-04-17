using AutoMapper;
using MyVocal.Model.Models;
using MyVocal.Service;
using MyVocal.Web.Infrastructure.Core;
using MyVocal.Web.Infrastructure.Extensions;
using MyVocal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyVocal.Web.Api
{
    [RoutePrefix("api/wordcategory")]
    public class WordCategoryController : ApiControllerBase
    {
        private IWordCategoryService _wordCategoryService;

        public WordCategoryController(IErrorService errorService, IWordCategoryService wordCategoryService) :
            base(errorService)
        {
            this._wordCategoryService = wordCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request,string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _wordCategoryService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.WordCategoryId).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<WordCategory>, IEnumerable<WordCategoryViewModel>>(query);

                var paginationSet = new PaginationSet<WordCategoryViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, WordCategoryViewModel wordCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newWordCategory = new WordCategory();

                    newWordCategory.UpdateWordCategory(wordCategoryVm);

                    var category = _wordCategoryService.Add(newWordCategory);

                    _wordCategoryService.Save();
                    //generate Id for WordCategory and send to client
                    var responseData = Mapper.Map<WordCategory, WordCategoryViewModel>(newWordCategory);

                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
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

                    _wordCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldWordCategory = _wordCategoryService.Delete(id);
                    _wordCategoryService.Save();

                    var responseData = Mapper.Map<WordCategory, WordCategoryViewModel>(oldWordCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
        
    }
}