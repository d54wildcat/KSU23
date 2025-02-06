using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the CrashedSaucer class
    /// </summary>
    public class CrashedSaucerUnitTest
    {
        #region Default Values
        /// <summary>
        /// Checks that the ToString method returns the name of the entree
        /// </summary>
        [Fact]
        public void ToStringShouldJustBeName()
        {
            CrashedSaucer cs = new();
            Assert.Equal(cs.Name, cs.ToString());
        }
        /// <summary>
        /// Checks that an unaltered Crashed Saucer has 2 french toast
        /// </summary>
        [Fact]
        public void DefaultStackSizeShouldBeTwoFrenchToast()
        {
            CrashedSaucer cs = new();
            Assert.Equal(2u, cs.StackSize);
        }

        /// <summary>
        /// Checks that a unaltered Crashed Saucer is served with syrup 
        /// </summary>
        [Fact]
        public void DefaultServedWithSyrup()
        {
            CrashedSaucer cs = new();
            Assert.True(cs.Syrup);
        }

        /// <summary>
        /// Checks that an unaltered Crashed Saucer is served with butter
        /// </summary>
        [Fact]
        public void DefaultServedWithButter()
        {
            CrashedSaucer cs = new();
            Assert.True(cs.Butter);
        }
        /// <summary>
        /// Checks that an unaltered Crashed Saucer has been assigned to IMenuItem Interface
        /// </summary>
        [Fact]
        public void DefaultShouldBeAssignedToInterface()
        {
            CrashedSaucer cs = new();
            Assert.IsAssignableFrom<IMenuItem>(cs);

        }
        /// <summary>
        /// Checks that an unaltered Crashed Saucer has been assigned to IMenuItem Interface
        /// </summary>
        [Fact]
        public void DefaultShouldBeAssignedToEntree()
        {
            CrashedSaucer cs = new();
            Assert.IsAssignableFrom<Entree>(cs);

        }
        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the CrashedSaucer's state mutates, the name does not change
        /// </summary>
        /// <param name="stackSize">The number of panacakes included</param>
        /// <param name="syrup">If the Crashed Saucer will be served with syrup</param>
        /// <param name="butter">If the Crashed Saucer will be served with berries</param>
        /// <remarks>There are more than 8 possible permutations of state, so we pick a subset to test against</remarks>
        [Theory]
        [InlineData(2, true, true)]
        [InlineData(0, true, true)]
        [InlineData(6, true, true)]
        [InlineData(6, true, false)]
        [InlineData(6, false, false)]
        [InlineData(3, true, false)]
        [InlineData(8, false, false)]
        [InlineData(11, true, true)]
        public void DescriptionShouldAlwaysBeCrashedSaucer(uint stackSize, bool syrup, bool butter)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                Butter = butter
            };
            Assert.Equal("A stack of crispy french toast smothered in syrup and topped with a pat of butter.", cs.Description);
        }

        /// <summary>
        /// This test checks that even as the FlyingSaucer's state mutates, the name does not change
        /// </summary>
        /// <param name="stackSize">The number of panacakes included</param>
        /// <param name="syrup">If the Crashed Saucer will be served with syrup</param>
        /// <param name="butter">If the Crashed Saucer will be served with berries</param>
        /// <remarks>There are more than 8 possible permutations of state, so we pick a subset to test against</remarks>
        [Theory]
        [InlineData(2, true, true)]
        [InlineData(0, true, true)]
        [InlineData(6, true, true)]
        [InlineData(6, true, false)]
        [InlineData(6, false, false)]
        [InlineData(3, true, false)]
        [InlineData(8, false, false)]
        [InlineData(11, true, true)]
        public void NameShouldAlwaysBeCrashedSaucer(uint stackSize, bool syrup, bool butter)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                Butter = butter
            };
            Assert.Equal("Crashed Saucer", cs.Name);
        }

        /// <summary>
        /// This test verifies that a CrashedSaucer's StackSize cannot exceed 6, and 
        /// if it is attempted, the StackSize will be set to 6.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetStackSizeAboveSix()
        {
            CrashedSaucer cs = new();
            cs.StackSize = 7;
            Assert.Equal(6u, cs.StackSize);
        }

        /// <summary>
        /// This test checks that even as the CrashedSaucer's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="stackSize">The number of french toast included</param>
        /// <param name="syrup">If the Crashed Saucer will be served with syrup</param>
        /// <param name="butter">If the Chrashed Saucer will be served with butter</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        /// <remarks>
        /// We supply the expected calories as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected calories are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(2, true, true,  149 * 2 + 52 + 35)]
        [InlineData(0, true, true,  149 * 0 + 52 + 35)]
        [InlineData(6, true, true, 149 * 6 + 52 + 35)]
        [InlineData(6, true, false, 149 * 6 + 52 + 0)]
        [InlineData(6, false, false, 149 * 6 + 0 + 0)]
        [InlineData(3, true, false, 149 * 3 + 52 + 0)]
        [InlineData(4, false, false, 149 * 4 + 0 + 0)]
        [InlineData(5, true, true, 149 * 5 + 52 + 35)]
        public void CaloriesShouldBeCorrect(uint stackSize, bool syrup, bool butter, uint calories)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                Butter = butter
            };
            Assert.Equal(calories, cs.Calories);

        }

        /// <summary>
        /// This Test verifies that the CrashedSaucer's Price is correct, given the number of french toast
        /// </summary>
        /// <param name="stackSize">The amount of french toast</param>
        /// <param name="price">The price of the item</param>
        [Theory]
        [InlineData(2, 6.45)]
        [InlineData(6, 12.45)]
        [InlineData(4, 9.45)]
        [InlineData(3, 7.95)]
        public void PriceShouldBeCorrect(uint stackSize, decimal price)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize
            };
            Assert.Equal(price, cs.Price);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Crashed Saucer
        /// </summary>
        /// <param name="stackSize">The number of french toasts</param>
        /// <param name="syrup">If served with syrup</param>
        /// <param name="butter">If served with butter</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(2, true, true, new string[] { })]
        [InlineData(4, true, true, new string[] { "4 Slices" })]
        public void SpecialInstructionsRelfectsState(uint stackSize, bool syrup, bool butter, string[] instructions)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                Butter = butter
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, cs.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, cs.SpecialInstructions.Count());
        }

        /// <summary>
        /// This test checks that the CrashedSaucer's ToString() method returns the name of the item
        /// </summary>
        [Fact]
        public void NameShouldShouldBeSameFromToString(){
            CrashedSaucer cs = new CrashedSaucer();
            Assert.Equal(cs.Name, cs.ToString());
        }
        #endregion

        #region INotifyPropertyChanged Tests
        /// <summary>
        /// This test checks that the CrashedSaucer implements the INotifyPropertyChanged interface with StackSize
        /// </summary>
        /// <param name="stackSize">stack size</param>
        /// <param name="propertyName">property Name</param>
        [Theory]
        [InlineData(4, "StackSize")]
        [InlineData(2, "StackSize")]
        [InlineData(3, "StackSize")]
        [InlineData(1, "Price")]
        [InlineData(5, "Price")]
        [InlineData(6, "Price")]
        [InlineData(4, "Calories")]
        [InlineData(3, "Calories")]
        [InlineData(5, "Calories")]
        public void ChangingSizeShouldNotifyOfPropertyChanges(uint stackSize, string propertyName)
        {
            CrashedSaucer cs = new();
            Assert.PropertyChanged(cs, propertyName, () => {
                cs.StackSize = stackSize;
            });
        }
        /// <summary>
        /// changing syrup changes properties
        /// </summary>
        /// <param name="extra">the sauce</param>
        /// <param name="propertyName">the property name</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        [InlineData(false, "Syrup")]
        public void ChangingSyrupShouldNotifyPropertyChanged(bool extra, string propertyName)
        {
            CrashedSaucer gh = new();

            Assert.PropertyChanged(gh, propertyName, () =>
            {
                gh.Syrup = extra;
            });
        }
        /// <summary>
        /// changing butter changes properties
        /// </summary>
        /// <param name="extra">the sauce</param>
        /// <param name="propertyName">the property name</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        [InlineData(false, "Butter")]
        public void ChangingButterShouldNotifyPropertyChanged(bool extra, string propertyName)
        {
            CrashedSaucer gh = new();

            Assert.PropertyChanged(gh, propertyName, () =>
            {
                gh.Butter = extra;
            });
        }
        #endregion

    }
}
