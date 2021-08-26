using DTO.Commands.Products.Requests;
using DTO.Commands.Products.Responses;
using DTO.Model.Products;
using GlobalServices.Interface;
using Repositories.Stock.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalServices.CommandHandle.Products.Handlers
{
    public class ProductHandler : IProductHandler
    {
        private readonly IProductRepositoryService _productRepositoryService;
        private readonly IProductRepositoryValidate _validate;

        public ProductHandler(IProductRepositoryService productRepositoryService, IProductRepositoryValidate validate)
        {
            _productRepositoryService = productRepositoryService;
            _validate = validate;
        }
        public async Task<ProductResponseCreate> Handler(ProductRequestCreate request)
        {
            var product = await _productRepositoryService.CreateAsync(new()
            {
                Code = request.Code,
                Description = request.Description,
            });

            var response = product.Response;

            return new()
            {
                Id = response.Id,
                Code = response.Code,
                Description = response.Description,
                Amount = response.Amount,
                Created = response.Created,
                Updated = response.Updated,
            };
        }

        public async Task<ProductResponseUpdate> Handler(ProductRequestUpdate request)
        {

            ProductModelRequest productModelRequest = new()
            {
                Code = request.Code,
                Description = request.Description,

            };

            ProductModelRequest product = productModelRequest;

            _validate.Update(product);

            ProductModelResponse productResponse = _productRepositoryService.UpdateAsync(product).Result.Response;

            return new()
            {
                Id = productResponse.Id,
                Code = productResponse.Code,
                Description = productResponse.Description,
                Amount = productResponse.Amount,
                CreatedAt = productResponse.Created,
                UpdatedAt = productResponse.Updated,
                Deleted = productResponse.Deleted
            };
        }

        public async Task<ProductResponseDelete> Handler(ProductRequestDelete request)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ProductResponseFind> Handler(ProductRequestFind request)
        {
            throw new System.NotImplementedException();
            //TODO o serviço valida
            //var response = await _productRepositoryService.GetByIdAsync((int)request.Id);

            //return new()
            //{
            //    Id = response.Id,
            //    Description = response.Description,
            //    Code = response.Code,
            //    Amount = response.Amount,
            //};
        }

        public async Task<IEnumerable<ProductResponseFind>> Handler()
        {
            var listResponse = _productRepositoryService.GetAllAsync().Result.Response;

            List<ProductResponseFind> response = new();
            foreach (var item in listResponse)
                response.Add(
                    new()
                    {
                        Id= item.Id,
                        Description = item.Description,
                        Code = item.Code,
                        Amount = item.Amount,
                    });

            return response;
        }
    }
}
