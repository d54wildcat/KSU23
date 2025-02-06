using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Represents an order containing multiple menu items
    /// </summary>
    public class Order : ICollection<IMenuItem>, INotifyPropertyChanged, INotifyCollectionChanged
    {
        /// <summary>
        /// The list of menu items in the order
        /// </summary>
        private List<IMenuItem> _items = new List<IMenuItem>();
        public event NotifyCollectionChangedEventHandler? CollectionChanged;
        public event PropertyChangedEventHandler? PropertyChanged;
        public Order()
        {
            _lastUsed++;
            Number = _lastUsed;
            _timeSet = DateTime.Now;
            PlacedAt = _timeSet;
        }
        /// <summary>
        /// Private backing field for number
        /// </summary>
        private static uint _lastUsed = 0;
        /// <summary>
         /// Number
        /// </summary>
        public uint Number { get; init; }
        /// <summary>
        /// Private backing field for placed at
        /// </summary>
         private static DateTime _timeSet;
        /// <summary>
        /// The date the order was placed at
        /// </summary>
        public DateTime PlacedAt { get; init; }
        /// <summary>
        /// The price of all items in the order
        /// </summary>
        public decimal Subtotal
        {
            get
            {
                decimal subtotal = 0.00m;
                foreach (IMenuItem item in _items)
                {
                    subtotal += item.Price;
                }
                return subtotal;
            }
        }
        /// <summary>
        /// private variable for tax rate
        /// </summary>
        private decimal _taxRate = 0.10m;
        /// <summary>
        /// Represents the sales tax rate
        /// </summary>
        public decimal TaxRate
        {
            get
            {
                return _taxRate;
            }
            set
            {
                if(_taxRate != value)
                {
                    _taxRate = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TaxRate"));
                }
            }
        }
        /// <summary>
        /// The tax on the order
        /// </summary>
        public decimal Tax
        {
            get
            {
                return Math.Round(Subtotal * TaxRate, 2);
            }
        }
        /// <summary>
        /// The total price of the order
        /// </summary>
        public decimal Total
        {
            get
            {
                return Subtotal + Tax;
            }
        }
        /// <summary>
        /// The number of items in the order
        /// </summary>
        public int Count
        {
            get
            {
                return _items.Count;
            }
        }
        /// <summary>
        /// Whether the order is read-only
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// Adds an item to the order
        /// </summary>
        /// <param name="item">The item to add</param>
        public void Add(IMenuItem item)
        {
            _items.Add(item);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
        }
        /// <summary>
        /// Clears the order
        /// </summary>
        public void Clear()
        {
            _items.Clear();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
        }
        /// <summary>
        /// Checks if the order contains a specific item
        /// </summary>
        /// <param name="item">The item to check</param>
        /// <returns>Returns true if the order contains the item</returns>
        public bool Contains(IMenuItem item)
        {
            return _items.Contains(item);
        }
        /// <summary>
        /// Copies the order to an array
        /// </summary>
        /// <param name="array">The array to copy to</param>
        /// <param name="arrayIndex">The index of the array</param>
        public void CopyTo(IMenuItem[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// Gets the enumerator for the order
        /// </summary>
        /// <returns>Returns the items in the enumerator</returns>
        public IEnumerator<IMenuItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }
        /// <summary>
        /// Removes an item from the order
        /// </summary>
        /// <param name="item">the item to remove</param>
        /// <returns>Returns true if able to remove</returns>
        public bool Remove(IMenuItem item)
        {
            int index = _items.IndexOf(item);
            if (index == -1) return false;
            _items.Remove(item);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, index));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
            return true;
        }
        /// <summary>
        /// Gets the collections enumerator for the order
        /// </summary>
        /// <returns>Returns the enumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

    }
}

