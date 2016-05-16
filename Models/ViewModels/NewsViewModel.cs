using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace Models.ViewModels
{
    public class NewsViewModel
    {
        public class NewsAddModel
        {
            [Required]
            [StringLength(20, ErrorMessage = "The Name must be at least {2} characters long.", MinimumLength = 6)]
            public string Title { get; set; }

            [Required]
            [StringLength(500, ErrorMessage = "The Name must be at least {2} characters long.", MinimumLength = 6)]
            public string Description { get; set; }

            [Required]
            public string Image { get; set; }

            public News GetNews()
            {
                return new News {Title = this.Title, Description = this.Description, Image = this.Image};
            }
        }
    }
}
