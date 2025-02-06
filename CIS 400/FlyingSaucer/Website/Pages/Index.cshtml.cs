using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheFlyingSaucer.Data;

namespace Website.Pages
{
    /// <summary>
    /// Backend for the razor page
    /// </summary>
    public class IndexModel : PageModel
    {

        /// <summary>
        /// Private backing for all menu items
        /// </summary>
        public IEnumerable<IMenuItem> Items { get; set; } = Menu.FullMenu;

        /// <summary>
        /// Backs list of entrees for index page
        /// </summary>
        public List<Entree>? Entrees { get; set; }

        /// <summary>
        /// Backs list of sides for index page
        /// </summary>
        public List<Side>? Sides { get; set; }

        /// <summary>
        /// Backs list of drinks for index page
        /// </summary>
        public List<Drink>? Drinks { get; set; }

        /// <summary>
        /// Binded property for search terms from form
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string? SearchTerms { get; set; }

        /// <summary>
        /// Binded property for different menu types for order
        /// (Entrees, Sides, Drinks)
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string[]? MenuTypes { get; set; }

        /// <summary>
        /// Binded property for minimum amount of calories
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public uint? MinCal { get; set; }

        /// <summary>
        /// Binded property for maximum amount of calories
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public uint? MaxCal { get; set; }

        /// <summary>
        /// Binded property for minimum price
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public decimal? MinPrice { get; set; }

        /// <summary>
        /// Binded property for maximum price
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public decimal? MaxPrice { get; set; }


