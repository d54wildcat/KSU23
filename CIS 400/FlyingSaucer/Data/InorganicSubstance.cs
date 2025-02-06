using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// A class representing the Inorganic Substance drink
    /// </summary>
    public class InorganicSubstance : Drink
    {
        /// <summary>
        /// The name of the drink
        /// </summary>
        /// <returns>The name of the drink</returns>
        public override string Name => "Inorganic Substance";
        /// <summary>
        /// The description of the drink
        /// </summary>
        /// <returns>The description of the drink</returns>
        public override string Description => "A cold glass of ice water.";
        /// <summary>
        /// size backing
        /// </summary>
        private ServingSize _size = ServingSize.Small;
        /// <summary>
        /// The Serving Size of the drink, defaults to small
        /// </summary>
        public ServingSize Size
        {
            get
            {
                return _size;
            }
            set
            {
                if (_size != value)
                {
                    _size = value;
                    OnPropertyChanged("Calories");
                    OnPropertyChanged("Price");
                    OnPropertyChanged("SpecialInstructions");
                    OnPropertyChanged("Size");
                }
            }
        }
        /// <summary>
        /// If Ice is included in the drink
        /// </summary>
        private bool _ice = true;
        /// <summary>
        /// If Ice is includeded in the drink
        /// </summary>
        public bool Ice
        {
            get
            {
                return _ice;
            }
            set
            {
                if (_ice != value)
                {
                    _ice = value;
                    OnPropertyChanged("Calories");
                    OnPropertyChanged("SpecialInstructions");
                    OnPropertyChanged("Ice");
                }
            }
        }
        /// <summary>
        /// The price of the drink
        /// </summary>
        /// <returns>The price of the drink</returns>
        public override decimal Price
        {
            get
            {
                switch (Size)
                {
                    case ServingSize.Medium:
                        return 0.00m;
                    case ServingSize.Large:
                        return 0.00m;
                    default:
                        return 0.00m;
                }
            }   
        }
        /// <summary>
        /// The calories of the drink
        /// </summary>
        /// <returns>The calories of the drink</returns>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case ServingSize.Medium:
                        return 0u;
                    case ServingSize.Large:
                        return 0u;
                    default:
                        return 0u;
                }
            }
        }
        /// <summary>
        /// The Special Instructions of the drink
        /// </summary>
        /// <returns>The special insturctions of the drink</returns>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (!Ice)
                {
                    instructions.Add("No Ice");
                }
                return instructions;
            }
        }
    }
}
