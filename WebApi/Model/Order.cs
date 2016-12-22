using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.OData.Builder;

namespace WebApi.Model
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
        [AutoExpand]
        public List<OrderProduct> Products { get; set; }
    }
}
