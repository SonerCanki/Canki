using Canki.Common.DTOs.Category;
using Canki.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Canki.Web.UI.APIs
{
    [Headers("Content-Type:application/json")]
    public interface ICategoryApi
    {
        [Get("/api/category")]
        Task<ApiResponse<WebApiResponse<List<CategoryResponse>>>> List();

        [Get("/api/category/{id}")]
        Task<ApiResponse<WebApiResponse<CategoryResponse>>> Get(Guid id);

        [Post("/api/category")]
        Task<ApiResponse<WebApiResponse<CategoryResponse>>> Post(CategoryRequest request);

        [Put("/api/category/{id}")]
        Task<ApiResponse<WebApiResponse<CategoryResponse>>> Put(Guid id,CategoryRequest request);

        [Delete("/api/category/{id}")]
        Task<ApiResponse<WebApiResponse<CategoryResponse>>> Delete(Guid id);

        [Get("/api/category/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/api/category/getactive/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> GetActive(Guid id);
    }
}
