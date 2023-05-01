using System.ComponentModel.DataAnnotations;

namespace OnBoardingProject.Common.Models
{
    public abstract class BaseModel
    {
        [Editable(false)]
        public Guid Id { get; set; }
    }
}