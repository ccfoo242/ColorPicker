﻿using ColorPicker.Models;
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

namespace ColorPicker
{
    public partial class ColorSliders : UserControl, IColorStateStorage
    {
        public DependencyProperty ColorStateProperty = 
            DependencyProperty.Register(nameof(ColorState), typeof(ColorState), typeof(ColorSliders), 
                new PropertyMetadata());
        
        public ColorState ColorState
        {
            get => (ColorState)GetValue(ColorStateProperty);
            set => SetValue(ColorStateProperty, value);
        }

        public NotifyableColor Color { get; set; }

        public ColorSliders()
        {
            Color = new NotifyableColor(this);
            InitializeComponent();
        }

        
    }
}
