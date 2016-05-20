using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;



namespace Models.ViewModels
{
   public class OrderCartViewModel
    {
        public Order Order { get; set; }
        public Cart Cart { get; set; }

    }
}
