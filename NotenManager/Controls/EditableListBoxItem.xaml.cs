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
using System.Windows.Threading;

namespace NotenManager.Controls
{
    /// <summary>
    /// Interaction logic for EditableListBoxItem.xaml
    /// </summary>
    public partial class EditableListBoxItem : UserControl
    {



        public string EditedValue
        {
            get { return (string)GetValue(EditedValueProperty); }
            set { SetValue(EditedValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditedValueProperty =
            DependencyProperty.Register("EditedValue", typeof(string), typeof(EditableListBoxItem), new PropertyMetadata(""));



        public EditableListBoxItem()
        {
            InitializeComponent();
            this.NameBox.DataContext = this;
            this.DisplayLabel.DataContext = this;
        }

        private void ContentControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            this.DisplayLabel.Visibility = Visibility.Hidden;
            this.NameBox.Visibility = Visibility.Visible;
            NameBox.Dispatcher.BeginInvoke(DispatcherPriority.Input,
    new Action(() => 
    {
        NameBox.Focus();         // Set Logical Focus
        Keyboard.Focus(NameBox); // Set Keyboard Focus
    }));
            

        }

        private void NameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.NameBox.Visibility = Visibility.Hidden;
                this.DisplayLabel.Visibility = Visibility.Visible;
            
            }
        }

        private void NameBox_LostFocus(object sender, RoutedEventArgs e)
        {
            this.NameBox.Visibility = Visibility.Hidden;
            this.DisplayLabel.Visibility = Visibility.Visible;
        }
    }
}
