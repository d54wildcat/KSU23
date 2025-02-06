using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit Tests for the CropCircle class
    /// </summary>
    public class CropCircleUnitTest
    {
        /// <summary>
        /// Checks that the ToString method returns the name of the side
        /// </summary>
        #region Default Values
        [Fact]
        public void ToStringShouldJustBeName()
        {
            CropCircle cc = new();
            Assert.Equal(cc.Name, cc.ToString());
        }
        /// <summary>
        /// Checks that a unaltered CropCircle is served with berries 
        /// </summary>
        [Fact]
        public void DefaultServedWithBerries()
        {
            CropCircle cc = new();
            Assert.True(cc.Berries);
        }
        /// <summary>
        /// This Test verifies that the Crop Circle's Price is correct
        /// </summary>
        /// <param name="price">The price of the item</param>
        [Theory]
        [InlineData(2.00)]
        public void PriceShouldBeCorrect(decimal price)
        {
            CropCircle cc = new();
            Assert.Equal(price, cc.Price, 0);
        }
        /// <summary>
        /// This test verifies that an unaltered Crop Circle is assigned to the IMenuItem Interface
        /// </summary>
        [Fact]
        public void DefaultShouldBeAssignedToInterface()
        {
            CropCircle cc = new();
            Assert.IsAssignableFrom<IMenuItem>(cc);

        }
        /// <summary>
        /// This test verifies that an unaltered Crop Circle is assigned to the Side Class
        /// </summary>
        [Fact]
        public void DefaultShouldBeAssignedToSide()
        {
            CropCircle cc = new();
            Assert.IsAssignableFrom<Side>(cc);

        }
        #endregion

        #region state changes
        /// <summary>
        /// This test checks that even as the CropCircle's state mutates, the name does not change
        /// </summary>
        /// <param name="berries">If the CropCircle will be served with berries</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void NameShouldAlwaysBeCropCircle(bool berries)
        {
            CropCircle cc = new()
            {
                Berries = berries
            };
            Assert.Equal("Crop Circle", cc.Name);
        }

        /// <summary>
        /// This test checks that even as the CropCircle's state mutates, the description does not change
        /// </summary>
        /// <param name="berries">If the CropCircle will be served with berries</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void DescriptionShouldAlwaysMatch(bool berries)
        {
            CropCircle cc = new()
            {
                Berries = berries
            };
            Assert.Equal("Oatmeal topped with mixed berries.", cc.Description);
        }

        /// <summary>
        /// This test checks that even as the CropCircle's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="biscuits">The number of biscuits included</param>
        /// <param name="berries">If the CropCircle will be served with berries</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        /// <remarks>
        /// We supply the expected calories as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected calories are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(true, 158 + 89)]
        [InlineData(false, 158)]
        public void CaloriesShouldBeCorrect(bool berries, uint calories)
        {
            CropCircle cc = new()
            {
                Berries = berries
            };
            Assert.Equal(calories, cc.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the CropCircle
        /// </summary>
        /// <param name="biscuits">The number of biscuits</param>
        /// <param name="berries">If served with berries</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, new string[] { })]
        [InlineData(false, new string[] { "Hold Berries" })]
        public void SpecialInstructionsRelfectsState(bool berries, string[] instructions)
        {
            CropCircle cc = new()
            {
                Berries = berries
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, cc.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, cc.SpecialInstructions.Count());
        }
        #endregion
        /// <summary>
        /// changing berries changes properties
        /// </summary>
        /// <param name="extra">the sauce</param>
        /// <param name="propertyName">the property name</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        [InlineData(false, "Berries")]
        public void ChangingBerrieaShouldNotifyPropertyChanged(bool extra, string propertyName)
        {
            CropCircle gh = new();

            Assert.PropertyChanged(gh, propertyName, () =>
            {
                gh.Berries = extra;
            });
        }
    }
}
