﻿using System;
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
    /// Interaction logic for CrashedSaucerControl.xaml
    /// </summary>
    public partial class CrashedSaucerControl : UserControl
    {
        public CrashedSaucerControl()
        {
            InitializeComponent();
            DataContext = new CrashedSaucer();
        }
    }
}
