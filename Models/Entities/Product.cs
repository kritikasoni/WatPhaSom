using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace Models.Entities
{
    public class Product

    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double WholesalePrice { get; set; }
        public double RetailPrice { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public Product()
        {
            Reviews = new List<Review>();
        }
    }
    

}
