using Canki.Common.DTOs.Base;

namespace Canki.Common.DTOs.Category
{
    public class CategoryResponse : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
    }
}
