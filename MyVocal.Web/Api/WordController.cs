using MyVocal.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyVocal.Service;
using MyVocal.Web.Models;

namespace MyVocal.Web.Api
{
    public class WordController : ApiControllerBase
    {
        private IWordService _wordService;

        public WordController(IErrorService errorService,IWordService wordService) : base(errorService)
        {
            this._wordService = wordService;
        }

        //[Route("getall")]
        //public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        int totalRow = 0;
        //        var model = _wordService.GetAll(keyword);

        //        totalRow = model.Count();
        //        var query = model.OrderByDescending(x => x.WordCategoryId).Skip(page * pageSize).Take(pageSize);

        //        var responseData = Mapper.Map<IEnumerable<WordCategory>, IEnumerable<WordCategoryViewModel>>(query);

        //        var paginationSet = new PaginationSet<WordCategoryViewModel>()
        //        {
        //            Items = responseData,
        //            Page = page,
        //            TotalCount = totalRow,
        //            TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
        //        };
        //        var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
        //        return response;
        //    });
        //}

        //[Route("create")]
        //[HttpPost]
        //[AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, WordViewModel wordCategoryVm)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (!ModelState.IsValid)
        //        {
        //            request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            var newWordCategory = new WordCategory();

        //            newWordCategory.UpdateWordCategory(wordCategoryVm);

        //            var category = _wordCategoryService.Add(newWordCategory);

        //            _wordCategoryService.Save();
        //            //generate Id for WordCategory and send to client
        //            var responseData = Mapper.Map<WordCategory, WordCategoryViewModel>(newWordCategory);

        //            response = request.CreateResponse(HttpStatusCode.Created, responseData);
        //        }
        //        return response;
        //    });
        //}

        //[Route("update")]
        //public HttpResponseMessage Put(HttpRequestMessage request, WordCategoryViewModel wordCategoryVm)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (ModelState.IsValid)
        //        {
        //            request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            var wordCategoryDb = _wordCategoryService.GetById(wordCategoryVm.WordCategoryId);
        //            wordCategoryDb.UpdateWordCategory(wordCategoryVm);
        //            _wordCategoryService.Update(wordCategoryDb);

        //            _wordCategoryService.Save();

        //            response = request.CreateResponse(HttpStatusCode.OK);
        //        }
        //        return response;
        //    });
        //}

        //public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (ModelState.IsValid)
        //        {
        //            request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            _wordCategoryService.Delete(id);
        //            _wordCategoryService.Save();

        //            response = request.CreateResponse(HttpStatusCode.OK);
        //        }
        //        return response;
        //    });
        //}

    }
}