        public void OnGet()
        {
            Items = Menu.FullMenu;
            Entrees = null;
            Sides = null;
            Drinks = null;

            //get item names based on search terms
            if (SearchTerms != null)
            {
                string[] splitedTerms = SearchTerms.Split(" ");
                Items = from item in Items
                        where splitedTerms.All(x => item.Name.Contains(x, StringComparison.InvariantCultureIgnoreCase))
                        select item;
            }

            // filter for menu item type
            if (MenuTypes != null && MenuTypes.Length != 0)
            {
                Items = from item in Items
                        where MenuTypes.Contains(GetItemTypeAsString(item))
                        select item;
            }

            // filter for item calories
            if (MinCal != null || MaxCal != null)
            {
                //only a max is specified
                if (MinCal == null)
                {
                    Items = from item in Items
                            where item.Calories <= MaxCal
                            select item;
                }

                //only a min is specified
                else if (MaxCal == null)
                {
                    Items = from item in Items
                            where item.Calories >= MinCal
                            select item;
                }

                //both specified
                else
                {
                    Items = from item in Items
                            where item.Calories >= MinCal && item.Calories <= MaxCal
                            select item;
                }
            }

            // filter for item price
            if (MinPrice != null || MaxPrice != null)
            {
                //only a max is specified
                if (MinPrice == null)
                {
                    Items = from item in Items
                            where item.Price <= MaxPrice
                            select item;
                }

                //only a min is specified
                else if (MaxPrice == null)
                {
                    Items = from item in Items
                            where item.Price >= MinPrice
                            select item;
                }

                //both are specified
                else
                {
                    Items = from item in Items
                            where item.Price >= MinPrice && item.Price <= MaxPrice
                            select item;
                }

            }
            // put each item into its item type list
            foreach (IMenuItem item in Items)
            {
                if (item is Entree entree)
                {
                    if (Entrees == null) Entrees = new List<Entree>();
                    Entrees.Add(entree);
                }
                if (item is Side side)
                {
                    if (Sides == null) Sides = new List<Side>();
                    Sides.Add(side);
                }
                if (item is Drink drink)
                {
                    if (Drinks == null) Drinks = new List<Drink>();
                    Drinks.Add(drink);
                }
            }
        }
        /// <summary>
        /// Method for item type filter
        /// determines what type of menu item an item is as a string
        /// </summary>
        /// <param name="item">menu item being checked</param>
        /// <returns>string of item type</returns>
        private string GetItemTypeAsString(IMenuItem item)
        {
            if (item is Entree)
                return "Entrees";
            if (item is Side)
                return "Sides";
            if (item is Drink)
                return "Drinks";

            return "";
        }
        /// <summary>
        /// Gets the location of the image of the given menu item
        /// </summary>
        /// <param name="item">IMenuItem being checked</param>
        /// <returns>string of the item's picture, returns null string if item is not recognized</returns>
        public string GetImageLocForItem(IMenuItem item)
        {
            if (item is FlyingSaucer)
                return "Flying Saucer Menu-02.svg";
            if (item is CrashedSaucer)
                return "Flying Saucer Menu-03.svg";
            if (item is LivestockMutilation)
                return "Flying Saucer Menu-05.svg";
            if (item is OuterOmelette)
                return "Flying Saucer Menu-04.svg";
            if (item is CropCircle)
                return "Flying Saucer Menu-07.svg";
            if (item is GlowingHaystack)
                return "Flying Saucer Menu-08.svg";
            if (item is TakenBacon)
                return "Flying Saucer Menu-09.svg";
            if (item is MissingLinks)
                return "Flying Saucer Menu-10.svg";
            if (item is EvisceratedEggs)
                return "Flying Saucer Menu-11.svg";
            if (item is YouAreToast)
                return "Flying Saucer Menu-12.svg";
            if (item is LiquifiedVegetation)
                return "Flying Saucer Menu-13.svg";
            if (item is SaucerFuel)
                return "Flying Saucer Menu-14.svg";
            if (item is InorganicSubstance)
                return "Flying Saucer Menu-15.svg";

            return "";
        }
        /// <summary>
        /// Gets additional information for each menu item.
        /// </summary>
        /// <param name="item">Item to get information for</param>
        /// <returns>String giving additional information</returns>
        public string GetAdditionalItemInfo(IMenuItem item)
        {
            if (item is FlyingSaucer)
            {
                return "Extra pancakes Are $0.75 ea.;\n" +
                    "Pancakes: 64 cals ea.;\n" +
                    "W/Syrup: 64 cal.;\n" +
                    "W/Whipped Cream: 414 cal.;\n" +
                    "W/Berries: 89 cal.";
            }

            if (item is CrashedSaucer)
            {
                return "Extra Toast: $1.50 ea.;\n" +
                    "Freach Toast slices: 149 cal. ea.;\n" +
                    "W/Syrup: 52 cal.;\n" +
                    "W/Butter: 35 cal.";
            }
            if (item is LivestockMutilation)
            {
                return "Extra biscuits: $1.00 ea.;\n" +
                    "W/Biscuits: 49 cal. ea.;\n" +
                    "W/Gravy: 140 cal.";
            }

            if (item is OuterOmelette)
            {
                return "Egg: 94 cal.;\n" +
                    "W/Cheddar Cheese: 113 cal.;\n" +
                    "W/Peppers: 24 cal.;\n" +
                    "W/Mushrooms: 4 cal.;\n" +
                    "W/Tomatoes: 22 cal.;\n" +
                    "W/Onions: 22 cal.";
            }
            if (item is CropCircle)
            {
                return "Just Plain: 158 cal.;\n" +
                    "W/Berries: 89 cal.";
            }
            if (item is GlowingHaystack)
            {
                return "Plain: 470 cal.;\n" +
                    "W/Green Chile Sauce: 23 cal.;\n" +
                    "W/Tomatoes: 22 cal.";
            }
            if (item is TakenBacon)
            {
                return "Extra Bacon: $1.00 ea.;\n" +
                    "Each Strip: 43 cal. ea";
            }
            if (item is MissingLinks)
            {
                return "Extra. Links: $1.00 ea.;\n" +
                    "Each Link: 391 cal. ea.";
            }
            if (item is EvisceratedEggs)
            {
                return "Extra Eggs: $1.00 ea.;\n" +
                    "Each Eggs: 78 cal. ea.";
            }
            if (item is YouAreToast)
            {
                return "Extra slices: $1.00 ea.;\n" +
                    "Each Toast: 100 cal. ea.";
            }
            if (item is LiquifiedVegetation)
            {
                return "";
            }
            if (item is SaucerFuel)
            {
                return "Decaf available;\n" +
                    "Cream: 92 cal";
            }
            if (item is InorganicSubstance)
            {
                return "";
            }

            return "";
        }
    }
}