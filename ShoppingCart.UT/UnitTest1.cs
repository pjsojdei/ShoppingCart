using System;
using Xunit;

namespace ShoppingCart.UT
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            ShoppingCart.Core.Implementation.ShoppingCardImplementation shoppingCart = new Core.Implementation.ShoppingCardImplementation();
            var cartItems = "ABCDABAA";
            foreach(char c in cartItems)
            {
                shoppingCart.Scan(c.ToString());
            }
            var totalPrice = shoppingCart.Total();
            Assert.Equal(32.4, totalPrice);
        }

        [Fact]
        public void Test2()
        {
            ShoppingCart.Core.Implementation.ShoppingCardImplementation shoppingCart = new Core.Implementation.ShoppingCardImplementation();
            var cartItems = "CCCCCCC";
            foreach (char c in cartItems)
            {
                shoppingCart.Scan(c.ToString());
            }
            var totalPrice = shoppingCart.Total();
            Assert.Equal(7.25, totalPrice);
        }

        [Fact]
        public void Test3()
        {
            ShoppingCart.Core.Implementation.ShoppingCardImplementation shoppingCart = new Core.Implementation.ShoppingCardImplementation();
            var cartItems = "ABCD";
            foreach (char c in cartItems)
            {
                shoppingCart.Scan(c.ToString());
            }
            var totalPrice = shoppingCart.Total();
            Assert.Equal(15.4, totalPrice);
        }
    }
}
