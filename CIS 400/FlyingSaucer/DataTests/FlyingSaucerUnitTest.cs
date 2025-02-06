namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the FlyingSaucer class
    /// </summary>
    public class FlyingSaucerUnitTest
    {
        #region default values
        /// <summary>
        /// Checks that the ToString method returns the name of the entree
        /// </summary>
        [Fact]
        public void ToStringShouldJustBeName()
        {
            FlyingSaucer fs = new();
            Assert.Equal(fs.Name, fs.ToString());
        }
        /// <summary>
        /// Checks that an unaltered Flying Saucer has 6 panacakes
        /// </summary>
        [Fact]
        public void DefaultStackSizeShouldBeSixPancakes()
        {
            FlyingSaucer fs = new();
            Assert.Equal(6u, fs.StackSize);
        }

        /// <summary>
        /// Checks that a unaltered Flying Saucer is served with syrup 
        /// </summary>
        [Fact]
        public void DefaultServedWithSyrup()
        {
            FlyingSaucer fs = new();
            Assert.True(fs.Syrup);
        }

        /// <summary>
        /// Checks that an unaltered Flying Saucer is served with berries
        /// </summary>
        [Fact]
        public void DefaultServedWithBerries()
        {
            FlyingSaucer fs = new();
            Assert.True(fs.Berries);
        }

        /// <summary>
        /// Checks that an unmodified Flying Saucer is served with whipped cream
        /// </summary>
        [Fact]
        public void DefaultServedWithWhippedCream()
        {
            FlyingSaucer fs = new();
            Assert.True(fs.WhippedCream);
        }
        /// <summary>
        /// Checks that an unaltered Flying Saucer has been assigned to IMenuItem Interface
        /// </summary>
        [Fact]
        public void DefaultShouldBeAssignedToInterface()
        {
            FlyingSaucer fs = new();
            Assert.IsAssignableFrom<IMenuItem>(fs);

        }
        /// <summary>
        /// Checks that an unaltered Flying Saucer has been assigned to Entree Class
        /// </summary>
        [Fact]
        public void DefaultShouldBeAssignedToEntree()
        {
            FlyingSaucer fs = new();
            Assert.IsAssignableFrom<Entree>(fs);

        }
        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the FlyingSaucer's state mutates, the name does not change
        /// </summary>
        /// <param name="stackSize">The number of panacakes included</param>
        /// <param name="syrup">If the Flying Saucer will be served with syrup</param>
        /// <param name="whippedCream">If the Flying Saucer will be served with whipped cream</param>
        /// <param name="berries">If the Flying Saucer will be served with berries</param>
        /// <remarks>There are more than 8 possible permutations of state, so we pick a subset to test against</remarks>
        [Theory]
        [InlineData(6, true, true, true)]
        [InlineData(0, true, true, true)]
        [InlineData(12, true, true, true)]
        [InlineData(6, true, false, true)]
        [InlineData(6, false, false, true)]
        [InlineData(3, true, false, false)]
        [InlineData(8, false, false, false)]
        [InlineData(11, true, true, false)]
        public void NameShouldAlwaysBeFlyingSaucer(uint stackSize, bool syrup, bool whippedCream, bool berries)
        {
            FlyingSaucer fs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                WhippedCream = whippedCream,
                Berries = berries
            };
            Assert.Equal("Flying Saucer", fs.Name);
        }

        /// <summary>
        /// This test checks that even as the FlyingSaucer's state mutates, the description reflects that state
        /// </summary>
        /// <param name="stackSize">The number of panacakes included</param>
        /// <param name="syrup">If the Flying Saucer will be served with syrup</param>
        /// <param name="whippedCream">If the Flying Saucer will be served with whipped cream</param>
        /// <param name="berries">If the Flying Saucer will be served with berries</param>
        /// <remarks>There are more than 8 possible permutations of state, so we pick a subset to test against</remarks>
        [Theory]
        [InlineData(6, true, true, true)]
        [InlineData(0, true, true, true)]
        [InlineData(12, true, true, true)]
        [InlineData(6, true, false, true)]
        [InlineData(6, false, false, true)]
        [InlineData(3, true, false, false)]
        [InlineData(8, false, false, false)]
        [InlineData(11, true, true, false)]
        public void DescriptionShouldAlwaysBeTheSame(uint stackSize, bool syrup, bool whippedCream, bool berries)
        {
            FlyingSaucer fs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                WhippedCream = whippedCream,
                Berries = berries
            };
            Assert.Equal("A stack of six pancakes, smothered in rich maple syrup, and topped with mixed berries and whipped cream.", fs.Description);
        }

        /// <summary>
        /// This test verifies that a FlyingSaucer's StackSize cannot exceed 12, and 
        /// if it is attempted, the StackSize will be set to 12.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetStackSizeAboveTwelve()
        {
            FlyingSaucer fs = new();
            fs.StackSize = 13;
            Assert.Equal(12u, fs.StackSize);
        }

        /// <summary>
        /// This Test verifies that the FlyingSaucer's Price is correct, given the number of pancakes
        /// </summary>
        /// <param name="stackSize">The amount of pancakes</param>
        /// <param name="price">The price of the item</param>
        [Theory]
        [InlineData(6, 8.50)]
        [InlineData(8, 10)]
        [InlineData(10, 11.50)]
        [InlineData(7, 9.25)]
        public void PriceShouldBeCorrect(uint stackSize, decimal price)
        {
            FlyingSaucer fs = new()
            {
                StackSize = stackSize
            };
            Assert.Equal(price, fs.Price);
        }

        /// <summary>
        /// This test checks that even as the FlyingSaucer's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="stackSize">The number of panacakes included</param>
        /// <param name="syrup">If the Flying Saucer will be served with syrup</param>
        /// <param name="whippedCream">If the Flying Saucer will be served with whipped cream</param>
        /// <param name="berries">If the Flying Saucer will be served with berries</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        /// <remarks>
        /// We supply the expected calories as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected calories are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(6, true, true, true, 64 * 6 + 32 + 414 + 89)]
        [InlineData(0, true, true, true, 64 * 0 + 32 + 414 + 89)]
        [InlineData(12, true, true, true, 64 * 12 + 32 + 414 + 89)]
        [InlineData(6, true, false, true, 64 * 6 + 32 + 0 + 89)]
        [InlineData(6, false, false, true, 64 * 6 + 0 + 0 + 89)]
        [InlineData(3, true, false, false, 64 * 3 + 32 + 0 + 0)]
        [InlineData(8, false, false, false, 64 * 8 + 0 + 0 + 0)]
        [InlineData(11, true, true, false, 64 * 11 + 32 + 414 + 0)]
        public void CaloriesShouldBeCorrect(uint stackSize, bool syrup, bool whippedCream, bool berries, uint calories)
        {
            FlyingSaucer fs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                WhippedCream = whippedCream,
                Berries = berries
            };
            Assert.Equal(calories, fs.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Flying Saucer
        /// </summary>
        /// <param name="stackSize">The number of panacakes</param>
        /// <param name="syrup">If served with syrup</param>
        /// <param name="whippedCream">If served with whipped cream</param>
        /// <param name="berries">If served with berries</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(6, true, true, true, new string[] {})]
        [InlineData(4, true, true, true, new string[] {"4 Pancakes"})]
        public void SpecialInstructionsRelfectsState(uint stackSize, bool syrup, bool whippedCream, bool berries, string[] instructions)
        {
            FlyingSaucer fs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                WhippedCream = whippedCream,
                Berries = berries
            };
            // Check that all expected special instructions exist
            foreach(string instruction in instructions)
            {
                Assert.Contains(instruction, fs.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, fs.SpecialInstructions.Count());
        }

        #endregion
        #region INotifyPropertyChanged Tests
        /// <summary>
        /// This test checks that the class implements the INotifyPropertyChanged interface with StackSize
        /// </summary>
        /// <param name="stackSize">stack size</param>
        /// <param name="propertyName">property Name</param>
        [Theory]
        [InlineData(4, "StackSize")]
        [InlineData(8, "StackSize")]
        [InlineData(2, "StackSize")]
        [InlineData(1, "Price")]
        [InlineData(5, "Price")]
        [InlineData(6, "Price")]
        [InlineData(4, "Calories")]
        [InlineData(3, "Calories")]
        [InlineData(5, "Calories")]
        public void ChangingSizeShouldNotifyOfPropertyChanges(uint stackSize, string propertyName)
        {
            FlyingSaucer cs = new();
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
            FlyingSaucer gh = new();

            Assert.PropertyChanged(gh, propertyName, () =>
            {
                gh.Syrup = extra;
            });
        }
        /// <summary>
        /// changing WhippedCream changes properties
        /// </summary>
        /// <param name="extra">the sauce</param>
        /// <param name="propertyName">the property name</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        [InlineData(false, "Whipped Cream")]
        public void ChangingWhippedCreamShouldNotifyPropertyChanged(bool extra, string propertyName)
        {
            FlyingSaucer gh = new();

            Assert.PropertyChanged(gh, propertyName, () =>
            {
                gh.WhippedCream = extra;
            });
        }
        /// <summary>
        /// changing Berries changes properties
        /// </summary>
        /// <param name="extra">the sauce</param>
        /// <param name="propertyName">the property name</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        [InlineData(false, "Berries")]
        public void ChangingBerriesShouldNotifyPropertyChanged(bool extra, string propertyName)
        {
            FlyingSaucer gh = new();

            Assert.PropertyChanged(gh, propertyName, () =>
            {
                gh.Berries = extra;
            });
        }

        #endregion
    }
}