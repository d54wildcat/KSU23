using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Class for the LiquifiedVegetation drink
    /// </summary>
    public class LiquifiedVegetation : Drink
    {
        /// <summary>
        /// The name of the drink
        /// </summary>
        /// <returns>The name of the drink</returns>
        public override string Name => "Liquified Vegetation";
        /// <summary>
        /// The description of the drink
        /// </summary>
        /// <returns>The description of the drink</returns>
        public override string Description => "A cold glass of blended vegetable juice.";
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
        /// If Ice is includeded in the drink
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
                        return 1.50m;
                    case ServingSize.Large:
                        return 2.00m;
                    default:
                        return 1.00m;
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
                        return 144u;
                    case ServingSize.Large:
                        return 216u;
                    default:
                        return 72u;
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
