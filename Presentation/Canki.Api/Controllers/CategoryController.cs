using AutoMapper;
using Canki.Common.DTOs.Category;
using Canki.Common.Models;
using Canki.Model.Entities;
using Canki.Service.Repository.Category;
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
    public class CategoryController : ControllerBase
    {
        ICategoryRepository _categoryRepository;
        IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<CategoryResponse>>>> GetCategories()
        {
            var categoryResult= _mapper.Map<List<CategoryResponse>>(await _categoryRepository.TableNoTracking.ToListAsync());

            if (categoryResult.Count > 0)
                return new WebApiResponse<List<CategoryResponse>>(true, "Succes", categoryResult);

            return new WebApiResponse<List<CategoryResponse>>(false, "Error");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<CategoryResponse>>> GetCategory(Guid id)
        {
             var category=await _categoryRepository.GetById(id);
            if (category != null)
                new WebApiResponse<CategoryResponse>(true, "Succes", _mapper.Map<CategoryResponse>(category));

            return new WebApiResponse<CategoryResponse>(false, "Error");
        }

        [HttpPost]

        public async Task<ActionResult<WebApiResponse<CategoryResponse>>> PostCategory(CategoryRequest request)
        {
            var category =  _mapper.Map<Category>(request);
            var categoryInsert = await _categoryRepository.Add(category);
            if (categoryInsert!=null)
            {
                new WebApiResponse<CategoryResponse>(true, "Succes", _mapper.Map<CategoryResponse>(categoryInsert));
            }
            return new WebApiResponse<CategoryResponse>(false, "Error");
        }

        [HttpPut]
        public async Task<ActionResult<WebApiResponse<CategoryResponse>>> PutCategory(Guid id, CategoryRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                Category entity = await _categoryRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _categoryRepository.Update(entity);
                if (updateResult != null)
                {
                    CategoryResponse rm = _mapper.Map<CategoryResponse>(updateResult);
                    return new WebApiResponse<CategoryResponse>(true, "Success", rm);
                }
                return new WebApiResponse<CategoryResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<CategoryResponse>>> DeleteUser(Guid id)
        {
            Category entity = await _categoryRepository.GetById(id);
            if (entity != null)
            {
                if (await _categoryRepository.Remove(entity))
                    return new WebApiResponse<CategoryResponse>
                        (true, "Success", _mapper.Map<CategoryResponse>(entity));
                else
                    return new WebApiResponse<CategoryResponse>(false, "Error");
            }
            return new WebApiResponse<CategoryResponse>(false, "Error");
        }
        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _categoryRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);

            return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactivate")]
        public async Task<ActionResult<WebApiResponse<List<CategoryResponse>>>> GetActive()
        {
            var categoryResult = _mapper.Map<List<CategoryResponse>>(await _categoryRepository.GetActive().ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<CategoryResponse>>(true, "Succes", categoryResult);
            }
            return new WebApiResponse<List<CategoryResponse>>(false, "Error");
        }
    }
}
