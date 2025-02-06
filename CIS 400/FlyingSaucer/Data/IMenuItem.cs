using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Interface for all the properties the menu items share
    /// </summary>
    public interface IMenuItem
    {

        /// <summary>
        /// The Name of the item
        /// </summary>
        /// <returns>The name of the item</returns>
        public string Name
        {
            get;
        }
        /// <summary>
        /// The description of the item
        /// </summary>
        /// <returns>The description of the item</returns>
        public string Description { get; }
        /// <summary>
        /// The Price of the Item
        /// </summary>
        ///<returns>The price of the item</returns>
        public decimal Price { get; }
        /// <summary>
        /// The Calories of the item
        /// </summary>
        /// <returns>The Calories of the item</returns>
        public uint Calories { get; }
        /// <summary>
        /// The Special Instructions for the item.
        /// </summary>
        /// <returns>The Special Insturctions of the item</returns>
        public IEnumerable<string> SpecialInstructions { get; } 
    }
}
