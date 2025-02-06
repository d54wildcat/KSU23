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
    public class TakenBaconUnitTest
    {
        #region Default Values
        /// <summary>
        /// Checks that the ToString method returns the name of the side
        /// </summary>
        [Fact]
        public void ToStringShouldJustBeName()
        {
            TakenBacon tb = new();
            Assert.Equal(tb.Name, tb.ToString());
        }
        /// <summary>
        /// Checks that an unaltered Taken Bacon has 2 strips
        /// </summary>
        [Fact]
        public void DefaultStackSizeShouldBeTwoStrips()
        {
            TakenBacon tb = new();
            Assert.Equal(2u, tb.Count);
        }
        /// <summary>
        /// Checks that an unaltered TakenBacon has been assigned to IMenuItem Interface
        /// </summary>
        [Fact]
        public void DefaultShouldBeAssignedToInterface()
        {
            TakenBacon tb = new();
            Assert.IsAssignableFrom<IMenuItem>(tb);

        }
        /// <summary>
        /// Checks that an unaltered TakenBacon has been assigned to Side Class
        /// </summary>
        [Fact]
        public void DefaultShouldBeAssignedToSide()
        {
            TakenBacon tb = new();
            Assert.IsAssignableFrom<Side>(tb);

        }

        #endregion

        #region state changes
        /// <summary>
        /// This test checks that even as the TakenBacon's state mutates, the name does not change
        /// </summary>
        /// <param name="count">How many strips of bacon</param>
        [Theory]
        [InlineData(2)]
        [InlineData(6)]
        public void NameShouldAlwaysBeTaconBacon(uint count)
        {
            TakenBacon tb = new()
            {
                Count = count
            };
            Assert.Equal("Taken Bacon", tb.Name);
        }

        /// <summary>
        /// This test checks that even as the TakenBacon's state mutates, the description does not change
        /// </summary>
        /// <param name="count">How many strips of bacon</param>
        [Theory]
        [InlineData(2)]
        [InlineData(6)]
        public void DescriptionShouldAlwaysMatch(uint count)
        {
            TakenBacon tb = new()
            {
                Count = count
            };
            Assert.Equal("Crispy strips of bacon.", tb.Description);
        }

        /// <summary>
        /// This test checks that even as the TakenBacon's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="count">The amount of strips of bacon</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        /// <remarks>
        /// We supply the expected calories as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected calories are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(2, 86)]
        [InlineData(3, 129)]
        [InlineData(4, 172)]
        [InlineData(5, 215)]
        [InlineData(6, 258)]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            TakenBacon tb = new()
            {
                Count = count
            };
            Assert.Equal(calories, tb.Calories);
        }

        /// <summary>
        /// This Test verifies that the TakenBacon's Price is correct, given the number of strips
        /// </summary>
        /// <param name="count">The amount of strips</param>
        /// <param name="price">The price of the item</param>
        [Theory]
        [InlineData(1, 1.00)]
        [InlineData(2, 2.00)]
        [InlineData(4, 4.00)]
        [InlineData(6, 6.00)]
        public void PriceShouldBeCorrect(uint count, decimal price)
        {
            TakenBacon tb = new()
            {
                Count = count
            };
            Assert.Equal(price, tb.Price);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the TakenBacon
        /// </summary>
        /// <param name="count">The amount of strips of bacon</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(2, new string[] { })]
        [InlineData(3, new string[] { "3 strips" })]
        [InlineData(4, new string[] { "4 strips" })]
        [InlineData(6, new string[] { "6 strips" })]
        public void SpecialInstructionsRelfectsState(uint count, string[] instructions)
        {
            TakenBacon tb = new()
            {
                Count = count
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, tb.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, tb.SpecialInstructions.Count());
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
            TakenBacon cs = new();
            Assert.PropertyChanged(cs, propertyName, () => {
                cs.Count = count;
            });
        }
    }
}
