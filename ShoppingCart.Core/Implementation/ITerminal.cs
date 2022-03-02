using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Core.Implementation
{
    public interface ITerminal
    {
        void Scan(string item);
        double Total();
    }
}
