using AsmC5.Models;

namespace AsmC5.Common.Request
{
    public class OrderRequestParameters : RequestParameters
    {
        public OrderStatus? OrderStatus { get; set; }
        public DateTime? FormDate { get; set; }
        public DateTime? ToDate { get; set; }


    }
}
