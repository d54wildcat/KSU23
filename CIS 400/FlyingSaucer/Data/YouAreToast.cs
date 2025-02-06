/* YouAreToast.cs
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
    /// Class for the TakenBacon side
    /// </summary>
    public class YouAreToast : Side, IMenuItem
    {
        /// <summary>
        /// Property for name
        /// </summary>
        /// <returns>Returns the Name of the item</returns>
        public override string Name => "You're Toast";
        /// <summary>
        /// Property for the description
        /// </summary>
        /// <returns>Returns the Description of the Item</returns>
        public override string Description => "Texas Toast.";
        /// <summary>
        /// private variable for the count
        /// </summary>
        private uint _count = 2;
        /// <summary>
        /// Property to get the count of strips of bacon
        /// </summary>
        public uint Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value != 2)
                {
                    if (value < 1)
                    {
                        _count = 1;
                    }
                    else if (value > 12) _count = 12;
                    else _count = value;
                }
                OnPropertyChanged("Calories");
                OnPropertyChanged("Price");
                OnPropertyChanged("Count");
                OnPropertyChanged("SpecialInstructions");
            }
        }
        /// <summary>
        /// Property to get the price, counted as price per strip
        /// </summary>
        /// <returns>The price of the item</returns>
        public override decimal Price
        {
            get
            {
                decimal price = 0;
                for (int i = 1; i <= Count; i++)
                {
                    price += 1.00m;
                }
                return price;
            }
        }
        /// <summary>
        /// Property to get the amount of calories
        /// </summary>
        /// <returns>The calories of the item</returns>
        public override uint Calories
        {
            get
            {
                uint calories = 0;
                for (int i = 1; i <= Count; i++)
                {
                    calories += 100u;
                }
                return calories;
            }
        }
        /// <summary>
        /// Property to get the special insturctions
        /// </summary>
        /// <returns>The Special Instructions of the item</returns>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (Count != 2)
                {
                    instructions.Add(Count + " slices");
                }
                return instructions;
            }
        }
    }
}
