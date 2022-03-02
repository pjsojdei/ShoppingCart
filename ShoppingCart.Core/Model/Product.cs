using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Core.Model
{
    public class Product
    {
        public string ProductCode { get; set; }
        // price per unit
        public double Price { get; set; }
        public int VolumeDiscount { get; set; }
        public double PricePerVolume { get; set; }
        public bool IsDiscountApplied { get { return this.VolumeDiscount > 0; } }

        
    }

}
