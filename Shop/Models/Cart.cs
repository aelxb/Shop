using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Cart
    {
        public Cart()
        {
            CartLines = new List<Products>();
        }
        public List<Products> CartLines { get; set; }

        // Вычисление итоговой стоимости

        public int FinalPrice
        {
            get
            {
                int sum = 0;

                foreach (Products product in CartLines)
                {
                    sum += product.Price_Product;

                }
                return sum;

            }

        }
    }
}