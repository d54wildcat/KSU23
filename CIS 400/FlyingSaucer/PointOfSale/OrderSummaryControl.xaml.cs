using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TheFlyingSaucer.Data;

namespace TheFlyingSaucer.PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderSummaryControl.xaml
    /// </summary>
    public partial class OrderSummaryControl : UserControl
    {
        /// <summary>
        /// The MainWindow
        /// </summary>
        private MainWindow MainWindow
        {
            get
            {
                DependencyObject dp = this;
                do
                {
                    dp = LogicalTreeHelper.GetParent(dp);
                }
                while (!(dp is null || dp is MainWindow));
                return (MainWindow)dp;
            }
        }

        public OrderSummaryControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Remove button method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        public void RemoveItemClick(object sender, RoutedEventArgs e)
        {
            if(DataContext is ICollection<IMenuItem> list)
            {
                if(e.OriginalSource is Button button)
                {
                    e.Handled = true;
                    list.Remove((IMenuItem)button.DataContext);
                    MainWindow.MenuBorder.Child = new MenuItemSelectionControl();
                }
            }
        }
        /// <summary>
        /// Edit button event
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        public void EditItemClick(object sender, RoutedEventArgs e)
        {

            if (DataContext is ICollection<IMenuItem> list)
            {
                if (e.OriginalSource is Button button)
                {
                    e.Handled = true;
                    var temp = (IMenuItem)button.DataContext;
                    switch (temp)
                    {
                        case FlyingSaucer:
                            MainWindow.MenuBorder.Child = new TheFlyingSaucerControL { DataContext = temp };
                            break;
                        case CrashedSaucer:
                            MainWindow.MenuBorder.Child = new CrashedSaucerControl() { DataContext = temp };
                            break;
                        case LivestockMutilation:
                            MainWindow.MenuBorder.Child = new LivestockMutilationControl() { DataContext = temp };
                            break;
                        case OuterOmelette:
                            MainWindow.MenuBorder.Child = new OuterOmeletteControl() { DataContext = temp };
                            break;
                        case CropCircle:
                            MainWindow.MenuBorder.Child = new CropCircleControl() { DataContext = temp };
                            break;
                        case GlowingHaystack:
                            MainWindow.MenuBorder.Child = new GlowingHaystackControl() { DataContext = temp };
                            break;
                        case TakenBacon:
                            MainWindow.MenuBorder.Child = new TakenBaconControl() { DataContext = temp };
                            break;
                        case MissingLinks:
                            MainWindow.MenuBorder.Child = new MissingLinksControl() { DataContext = temp };
                            break;
                        case EvisceratedEggs:
                            MainWindow.MenuBorder.Child = new EvisceratedEggsControl() { DataContext = temp };
                            break;
                        case YouAreToast:
                            MainWindow.MenuBorder.Child = new YouAreToastControl() { DataContext = temp };
                            break;
                        case LiquifiedVegetation:
                            MainWindow.MenuBorder.Child = new LiquifiedVegetationControl() { DataContext = temp };
                            break;
                        case SaucerFuel:
                            MainWindow.MenuBorder.Child = new SaucerFuelControl() { DataContext = temp };
                            break;
                        case InorganicSubstance:
                            MainWindow.MenuBorder.Child = new InorganicSubstanceControl() { DataContext = temp };
                            break;
                    }
                }
            }
        }
    }
}
