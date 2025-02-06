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
    /// Interaction logic for SizeControl.xaml
    /// </summary>
    public partial class ServingSizeControl : UserControl
    {
        public ServingSizeControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Dependency Property for the Size
        /// </summary>
        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.Register("Size", typeof(ServingSize), typeof(ServingSizeControl), new PropertyMetadata(ServingSize.Small));
        /// <summary>
        /// Property for the Size
        /// </summary>
        public ServingSize Size
        {
            get { return (ServingSize)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }
        /// <summary>
        /// Property dependent on decreasing the Size of the property
        /// </summary>
        public static readonly DependencyProperty DecreaseSizeCommandProperty =
            DependencyProperty.Register("DecreaseSizeCommand", typeof(ICommand), typeof(ServingSizeControl), new PropertyMetadata(null));
        /// <summary>
        /// Property for the decrease command
        /// </summary>
        public ICommand DecreaseSizeCommand
        {
            get { return (ICommand)GetValue(DecreaseSizeCommandProperty); }
            set { SetValue(DecreaseSizeCommandProperty, value); }
        }
        /// <summary>
        /// Property dependant on increasing the size
        /// </summary>
        public static readonly DependencyProperty IncreaseSizeCommandProperty =
            DependencyProperty.Register("IncreaseSizeCommand", typeof(ICommand), typeof(ServingSizeControl), new PropertyMetadata(null));
        /// <summary>
        /// property to increase the size
        /// </summary>
        public ICommand IncreaseSizeCommand
        {
            get { return (ICommand)GetValue(IncreaseSizeCommandProperty); }
            set { SetValue(IncreaseSizeCommandProperty, value); }
        }
        
    }
}
