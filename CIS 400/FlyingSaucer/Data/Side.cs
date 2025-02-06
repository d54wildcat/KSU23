using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// A base class representing the sides
    /// </summary>
    public abstract class Side : IMenuItem, INotifyPropertyChanged
    {
        /// <summary>
        /// The name of the side
        /// </summary>
        /// <returns>The name of the side</returns>
        public abstract string Name { get; }
        /// <summary>
        /// The description of the side
        /// </summary>
        /// <returns>The description of the side</returns>
        public abstract string Description { get; }
        /// <summary>
        /// The price of the side
        /// </summary>
        /// <returns>The price of the side</returns>
        public abstract decimal Price { get; }
        /// <summary>
        /// The calories of the side
        /// </summary>
        /// <returns>The calories of the side</returns>
        public abstract uint Calories { get; }
        /// <summary>
        /// Special instructions for the side
        /// </summary>
        /// <returns>A list of all the special instructions</returns>
        public virtual IEnumerable<string> SpecialInstructions { get; }
        /// <summary>
        /// Returns the name of the side
        /// </summary>
        /// <returns>Returns the name of the side</returns>
        public override string ToString()
        {
            return Name.ToString();
        }
        /// <summary>
        /// Event for the property changed
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;
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
