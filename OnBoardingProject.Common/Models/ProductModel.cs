using OnBoardingProject.Common.Enums;

namespace OnBoardingProject.Common.Models
{
    public class ProductModel : BaseModel
    {

        public string ImageSource { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ProductCategory Category { get; set; } = 0;
    }
}
