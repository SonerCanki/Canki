using AutoMapper;
using Canki.Web.UI.APIs;
using Canki.Web.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canki.Web.UI.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoryApi _categoryApi;
        private readonly IMapper _mapper;

        public CategoryViewComponent(ICategoryApi categoryApi, IMapper mapper)
        {
            _categoryApi = categoryApi;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<CategoryListViewModel> categoryList = new List<CategoryListViewModel>();
            var listResult = await _categoryApi.List();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                categoryList = _mapper.Map<List<CategoryListViewModel>>(listResult.Content.ResultData);

            return View(categoryList);
        }
    }
}
