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
    /// Interaction logic for MenuItemSelectionControl.xaml
    /// </summary>
    public partial class MenuItemSelectionControl : UserControl
    {
        /// <summary>
        /// The Main Window
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
        public MenuItemSelectionControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// event handler for clicking a menu item
        /// </summary>
        /// <param name="sender">sneder for the event</param>
        /// <param name="e">Metadata for the event</param>
        private void AddItemClick(object sender, RoutedEventArgs e)
        {
            if (sender == takenBaconButton)
            {
                var item = new TakenBacon();

                if (DataContext is ICollection<IMenuItem> list)
                {
                    list.Add(item);
                    MainWindow.MenuBorder.Child = new TakenBaconControl() { DataContext = item };
                }
            }
            else if (sender == flyingSaucerButton)
            {
                var item = new FlyingSaucer();

                if (DataContext is ICollection<IMenuItem> list)
                {
                    list.Add(item);
                    MainWindow.MenuBorder.Child = new TheFlyingSaucerControL() { DataContext = item };
                }
            }
            else if (sender == crashedSaucerButton)
            {
                var item = new CrashedSaucer();

                if (DataContext is ICollection<IMenuItem> list)
                {
                    list.Add(item);
                    MainWindow.MenuBorder.Child = new CrashedSaucerControl() { DataContext = item };
                }
            }
            else if (sender == livestockMutilationButton)
            {
                var item = new LivestockMutilation();

                if (DataContext is ICollection<IMenuItem> list)
                {
                    list.Add(item);
                    MainWindow.MenuBorder.Child = new LivestockMutilationControl() { DataContext = item };
                }
            }
            else if (sender == outerOmeltteButton)
            {
                var item = new OuterOmelette();

                if (DataContext is ICollection<IMenuItem> list)
                {
                    list.Add(item);
                    MainWindow.MenuBorder.Child = new OuterOmeletteControl() { DataContext = item };
                }
            }
            else if (sender == cropCircleButton)
            {
                var item = new CropCircle();

                if (DataContext is ICollection<IMenuItem> list)
                {
                    list.Add(item);
                    MainWindow.MenuBorder.Child = new CropCircleControl() { DataContext = item };
                }
            }
            else if (sender == glowingHaystackButton)
            {
                var item = new GlowingHaystack();

                if (DataContext is ICollection<IMenuItem> list)
                {
                    list.Add(item);
                    MainWindow.MenuBorder.Child = new GlowingHaystackControl() { DataContext = item };
                }
            }
            else if (sender == missingLinksButton)
            {
                var item = new MissingLinks();

                if (DataContext is ICollection<IMenuItem> list)
                {
                    list.Add(item);
                    MainWindow.MenuBorder.Child = new MissingLinksControl() { DataContext = item };
                }
            }
            else if (sender == evisceratedEggsButton)
            {
                var item = new EvisceratedEggs();

                if (DataContext is ICollection<IMenuItem> list)
                {
                    list.Add(item);
                    MainWindow.MenuBorder.Child = new EvisceratedEggsControl() { DataContext = item };
                }
            }
            else if (sender == youAreToastButton)
            {
                var item = new YouAreToast();

                if (DataContext is ICollection<IMenuItem> list)
                {
                    list.Add(item);
                    MainWindow.MenuBorder.Child = new YouAreToastControl() { DataContext = item };
                }
            }
            else if (sender == liquifiedVegetationButton)
            {
                var item = new LiquifiedVegetation();

                if (DataContext is ICollection<IMenuItem> list)
                {
                    list.Add((IMenuItem)item);
                    MainWindow.MenuBorder.Child = new LiquifiedVegetationControl() { DataContext = item };
                }
            }
            else if (sender == saucerFuelButton)
            {
                var item = new SaucerFuel();

                if (DataContext is ICollection<IMenuItem> list)
                {
                    list.Add(item);
                    MainWindow.MenuBorder.Child = new SaucerFuelControl() { DataContext = item };
                }
            }
            else if (sender == inorganicSubstanceButton)
            {
                var item = new InorganicSubstance();

                if (DataContext is ICollection<IMenuItem> list)
                {
                    list.Add(item);
                    MainWindow.MenuBorder.Child = new InorganicSubstanceControl() { DataContext = item };
                }
            }
        }
    }
}
