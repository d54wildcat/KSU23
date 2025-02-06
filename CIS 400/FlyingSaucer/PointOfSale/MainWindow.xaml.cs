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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheFlyingSaucer.Data;

namespace TheFlyingSaucer.PointOfSale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindow MainWindowWindow
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

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Order();
        }
        /// <summary>
        /// Order summary
        /// </summary>
        /// <param name="sender">the object to send</param>
        /// <param name="e">The object summary</param>
        private void OrderSummaryControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Method intentionally left empty.
        }
        /// <summary>
        /// Back to menu button event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        public void BackToMenu(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICollection<IMenuItem> list)
            {
                if (e.OriginalSource is Button button)
                {
                    e.Handled = true;
                    this.MenuBorder.Child = new MenuItemSelectionControl();
                }
            }
        }
    }
}
