using DTO.Interfaces.Products;
using DTO.Model.Products;
using Entities.Stock;
using Repositories.Stock.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Stock.Service
{
    public class ProductRepositoryService : IProductRepositoryService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductRepositoryValidate _validate;

        public ProductRepositoryService(IProductRepository productRepository, IProductRepositoryValidate validate)
        {
            _productRepository = productRepository;
            _validate = validate;
        }

        public async Task<IProductNotificationList> GetAllAsync()
        {
            List<ProductModelResponse> listResponse = new();
            try
            {
                List<Product> listProduct = _productRepository.GetAll().Result.ToList();
                foreach (Product product in listProduct)
                    listResponse.Add(new ProductModelResponse()
                    {
                        Id = product.Id,
                        Code = product.Code,
                        Description = product.Description,
                        Amount = product.Amount,
                        Deleted = false,
                        Created = product.Created,
                        Updated = product.Updated
                    });

                return new ProductNotificationList()
                {
                    StatusCode = 0,
                    StatusDescription = "",
                    ValidationList = new List<string>(),
                    Request = null,
                    Response = listResponse
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> RemoveAsync(int productId, int amount)
        {
            try
            {
                Product product = await _productRepository.GetById(productId);
                product.Amount -= amount;

                _ = _productRepository.Update(product);
                Product response = await _productRepository.GetById(productId);

                return (int)response.Amount;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IProductNotification> CreateAsync(ProductModelRequest dto)
        {
            IProductNotification response = new ProductNotification() { Request = dto };

            try
            {
                response.ValidationList = _validate.Create(dto).ToList();

                if (response.ValidationList.ToList().Count > 0)
                    throw new Exception("Error in repository!");

                Product entity = new()
                {
                    Code = dto.Code,
                    Description = dto.Description,
                };

                _ = _productRepository.Create(entity);

                response.Response = new()
                {
                    Id = entity.Id,
                    Description = entity.Description,
                    Code = entity.Code,
                    Amount = entity.Amount,
                    Created = entity.Created,
                    Updated = entity.Updated,
                };

                return response;
            }
            catch (Exception e)
            {
                response.StatusDescription = e.Message;
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return response;
            }
            finally
            {
                //TODO Grvar log

            }
        }

        public async Task<IProductNotification> GetByCodeAsync(long code)
        {
            var model = await _productRepository.GetByCode(code);

            return new ProductNotification()
            {
                Request = null,
                Response = new()
                {
                    Id = model.Id,
                    Description = model.Description,
                    Code = model.Code,
                    Amount = model.Amount,
                    Created = model.Created,
                    Updated = model.Updated,
                }
            };
        }

        public async Task<int> AddAsync(int productId, int amount)
        {
            var model = await _productRepository.GetById(productId);
            model.Amount += amount;
            _productRepository.Update(model);
            return (int)model.Amount;
        }

        public async Task<IProductNotification> UpdateAsync(ProductModelRequest obj)
        {
            throw new NotImplementedException();
        }

        public async Task<string> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IProductNotification> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}