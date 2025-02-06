using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TheFlyingSaucer.Data;


namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Static class for all menu items
    /// </summary>
    public static class Menu
    {
        /// <summary>
        /// Gets the list of all available default entrees
        /// </summary>
        public static IEnumerable<IMenuItem> Entrees
        {
            get
            {
                List<Entree> entrees = new()
                {
                    new CrashedSaucer(),
                    new FlyingSaucer(),
                    new OuterOmelette(),
                    new LivestockMutilation()
                };
                return entrees;
            }
        }
        /// <summary>
        /// Gets the list of all available default drinks
        /// </summary>
        public static IEnumerable<IMenuItem> Drinks
        {
            get
            {
                List<Drink> drinks = new()
                {
                    //need three sizes for each drinks for a total of 9 drinks
                    new InorganicSubstance() { Size = ServingSize.Small },
                    new InorganicSubstance() {Size = ServingSize.Medium },
                    new InorganicSubstance() {Size = ServingSize.Large },
                    new LiquifiedVegetation() { Size = ServingSize.Small },
                    new LiquifiedVegetation() {Size = ServingSize.Medium },
                    new LiquifiedVegetation() {Size = ServingSize.Large },
                    new SaucerFuel() { Size = ServingSize.Small },
                    new SaucerFuel() {Size = ServingSize.Medium },
                    new SaucerFuel() {Size = ServingSize.Large },
                };
                return drinks;
            }
        }
        /// <summary>
        /// Gets the list of all available default Sides
        /// </summary>
        public static IEnumerable<IMenuItem> Sides
        {
            get
            {
                List<Side> sides = new()
                {
                    new CropCircle(),
                    new GlowingHaystack(),
                    new TakenBacon(),
                    new EvisceratedEggs(),
                    new MissingLinks(),
                    new YouAreToast()
                };
                return sides;
            }
        }
        /// <summary>
        /// List of all available menu items
        /// </summary>
        public static IEnumerable<IMenuItem> FullMenu
        {
            get
            {
                List<IMenuItem> fullMenu = new List<IMenuItem>
                {
                    new CrashedSaucer(),
                    new FlyingSaucer(),
                    new OuterOmelette(),
                    new LivestockMutilation(),
                    new CropCircle(),
                    new GlowingHaystack(),
                    new EvisceratedEggs(),
                    new MissingLinks(),
                    new TakenBacon(),
                    new YouAreToast(),
                    new LiquifiedVegetation() { Size = ServingSize.Small },
                    new LiquifiedVegetation() { Size = ServingSize.Medium },
                    new LiquifiedVegetation() { Size = ServingSize.Large },
                    new SaucerFuel() { Size = ServingSize.Small },
                    new SaucerFuel() { Size = ServingSize.Medium },
                    new SaucerFuel() { Size = ServingSize.Large },
                    new InorganicSubstance() { Size = ServingSize.Small },
                    new InorganicSubstance() { Size = ServingSize.Medium },
                    new InorganicSubstance() { Size = ServingSize.Large }
                };
                return fullMenu;
            }
            
        }
        /// <summary>
        /// private list to use for searching
        /// </summary>
        private static List<IMenuItem> _items = new List<IMenuItem>();
        /// <summary>
        /// gets all the properties in the IMenuItem
        /// </summary>
        public static IEnumerable<IMenuItem> All { get { return _items; } }
        /// <summary>
        /// Searches the class for matching menu items
        /// </summary>
        /// <param name="terms">The terms to search for</param>
        /// <returns>A collection of menu items</returns>
        public static IEnumerable<IMenuItem> Search(string terms)
        {
            List<IMenuItem> results = new List<IMenuItem>();
            if (terms == null) return FullMenu;
            foreach(IMenuItem menu in FullMenu) 
            {
                bool searched = true;
                string[] words=terms.Split(' ');
                foreach(string word in words)
                {
                    if (!menu.Name.Contains(word, StringComparison.CurrentCultureIgnoreCase))
                    {
                        searched = false;
                    }
                }
                if (searched) results.Add(menu);
            }
            return results;
        }
    }
}
