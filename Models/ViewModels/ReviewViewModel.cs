using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace Models.ViewModels
{
    public class ReviewViewModel
    {
        public class ReviewAddModel
        {
            [Required]
            [StringLength(500, ErrorMessage = "The Name must be at least {2} characters long.", MinimumLength = 6)]
            public string Description { get; set; }

            [Required]
            public int ProductId { get; set; }

            public Review GetReview()
            {
                return new Review {Description = this.Description, ProductId = this.ProductId};
            }
        }
    }

}
