using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit Tests for the TakenBacon class
    /// </summary>
    public class MissingLinksUnitTest
    {
        #region Default Values
        /// <summary>
        /// Checks that the ToString method returns the name of the side
        /// </summary>
        [Fact]
        public void ToStringShouldJustBeName()
        {
            MissingLinks ml = new();
            Assert.Equal(ml.Name, ml.ToString());
        }
        /// <summary>
        /// Checks that an unaltered MissingLinks has 2 links
        /// </summary>
        [Fact]
        public void DefaultStackSizeShouldBeTwoLinks()
        {
            MissingLinks ml = new();
            Assert.Equal(2u, ml.Count);
        }
        /// <summary>
        /// Checks that an unaltered MissingLinks has been assigned to IMenuItem Interface
        /// </summary>
        [Fact]
        public void DefaultShouldBeAssignedToInterface()
        {
            MissingLinks ml = new();
            Assert.IsAssignableFrom<IMenuItem>(ml);

        }
        /// <summary>
        /// Checks that an unaltered MissingLinks has been assigned to Side Class
        /// </summary>
        [Fact]
        public void DefaultShouldBeAssignedToSide()
        {
            MissingLinks ml = new();
            Assert.IsAssignableFrom<Side>(ml);

        }
        #endregion

        #region state changes
        /// <summary>
        /// This test checks that even as the MissingLinks's state mutates, the name does not change
        /// </summary>
        /// <param name="count">How many links</param>
        [Theory]
        [InlineData(2)]
        [InlineData(8)]
        public void NameShouldAlwaysBeMissingLinks(uint count)
        {
            MissingLinks ml = new()
            {
                Count = count
            };
            Assert.Equal("Missing Links", ml.Name);
        }

        /// <summary>
        /// This test checks that even as the MissingLinks's state mutates, the description does not change
        /// </summary>
        /// <param name="count">How many strips of bacon</param>
        [Theory]
        [InlineData(2)]
        [InlineData(8)]
        public void DescriptionShouldAlwaysMatch(uint count)
        {
            MissingLinks ml = new()
            {
                Count = count
            };
            Assert.Equal("Sizzling pork sausage links.", ml.Description);
        }

        /// <summary>
        /// This test checks that even as the MissingLinks's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="count">The amount of links</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        /// <remarks>
        /// We supply the expected calories as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected calories are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(2, 782)]
        [InlineData(3, 1173)]
        [InlineData(4, 1564)]
        [InlineData(5, 1955)]
        [InlineData(8, 3128)]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            MissingLinks ml = new()
            {
                Count = count
            };
            Assert.Equal(calories, ml.Calories);
        }

        /// <summary>
        /// This Test verifies that the MissingLinks's Price is correct, given the number of strips
        /// </summary>
        /// <param name="count">The amount of links</param>
        /// <param name="price">The price of the item</param>
        [Theory]
        [InlineData(1, 1.00)]
        [InlineData(2, 2.00)]
        [InlineData(4, 4.00)]
        [InlineData(6, 6.00)]
        [InlineData(8, 8.00)]
        public void PriceShouldBeCorrect(uint count, decimal price)
        {
            MissingLinks ml = new()
            {
                Count = count
            };
            Assert.Equal(price, ml.Price);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the MissingLinks class
        /// </summary>
        /// <param name="count">The amount of links</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(2, new string[] { })]
        [InlineData(3, new string[] { "3 links" })]
        [InlineData(4, new string[] { "4 links" })]
        [InlineData(6, new string[] { "6 links" })]
        public void SpecialInstructionsRelfectsState(uint count, string[] instructions)
        {
            MissingLinks ml = new()
            {
                Count = count
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, ml.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, ml.SpecialInstructions.Count());
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
            MissingLinks cs = new();
            Assert.PropertyChanged(cs, propertyName, () => {
                cs.Count = count;
            });
        }
    }
}
