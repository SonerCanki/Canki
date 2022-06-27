using AutoMapper;
using Canki.Common.DTOs.ProductDetail;
using Canki.Common.Models;
using Canki.Model.Entities;
using Canki.Service.Repository.ProductDetail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canki.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        IProductDetailRepository _productDetailRepository;
        IMapper _mapper;

        public ProductDetailController(IProductDetailRepository productDetailRepository, IMapper mapper)
        {
            _productDetailRepository = productDetailRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<ProductDetailResponse>>>> GetProductDetails()
        {
            var productDetailResult = _mapper.Map<List<ProductDetailResponse>>(await _productDetailRepository.TableNoTracking.ToListAsync());

            if (productDetailResult.Count > 0)
                return new WebApiResponse<List<ProductDetailResponse>>(true, "Succes", productDetailResult);

            return new WebApiResponse<List<ProductDetailResponse>>(false, "Error");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductDetailResponse>>> GetProductDetail(Guid id)
        {
            var productDetail = await _productDetailRepository.GetById(id);
            if (productDetail != null)
                new WebApiResponse<ProductDetailResponse>(true, "Succes", _mapper.Map<ProductDetailResponse>(productDetail));

            return new WebApiResponse<ProductDetailResponse>(false, "Error");
        }

        [HttpPost]

        public async Task<ActionResult<WebApiResponse<ProductDetailResponse>>> PostProductDetail(ProductDetailRequest request)
        {
            var productDetail = _mapper.Map<ProductDetail>(request);
            var productDetailInsert = await _productDetailRepository.Add(productDetail);
            if (productDetailInsert != null)
            {
                new WebApiResponse<ProductDetailResponse>(true, "Succes", _mapper.Map<ProductDetailResponse>(productDetailInsert));
            }
            return new WebApiResponse<ProductDetailResponse>(false, "Error");
        }

        [HttpPut]
        public async Task<ActionResult<WebApiResponse<ProductDetailResponse>>> PutProductDetail(Guid id, ProductDetailRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                ProductDetail entity = await _productDetailRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _productDetailRepository.Update(entity);
                if (updateResult != null)
                {
                    ProductDetailResponse rm = _mapper.Map<ProductDetailResponse>(updateResult);
                    return new WebApiResponse<ProductDetailResponse>(true, "Success", rm);
                }
                return new WebApiResponse<ProductDetailResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductDetailResponse>>> DeleteProductDetail(Guid id)
        {
            ProductDetail entity = await _productDetailRepository.GetById(id);
            if (entity != null)
            {
                if (await _productDetailRepository.Remove(entity))
                    return new WebApiResponse<ProductDetailResponse>
                        (true, "Success", _mapper.Map<ProductDetailResponse>(entity));
                else
                    return new WebApiResponse<ProductDetailResponse>(false, "Error");
            }
            return new WebApiResponse<ProductDetailResponse>(false, "Error");
        }
        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _productDetailRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);

            return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactivate")]
        public async Task<ActionResult<WebApiResponse<List<ProductDetailResponse>>>> GetActive()
        {
            var productDetailResult = _mapper.Map<List<ProductDetailResponse>>(await _productDetailRepository.GetActive().ToListAsync());
            if (productDetailResult.Count > 0)
            {
                return new WebApiResponse<List<ProductDetailResponse>>(true, "Succes", productDetailResult);
            }
            return new WebApiResponse<List<ProductDetailResponse>>(false, "Error");
        }
    }
}
