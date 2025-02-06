using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the InorganicSubstance class
    /// </summary>
    public class InorganicSubstanceUnitTest
    {
        #region Default Values
        /// <summary>
        /// Checks that the ToString method returns the name of the drink
        /// </summary>
        [Fact]
        public void ToStringShouldJustBeName()
        {
            InorganicSubstance iS = new();
            Assert.Equal(iS.Name, iS.ToString());
        }
        /// <summary>
        /// Checks that a unaltered InorganicSubstance is served with ice 
        /// </summary>
        [Fact]
        public void DefaultServedWithIce()
        {
            InorganicSubstance iS = new();
            Assert.True(iS.Ice);
        }
        /// <summary>
        /// Checks that a unaltered InorganicSubstance is served with a small size
        /// </summary>
        [Fact]
        public void DefaultSizeSmall()
        {
            InorganicSubstance iS = new();
            Assert.Equal(ServingSize.Small, iS.Size);
        }
        /// <summary>
        /// This test verifies that an unaltered InorganicSubstance is assigned to the IMenuItem Interface
        /// </summary>
        [Fact]
        public void DefaultShouldBeAssignedToInterface()
        {
            InorganicSubstance iS = new();
            Assert.IsAssignableFrom<IMenuItem>(iS);

        }
        /// <summary>
        /// This test verifies that an unaltered InorganicSubstance is assigned to the Drink Class
        /// </summary>
        [Fact]
        public void DefaultShouldBeAssignedToDrink()
        {
            InorganicSubstance iS = new();
            Assert.IsAssignableFrom<Drink>(iS);

        }
        #endregion
        #region state changes
        /// <summary>
        /// This Test verifies that the InorganicSubstance's Price is correct, given the size of the drink
        /// </summary>
        /// <param name="size">The size of the drink</param>
        /// <param name="price">The price of the item</param>
        [Theory]
        [InlineData(ServingSize.Small, 0.00)]
        [InlineData(ServingSize.Medium, 0.00)]
        [InlineData(ServingSize.Large, 0.00)]
        public void PriceShouldBeCorrect(ServingSize size, decimal price)
        {
            InorganicSubstance iS = new()
            {
                Size = size
            };
            Assert.Equal(price, iS.Price);
        }

        /// <summary>
        /// This test checks that even as the InorganicSubstance's state mutates, the name does not change
        /// </summary>
        /// <param name="ice">If the InorganicSubstance will be served with ice</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void NameShouldAlwaysBeCropCircle(bool ice)
        {
            InorganicSubstance iS = new()
            {
                Ice = ice
            };
            Assert.Equal("Inorganic Substance", iS.Name);
        }

        /// <summary>
        /// This test checks that even as the InorganicSubstance's state mutates, the description does not change
        /// </summary>
        /// <param name="ice">If the InorganicSubstance will be served with ice</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void DescriptionShouldAlwaysMatch(bool ice)
        {
            InorganicSubstance iS = new()
            {
                Ice = ice
            };
            Assert.Equal("A cold glass of ice water.", iS.Description);
        }

        /// <summary>
        /// This test checks that even as the InorganicSubstance's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="ice">If Ice is included</param>
        /// <param name="size">The Size of the drink</param>
        /// <param name="calories">The calories in the drink</param>
        /// <remarks>
        /// We supply the expected calories as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected calories are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(true, ServingSize.Small, 0)]
        [InlineData(false, ServingSize.Medium, 0)]
        [InlineData(true, ServingSize.Large, 0)]

        public void CaloriesShouldBeCorrect(bool ice, ServingSize size, uint calories)
        {
            InorganicSubstance iS = new()
            {
                Ice = ice,
                Size = size
            };
            Assert.Equal(calories, iS.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the InorganicSubstance
        /// </summary>
        /// <param name="ice">If served with ice</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, new string[] { })]
        [InlineData(false, new string[] { "No Ice" })]
        public void SpecialInstructionsRelfectsState(bool ice, string[] instructions)
        {
            InorganicSubstance iS = new()
            {
                Ice = ice
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, iS.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, iS.SpecialInstructions.Count());
        }
        #endregion

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
            InorganicSubstance gh = new();

            Assert.PropertyChanged(gh, propertyName, () =>
            {
                gh.Ice = extra;
            });
        }
        /// <summary>
        /// Testing the size changes with the interface
        /// </summary>
        /// <param name="size">size</param>
        /// <param name="propertyName">property name</param>
        [Theory]
        [InlineData(ServingSize.Medium, "Size")]
        [InlineData(ServingSize.Large, "Size")]
        [InlineData(ServingSize.Medium, "Price")]
        [InlineData(ServingSize.Large, "Price")]
        [InlineData(ServingSize.Medium, "Calories")]
        [InlineData(ServingSize.Large, "Calories")]
        public void ChangingSizeShouldNotifyOfPropertyChanges(ServingSize size, string propertyName)
        {
            InorganicSubstance inorg = new();
            Assert.PropertyChanged(inorg, propertyName, () => {
                inorg.Size = size;
            });
        }
    }
}
