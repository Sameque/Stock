using DTO.Commands.Products.Requests;
using DTO.Commands.Products.Responses;
using DTO.Model.Products;
using GlobalServices.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductFacade _productFacade;
        private readonly IProductHandler _productHandler;

        public ProductController(IProductFacade productFacade, IProductHandler productHandler)
        {
            _productFacade = productFacade;
            _productHandler = productHandler;
        }

        [HttpPost]
        public async Task<ActionResult<ProductNotification>> PostAsync(ProductModelRequest model)
        {
            try
            {
                var response = _productFacade.Create(model);

                if (response == null || response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    return await Task.FromResult(BadRequest(response));
                else
                    return await Task.FromResult(Created(string.Empty, response));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            finally
            {
                //TODO Gravar Log aqui 
            }
        }

        [HttpPut]
        public async Task<ActionResult<ProductResponseUpdate>> PutAsync(ProductRequestUpdate request)
        {
            ProductResponseUpdate response = new();
            try
            {
                response = await _productHandler.Handler(request);
                return Created(string.Empty, response);
            }
            catch (Exception)
            {
                return BadRequest(response);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponseFind>>> GetAllAsync()
        {
            IEnumerable<ProductResponseFind> response = new List<ProductResponseFind>();
            try
            {
                response = await _productHandler.Handler();
                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}