namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the Outer Omelette class
    /// </summary>
    public class OuterOmeletteUnitTest
    {
        #region Default Values
        /// <summary>
        /// Checks that the ToString method returns the name of the entree
        /// </summary>
        [Fact]
        public void ToStringShouldJustBeName()
        {
            OuterOmelette oo = new();
            Assert.Equal(oo.Name, oo.ToString());
        }
        /// <summary>
        /// Checks that a unaltered Outer Omelette is served with cheddar cheese 
        /// </summary>
        [Fact]
        public void DefaultServedWithCheddarCheese()
        {
            OuterOmelette oo = new();
            Assert.True(oo.CheddarCheese);
        }
        /// <summary>
        /// Checks that a unaltered Outer Omelette is served with peppers 
        /// </summary>
        [Fact]
        public void DefaultServedWithPeppers()
        {
            OuterOmelette oo = new();
            Assert.True(oo.Peppers);
        }
        /// <summary>
        /// Checks that a unaltered Outer Omelette is served with mushrooms 
        /// </summary>
        [Fact]
        public void DefaultServedWithMushrooms()
        {
            OuterOmelette oo = new();
            Assert.True(oo.Mushrooms);
        }
        /// <summary>
        /// Checks that a unaltered Outer Omelette is served with tomatoes 
        /// </summary>
        [Fact]
        public void DefaultServedWithTomatoes()
        {
            OuterOmelette oo = new();
            Assert.True(oo.Tomatoes);
        }
        /// <summary>
        /// Checks that a unaltered Outer Omelette is served with onions 
        /// </summary>
        [Fact]
        public void DefaultServedWithOnions()
        {
            OuterOmelette oo = new();
            Assert.True(oo.Onions);
        }
        /// <summary>
        /// This Test verifies that the Outer Omelette's Price is correct
        /// </summary>
        /// <param name="biscuit">The amount of biscuits</param>
        /// <param name="price">The price of the item</param>
        [Theory]
        [InlineData(7.45)]
        public void PriceShouldBeCorrect(decimal price)
        {
            OuterOmelette oo = new();
            Assert.Equal(price, oo.Price, 0);
        }
        /// <summary>
        /// Checks that an unaltered OuterOmelette has been assigned to IMenuItem Interface
        /// </summary>
        [Fact]
        public void DefaultShouldBeAssignedToInterface()
        {
            OuterOmelette oo = new();
            Assert.IsAssignableFrom<IMenuItem>(oo);

        }
        /// <summary>
        /// Checks that an unaltered OuterOmelette has been assigned to Entree Class
        /// </summary>
        [Fact]
        public void DefaultShouldBeAssignedToEntree()
        {
            OuterOmelette oo = new();
            Assert.IsAssignableFrom<Entree>(oo);

        }
        #endregion


        #region state changes

        /// <summary>
        /// This tests if the state is changed, the name stays the same
        /// </summary>
        /// <param name="cheddarCheese">If the dish is to be served with cheddar cheese</param>
        /// <param name="peppers">If the dish is to be served with peppers</param>
        /// <param name="mushrooms">If the dish is to be served with mushrooms</param>
        /// <param name="tomatoes">If the dish is to be served with tomatoes</param>
        /// <param name="onions">If the dish is to be served with onions</param>
        [Theory]
        [InlineData(true, true, true, true, true)]
        [InlineData(true, false, true, true, true)]
        [InlineData(true, true, false, true, true)]
        [InlineData(false, true, true, true, true)]
        [InlineData(true, true, true, false, true)]
        [InlineData(false, false, false, false, false)]
        [InlineData(true, true, true, true, false)]
        public void NameShouldAlwaysBeOuterOmelette(bool cheddarCheese, bool peppers, bool mushrooms, bool tomatoes, bool onions)
        {
            OuterOmelette oo = new()
            {
                CheddarCheese = cheddarCheese,
                Peppers = peppers,
                Mushrooms = mushrooms,
                Tomatoes = tomatoes,
                Onions = onions
            };
            Assert.Equal("Outer Omelette", oo.Name);
        }

        /// <summary>
        /// This tests if the state is changed, the description stays the same
        /// </summary>
        /// <param name="cheddarCheese">If the dish is to be served with cheddar cheese</param>
        /// <param name="peppers">If the dish is to be served with peppers</param>
        /// <param name="mushrooms">If the dish is to be served with mushrooms</param>
        /// <param name="tomatoes">If the dish is to be served with tomatoes</param>
        /// <param name="onions">If the dish is to be served with onions</param>
        [Theory]
        [InlineData(true, true, true, true, true)]
        [InlineData(true, false, true, true, true)]
        [InlineData(true, true, false, true, true)]
        [InlineData(false, true, true, true, true)]
        [InlineData(true, true, true, false, true)]
        [InlineData(false, false, false, false, false)]
        [InlineData(true, true, true, true, false)]
        public void DescriptionShouldAlwaysMatch(bool cheddarCheese, bool peppers, bool mushrooms, bool tomatoes, bool onions)
        {
            OuterOmelette oo = new()
            {
                CheddarCheese = cheddarCheese,
                Peppers = peppers,
                Mushrooms = mushrooms,
                Tomatoes = tomatoes,
                Onions = onions
            };
            Assert.Equal("A fully loaded Omelette.", oo.Description);
        }
        /// <summary>
        /// This test checks that even as the Outer Omelette's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="cheddarCheese">If the dish is to be served with cheddar cheese</param>
        /// <param name="peppers">If the dish is to be served with peppers</param>
        /// <param name="mushrooms">If the dish is to be served with mushrooms</param>
        /// <param name="tomatoes">If the dish is to be served with tomatoes</param>
        /// <param name="onions">If the dish is to be served with onions</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        /// <remarks>
        /// We supply the expected calories as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected calories are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(true, true, true, true, true, 94 + 113 + 24 + 4 +22 +22)]
        [InlineData(true, false, true, true, true, 94 + 113 + 4 + 22 + 22)]
        [InlineData(true, true, false, true, true, 94 + 113 + 24 + 22 + 22)]
        [InlineData(false, true, true, true, true, 94 + 24 + 4 +22 +22)]
        [InlineData(true, true, true, false, true, 94 + 113 + 24 + 4 + 22)]
        [InlineData(false, false, false, false, false, 94)]
        [InlineData(true, true, true, true, false, 94 + 113 + 24 +4 + 22)]
        public void CaloriesShouldBeCorrect(bool cheddarCheese, bool peppers, bool mushrooms, bool tomatoes, bool onions, uint calories)
        {
            OuterOmelette oo = new()
            {
                CheddarCheese = cheddarCheese,
                Peppers = peppers,
                Mushrooms = mushrooms,
                Tomatoes = tomatoes,
                Onions = onions
            };
            Assert.Equal(calories, oo.Calories);
        }



        /// <summary>
        /// Checks that the special instructions reflect the current state of the Outer Omelette
        /// </summary>
        /// <param name="cheddarCheese">If the dish is to be served with cheddar cheese</param>
        /// <param name="peppers">If the dish is to be served with peppers</param>
        /// <param name="mushrooms">If the dish is to be served with mushrooms</param>
        /// <param name="tomatoes">If the dish is to be served with tomatoes</param>
        /// <param name="onions">If the dish is to be served with onions</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, true, true, true, true, new string[] { })]
        [InlineData(false, true, true, true, true, new string[] { "Hold Cheddar Cheese" })]
        [InlineData(true, false, true, true, true, new string[] { "Hold Peppers" })]
        [InlineData(true, true, false, true, true, new string[] { "Hold Mushrooms" })]
        [InlineData(true, true, true, false, true, new string[] { "Hold Tomatoes" })]
        [InlineData(true, true, true, true, false, new string[] { "Hold Onions" })]
        public void SpecialInstructionsRelfectsState(bool cheddarCheese, bool peppers, bool mushrooms, bool tomatoes, bool onions, string[] instructions)
        {
            OuterOmelette oo = new()
            {
                CheddarCheese = cheddarCheese,
                Peppers = peppers,
                Mushrooms = mushrooms,
                Tomatoes = tomatoes,
                Onions = onions
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, oo.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, oo.SpecialInstructions.Count());
        }
        #endregion
        /// <summary>
        /// changing Cheddar Cheese changes properties
        /// </summary>
        /// <param name="extra">the sauce</param>
        /// <param name="propertyName">the property name</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        [InlineData(false, "Cheddar Cheese")]
        public void ChangingCheeseShouldNotifyPropertyChanged(bool extra, string propertyName)
        {
            OuterOmelette gh = new();

            Assert.PropertyChanged(gh, propertyName, () =>
            {
                gh.CheddarCheese = extra;
            });
        }
        /// <summary>
        /// changing peppers changes properties
        /// </summary>
        /// <param name="extra">the sauce</param>
        /// <param name="propertyName">the property name</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        [InlineData(false, "Peppers")]
        public void ChangingPeppersShouldNotifyPropertyChanged(bool extra, string propertyName)
        {
            OuterOmelette gh = new();

            Assert.PropertyChanged(gh, propertyName, () =>
            {
                gh.Peppers = extra;
            });
        }
        /// <summary>
        /// changing mushrooms changes properties
        /// </summary>
        /// <param name="extra">the sauce</param>
        /// <param name="propertyName">the property name</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        [InlineData(false, "Mushrooms")]
        public void ChangingMushroomsShouldNotifyPropertyChanged(bool extra, string propertyName)
        {
            OuterOmelette gh = new();

            Assert.PropertyChanged(gh, propertyName, () =>
            {
                gh.Mushrooms = extra;
            });
        }
        /// <summary>
        /// changing tomatoes changes properties
        /// </summary>
        /// <param name="extra">the sauce</param>
        /// <param name="propertyName">the property name</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        [InlineData(false, "Tomatoes")]
        public void ChangingTomatoesShouldNotifyPropertyChanged(bool extra, string propertyName)
        {
            OuterOmelette gh = new();

            Assert.PropertyChanged(gh, propertyName, () =>
            {
                gh.Tomatoes = extra;
            });
        }
        /// <summary>
        /// changing onions changes properties
        /// </summary>
        /// <param name="extra">the sauce</param>
        /// <param name="propertyName">the property name</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        [InlineData(false, "Onions")]
        public void ChangingOnionsShouldNotifyPropertyChanged(bool extra, string propertyName)
        {
            OuterOmelette gh = new();

            Assert.PropertyChanged(gh, propertyName, () =>
            {
                gh.Onions = extra;
            });
        }
    }
}
