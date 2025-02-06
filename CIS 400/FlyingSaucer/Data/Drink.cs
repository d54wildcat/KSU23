using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Class for the Drink items
    /// </summary>
    public abstract class Drink : IMenuItem, INotifyPropertyChanged
    {
        /// <summary>
        /// Event for the property changed
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;
        /// <summary>
        /// The name of the Drink
        /// </summary>
        /// <returns>The name of the Drink</returns>
        public abstract string Name { get; }
        /// <summary>
        /// The description of the Drink
        /// </summary>
        /// <returns>The description of the Drink</returns>
        public abstract string Description
        {
            get;
        }
        /// <summary>
        /// The price of the Drink
        /// </summary>
        /// <returns>The price of the Drink</returns>
        public abstract decimal Price { get; }
        /// <summary>
        /// The calories of the Drink
        /// </summary>
        /// <returns>The calories of the Drink</returns>
        public abstract uint Calories { get; }
        /// <summary>
        /// Special instructions for the Drink
        /// </summary>
        /// <returns>A list of all the special instructions</returns>
        public virtual IEnumerable<string> SpecialInstructions { get; }

        /// <summary>
        /// The Size of the drink
        /// </summary>
        public ServingSize Size { get; set; }

        /// <summary>
        /// Returns the name of the String
        /// </summary>
        /// <returns>Returns the name of the String</returns>
        public override string ToString()
        {
            return Name.ToString();
        }
        
        /// <summary>
        /// Method on if the property is changed
        /// </summary>
        /// <param name="propertyName">the property name</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
