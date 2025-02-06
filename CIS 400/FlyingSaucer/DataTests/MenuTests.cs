using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFlyingSaucer.Data;
using Website.Pages;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Test for the menu class
    /// </summary>
    public class MenuTests
    {
        /// <summary>
        /// Test to check total number of items
        /// </summary>
        [Fact]
        public void MenuHasRightTotalNumber()
        {
            Assert.Equal(19, Menu.FullMenu.Count());
        }
        /// <summary>
        /// Menu has the correct side number
        /// </summary>
        [Fact]
        public void MenuHasCorrectSideNumber()
        {
            Assert.Equal(6, Menu.Sides.Count());
        }
        /// <summary>
        /// Menu has the correct drink number
        /// </summary>
        [Fact]
        public void MenuHasCorrectDrinkNumber()
        {
            Assert.Equal(9, Menu.Drinks.Count());
        }
        /// <summary>
        /// Entree contains all entree items
        /// </summary>
        [Fact]
        public void EntreeHasAllEntrees()
        {
            List<Entree> list = new List<Entree>();
            list.Add(new FlyingSaucer());
            list.Add(new CrashedSaucer());
            list.Add(new LivestockMutilation());
            list.Add(new OuterOmelette());
            for(int i =0; i<list.Count; i++)
            {
                Assert.Contains(Menu.Entrees, (x) => { return list[i].GetType() == x.GetType();  });
            }
        }
        /// <summary>
        /// Menu contains all drinks
        /// </summary>
        [Fact]
        public void DrinkHasAllDrinks()
        {
            List<Drink> list = new List<Drink>();
            list.Add(new LiquifiedVegetation());
            list.Add(new LiquifiedVegetation());
            list.Add(new LiquifiedVegetation());
            list.Add(new SaucerFuel());
            list.Add(new SaucerFuel());
            list.Add(new SaucerFuel());
            list.Add(new InorganicSubstance());
            list.Add(new InorganicSubstance());
            list.Add(new InorganicSubstance());
            for (int i = 0; i < list.Count; i++)
            {
                Assert.Contains(Menu.Drinks, (x) => { return list[i].GetType() == x.GetType(); });
            }
        }
        /// <summary>
        /// Menu contains all sides
        /// </summary>
        [Fact]
        public void SideHasAllSides()
        {
            List<Side> list = new List<Side>();
            list.Add(new CropCircle());
            list.Add(new GlowingHaystack());
            list.Add(new TakenBacon());
            list.Add(new MissingLinks());
            list.Add(new EvisceratedEggs());
            list.Add(new YouAreToast());
            for (int i = 0; i < list.Count; i++)
            {
                Assert.Contains(Menu.Sides, (x) => { return list[i].GetType() == x.GetType(); });
            }
        }
        /// <summary>
        /// Test to see if the search works
        /// </summary>
        [Fact]
        public void SearchWorks()
        {
            IndexModel model = new IndexModel();
            if(model.SearchTerms != null)
            {
                model.OnGet();
                model.Items = Menu.Search("Saucer");
                Assert.Equal(3, model.Items.Count());
            }
        }
    }
}
