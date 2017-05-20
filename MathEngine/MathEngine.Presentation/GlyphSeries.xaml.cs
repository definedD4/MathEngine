using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    /// Interaction logic for GlyphSeries.xaml
    /// </summary>
    public partial class GlyphSeries : UserControl
    {
        public GlyphSeries()
        {
            InitializeComponent();
        }

        public IEnumerable<Glyph> ItemsSource
        {
            get { return (IEnumerable<Glyph>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable<Glyph>), typeof(GlyphSeries), new PropertyMetadata(new PropertyChangedCallback(OnItemsSourcePropertyChanged)));

        private static void OnItemsSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as GlyphSeries;
            control?.OnItemsSourceChanged((IEnumerable<Glyph>)e.OldValue, (IEnumerable<Glyph>)e.NewValue);
        }



        private void OnItemsSourceChanged(IEnumerable<Glyph> oldValue, IEnumerable<Glyph> newValue)
        {
            var oldValueINotifyCollectionChanged = oldValue as INotifyCollectionChanged;

            if (null != oldValueINotifyCollectionChanged)
            {
                oldValueINotifyCollectionChanged.CollectionChanged -= new NotifyCollectionChangedEventHandler(ItemsSourceCollectionChanged);
            }

            var newValueINotifyCollectionChanged = newValue as INotifyCollectionChanged;
            if (null != newValueINotifyCollectionChanged)
            {
                newValueINotifyCollectionChanged.CollectionChanged += new NotifyCollectionChangedEventHandler(ItemsSourceCollectionChanged);
            }

        }

        void ItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            
        }
    }
}
