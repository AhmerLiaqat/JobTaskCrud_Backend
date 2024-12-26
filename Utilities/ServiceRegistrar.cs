using JobTaskCrud.Common.GenericRepository;
using JobTaskCrud.Repositories.ProductRepository;
using JobTaskCrud.Services.ProductServices;

namespace JobTaskCrud.Utilities
{
    public class ServiceRegistrar
    {
        public static void registerServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
