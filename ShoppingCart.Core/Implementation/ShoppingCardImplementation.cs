using ShoppingCart.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Core.Implementation
{
    public class ShoppingCardImplementation : ITerminal
    {
        public static List<Product> ProductDatabase;
        private List<Cart> currentOrder;
        public ShoppingCardImplementation()
        {
            currentOrder = new List<Cart>();

            ProductDatabase = new List<Product>();
            // prepare the product database
            ProductDatabase.Add(new Product
            {
                ProductCode = "A",
                Price = 2,
                VolumeDiscount = 4,
                PricePerVolume = 7
            });
            ProductDatabase.Add(new Product
            {
                ProductCode = "B",
                Price = 12,
                VolumeDiscount = 0,
                PricePerVolume = 0
            });
            ProductDatabase.Add(new Product
            {
                ProductCode = "C",
                Price = 1.25,
                VolumeDiscount = 6,
                PricePerVolume = 6
            });
            ProductDatabase.Add(new Product
            {
                ProductCode = "D",
                Price = 0.15,
                VolumeDiscount = 0,
                PricePerVolume = 0
            });
        }
        public void Scan(string productCode)
        {
            var existingProductInCart = currentOrder.FirstOrDefault(t => t.ProductCode.Equals(productCode.ToUpper()));

            if (existingProductInCart != null)
            {
                // if it's a same product then increase the quantity
                existingProductInCart.Quantity++;
            }
            else
            {
                if (!ShoppingCardImplementation.ProductDatabase.Select(t => t.ProductCode).Contains(productCode.ToUpper()))
                {
                    // if the input product code is not existing in the database then don't add
                    return;
                }
                currentOrder.Add(new Cart { ProductCode = productCode.ToUpper(), Quantity = 1 });
            }
        }

        public double Total()
        {
            double totalValue = 0;
            foreach (var item in currentOrder)
            {
                var itemInformation = ShoppingCardImplementation.ProductDatabase.FirstOrDefault(t => t.ProductCode.Equals(item.ProductCode));
                if (itemInformation != null)
                {
                    if (itemInformation.IsDiscountApplied)
                    {
                        if (item.Quantity >= itemInformation.VolumeDiscount)
                        {
                            totalValue += (int)(item.Quantity / itemInformation.VolumeDiscount) * itemInformation.PricePerVolume;
                            totalValue += (item.Quantity % itemInformation.VolumeDiscount) * itemInformation.Price;
                            // move to the next item
                            continue;
                        }
                    }

                    // no discount, just multiply them by quantity
                    totalValue += item.Quantity * itemInformation.Price;

                }
            }

            return totalValue;
        }

    }
}
