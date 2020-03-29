using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UKHO.WCF.ClientLib;
using UKHO.WCF.ClientLib.ukhowcfservice;

namespace UKHO.API.Services.Controllers
{
    public class OrderServiceController : ApiController
    {
        private readonly UKHOWcfClient client = null;
        public OrderServiceController()
        {
            client = new UKHOWcfClient();
        }
        // GET: api/OrderService
        /// <summary>
        /// 
        /// </summary>
        /// <param name="getOrderRequest"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(GetOrderRequest getOrderRequest)
        {
            var response = new HttpResponseMessage();
            if (getOrderRequest == null)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Input is Empty", "application/json");
                return response;
            }
            var getOrderResponse = client.GetOrderClient(getOrderRequest);

            if (getOrderResponse.Messages.Length > 0)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, getOrderResponse, "application/json");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, getOrderResponse, "application/json");
            }
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="submitOrderRequest"></param>
        /// <returns></returns>
        // POST: api/OrderService
        public HttpResponseMessage Post([FromBody]SubmitOrderRequest submitOrderRequest)
        {
            var response = new HttpResponseMessage();
            if (submitOrderRequest == null)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Input is Empty", "application/json");
                return response;
            }
            submitOrderRequest.RequestId = Guid.NewGuid().ToString();
            var submitOrderResponse = client.SubmitOrderClient(submitOrderRequest);

            if (submitOrderResponse.Messages.Length > 0)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, submitOrderResponse, "application/json");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, submitOrderResponse, "application/json");
            }
            return response;
        }
    }
}
