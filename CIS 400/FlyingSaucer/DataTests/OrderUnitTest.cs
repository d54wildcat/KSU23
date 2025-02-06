using Xunit;
using Xunit.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.ComponentModel;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the order class
    /// </summary>
    public class OrderUnitTest
    {
        /// <summary>
        /// A mock menu item for testing
        /// </summary>
        internal class MockMenuItem : IMenuItem 
        {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public uint Calories { get; set; }
        public IEnumerable<string> SpecialInstructions { get; set; }
        }
        /// <summary>
        /// Ensures the property changed is implemented
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
        Order order = new Order();
        Assert.IsAssignableFrom<INotifyPropertyChanged>(order);
        }
        /// <summary>
        /// Ensures the Collection changed is implemented
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyCollectionChanged()
        {
            Order order = new Order();
            Assert.IsAssignableFrom<INotifyCollectionChanged>(order);
        }
        /// <summary>
        /// Checks that the default order has a subtotal of the prices
        /// </summary>
        [Fact]
        public void SubtotalShouldReflectItemPrices()
        {
            Order order = new Order();
            order.Add(new MockMenuItem() { Price = 1.00m });
            order.Add(new MockMenuItem() { Price = 2.50m });
            order.Add(new MockMenuItem() { Price = 3.00m });
            Assert.Equal(6.50m, order.Subtotal);
        }
        /// <summary>
        /// unit test to ensure the taxrate can be set
        /// </summary>
        /// <param name="taxRate">the tax rate</param>
        [Theory]
        [InlineData(.01)]
        [InlineData(.03)]
        [InlineData(.04)]
        [InlineData(.1)]
        [InlineData(.08)]
        [InlineData(.09)]
        [InlineData(.15)]
        [InlineData(.20)]
        public void TaxRateValueIsCorrect(decimal taxRate)
        {
            Order order = new Order()
            {
                TaxRate = taxRate,
            };
            Assert.Equal(taxRate, order.TaxRate);

        }
        /// <summary>
         /// Tax reflects the price
        /// </summary>
        [Fact]
        public void TaxShouldReflectCorrectPrice()
        {
            Order order = new Order();
            order.Add(new MockMenuItem() { Price = 1.00m });
            order.Add(new MockMenuItem() { Price = 2.50m });
            order.Add(new MockMenuItem() { Price = 3.00m });
            Assert.Equal(6.50m * order.TaxRate, order.Tax);
        }  
        /// <summary>
        /// Test that the total is correct
        /// </summary>
        [Fact]
        public void TotalShouldBeCorrect()
        {
            var order = new Order();
            order.Add(new MockMenuItem() { Price = 1.00m });
            order.Add(new MockMenuItem() { Price = 2.50m });
            order.Add(new MockMenuItem() { Price = 3.00m });
            order.TaxRate = 0.045m;
            Assert.Equal(6.79m, order.Total);
        }
        /// <summary>
        /// Checks to see if the count property is working
        /// </summary>
        [Fact]
        public void CountPropertyIsAccurate()
        {
            Order order = new Order();
            order.Add(new MockMenuItem());
            order.Add(new MockMenuItem());
            order.Add(new MockMenuItem());
            Assert.Equal(3, order.Count);
        }
        /// <summary>
        /// test to see that the readonly method is default set to false
        /// </summary>
        [Fact]
        public void IsReadOnlyInitiallyFalse()
        {
            var order = new Order();
            Assert.False(order.IsReadOnly);
        }
        /// <summary>
        /// Adds an Item to the order
        /// </summary>
        [Fact]
        public void AddMethodAddsItem()
        {
            var order = new Order();
            MockMenuItem mockItem = new MockMenuItem();
            order.Add(mockItem);
            Assert.Contains(mockItem, order);
        }
        /// <summary>
        /// Test to see that clear empties the order
        /// </summary>
        [Fact]
        public void ClearMethodEmptiesOrder()
        {
            var order = new Order();
            order.Add(new MockMenuItem());
            order.Add(new MockMenuItem());
            order.Add(new MockMenuItem());
            order.Clear();
            Assert.Empty(order);
        }
        /// <summary>
        /// Test to check that the order contains the item
        /// </summary>
        [Fact]
        public void ContainsAnItem()
        {
            var order = new Order();
            MockMenuItem mockItem = new MockMenuItem();
            order.Add(mockItem);
            MockMenuItem mockItem2 = new MockMenuItem();
            order.Add(mockItem2);
            MockMenuItem mockItem3 = new MockMenuItem();
            order.Add(mockItem3);
            Assert.Contains(mockItem2, order);
        }
        /// <summary>
        /// test to check that the contains method returns false if items not contained
        /// </summary>
        [Fact]
        public void ContainsMethodReturnsIfItemIsNotContained()
        {
            var order = new Order();
            MockMenuItem mockItem = new MockMenuItem();
            Assert.False(order.Contains(mockItem));
        }
        /// <summary>
        /// method to see if order is copied into array
        /// </summary>
        [Fact]
        public void CopyToArrayCopiesCorrectly()
        {
            var order = new Order();
            MockMenuItem mockItem = new MockMenuItem();
            order.Add(mockItem);
            IMenuItem[] array = new IMenuItem[1];
            order.CopyTo(array, 0);
            Assert.Equal(mockItem, array[0]);
        }

        /// <summary>
        /// test to make sure the get enumerator method
        /// </summary>
        [Fact]
        public void GetEnumeratorReturnsIEnumerator()
        {
            Order order = new Order();
            order.Add(new MockMenuItem());
            order.Add(new MockMenuItem());
            order.Add(new MockMenuItem());
            order.GetEnumerator();
            Assert.True(order is IEnumerable<IMenuItem>);
        }
        /// <summary>
        /// Test to check that the order can remove the item
        /// </summary>
        [Fact]
        public void RemovesAnItem()
        {
            var order = new Order();
            MockMenuItem mockItem = new MockMenuItem();
            order.Add(mockItem);
            MockMenuItem mockItem2 = new MockMenuItem();
            order.Add(mockItem2);
            MockMenuItem mockItem3 = new MockMenuItem();
            order.Add(mockItem3);
            order.Remove(mockItem);
            Assert.DoesNotContain(mockItem, order);
        }

        /// <summary>
        /// method to get the enumerator from the get enumerator
        /// </summary>
        [Fact]
        public void GetEnumeratorGetsEnumerator()
        {
            Order order = new Order();
            order.Add(new MockMenuItem());
            order.Add(new MockMenuItem());
            order.Add(new MockMenuItem());
            order.GetEnumerator();
            Assert.True(order is IEnumerable<IMenuItem>);
        }  
        /// <summary>
        /// Ensures that adding a menu item triggers the collection change
        /// </summary>
        [Fact]
        public void AddingMenuItemNotifiesCollectionChanged()
        {
            Order order = new Order();
            FlyingSaucer fs = new FlyingSaucer();
            Assert.PropertyChanged(order, "Total", () => {
            order.Add(fs);
            });
        }
        /// <summary>
        /// Checks that the tax rate triggers the property change
        /// </summary>
        [Fact]
        public void ChangingTaxRateShouldNotifyOfPropertyChange()
        {
            Order order = new Order();
            Assert.PropertyChanged(order, "TaxRate", () => 
            {
                order.TaxRate = 0.15m;
            });
        }
    }
}
