/* FlyingSaucer.cs
 * Author: Nathan Bean
 * Modified By: Dacey Wieland
 */
namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Class for the FlyingSaucer menu item.
    /// </summary>
    public class FlyingSaucer : Entree
    {
        /// <summary>
        /// The name of the FlyingSaucer instance
        /// </summary>
        /// <returns>Returns the Name of the item</returns>
        /// 
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>

        public override string Name => "Flying Saucer";

        /// <summary>
        /// The description of the FlyingSaucer instance
        /// </summary>
        /// <returns>Returns the Description of the Item</returns>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description => "A stack of six pancakes, smothered in rich maple syrup, and topped with mixed berries and whipped cream.";

        /// <summary>
        /// The private backing field for the StackSize property
        /// </summary>
        private uint _stackSize = 6;

        /// <summary>
        /// The number of panacakes in this instance of a Flying Saucer
        /// </summary>
        /// <remarks>
        /// Note the set limits the stack size to a maximum of 12 pancakes
        /// </remarks>
        public uint StackSize { 
            get 
            { 
                return _stackSize; 
            }
            set
            {
                if (value <= 12)
                {
                    _stackSize = value;
                }
                else
                {
                    _stackSize = 12;
                }
                OnPropertyChanged("Calories");
                OnPropertyChanged("Price");
                OnPropertyChanged("StackSize");
                OnPropertyChanged("SpecialInstructions");
            }
        }

        /// <summary>
        /// private variable for the syrup
        /// </summary>
        private bool _syrup = true;
        /// <summary>
        /// Property to get or set the syrup
        /// </summary>
        public bool Syrup
        {
            get
            {

                return _syrup;
            }
            set
            {
                if (_syrup != value)
                {
                    _syrup = value;
                    OnPropertyChanged("Calories");
                    OnPropertyChanged("SpecialInstructions");
                    OnPropertyChanged("Syrup");
                }
            }
        }

        /// <summary>
        /// private variable for the Whipped Cream
        /// </summary>
        private bool _whippedCream = true;
        /// <summary>
        /// Property to get or set the syrup
        /// </summary>
        public bool WhippedCream
        {
            get
            {

                return _whippedCream;
            }
            set
            {
                if (_whippedCream != value)
                {
                    _whippedCream = value;
                    OnPropertyChanged("Calories");
                    OnPropertyChanged("SpecialInstructions");
                    OnPropertyChanged("Whipped Cream");
                }
            }
        }

        /// <summary>
        /// private variable for the Berries
        /// </summary>
        private bool _berries = true;
        /// <summary>
        /// Property to get or set the syrup
        /// </summary>
        public bool Berries
        {
            get
            {

                return _berries;
            }
            set
            {
                if (_berries != value)
                {
                    _berries = value;
                    OnPropertyChanged("Calories");
                    OnPropertyChanged("SpecialInstructions");
                    OnPropertyChanged("Berries");
                }
            }
        }

        /// <summary>
        /// The price of the FlyingSaucer instance
        /// </summary>
        /// <returns>The price of the item</returns>
        public override decimal Price
        {
            get
                { 
                decimal price = 8.50m;
                if (StackSize > 6)
                {
                    decimal additional = StackSize - 6;
                    additional *= 0.75m;
                    return price + additional;
                }
                else return price;
            }
        }

        /// <summary>
        /// The calories of the FlyingSaucer instance
        /// </summary>
        /// <returns>The calories of the item</returns>
        /// <remarks>
        /// This is a get-only property whose value is derived from the other properties of the class.
        /// </remarks>
        public override uint Calories
        {
            get
            {
                uint calories = 64u * StackSize;
                if (Syrup) calories += 32u;
                if (WhippedCream) calories += 414u;
                if (Berries) calories += 89u;
                return calories;

            }
        }

        /// <summary>
        /// Special instructions for the preparation of this FlyingSaucer
        /// </summary>
        /// <returns>The Special Instructions of the item</returns>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (StackSize != 6) instructions.Add($"{StackSize} Pancakes");
                if (!Syrup) instructions.Add("Hold Syrup");
                if (!WhippedCream) instructions.Add("Hold Whipped Cream");
                if (!Berries) instructions.Add("Hold Berries");
                return instructions;
            }
        }
    }
}