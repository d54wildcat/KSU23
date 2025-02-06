/*CropCircle.cs
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
    /// Class for the CropCircle side
    /// </summary>
    public class CropCircle : Side
    {
        /// <summary>
        /// Property for the name
        /// </summary>
        /// <returns>Returns the Name of the item</returns>
        public override string Name => "Crop Circle";
        /// <summary>
        /// Property for the description
        /// </summary>
        /// <returns>Returns the Description of the Item</returns>
        public override string Description => "Oatmeal topped with mixed berries.";
        /// <summary>
        /// Private bool for the berries property
        /// </summary>
        bool _berries = true;
        /// <summary>
        /// Property for the berries, defaults to true
        /// </summary>
        public bool Berries
        {
            get
            {
                return _berries;
            }
            set
            {
                if (_berries != value) 
                {
                    _berries = value;
                    OnPropertyChanged("Calories");
                    OnPropertyChanged("SpecialInstructions");
                    OnPropertyChanged("Berries");
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
        private uint _calories = 158;
        /// <summary>
        /// Property to get the number of calories.
        /// </summary>
        /// <returns>The calories of the item</returns>
        public override uint Calories 
        {
            get
            {
                uint calories = _calories;
                if (Berries) calories += 89u;
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
                List<string> instructions = new List<string>();
                if (!Berries) instructions.Add("Hold Berries");
                return instructions;
            }
        }
    }
}
