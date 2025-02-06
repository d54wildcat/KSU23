namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the GlowingHaystack class
    /// </summary>
    public class GlowingHaystackUnitTest
    {
        #region Default Values
        /// <summary>
        /// Checks that the ToString method returns the name of the side
        /// </summary>
        [Fact]
        public void ToStringShouldJustBeName()
        {
            GlowingHaystack gh = new();
            Assert.Equal(gh.Name, gh.ToString());
        }
        /// <summary>
        /// Checks that a unaltered GlowingHaystack is served with Green Chile Sauce
        /// </summary>
        [Fact]
        public void DefaultServedWithGreenChileSauce()
        {
            GlowingHaystack gh = new();
            Assert.True(gh.GreenChileSauce);
        }
        /// <summary>
        /// Checks that a unaltered GlowingHaystack is served with Sour Cream 
        /// </summary>
        [Fact]
        public void DefaultServedWithSourCream()
        {
            GlowingHaystack gh = new();
            Assert.True(gh.SourCream);
        }
        /// <summary>
        /// Checks that a unaltered GlowingHaystack is served with tomatoes 
        /// </summary>
        [Fact]
        public void DefaultServedWithTomatoes()
        {
            GlowingHaystack gh = new();
            Assert.True(gh.Tomatoes);
        }
        /// <summary>
        /// This Test verifies that the GlowingHaystack's Price is correct
        /// </summary>
        /// <param name="biscuit">The amount of biscuits</param>
        /// <param name="price">The price of the item</param>
        [Theory]
        [InlineData(2.00)]
        public void PriceShouldBeCorrect(decimal price)
        {
            GlowingHaystack gh = new();
            Assert.Equal(price, gh.Price, 0);
        }
        /// <summary>
        /// Checks that an unaltered Glowing Haystack has been assigned to IMenuItem Interface
        /// </summary>
        [Fact]
        public void DefaultShouldBeAssignedToInterface()
        {
            GlowingHaystack gh = new();
            Assert.IsAssignableFrom<IMenuItem>(gh);

        }
        /// <summary>
        /// Checks that an unaltered Glowing Haystack has been assigned to Side Class
        /// </summary>
        [Fact]
        public void DefaultShouldBeAssignedToSide()
        {
            GlowingHaystack gh = new();
            Assert.IsAssignableFrom<Side>(gh);

        }
        #endregion


        #region state changes

        /// <summary>
        /// This tests if the state is changed, the name stays the same
        /// </summary>
        /// <param name="greenSauce">If the dish is to be served with cheddar cheese</param>
        /// <param name="sourCream">If the dish is to be served with peppers</param>
        /// <param name="tomatoes">If the dish is to be served with tomatoes</param>
        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, false, true)]
        [InlineData(true, false, false)]
        [InlineData(true, true, false)]
        [InlineData(false, true, true)]
        [InlineData(false, false, false)]
        [InlineData(false, false, true)]
        [InlineData(false, true, false)]
        public void NameShouldAlwaysBeOuterOmelette(bool greenSauce, bool sourCream, bool tomatoes)
        {
            GlowingHaystack gh = new()
            {
                GreenChileSauce = greenSauce,
                SourCream = sourCream,
                Tomatoes = tomatoes,
            };
            Assert.Equal("Glowing Haystack", gh.Name);
        }

        /// <summary>
        /// This tests if the state is changed, the description stays the same
        /// </summary>
        /// <param name="greenSauce">If the dish is to be served with cheddar cheese</param>
        /// <param name="sourCream">If the dish is to be served with peppers</param>
        /// <param name="tomatoes">If the dish is to be served with tomatoes</param>
        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, false, true)]
        [InlineData(true, false, false)]
        [InlineData(true, true, false)]
        [InlineData(false, true, true)]
        [InlineData(false, false, false)]
        [InlineData(false, false, true)]
        [InlineData(false, true, false)]

        public void DescriptionShouldAlwaysMatch(bool greenSauce, bool sourCream, bool tomatoes)
        {
            GlowingHaystack gh = new()
            {
                GreenChileSauce = greenSauce,
                SourCream = sourCream,
                Tomatoes = tomatoes,
            };
            Assert.Equal("Hash browns smothered in green chile sauce, sour cream, and topped with tomatoes.", gh.Description);
        }
        /// <summary>
        /// This test checks that even as the GlowingHaystack's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="greenSauce">If the dish is to be served with cheddar cheese</param>
        /// <param name="sourCream">If the dish is to be served with peppers</param>
        /// <param name="tomatoes">If the dish is to be served with tomatoes</param>
        /// <param name = "calories" > The amount of calories in the dish</param>
        [Theory]
        [InlineData(true, true, true, 470 + 15 + 23 + 22)]
        [InlineData(true, false, true, 470 + 15 + 22)]
        [InlineData(true, false, false, 470 + 15)]
        [InlineData(true, true, false, 470 + 15 + 23)]
        [InlineData(false, true, true, 470 + 23 + 22)]
        [InlineData(false, false, false, 470)]
        [InlineData(false, false, true, 470 + 22)]
        [InlineData(false, true, false, 470 + 23)]
        public void CaloriesShouldBeCorrect(bool greenSauce, bool sourCream, bool tomatoes, uint calories)
        {
            GlowingHaystack gh = new()
            {
                GreenChileSauce = greenSauce,
                SourCream = sourCream,
                Tomatoes = tomatoes,
            };
            Assert.Equal(calories, gh.Calories);
        }



        /// <summary>
        /// Checks that the special instructions reflect the current state of the Outer Omelette
        /// </summary>
        /// <param name="greenSauce">If the dish is to be served with cheddar cheese</param>
        /// <param name="sourCream">If the dish is to be served with peppers</param>
        /// <param name="tomatoes">If the dish is to be served with tomatoes</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, true, true, new string[] { })]
        [InlineData(false, true, true, new string[] { "Hold Green Chile Sauce" })]
        [InlineData(true, false, true, new string[] { "Hold Sour Cream" })]
        [InlineData(true, true, false, new string[] { "Hold Tomatoes." })]
        public void SpecialInstructionsRelfectsState(bool greenSauce, bool sourCream, bool tomatoes, string[] instructions)
        {
            GlowingHaystack gh = new()
            {
                GreenChileSauce = greenSauce,
                SourCream = sourCream,
                Tomatoes = tomatoes,
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, gh.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, gh.SpecialInstructions.Count());
        }
        /// <summary>
        /// This checks the item can be cast to the IMenuItem interface
        /// </summary>
        [Fact]
        public void CanBeCastToAnIMenuItem()
        {
            GlowingHaystack gh = new GlowingHaystack();
            Assert.IsAssignableFrom<IMenuItem>(gh);
        }
        /// <summary>
        /// This checks that this item can be cast to a Side
        /// </summary>
        [Fact]
        public void CanBeCastToASide()
        {
            GlowingHaystack gh = new GlowingHaystack();
            Assert.IsAssignableFrom<Side>(gh);
        }
        /// <summary>
        /// changing sauce changes properties
        /// </summary>
        /// <param name="gcs">the sauce</param>
        /// <param name="propertyName">the property name</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        [InlineData(false, "Green Chile Sauce")]
        public void ChangingGreenChileSauceShouldNotifyPropertyChanged(bool gcs, string propertyName)
        {
            GlowingHaystack gh = new();

            Assert.PropertyChanged(gh, propertyName, () =>
            {
                gh.GreenChileSauce = gcs;
            });
        }
        /// <summary>
        /// changing sourcream changes properties
        /// </summary>
        /// <param name="sc">the sauce</param>
        /// <param name="propertyName">the property name</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        [InlineData(false, "Sour Cream")]
        public void ChangingSourCreamShouldNotifyPropertyChanged(bool sc, string propertyName)
        {
            GlowingHaystack gh = new();
            
            Assert.PropertyChanged(gh, propertyName, () =>
            {
                gh.SourCream = sc;
            });
        }
        /// <summary>
        /// changing tomatoes changes properties
        /// </summary>
        /// <param name="t">the sauce</param>
        /// <param name="propertyName">the property name</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        [InlineData(false, "Tomatoes")]
        public void ChangingTomatoesShouldNotifyPropertyChanged(bool t, string propertyName)
        {
            GlowingHaystack gh = new();

            Assert.PropertyChanged(gh, propertyName, () =>
            {
                gh.Tomatoes = t;
            });
        }
        #endregion
    }
}
