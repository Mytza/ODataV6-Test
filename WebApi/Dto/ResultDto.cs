using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.OData.Builder;
using Microsoft.OData.UriParser;

namespace WebApi.Dto
{
    public class ResultDto
    {
        public string CustomerName { get; set; }
        public IList<ResultComponentsDto> ResultComponentsDtos { get; set; }
    }
}
