/*OuterOmelette.cs
 * Author: Dacey Wieland
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Class for the menu item Outer Omelette
    /// </summary>
    public class OuterOmelette : Entree, IMenuItem
    {
        /// <summary>
        /// The name of the entree
        /// </summary>
        /// <returns>Returns the Name of the item</returns>
        public override string Name => "Outer Omelette";
        /// <summary>
        /// The description of the entree
        /// </summary>
        /// <returns>Returns the Description of the Item</returns>
        public override string Description => "A fully loaded Omelette.";
        /// <summary>
        /// If Cheddar Cheese is included in the drink
        /// </summary>
        private bool _cheddarCheese = true;
        /// <summary>
        /// If Cheddar Cheese is includeded in the drink
        /// </summary>
        public bool CheddarCheese
        {
            get
            {
                return _cheddarCheese;
            }
            set
            {
                if (_cheddarCheese != value)
                {
                    _cheddarCheese = value;
                    OnPropertyChanged("Calories");
                    OnPropertyChanged("SpecialInstructions");
                    OnPropertyChanged("Cheddar Cheese");
                }
            }
        }
        /// <summary>
        /// If Peppers is included in the drink
        /// </summary>
        private bool _peppers = true;
        /// <summary>
        /// Property to get or set Peppers
        /// </summary>
        public bool Peppers
        {
            get
            {
                return _peppers;
            }
            set
            {
                if (_peppers != value)
                {
                    _peppers = value;
                    OnPropertyChanged("Calories");
                    OnPropertyChanged("SpecialInstructions");
                    OnPropertyChanged("Peppers");
                }
            }
        }
        /// <summary>
        /// If Mushrooms is included in the drink
        /// </summary>
        private bool _mushrooms = true;
        /// <summary>
        /// Property to get or set Mushrooms
        /// </summary>
        public bool Mushrooms
        {
            get
            {
                return _mushrooms;
            }
            set
            {
                if (_mushrooms != value)
                {
                    _mushrooms = value;
                    OnPropertyChanged("Calories");
                    OnPropertyChanged("SpecialInstructions");
                    OnPropertyChanged("Mushrooms");
                }
            }
        }
        /// <summary>
        /// If Tomatoes is included in the drink
        /// </summary>
        private bool _tomatoes = true;
        /// <summary>
        /// Property to get or set Tomatoes
        /// </summary>
        public bool Tomatoes
        {
            get
            {
                return _tomatoes;
            }
            set
            {
                if (_tomatoes != value)
                {
                    _tomatoes = value;
                    OnPropertyChanged("Calories");
                    OnPropertyChanged("SpecialInstructions");
                    OnPropertyChanged("Tomatoes");
                }
            }
        }
        /// <summary>
        /// If Onions is included in the drink
        /// </summary>
        private bool _onions = true;
        /// <summary>
        /// Property to get or set Onions
        /// </summary>
        public bool Onions
        {
            get
            {
                return _onions;
            }
            set
            {
                if (_onions != value)
                {
                    _onions = value;
                    OnPropertyChanged("Calories");
                    OnPropertyChanged("SpecialInstructions");
                    OnPropertyChanged("Onions");
                }
            }
        }
        /// <summary>
        /// Property to set the price of the entree
        /// </summary>
        /// <returns>The price of the item</returns>
        public override decimal Price => 7.45m;
        /// <summary>
        /// private variable to set the default calories
        /// </summary>
        private uint _calories = 94;
        /// <summary>
        /// Property to get the number of calories of the entree
        /// </summary>
        /// <returns>The calories of the item</returns>
        public override uint Calories
        {
            get
            {
                uint calories = _calories;
                if (CheddarCheese) calories += 113u;
                if (Peppers) calories += 24u;
                if (Mushrooms) calories += 4u;
                if (Tomatoes) calories += 22u;
                if (Onions) calories += 22u;
                return calories;
            }
        }
        /// <summary>
        /// Property for special instructions, specifically if any fillings is not wanted
        /// </summary>
        /// <returns>The Special Instructions of the item</returns>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> special = new();
                if (!CheddarCheese) special.Add("Hold Cheddar Cheese");
                if (!Peppers) special.Add("Hold Peppers");
                if (!Mushrooms) special.Add("Hold Mushrooms");
                if (!Tomatoes) special.Add("Hold Tomatoes");
                if (!Onions) special.Add("Hold Onions");
                return special;
            }
        }
    }
}