using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// A class representing the Saucer Fuel drink
    /// </summary>
    public class SaucerFuel : Drink
    {
        /// <summary>
        /// If Decaf is includeded in the drink
        /// </summary>
        private bool _decaf = false;
        /// <summary>
        /// If Decaf is includeded in the drink
        /// </summary>
        public bool Decaf
        {
            get
            {
                return _decaf;
            }
            set
            {
                if (_decaf != value)
                {
                    _decaf = value;
                    OnPropertyChanged("Calories");
                    OnPropertyChanged("SpecialInstructions");
                    OnPropertyChanged("Decaf");
                }
            }
        }
        /// <summary>
        /// The name of the drink
        /// </summary>
        /// <returns>The name of the drink</returns>
        public override string Name
        {
            get
            {
                if (!Decaf)
                {
                    return "Saucer Fuel";
                }
                else { return "Decaf Saucer Fuel"; }
            }
        }
        /// <summary>
        /// The description of the drink
        /// </summary>
        /// <returns>The description of the drink</returns>
        public override string Description =>"A steaming cup of coffee.";
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
        /// If Cream is included in the drink
        /// </summary>
        private bool _cream = false;
        /// <summary>
        /// If Cream is included in the drink
        /// </summary>
        public bool Cream
        {
            get
            {
                return _cream;
            }
            set
            {
                if (_cream != value)
                {
                    _cream = value;
                    OnPropertyChanged("Calories");
                    OnPropertyChanged("SpecialInstructions");
                    OnPropertyChanged("Cream");
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
                        if (Cream)
                        {
                            return 2u + 29u;
                        }
                        else { return 2u; }
                    case ServingSize.Large:
                        if (Cream)
                        {
                            return 3u + 29u;
                        }
                        else { return 3u; }
                    default:
                        if (Cream)
                        {
                            return 1u + 29u;
                        }
                        else { return 1u; }
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
                if (Cream)
                {
                    instructions.Add("With Cream");
                }
                return instructions;
            }
        }
    }
}
