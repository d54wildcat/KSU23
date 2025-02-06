/*EvisceratedEggs.cs
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
    /// Class for the Eviscerated Eggs side
    /// </summary>
    public class EvisceratedEggs : Side
    {
        /// <summary>
        /// Property for name
        /// </summary>
        /// <returns>Returns the Name of the item</returns>
        public override string Name => "Eviscerated Eggs";
        /// <summary>
        /// Property for the description
        /// </summary>
        /// <returns>Returns the description of the item</returns>
        public override string Description => "Eggs prepared the way you like.";
        /// <summary>
        /// private variable for the count
        /// </summary>
        private uint _count = 2;
        /// <summary>
        /// private variable for the style
        /// </summary>
        public EggStyle _style = EggStyle.OverEasy;
        /// <summary>
        /// Property to get the style of the eggs
        /// </summary>
        public EggStyle Style {
            get
            {
                return _style;
            }
            set
            {
                if (_style != value)
                {
                    _style = value;
                    OnPropertyChanged("Style");
                    OnPropertyChanged("Calories");
                    OnPropertyChanged("SpecialInstructions");
                }
            }
        }
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
        public override uint Calories => 78u * Count;
        /// <summary>
        /// Property to get the special insturctions
        /// </summary>
        /// <returns>The Special Instructions of the item</returns>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (Count != 2) instructions.Add($"{Count} eggs ");
                if (Style == EggStyle.OverEasy) instructions.Add("Over Easy");
                if (Style == EggStyle.SunnySideUp) instructions.Add("Sunny Side Up");
                if (Style == EggStyle.HardBoiled) instructions.Add("Hard Boiled");
                if (Style == EggStyle.Scrambled) instructions.Add("Scrambled");
                if (Style == EggStyle.SoftBoiled) instructions.Add("Soft Boiled");
                if (Style == EggStyle.Poached) instructions.Add("Poached");
                return instructions;
            }
        }
    }
}
