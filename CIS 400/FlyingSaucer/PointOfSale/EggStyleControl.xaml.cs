using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using TheFlyingSaucer.Data;

namespace TheFlyingSaucer.PointOfSale
{
    /// <summary>
    /// Interaction logic for EggStyleControl.xaml
    /// </summary>
    public partial class EggStyleControl : UserControl
    {
        /// <summary>
        /// Initializes the EggStyleControl
        /// </summary>
        public EggStyleControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Dependency property for the egg style
        /// </summary>
        public static readonly DependencyProperty EggStyleProperty =
            DependencyProperty.Register("EggStyle", typeof(EggStyle), typeof(EggStyleControl), new PropertyMetadata(EggStyle.SoftBoiled));
        /// <summary>
        /// Gets and sets the egg style
        /// </summary>
        public EggStyle EggStyle
        {
            get { return (EggStyle)GetValue(EggStyleProperty); }
            set { SetValue(EggStyleProperty, value); }
        }
        /// <summary>
        /// Dependency property for the egg style list
        /// </summary>
        public static readonly DependencyProperty EggStyleListProperty =
            DependencyProperty.Register("EggStyleList", typeof(IEnumerable<EggStyle>), typeof(EggStyleControl), new PropertyMetadata(new List<EggStyle>
            {
                EggStyle.SoftBoiled,
                EggStyle.HardBoiled,
                EggStyle.Scrambled,
                EggStyle.Poached,
                EggStyle.SunnySideUp,
                EggStyle.OverEasy
            }));
        /// <summary>
        /// Gets and sets the egg style list
        /// </summary>
        public IEnumerable<EggStyle> EggStyleList
        {
            get { return (IEnumerable<EggStyle>)GetValue(EggStyleListProperty); }
            set { SetValue(EggStyleListProperty, value); }
        }
    }


}
