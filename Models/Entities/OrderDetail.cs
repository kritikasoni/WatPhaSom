using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;
using Models.Repositories;
using Models.Repository;

namespace Models.Entities
{
    public class OrderDetail
    {
     

        [Key]
        public int Id { get; set; }
        [ForeignKey("Order")]
         public int OrderId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }


      /*  public void AddProductInCartToOrderDetail(Cart cart)
        {
            
          CartLine lines =new CartLine();
            CartLine.

        }
        */
       
        }
    }

    
   
    





