using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit Tests for the LivestockMutilation class
    /// </summary>
    public class LivestockMutilationUnitTest
    {
        #region Default Values
        /// <summary>
        /// Checks that the ToString method returns the name of the entree
        /// </summary>
        [Fact]
        public void ToStringShouldJustBeName()
        {
            LivestockMutilation lm = new();
            Assert.Equal(lm.Name, lm.ToString());
        }
        /// <summary>
        /// Checks that an unaltered Livestock Mutilation has 3 biscuits
        /// </summary>
        [Fact]
        public void DefaultStackSizeShouldBeThreeBiscuits()
        {
            LivestockMutilation lm = new();
            Assert.Equal(3u, lm.Biscuits);
        }

        /// <summary>
        /// Checks that a unaltered Livestock Mutilation is served with gravy 
        /// </summary>
        [Fact]
        public void DefaultServedWithGravy()
        {
            LivestockMutilation lm = new();
            Assert.True(lm.Gravy);
        }
        /// <summary>
        /// Checks that an unaltered LivestockMutilation has been assigned to IMenuItem Interface
        /// </summary>
        [Fact]
        public void DefaultShouldBeAssignedToInterface()
        {
            LivestockMutilation lm = new();
            Assert.IsAssignableFrom<IMenuItem>(lm);

        }
        /// <summary>
        /// Checks that an unaltered LivestockMutilation has been assigned to IMenuItem Interface
        /// </summary>
        [Fact]
        public void DefaultShouldBeAssignedToEntree()
        {
            LivestockMutilation lm = new();
            Assert.IsAssignableFrom<Entree>(lm);

        }
        #endregion

        #region state changes
        /// <summary>
        /// This test checks that even as the LivestockMutilation's state mutates, the name does not change
        /// </summary>
        /// <param name="biscuits">The number of biscuits included</param>
        /// <param name="gravy">If the LivestockMutilation will be served with gravy</param>
        [Theory]
        [InlineData(2, true)]
        [InlineData(0, true)]
        [InlineData(6, true)]
        [InlineData(6, false)]
        [InlineData(3, true)]
        [InlineData(8, false)]
        [InlineData(11, true)]
        public void NameShouldAlwaysBeLivestockMutilation(uint biscuits, bool gravy)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = biscuits,
                Gravy = gravy,
            };
            Assert.Equal("Livestock Mutilation", lm.Name);
        }

        /// <summary>
        /// This test checks that even as the LivestockMutilation's state mutates, the description does not change
        /// </summary>
        /// <param name="biscuits">The number of biscuits included</param>
        /// <param name="gravy">If the LivestockMutilation will be served with gravy</param>
        [Theory]
        [InlineData(2, true)]
        [InlineData(0, true)]
        [InlineData(6, true)]
        [InlineData(6, false)]
        [InlineData(3, true)]
        [InlineData(8, false)]
        [InlineData(11, true)]
        public void DescriptionShouldAlwaysMatch(uint biscuits, bool gravy)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = biscuits,
                Gravy = gravy,
            };
            Assert.Equal("A hearty serving of biscuits, smothered in sausage-laden gravy.", lm.Description);
        }

        /// <summary>
        /// This test verifies that a CrashedSaucer's StackSize cannot exceed 6, and 
        /// if it is attempted, the StackSize will be set to 6.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetBiscuitsAboveEight()
        {
            LivestockMutilation lm = new();
            lm.Biscuits = 9;
            Assert.Equal(8u, lm.Biscuits);
        }

        /// <summary>
        /// This test checks that even as the LivestockMutilation's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="biscuits">The number of biscuits included</param>
        /// <param name="gravy">If the Livestock Mutilation will be served with gravy</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        /// <remarks>
        /// We supply the expected calories as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected calories are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(2, true,  49 * 2 + 140)]
        [InlineData(0, true,  49 * 0 + 140)]
        [InlineData(6, true,  49 * 6 + 140)]
        [InlineData(6, false, 49 * 6 + 0)]
        [InlineData(3, true,  49 * 3 + 140)]
        [InlineData(4, false, 49 * 4 + 0)]
        [InlineData(5, true,  49 * 5 + 140)]
        public void CaloriesShouldBeCorrect(uint biscuits, bool gravy, uint calories)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = biscuits,
                Gravy = gravy,
            };
            Assert.Equal(calories, lm.Calories);
        }

        /// <summary>
        /// This Test verifies that the LivestockMutilation's Price is correct, given the number of french toast
        /// </summary>
        /// <param name="biscuit">The amount of biscuits</param>
        /// <param name="price">The price of the item</param>
        [Theory]
        [InlineData(3, 7.25)]
        [InlineData(6, 10.25)]
        [InlineData(4, 8.25)]
        [InlineData(8, 12.25)]
        public void PriceShouldBeCorrect(uint biscuit, decimal price)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = biscuit
            };
            Assert.Equal(price, lm.Price);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Livestock Mutilation
        /// </summary>
        /// <param name="biscuits">The number of biscuits</param>
        /// <param name="gravy">If served with gravy</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(3, true, new string[] { })]
        [InlineData(6, true, new string[] { "6 biscuits" })]
        public void SpecialInstructionsRelfectsState(uint biscuits, bool gravy, string[] instructions)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = biscuits,
                Gravy = gravy,
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, lm.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, lm.SpecialInstructions.Count());
        }
        #endregion

        /// <summary>
        /// changing gravy changes properties
        /// </summary>
        /// <param name="extra">the sauce</param>
        /// <param name="propertyName">the property name</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        [InlineData(false, "Gravy")]
        public void ChangingGravyShouldNotifyPropertyChanged(bool extra, string propertyName)
        {
            LivestockMutilation gh = new();

            Assert.PropertyChanged(gh, propertyName, () =>
            {
                gh.Gravy = extra;
            });
        }
        /// <summary>
        /// This test checks that the class implements the INotifyPropertyChanged interface with biscuits
        /// </summary>
        /// <param name="biscuits">stack size</param>
        /// <param name="propertyName">property Name</param>
        [Theory]
        [InlineData(7, "Biscuits")]
        [InlineData(8, "Biscuits")]
        [InlineData(2, "Biscuits")]
        [InlineData(1, "Price")]
        [InlineData(5, "Price")]
        [InlineData(6, "Price")]
        [InlineData(4, "Calories")]
        [InlineData(3, "Calories")]
        [InlineData(5, "Calories")]
        public void ChangingSizeShouldNotifyOfPropertyChanges(uint biscuits, string propertyName)
        {
            LivestockMutilation cs = new();
            Assert.PropertyChanged(cs, propertyName, () => {
                cs.Biscuits = biscuits;
            });
        }
    }
}
