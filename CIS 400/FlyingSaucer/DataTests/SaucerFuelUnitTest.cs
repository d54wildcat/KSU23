using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the Saucer Fuel drink
    /// </summary>
    public class SaucerFuelUnitTest
    {
        #region Default Values
        /// <summary>
        /// Checks that the ToString method returns the name of the drink
        /// </summary>
        [Fact]
        public void ToStringShouldJustBeName()
        {
            SaucerFuel sf = new();
            Assert.Equal(sf.Name, sf.ToString());
        }
        /// <summary>
        /// Checks that a unaltered SaucerFuel is not served with decaf 
        /// </summary>
        [Fact]
        public void DefaultServedWithoutDecaf()
        {
            SaucerFuel sf = new();
            Assert.False(sf.Decaf);
        }
        /// <summary>
        /// Checks that a unaltered SaucerFuel is not served with cream 
        /// </summary>
        [Fact]
        public void DefaultServedWithoutCream()
        {
            SaucerFuel sf = new();
            Assert.False(sf.Cream);
        }
        /// <summary>
        /// Checks that a unaltered SaucerFuel is served with a small size
        /// </summary>
        [Fact]
        public void DefaultSizeSmall()
        {
            SaucerFuel sf = new();
            Assert.Equal(ServingSize.Small, sf.Size);
        }
        /// <summary>
        /// This test verifies that an unaltered SaucerFuel is assigned to the IMenuItem Interface
        /// </summary>
        [Fact]
        public void DefaultShouldBeAssignedToInterface()
        {
            SaucerFuel sf = new();
            Assert.IsAssignableFrom<IMenuItem>(sf);

        }
        /// <summary>
        /// This test verifies that an unaltered LiquifiedVegetation is assigned to the Drink Class
        /// </summary>
        [Fact]
        public void DefaultShouldBeAssignedToDrink()
        {
            SaucerFuel sf = new();
            Assert.IsAssignableFrom<Drink>(sf);

        }
        #endregion
        #region state changes
        /// <summary>
        /// This test verifies that the SaucerFuel's size, price, and calories are changed accordingly
        /// </summary>
        /// <param name="size">The size of the drink</param>
        /// <param name="propertyName">The property name</param>
        [Theory]
        [InlineData(ServingSize.Medium, "Size")]
        [InlineData(ServingSize.Large, "Size")]
        [InlineData(ServingSize.Medium, "Price")]
        [InlineData(ServingSize.Large, "Price")]
        [InlineData(ServingSize.Medium, "Calories")]
        [InlineData(ServingSize.Large, "Calories")]
        public void ChangingSizeShouldNotifyOfPropertyChanges(ServingSize size, string propertyName)
        {
            SaucerFuel saucerFuel = new();
            Assert.PropertyChanged(saucerFuel, propertyName, () => {
                saucerFuel.Size = size;
            });
        }
        /// <summary>
        /// This test verifies that the SaucerFuel's class implements INotify changed
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            SaucerFuel saucerFuel = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(saucerFuel);
        }
        /// <summary>
        /// This Test verifies that the SaucerFuel's Price is correct, given the size of the drink
        /// </summary>
        /// <param name="size">The size of the drink</param>
        /// <param name="price">The price of the item</param>
        [Theory]
        [InlineData(ServingSize.Small, 1.00)]
        [InlineData(ServingSize.Medium, 1.50)]
        [InlineData(ServingSize.Large, 2.00)]
        public void PriceShouldBeCorrect(ServingSize size, decimal price)
        {
            SaucerFuel sf = new()
            {
                Size = size
            };
            Assert.Equal(price, sf.Price);
        }

        /// <summary>
        /// This test checks that even as the SaucerFuel's state mutates, the name changes as well
        /// </summary>
        /// <param name="decaf">If the SaucerFuel will be served with ice</param>
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void NameShouldAlwaysBeSaucerFuel(bool decaf)
        {
            SaucerFuel sf = new()
            {
                Decaf = decaf
            };
            Assert.Equal("Saucer Fuel", sf.Name);
            Assert.Equal("Decaf Saucer Fuel", sf.Name);
        }

        /// <summary>
        /// This test checks that even as the SaucerFuel's state mutates, the description does not change
        /// </summary>
        /// <param name="decaf">If the SaucerFuel will be served with decaf</param>
        /// <param name="cream">If the saucerFuel will be served with cream</param>
        [Theory]
        [InlineData(true, true)]
        [InlineData(false, true)]
        [InlineData(true, false)]
        [InlineData(false, false)]
        public void DescriptionShouldAlwaysMatch(bool decaf, bool cream)
        {
            SaucerFuel sf = new()
            {
                Decaf = decaf,
                Cream = cream
            };
            Assert.Equal("A steaming cup of coffee.", sf.Description);
        }

        /// <summary>
        /// This test checks that even as the SaucerFuel's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="decaf">If decaf is included</param>
        /// <param name="cream">If cream is included</param>
        /// <param name="size">The Size of the drink</param>
        /// <param name="calories">The calories in the drink</param>
        /// <remarks>
        /// We supply the expected calories as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected calories are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(true, true, ServingSize.Small, 30)]
        [InlineData(false, false, ServingSize.Medium, 2)]
        [InlineData(true, false, ServingSize.Large, 3)]
        [InlineData(false, true, ServingSize.Large, 32)]

        public void CaloriesShouldBeCorrect(bool decaf, bool cream, ServingSize size, uint calories)
        {
            SaucerFuel sf = new()
            {
                Decaf = decaf,
                Cream = cream,
                Size = size
            };
            Assert.Equal(calories, sf.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the SaucerFuel
        /// </summary>
        /// <param name="decaf">If served with decaf</param>
        /// <param name="cream">If served with cream</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, false, new string[] { })]
        [InlineData(false, true,  new string[] { "With Cream" })]
        public void SpecialInstructionsRelfectsState(bool decaf, bool cream, string[] instructions)
        {
            SaucerFuel sf = new()
            {
                Decaf = decaf,
                Cream = cream
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, sf.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, sf.SpecialInstructions.Count());
        }
        #endregion
    }
}
