using MyVocal.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyVocal.Service;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MyVocal.Web.Api
{
    [RoutePrefix("api/oxford")]
    public class OxfordApiController : ApiControllerBase
    {
        private string _result ;

        public  OxfordApiController(IErrorService errorService) : base(errorService)
        {
          
        }

       
        [Route("getword")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
           
            return CreateHttpResponse(request, () =>
           {
               var response = request.CreateResponse(HttpStatusCode.OK, _result);
               return response;
           });
        }

        private async Task HttpClientCall()
        {
            // Create a client
            HttpClient httpClient = new HttpClient();

            // Add a new Request Message
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://od-api.oxforddictionaries.com/api/v1/entries/en/teacher");

            // Add our custom headers
            requestMessage.Headers.Add("app_id", "5a70d539");
            requestMessage.Headers.Add("app_key", "b51d905b4ce6338773c9839def5b4121");

            // Send the request to the server
            HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
           
            _result= response.Content.ReadAsStringAsync().Result;
            response.Dispose();
            // Just as an example I'm turning the response into a string here

        }


    }
}
