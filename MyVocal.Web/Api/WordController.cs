using MyVocal.Web.Infrastructure.Core;
using MyVocal.Web.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyVocal.Service;
using MyVocal.Web.Models;
using AutoMapper;
using MyVocal.Model.Models;

namespace MyVocal.Web.Api
{
    [RoutePrefix("api/word")]
    public class WordController : ApiControllerBase
    {
        private IWordService _wordService;

        public WordController(IErrorService errorService,IWordService wordService) : base(errorService)
        {
            this._wordService = wordService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword,int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () => 
            {
                int totalRow = 0;
                var model = _wordService.GetAll(keyword);
                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.WordId).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Word>, IEnumerable<WordViewModel>>(query);
                var paginationSet = new PaginationSet<WordViewModel>()
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

        //get word detail
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _wordService.GetById(id);
                var responseData = Mapper.Map<Word, WordViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        //Create a word
        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, WordViewModel wordVm)
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
                    var newWord = new Word();
                    newWord.UpdateWord(wordVm);
                    var category = _wordService.Add(newWord);
                    _wordService.Save();

                    //generate Id for Word and send to client
                    var responseData = Mapper.Map<Word, WordViewModel>(newWord);

                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, WordViewModel wordVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var wordDb = _wordService.GetById(wordVm.WordCategoryId);
                    //wordCategoryDb.UpdateWord(wordCategoryVm);
                    wordDb.UpdateWord(wordVm);
                    _wordService.Update(wordDb);
                    _wordService.Save();

                    var responseData = Mapper.Map<Word, WordViewModel>(wordDb);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
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
                    var oldWordCategory = _wordService.Delete(id);
                    _wordService.Save() ;

                    var responseData = Mapper.Map<Word, WordViewModel>(oldWordCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
    }
}
