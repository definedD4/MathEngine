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

namespace MathEngine.Presentation
{
    /// <summary>
    /// Interaction logic for Char.xaml
    /// </summary>
    public partial class Char : Glyph
    {
        public Char()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof(char), typeof(Char), new PropertyMetadata(default(char)));

        public char Value
        {
            get { return (char) GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
    }
}
