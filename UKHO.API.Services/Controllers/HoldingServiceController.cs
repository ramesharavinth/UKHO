using System.Net;
using System.Net.Http;
using System.Web.Http;
using UKHO.WCF.ClientLib;
using UKHO.WCF.ClientLib.ukhowcfservice;

namespace UKHO.API.Services.Controllers
{
    public class HoldingServiceController : ApiController
    {
        private readonly UKHOWcfClient client = null;
        public HoldingServiceController()
        {
            client = new UKHOWcfClient();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="getHoldingRequest"></param>
        /// <returns></returns>
        // GET: api/HoldingService
        public HttpResponseMessage Get(GetHoldingRequest getHoldingRequest)
        {
            var response = new HttpResponseMessage();
            if (getHoldingRequest == null)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Input is Empty" , "application/json");
                return response;
            }
            var getHoldingResponse = client.GetHoldingClient(getHoldingRequest);
            
            if (getHoldingResponse.Messages.Length > 0)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, getHoldingResponse, "application/json");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, getHoldingResponse, "application/json");
            }
            return response;
        }
    }
}
