using UKHO.WCF.ClientLib.ukhowcfservice;

namespace UKHO.WCF.ClientLib
{
    public class UKHOWcfClient
    {
        private readonly OrderingServiceClient client = null;

        public UKHOWcfClient()
        {
            client = new OrderingServiceClient();
            client.ClientCredentials.UserName.UserName = "B2BCCMarine";
            client.ClientCredentials.UserName.Password = "Bx5p##}4.f";
        }

        public GetOrderResponse GetOrderClient(GetOrderRequest getOrderRequest)
        {
            var getOrderResponse = client.GetOrder(getOrderRequest);
            return getOrderResponse;
        }

        public SubmitOrderResponse SubmitOrderClient(SubmitOrderRequest submitOrderRequest)
        {
            var submitOrderResponse = client.SubmitOrder(submitOrderRequest);
            return submitOrderResponse;
        }

        public GetHoldingResponse GetHoldingClient(GetHoldingRequest getHoldingRequest)
        {
            var getHoldingResponse = client.GetHoldings(getHoldingRequest);
            return getHoldingResponse;
        }
    }
}