using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// A base class representing the entrees
    /// </summary>
    public abstract class Entree : IMenuItem, INotifyPropertyChanged
    {
        /// <summary>
        /// The name of the entree
        /// </summary>
        /// <returns>The name of the entree</returns>
        public abstract string Name { get; }
        /// <summary>
        /// The description of the entree
        /// </summary>
        /// <returns>The description of the entree</returns>
        public abstract string Description { get; }
        /// <summary>
        /// The price of the entree
        /// </summary>
        /// <returns>The price of the entree</returns>
        public abstract decimal Price { get; }
        /// <summary>
        /// The calories of the entree
        /// </summary>
        /// <returns>The calories of the entree</returns>
        public abstract uint Calories { get; }
        /// <summary>
        /// Special instructions for the entree
        /// </summary>
        /// <returns>A list of all the special instructions</returns>
        public virtual IEnumerable<string> SpecialInstructions { get; }
        /// <summary>
        /// Returns the name of the entree
        /// </summary>
        /// <returns>Returns the name of the entree</returns>
        public override string ToString()
        {
            return Name;
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
