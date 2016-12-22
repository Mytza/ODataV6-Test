using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.OData.Builder;
using WebApi.Model;

namespace WebApi.Dto
{
    public class ResultComponentsDto
    {
        public string Description { get; set; }
        [AutoExpand]
        public IList<Product> Products { get; set; }
    }
}
