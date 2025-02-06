/*CrashedSaucer.cs
 * Author: Dacey Wieland
 */

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Class for the menu item Crashed Saucer
    /// </summary>
    public class CrashedSaucer : Entree
    {
        /// <summary>
        /// Property to get the name of the item
        /// </summary>
        /// <returns>Returns the Name of the item</returns>
        public override string Name => "Crashed Saucer";

        /// <summary>
        /// Property toget the description of the item
        /// </summary>
        /// <returns>Returns the Description of the Item</returns>
        public override string Description => "A stack of crispy french toast smothered in syrup and topped with a pat of butter.";

        /// <summary>
        /// private variable to set the default stack size
        /// </summary>
        private uint _stacks = 2;
        /// <summary>
        /// private variable for the initial amount of calories
        /// </summary>
        private uint _calories = 149u;
        /// <summary>
        /// Property to get or set the stack size
        /// </summary>
        public uint StackSize
        {
            get
            {
                return _stacks;
            }

            set
            {
                if (value <= 6)
                {
                    _stacks = value;
                }
                else
                {
                    _stacks = 6;
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
                if(_syrup != value)
                {
                    _syrup = value;
                    OnPropertyChanged("Calories");
                    OnPropertyChanged("SpecialInstructions");
                    OnPropertyChanged("Syrup");
                }
            }
        }
        /// <summary>
        /// Private field for butter
        /// </summary>
        private bool _butter = true;
        /// <summary>
        /// Property to get or set Butter.
        /// </summary>
        public bool Butter
        {
            get
            {
                return _butter;
            }
            set
            {
                if(_butter != value)
                {
                    _butter = value;
                    OnPropertyChanged("Calories");
                    OnPropertyChanged("SpecialInstructions");
                    OnPropertyChanged("Butter");
                }
            }
        }
        /// <summary>
        /// Price of the entree
        /// </summary>
        /// <returns>The price of the item</returns>
        public override decimal Price
        {
            get
            {
                decimal price = 6.45m;
                if (StackSize > 2)
                {
                    decimal additional = StackSize - 2;
                    price += (additional * 1.50m);
                    return price;
                }
                else return price;
            }
        }
        /// <summary>
        /// Get only property with values from the other properties of the class.
        /// </summary>
        /// <returns>The calories of the item</returns>
        public override uint Calories
        {
            get
            {
                uint calories = (_calories * StackSize);
                if (Syrup) calories += 52u;
                if (Butter) calories += 35u;
                return calories;
            }
        }
        /// <summary>
        /// Special instructions for the preparation of the menu item CrashedSaucer
        /// </summary>
        /// <returns>The Special Instructions of the item</returns>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> special = new();
                if (StackSize != 2) special.Add($"{StackSize} Slices");
                if (!Butter) special.Add("Hold Butter");
                if (!Syrup) special.Add("Hold Syrup");
                return special;
            }
        }
    }
}
