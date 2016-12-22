using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;
using Microsoft.OData.UriParser;
using WebApi.Dto;
using WebApi.Model;

namespace WebApi.Controllers
{
    public class CustomersController : ODataController
    {
        //Bound function
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = 4)]
        public async Task<IHttpActionResult> GetResult(int number)
        {
            var result = new ResultDto
            {
                CustomerName = "Test",
                ResultComponentsDtos = new List<ResultComponentsDto>
                {
                    new ResultComponentsDto
                    {
                        Description = "Test 1",
                        Products = new List<Product>
                        {
                            new Product
                            {
                                Id = Guid.NewGuid(),
                                Name = "1"
                            },
                            new Product
                            {
                                Id = Guid.NewGuid(),
                                Name = "2"
                            },
                        }
                    },
                    new ResultComponentsDto
                    {
                        Description = "Test 2",
                        Products = new List<Product>
                        {
                            new Product
                            {
                                Id = Guid.NewGuid(),
                                Name = "3"
                            },
                            new Product
                            {
                                Id = Guid.NewGuid(),
                                Name = "4"
                            },
                        }
                    }
                }
            };
            return Ok(result);
        }

        [HttpGet]
        [EnableQuery(MaxExpansionDepth = 4)]
        public async Task<IHttpActionResult> GetResult2(int number)
        {
            var result = new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Test1",
                Orders = new List<Order>
                {
                    new Order
                    {
                        Id = Guid.NewGuid(),
                        Date = DateTimeOffset.Now,
                        Products = new List<OrderProduct>
                        {
                            new OrderProduct
                            {
                                Id = Guid.NewGuid(),
                                Price = 10,
                                ProductId = Guid.NewGuid()
                            }
                        }
                    }
                }
            };
            return Ok(result);
        }

        //Unbound function
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = 4)]
        [ODataRoute("GetResultUnbound(Number={number})")]
        public async Task<IHttpActionResult> GetResultUnbound(int number)
        {
            var result = new ResultDto
            {
                CustomerName = "Test",
                ResultComponentsDtos = new List<ResultComponentsDto>
                {
                    new ResultComponentsDto
                    {
                        Description = "Test 1",
                        Products = new List<Product>
                        {
                            new Product
                            {
                                Id = Guid.NewGuid(),
                                Name = "1"
                            },
                            new Product
                            {
                                Id = Guid.NewGuid(),
                                Name = "2"
                            },
                        }
                    },
                    new ResultComponentsDto
                    {
                        Description = "Test 2",
                        Products = new List<Product>
                        {
                            new Product
                            {
                                Id = Guid.NewGuid(),
                                Name = "3"
                            },
                            new Product
                            {
                                Id = Guid.NewGuid(),
                                Name = "4"
                            },
                        }
                    }
                }
            };
            return Ok(result);
        }
    }
}
