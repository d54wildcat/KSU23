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

namespace TheFlyingSaucer.PointOfSale
{
    /// <summary>
    /// Interaction logic for CountControl.xaml
    /// </summary>
    public partial class CountControl : UserControl
    {
        public CountControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Controls the count property
        /// </summary>
        public static readonly DependencyProperty CountProperty = DependencyProperty.Register(
                nameof(Count), 
                typeof(uint),
                typeof(CountControl),
                new FrameworkPropertyMetadata(0u, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        /// <summary>
        /// Gets and sets the count property
        /// </summary>
        public uint Count
        {
            get { return (uint)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }
        /// <summary>
        /// Handles increment
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arg</param>
        private void HandleIncrement(object sender, RoutedEventArgs e)
        {
            if (Count != uint.MaxValue) Count++;
            e.Handled = true;
        }

        /// <summary>
        /// Handles decrement
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arg</param>
        private void HandleDecrement(object sender, RoutedEventArgs e)
        {
            if (Count != 0) Count--;
            e.Handled = true;
        }


    }
}
