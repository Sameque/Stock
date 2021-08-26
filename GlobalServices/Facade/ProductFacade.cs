using DTO.Interfaces.Products;
using DTO.Model.Products;
using GlobalServices.Interface;

namespace GlobalServices.Facade
{
    public class ProductFacade : IProductFacade
    {
        private readonly IProductGlobalServices _globalServices;

        public ProductFacade(IProductGlobalServices globalServices)
        {
            _globalServices = globalServices;
        }

        public IProductNotification Create(ProductModelRequest request)
        {
                var response = _globalServices.CreateAsync(request).Result;
                if (response == null || response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    return response;

                if (request.Amount > 0)
                    response.Response.Amount = _globalServices.AddAsync(response.Response.Id, request.Amount).Result;

                return response;
        }
    }
}
