using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.OData.Builder;

namespace WebApi.Model
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [AutoExpand]
        public List<Order> Orders { get; set; }
    }
}
