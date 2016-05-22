using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
  public   class CheckOutViewModel
    {
        public string Note { get; set; }
        public string Attachment { get; set; }
      //  [Required]
       // public PaymentMethod PaymentMethod { get; set; }
       // [Required]
      //  public TransportationType TransportationType { get; set; }
    }
}
