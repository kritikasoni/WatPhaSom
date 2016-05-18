using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatPhaSom.Models;

namespace Models.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {

            CartLine line = lineCollection
                .FirstOrDefault(p => p.Product.Id == product.Id);

            if (line == null)
            {
                lineCollection.Add(new CartLine
                    {
                        Product = product,
                        Quantity = quantity
                    }
                );
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {

            lineCollection.RemoveAll(l => l.Product.Id == product.Id);

        }

        public void UpdateLine(Product product, int newQuantity)
        {
            CartLine line = lineCollection
                .FirstOrDefault(p => p.Product.Id == product.Id);
            if (line != null)
            {
                line.Quantity = newQuantity;
            }
        }

        public double ComputeTotalValue(string roleName)
        {
            if (roleName.Equals("Wholesale"))
            {
                return lineCollection.Sum(e => e.Product.WholesalePrice * e.Quantity);
            }
            return lineCollection.Sum(e => e.Product.RetailPrice * e.Quantity);

        }

        public void Clear()
        {

            lineCollection.Clear();

        }

        public IEnumerable<CartLine> Lines
        {

            get { return lineCollection; }

        }

    }

}

