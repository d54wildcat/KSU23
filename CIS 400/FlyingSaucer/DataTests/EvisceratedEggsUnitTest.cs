using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit Tests for the EvisceratedEggs class
    /// </summary>
    public class EvisceratedEggstUnitTest
    {
        #region Default Values
        /// <summary>
        /// Checks that the ToString method returns the name of the side
        /// </summary>
        [Fact]
        public void ToStringShouldJustBeName()
        {
            EvisceratedEggs ee = new();
            Assert.Equal(ee.Name, ee.ToString());
        }
        /// <summary>
        /// Checks that an unaltered EvisceratedEggs has 2 eggs
        /// </summary>
        [Fact]
        public void DefaultStackSizeShouldBeTwoEggs()
        {
            EvisceratedEggs ee = new();
            Assert.Equal(2u, ee.Count);
        }

        /// <summary>
        /// need a test to determine default style of over easy
        /// </summary>
        [Fact]
        public void DefaultStyleShouldBeOverEasy()
        {
            EvisceratedEggs ee = new();
            Assert.Equal(EggStyle.OverEasy, ee.Style);
        }
        /// <summary>
        /// Checks that an unaltered Eviscerated Eggs has been assigned to IMenuItem Interface
        /// </summary>
        [Fact]
        public void DefaultShouldBeAssignedToInterface()
        {
            EvisceratedEggs ee = new();
            Assert.IsAssignableFrom<IMenuItem>(ee);

        }
        /// <summary>
        /// Checks that an unaltered Eviscerated Eggs has been assigned to Side Class
        /// </summary>
        [Fact]
        public void DefaultShouldBeAssignedToSide()
        {
            EvisceratedEggs ee = new();
            Assert.IsAssignableFrom<Side>(ee);

        }

        #endregion

        #region state changes
        /// <summary>
        /// This test checks that even as the EvisceratedEggs's state mutates, the name does not change
        /// </summary>
        /// <param name="count">How many eggs</param>
        [Theory]
        [InlineData(2)]
        [InlineData(1)]
        [InlineData(6)]
        public void NameShouldAlwaysBeYouAreToast(uint count)
        {
            EvisceratedEggs ee = new()
            {
                Count = count
            };
            Assert.Equal("Eviscerated Eggs", ee.Name);
        }

        /// <summary>
        /// This test checks that even as the EvisceratedEggs's state mutates, the description does not change
        /// </summary>
        /// <param name="count">How many eggs</param>
        [Theory]
        [InlineData(2)]
        [InlineData(1)]
        [InlineData(6)]
        public void DescriptionShouldAlwaysMatch(uint count)
        {
            EvisceratedEggs ee = new()
            {
                Count = count
            };
            Assert.Equal("Eggs prepared the way you like.", ee.Description);
        }

        /// <summary>
        /// This test checks that even as the EvisceratedEggs's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="count">The amount of eggs</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        /// <remarks>
        /// We supply the expected calories as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected calories are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(2, 156)]
        [InlineData(1, 78)]
        [InlineData(4, 312)]
        [InlineData(6, 468)]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            EvisceratedEggs ee = new()
            {
                Count = count
            };
            Assert.Equal(calories, ee.Calories);
        }

        /// <summary>
        /// This Test verifies that the EvisceratedEggs's Price is correct, given the number of strips
        /// </summary>
        /// <param name="count">The amount of eggs</param>
        /// <param name="price">The price of the item</param>
        [Theory]
        [InlineData(1, 1.00)]
        [InlineData(3, 3.00)]
        [InlineData(6, 6.00)]
        [InlineData(2, 2.00)]
        public void PriceShouldBeCorrect(uint count, decimal price)
        {
            EvisceratedEggs ee = new()
            {
                Count = count
            };
            Assert.Equal(price, ee.Price);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the EvisceratedEggs class
        /// </summary>
        /// <param name="count">The amount of eggs</param>
        /// <param name="style"> The style of the eggs</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(2, new string[] { })]
        [InlineData(1, new string[] { "1 eggs, Over Easy" })]
        [InlineData(3, new string[] { "3 OverEasy eggs" })]
        [InlineData(4, new string[] { "4 OverEasy eggs" })]
        [InlineData(5, new string[] { "5 OverEasy eggs" })]
        [InlineData(6, new string[] { "6 OverEasy eggs" })]
        public void SpecialInstructionsRelfectsState(uint count, string[] instructions)
        {
            EvisceratedEggs ee = new()
            {
                Count = count
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, ee.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, ee.SpecialInstructions.Count());
        }
        #endregion.

        /// <summary>
        /// This test checks that the class implements the INotifyPropertyChanged interface with Count
        /// </summary>
        /// <param name="stackSize">count</param>
        /// <param name="propertyName">property Name</param>
        [Theory]
        [InlineData(4, "Count")]
        [InlineData(2, "Count")]
        [InlineData(3, "Count")]
        [InlineData(1, "Price")]
        [InlineData(5, "Price")]
        [InlineData(6, "Price")]
        [InlineData(4, "Calories")]
        [InlineData(3, "Calories")]
        [InlineData(5, "Calories")]
        public void ChangingSizeShouldNotifyOfPropertyChanges(uint stackSize, string propertyName)
        {
            EvisceratedEggs cs = new();
            Assert.PropertyChanged(cs, propertyName, () => {
                cs.Count = stackSize;
            });
        }
        /// <summary>
        /// Tests the Eggstyle with the interface
        /// </summary>
        /// <param name="style">style</param>
        /// <param name="propertyName">the name</param>
        [Theory]
        [InlineData(EggStyle.Poached, "Style")]
        [InlineData(EggStyle.HardBoiled, "Style")]
        [InlineData(EggStyle.SoftBoiled, "Style")]
        [InlineData(EggStyle.SunnySideUp, "Style")]
        [InlineData(EggStyle.Scrambled, "Style")]
        public void ChangingEggStyleShouldNotifyPropertyChanged(EggStyle style, string propertyName)
        {
            EvisceratedEggs cs = new();
            Assert.PropertyChanged(cs, propertyName, () =>
            {
                cs.Style = style;
            });
        }

    }
}
