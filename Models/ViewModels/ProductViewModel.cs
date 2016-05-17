using System.ComponentModel.DataAnnotations;
using Models.Entities;

namespace Models.Repository.ViewModels
{
    public class ProductViewModel
    {
        public class ProductAddModel
        {
            [Required]
            [StringLength(20, ErrorMessage = "The Name must be at least {2} characters long.", MinimumLength = 6)]
            public string Name { get; set; }
            [Required]
            public double Price { get; set; }
            [Required]
            [StringLength(500, ErrorMessage = "The Name must be at least {2} characters long.", MinimumLength = 6)]
            public string Description { get; set; }
            [Required]
            public string Image { get; set; }

            public Product GetProduct()
            {
                return new Product {Name = this.Name, Description = this.Description, Image = this.Image, WholesalePrice = this.Price};
            }
        }
    }
}