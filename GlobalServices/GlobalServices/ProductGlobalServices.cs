using DTO.Interfaces.Products;
using DTO.Model.Products;
using GlobalServices.Interface;
using Repositories.Stock.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalServices.GlobalServices
{
    public class ProductGlobalServices : IProductGlobalServices
    {
        private readonly IProductRepositoryService _repositoryService;
        private readonly IProductGlobalValidation _validation;
        private readonly IUnitOfWork _unitOfWork;

        public ProductGlobalServices(IProductRepositoryService repositoryService, IProductGlobalValidation validation, IUnitOfWork unitOfWork)
        {
            _repositoryService = repositoryService;
            _validation = validation;
            _unitOfWork = unitOfWork;
        }

        public Task<int> AddAsync(int id, int amount)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CheckAmountAsync(int id)
        {
            throw new NotImplementedException();

            //var response = await _repositoryService.GetByIdAsync(id);
            //return (int)response.Amount;
        }

        public async Task<IProductNotification> CreateAsync(ProductModelRequest request)
        {
            IProductNotification response = new ProductNotification() { Request = request };

            response.ValidationList = _validation.Validation(request).ToList();

            try
            {
                if (response.ValidationList.ToList().Count > 0)
                {
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    response.StatusDescription = "Service validation error!";
                }
                else
                {
                    response = await _repositoryService.CreateAsync(request);
                }

                return response;

            }
            catch (Exception)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.StatusDescription = "Erro não mapeado";
                return response;
            }
            finally
            {
                //TODO gravar Log
                //log(response);
            }
        }

        public Task<string> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<IProductNotification>> FindAsync(ProductModelRequest obj)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductModelResponse> GetByCodeAsync(long code)
        {
            var product = await _repositoryService.GetByCodeAsync(code);
            var response = product.Response;
            return new()
            {
                Code = response.Code,
                Description = response.Description,
                Amount = response.Amount
            };
        }

        public Task<int> RemoveAsync(int id, int amount)
        {
            throw new NotImplementedException();
        }

        public Task<IProductNotification> UpdateAsync(ProductModelRequest obj)
        {
            throw new NotImplementedException();
        }
    }
}