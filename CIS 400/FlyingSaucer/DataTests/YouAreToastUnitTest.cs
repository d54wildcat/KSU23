using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit Tests for the YouAreToast class
    /// </summary>
    public class YouAreToastUnitTest
    {
        #region Default Values
        /// <summary>
        /// Checks that the ToString method returns the name of the side
        /// </summary>
        [Fact]
        public void ToStringShouldJustBeName()
        {
            YouAreToast yt = new();
            Assert.Equal(yt.Name, yt.ToString());
        }
        /// <summary>
        /// Checks that an unaltered YouAreToast has 2 links
        /// </summary>
        [Fact]
        public void DefaultStackSizeShouldBeTwoToast()
        {
            YouAreToast yt = new();
            Assert.Equal(2u, yt.Count);
        }
        /// <summary>
        /// Checks that an unaltered YouAreToast has been assigned to IMenuItem Interface
        /// </summary>
        [Fact]
        public void DefaultShouldBeAssignedToInterface()
        {
            YouAreToast yt = new();
            Assert.IsAssignableFrom<IMenuItem>(yt);

        }
        /// <summary>
        /// Checks that an unaltered YouAreToast has been assigned to Side Class
        /// </summary>
        [Fact]
        public void DefaultShouldBeAssignedToSide()
        {
            YouAreToast yt = new();
            Assert.IsAssignableFrom<Side>(yt);

        }
        #endregion

        #region state changes
        /// <summary>
        /// This test checks that even as the YouAreToast's state mutates, the name does not change
        /// </summary>
        /// <param name="count">How much toast</param>
        [Theory]
        [InlineData(2)]
        [InlineData(12)]
        public void NameShouldAlwaysBeYouAreToast(uint count)
        {
            YouAreToast yt = new()
            {
                Count = count
            };
            Assert.Equal("You're Toast", yt.Name);
        }

        /// <summary>
        /// This test checks that even as the YouAreToast's state mutates, the description does not change
        /// </summary>
        /// <param name="count">How much toast</param>
        [Theory]
        [InlineData(2)]
        [InlineData(12)]
        public void DescriptionShouldAlwaysMatch(uint count)
        {
            YouAreToast yt = new()
            {
                Count = count
            };
            Assert.Equal("Texas Toast.", yt.Description);
        }

        /// <summary>
        /// This test checks that even as the YouAreToast's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="count">The amount of toast</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        /// <remarks>
        /// We supply the expected calories as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected calories are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(2, 200)]
        [InlineData(6, 600)]
        [InlineData(8, 800)]
        [InlineData(10, 1000)]
        [InlineData(12, 1200)]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            YouAreToast yt = new()
            {
                Count = count
            };
            Assert.Equal(calories, yt.Calories);
        }

        /// <summary>
        /// This Test verifies that the YouAreToast's Price is correct, given the number of strips
        /// </summary>
        /// <param name="count">The amount of toast</param>
        /// <param name="price">The price of the item</param>
        [Theory]
        [InlineData(1, 1.00)]
        [InlineData(8, 8.00)]
        [InlineData(6, 6.00)]
        [InlineData(12, 12.00)]
        public void PriceShouldBeCorrect(uint count, decimal price)
        {
            YouAreToast yt = new()
            {
                Count = count
            };
            Assert.Equal(price, yt.Price);
        }   

        /// <summary>
        /// Checks that the special instructions reflect the current state of the YouAreToast class
        /// </summary>
        /// <param name="count">The amount of toast</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(2, new string[] { })]
        [InlineData(4, new string[] { "4 slices" })]
        [InlineData(6, new string[] { "6 slices" })]
        [InlineData(8, new string[] { "8 slices" })]
        [InlineData(10, new string[] { "10 slices" })]
        [InlineData(12, new string[] { "12 slices" })]
        public void SpecialInstructionsRelfectsState(uint count, string[] instructions)
        {
            YouAreToast yt = new()
            {
                Count = count
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, yt.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, yt.SpecialInstructions.Count());
        }
        #endregion

        /// <summary>
        /// This test checks that the class implements the INotifyPropertyChanged interface with Count
        /// </summary>
        /// <param name="count">stack size</param>
        /// <param name="propertyName">property Name</param>
        [Theory]
        [InlineData(4, "Count")]
        [InlineData(8, "Count")]
        [InlineData(2, "Count")]
        [InlineData(1, "Price")]
        [InlineData(5, "Price")]
        [InlineData(6, "Price")]
        [InlineData(4, "Calories")]
        [InlineData(3, "Calories")]
        [InlineData(5, "Calories")]
        public void ChangingSizeShouldNotifyOfPropertyChanges(uint count, string propertyName)
        {
            YouAreToast cs = new();
            Assert.PropertyChanged(cs, propertyName, () => {
                cs.Count = count;
            });
        }
    }
}
