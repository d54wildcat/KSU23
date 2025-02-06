/*GlowingHaystack.cs
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
    /// Class for the GlowingHaystack side
    /// </summary>
    public class GlowingHaystack : Side
    {
        /// <summary>
        /// Property for the name
        /// </summary>
        /// <returns>Returns the Name of the item</returns>
        public override string Name => "Glowing Haystack";
        /// <summary>
        /// Property for the description
        /// </summary>
        /// <returns>Returns the Description of the Item</returns>
        public override string Description => "Hash browns smothered in green chile sauce, sour cream, and topped with tomatoes.";
        /// <summary>
        /// Private bool for the chile sauce
        /// </summary>
        private bool _greenChileSauce = true;
        /// <summary>
        /// Property for the Green Chile Sauce, defaults to true
        /// </summary>
        public bool GreenChileSauce
        {
            get
            {

                return _greenChileSauce;
            }
            set
            {
                if (_greenChileSauce != value)
                {
                    _greenChileSauce = value;
                    OnPropertyChanged("Calories");
                    OnPropertyChanged("SpecialInstructions");
                    OnPropertyChanged("Green Chile Sauce");
                }
            }
        }
        /// <summary>
        /// Private bool for the sour cream
        /// </summary>
        private bool _sourCream = true;
        /// <summary>
        /// Property for the SourCream, defaults to true
        /// </summary>
        public bool SourCream
        {
            get
            {

                return _sourCream;
            }
            set
            {
                if (_sourCream != value)
                {
                    _sourCream = value;
                    OnPropertyChanged("Calories");
                    OnPropertyChanged("SpecialInstructions");
                    OnPropertyChanged("Sour Cream");
                }
            }
        }
        /// <summary>
        /// Private bool for the Tomatoes
        /// </summary>
        private bool _tomatoes = true;
        /// <summary>
        /// Property for the Tomatoes, defaults to true
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
        /// Price of the entree
        /// </summary>
        /// <returns>The price of the item</returns>
        public override decimal Price => 2.00m;
        /// <summary>
        /// default value of the calories, without anything added
        /// </summary>
        private uint _calories = 470;
        /// <summary>
        /// Property to get the number of calories.
        /// </summary>
        /// <returns>The calories of the item</returns>
        public override uint Calories
        {
            get
            {
                uint calories = _calories;
                if (GreenChileSauce) calories += 15u;
                if (SourCream) calories += 23u;
                if (Tomatoes) calories += 22u;
                return calories;
            }
        }
        /// <summary>
        /// Property to get the special instructions
        /// </summary>
        /// <returns>The Special Instructions of the item</returns>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (!GreenChileSauce) instructions.Add("Hold Green Chile Sauce");
                if (!SourCream) instructions.Add("Hold Sour Cream");
                if (!Tomatoes) instructions.Add("Hold Tomatoes.");
                return instructions;
            }
        }
    }
}
