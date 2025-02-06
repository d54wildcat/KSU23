/*LivestockMutilation.cs
 * Author: Dacey Wieland
 */
namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Class for the LivestockMutilation item.
    /// </summary>
    public class LivestockMutilation : Entree, IMenuItem
    {
        /// <summary>
        /// Property to get the name of the item
        /// </summary>
        /// <returns>Returns the Name of the item</returns>
        public override string Name => "Livestock Mutilation";
        /// <summary>
        /// Property to get the description of the item
        /// </summary>
        /// <returns>Returns the Description of the Item</returns>
        public override string Description => "A hearty serving of biscuits, smothered in sausage-laden gravy.";
        /// <summary>
        /// Property to get the default value of biscuits
        /// </summary>
        private uint _biscuits = 3;
        /// <summary>
        /// Property to get the amount of Biscuits
        /// </summary>
        public uint Biscuits
        {
            get
            {
                return _biscuits;
            }
            set
            {
                if (value <= 8)
                {
                    _biscuits = value;
                }
                else
                {
                    _biscuits = 8;
                }
                OnPropertyChanged("Calories");
                OnPropertyChanged("Price");
                OnPropertyChanged("Biscuits");
                OnPropertyChanged("SpecialInstructions");
            }
        }
        /// <summary>
        /// Property to get the default value of gravy
        /// </summary>
        private bool _gravy = true;
        /// <summary>
        /// Property to check if the customer wants gravy
        /// </summary>
        public bool Gravy
        {
            get
            {

                return _gravy;
            }
            set
            {
                if (_gravy != value)
                {
                    _gravy = value;
                    OnPropertyChanged("Calories");
                    OnPropertyChanged("SpecialInstructions");
                    OnPropertyChanged("Gravy");
                }
            }
        }
        /// <summary>
        /// property to get the total price
        /// </summary>
        /// <returns>The price of the item</returns>
        public override decimal Price
        {
            get
            {
                decimal price = 7.25m;
                if (Biscuits > 3)
                {
                    decimal additional = (Biscuits - 3) * 1.00m;
                    price += additional;
                    return price;
                }
                else return price;
            }
        }

        /// <summary>
        /// property to get the total amount of calories of the item
        /// </summary>
        /// <returns>The calories of the item</returns>
        public override uint Calories
        {
            get
            {
                uint calories = (49u * Biscuits);
                if (Gravy) calories += 140u;
                return calories;

            }
        }
        /// <summary>
        /// Property for the special instructions
        /// </summary>
        /// <returns>The Special Instructions of the item</returns>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> special = new();
                if (Biscuits != 3) special.Add($"{Biscuits} biscuits");
                if (!Gravy) special.Add("Hold Gravy");
                return special;
            }
        }
    }
}
