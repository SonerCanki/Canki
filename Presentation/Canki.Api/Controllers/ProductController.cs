using AutoMapper;
using Canki.Common.DTOs.Product;
using Canki.Common.Models;
using Canki.Model.Entities;
using Canki.Service.Repository.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Canki.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductRepository _productRepository;
        IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<ProductResponse>>>> GetProducts()
        {
            var productResult = _mapper.Map<List<ProductResponse>>(await _productRepository.TableNoTracking.ToListAsync());

            if (productResult.Count > 0)
                return new WebApiResponse<List<ProductResponse>>(true, "Succes", productResult);

            return new WebApiResponse<List<ProductResponse>>(false, "Error");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductResponse>>> GetProduct(Guid id)
        {
            var product = await _productRepository.GetById(id);
            if (product != null)
                new WebApiResponse<ProductResponse>(true, "Succes", _mapper.Map<ProductResponse>(product));

            return new WebApiResponse<ProductResponse>(false, "Error");
        }

        [HttpPost]

        public async Task<ActionResult<WebApiResponse<ProductResponse>>> PostProduct(ProductRequest request)
        {
            var product = _mapper.Map<Product>(request);
            var productInsert = await _productRepository.Add(product);
            if (productInsert != null)
            {
                new WebApiResponse<ProductResponse>(true, "Succes", _mapper.Map<ProductResponse>(productInsert));
            }
            return new WebApiResponse<ProductResponse>(false, "Error");
        }

        [HttpPut]
        public async Task<ActionResult<WebApiResponse<ProductResponse>>> PutProduct(Guid id, ProductRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                Product entity = await _productRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _productRepository.Update(entity);
                if (updateResult != null)
                {
                    ProductResponse rm = _mapper.Map<ProductResponse>(updateResult);
                    return new WebApiResponse<ProductResponse>(true, "Success", rm);
                }
                return new WebApiResponse<ProductResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductResponse>>> DeleteProduct(Guid id)
        {
            Product entity = await _productRepository.GetById(id);
            if (entity != null)
            {
                if (await _productRepository.Remove(entity))
                    return new WebApiResponse<ProductResponse>
                        (true, "Success", _mapper.Map<ProductResponse>(entity));
                else
                    return new WebApiResponse<ProductResponse>(false, "Error");
            }
            return new WebApiResponse<ProductResponse>(false, "Error");
        }
        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _productRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);

            return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactivate")]
        public async Task<ActionResult<WebApiResponse<List<ProductResponse>>>> GetActive()
        {
            var productResult = _mapper.Map<List<ProductResponse>>(await _productRepository.GetActive().ToListAsync());
            if (productResult.Count > 0)
            {
                return new WebApiResponse<List<ProductResponse>>(true, "Succes", productResult);
            }
            return new WebApiResponse<List<ProductResponse>>(false, "Error");
        }
    }
}
