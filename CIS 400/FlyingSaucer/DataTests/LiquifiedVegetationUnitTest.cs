using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit Tests for the Liquified Vegetation Class
    /// </summary>
    public class LiquifiedVegetationUnitTest
    {
        #region Default Values
        /// <summary>
        /// Checks that the ToString method returns the name of the drink
        /// </summary>
        [Fact]
        public void ToStringShouldJustBeName()
        {
            LiquifiedVegetation lv = new();
            Assert.Equal(lv.Name, lv.ToString());
        }
        /// <summary>
        /// Checks that a unaltered LiquifiedVegetation is served with ice 
        /// </summary>
        [Fact]
        public void DefaultServedWithIce()
        {
            LiquifiedVegetation lv = new();
            Assert.True(lv.Ice);
        }
        /// <summary>
        /// Checks that a unaltered LiquifiedVegetation is served with a small size
        /// </summary>
        [Fact]
        public void DefaultSizeSmall()
        {
            LiquifiedVegetation lv = new();
            Assert.Equal(ServingSize.Small, lv.Size);
        }
        /// <summary>
        /// This test verifies that an unaltered LiquifiedVegetation is assigned to the IMenuItem Interface
        /// </summary>
        [Fact]
        public void DefaultShouldBeAssignedToInterface()
        {
            LiquifiedVegetation lv = new();
            Assert.IsAssignableFrom<IMenuItem>(lv);
            
        }
        /// <summary>
        /// This test verifies that an unaltered LiquifiedVegetation is assigned to the Drink Class
        /// </summary>
        [Fact]
        public void DefaultShouldBeAssignedToDrink()
        {
            LiquifiedVegetation lv = new();
            Assert.IsAssignableFrom<Drink>(lv);

        }
        #endregion
        #region state changes
        /// <summary>
        /// This Test verifies that the Liquified Vegetation's Price is correct, given the size of the drink
        /// </summary>
        /// <param name="size">The size of the drink</param>
        /// <param name="price">The price of the item</param>
        [Theory]
        [InlineData(ServingSize.Small, 1.00)]
        [InlineData(ServingSize.Medium, 1.50)]
        [InlineData(ServingSize.Large, 2.00)]
        public void PriceShouldBeCorrect(ServingSize size, decimal price)
        {
            LiquifiedVegetation lv = new()
            {
                Size = size
            };
            Assert.Equal(price, lv.Price);
        }

        /// <summary>
        /// This test checks that even as the LiquifiedVegetation's state mutates, the name does not change
        /// </summary>
        /// <param name="ice">If the LiquifiedVegetation will be served with ice</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void NameShouldAlwaysBeCropCircle(bool ice)
        {
            LiquifiedVegetation lv = new()
            {
                Ice = ice
            };
            Assert.Equal("Liquified Vegetation", lv.Name);
        }

        /// <summary>
        /// This test checks that even as the LiquifiedVegetation's state mutates, the description does not change
        /// </summary>
        /// <param name="ice">If the LiquifiedVegetation will be served with ice</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void DescriptionShouldAlwaysMatch(bool ice)
        {
            LiquifiedVegetation lv = new()
            {
                Ice = ice
            };
            Assert.Equal("A cold glass of blended vegetable juice.", lv.Description);
        }

        /// <summary>
        /// This test checks that even as the LiquifiedVegetation's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="ice">If Ice is included</param>
        /// <param name="size">The Size of the drink</param>
        /// <param name="calories">The calories in the drink</param>
        /// <remarks>
        /// We supply the expected calories as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected calories are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(true, ServingSize.Small, 72)]
        [InlineData(false,ServingSize.Medium, 144)]
        [InlineData(true, ServingSize.Large, 216)]

        public void CaloriesShouldBeCorrect(bool ice, ServingSize size, uint calories)
        {
            LiquifiedVegetation lv = new()
            {
                Ice = ice,
                Size = size
            };
            Assert.Equal(calories, lv.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the LiquifiedVegetation
        /// </summary>
        /// <param name="ice">If served with ice</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, new string[] { })]
        [InlineData(false, new string[] { "No Ice" })]
        public void SpecialInstructionsRelfectsState(bool ice, string[] instructions)
        {
            LiquifiedVegetation lv = new()
            {
                Ice = ice
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, lv.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, lv.SpecialInstructions.Count());
        }
        #endregion

        /// <summary>
        /// Changing the size should notify property changed
        /// </summary>
        /// <param name="size">the size</param>
        /// <param name="propertyName">the property name</param>
        [Theory]
        [InlineData(ServingSize.Medium, "Size")]
        [InlineData(ServingSize.Large, "Size")]
        [InlineData(ServingSize.Medium, "Price")]
        [InlineData(ServingSize.Large, "Price")]
        [InlineData(ServingSize.Medium, "Calories")]
        [InlineData(ServingSize.Large, "Calories")]
        public void ChangingSizeShouldNotifyOfPropertyChanges(ServingSize size, string propertyName)
        {
            LiquifiedVegetation lq = new();
            Assert.PropertyChanged(lq, propertyName, () => {
                lq.Size = size;
            });
        }
        /// <summary>
        /// changing Ice changes properties
        /// </summary>
        /// <param name="extra">the sauce</param>
        /// <param name="propertyName">the property name</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        [InlineData(false, "Ice")]
        public void ChangingIceShouldNotifyPropertyChanged(bool extra, string propertyName)
        {
            LiquifiedVegetation gh = new();

            Assert.PropertyChanged(gh, propertyName, () =>
            {
                gh.Ice = extra;
            });
        }
    }
}
