using System.Collections.Generic;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.OData.Query;
using System.Web.OData.Routing.Conventions;
using Microsoft.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.UriParser;
using Microsoft.Owin.Diagnostics;
using Microsoft.Practices.Unity;
using Owin;
using WebApi.Dto;
using WebApi.Model;

namespace WebApi
{
    public class WebApiStartup
    {
        public void MakeConfiguration(IAppBuilder appBuilder)
        {
            var configuration = new HttpConfiguration();
            var container = new UnityContainer();
            var unityResolver = new UnityResolver(container);
            configuration.DependencyResolver = unityResolver;
            configuration.EnableDependencyInjection();

            configuration.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
            //TODO verify ODATAV6
            configuration.MapODataServiceRoute(
                "ODataRoute",
                null,
                builder =>
                    builder.AddService(ServiceLifetime.Singleton, sp => GetModel())
                        .AddService<IEnumerable<IODataRoutingConvention>>(ServiceLifetime.Singleton, sp =>
                                ODataRoutingConventions.CreateDefaultWithAttributeRouting("ODataRoute", configuration))
                        .AddService<ODataUriResolver>(ServiceLifetime.Singleton,
                            sp => new UnqualifiedCallAndEnumPrefixFreeResolver()));
            var webApiServer = new HttpServer(configuration);

            appBuilder.UseErrorPage(ErrorPageOptions.ShowAll);
            appBuilder.UseWebApi(webApiServer);
        }

        private IEdmModel GetModel()
        {
            //OData
            var odataBuilder = new ODataConventionModelBuilder {Namespace = "EntitySets"};
            odataBuilder.EntitySet<Product>("Products");
            odataBuilder.EntitySet<OrderProduct>("OrderProducts");
            odataBuilder.EntitySet<Order>("Orders");
            odataBuilder.EntitySet<Customer>("Customers");

            var resultComponentsComplexType = odataBuilder.ComplexType<ResultComponentsDto>();
            resultComponentsComplexType.Property(rc => rc.Description);
            var products = resultComponentsComplexType.HasMany(rc => rc.Products);
            products.AutoExpand = true;
            products.AutomaticallyExpand(true);

            var result = odataBuilder.ComplexType<ResultDto>();
            result.Property(r => r.CustomerName);
            var resultComponents = result.CollectionProperty(r => r.ResultComponentsDtos);
            resultComponents.AutoExpand = true; 


            var getResult = odataBuilder.EntityType<Customer>().Collection.Function("GetResult");
            getResult.Parameter<int>("Number");
            getResult.Returns<ResultDto>();

            var getResult2 = odataBuilder.EntityType<Customer>().Collection.Function("GetResult2");
            getResult2.Parameter<int>("Number");
            getResult2.ReturnsCollectionFromEntitySet<Customer>("Customers");

            var getResultUnbound = odataBuilder.Function("GetResultUnbound");
            getResultUnbound.Parameter<int>("Number");
            getResultUnbound.Returns<ResultDto>();

            return odataBuilder.GetEdmModel();
        }
    }
}
