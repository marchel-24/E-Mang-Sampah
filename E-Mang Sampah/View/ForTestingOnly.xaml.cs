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
using System.Windows.Shapes;

namespace E_Mang_Sampah.View
{
    /// <summary>
    /// Interaction logic for ForTestingOnly.xaml
    /// </summary>
    public partial class ForTestingOnly : Window
    {
        public ForTestingOnly()
        {
            InitializeComponent();
            stackPanel.Children.Add(new TextBox());
            stackPanel.Children.Add(new TextBox());
            stackPanel.Children.Add(new TextBox());
            stackPanel.Children.Add(new TextBox());
        }
    }
}
