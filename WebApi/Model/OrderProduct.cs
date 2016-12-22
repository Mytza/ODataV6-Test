using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class OrderProduct
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
    }
}
