/*TakenBacon.cs
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
    public class TakenBacon : Side
    {
        /// <summary>
        /// Property for name
        /// </summary>
        /// <returns>Returns the Name of the item</returns>
        public override string Name => "Taken Bacon";
        /// <summary>
        /// Property for the description
        /// </summary>
        /// <returns>Returns the Description of the Item</returns>
        public override string Description => "Crispy strips of bacon.";
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
                    else if (value > 6) _count = 6;
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
        public override decimal Price => 1.00m * Count;
        /// <summary>
        /// Property to get the amount of calories
        /// </summary>
        /// <returns>The calories of the item</returns>
        public override uint Calories => 43u * Count;
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
                    instructions.Add(Count + " strips");
                }
                return instructions;
            }
        }
    }
}
