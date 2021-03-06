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

namespace MathEngine.Presentation
{
    /// <summary>
    /// Interaction logic for Parenthesis.xaml
    /// </summary>
    public partial class Parenthesis : Glyph
    {
        public Parenthesis()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ContentProperty = DependencyProperty.Register(
            "Content", typeof(IEnumerable<Glyph>), typeof(Parenthesis), new PropertyMetadata(default(IEnumerable<Glyph>)));

        public IEnumerable<Glyph> Content
        {
            get { return (IEnumerable<Glyph>) GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
    }
}
