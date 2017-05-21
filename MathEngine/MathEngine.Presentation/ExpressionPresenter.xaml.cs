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
    /// Interaction logic for ExpressionPresenter.xaml
    /// </summary>
    public partial class ExpressionPresenter : UserControl
    {
        public ExpressionPresenter()
        {
            InitializeComponent();

            Build();
        }

        private void Build()
        {
            Glyphs.ItemsSource = new Glyph[]
            {
                new Char {Value = '-'},
                new Char {Value = '5'},
                new Parenthesis
                {
                    Content = new Glyph[]
                    {
                        new Char() {Value = '2'},
                        new Char() {Value = ' '},
                        new Char() {Value = 'x'},
                        new Char() {Value = '+'},
                        new Char() {Value = '3'}
                    }
                },
                new Char {Value = '+'},
                new Char {Value = 'z'}
            };
        }
    }
}
