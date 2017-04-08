using NotenManager.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace NotenManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<Student> Class1;
        public ObservableCollection<Student> Class2;
        public ObservableCollection<Student> Class3;
        public ObservableCollection<Student> Class4;

        public ObservableCollection<Student> CurrentClass
        {
            get { return (ObservableCollection<Student>)GetValue(CurrentClassProperty); }
            set { SetValue(CurrentClassProperty, value); }
        }


        // Using a DependencyProperty as the backing store for CurrentClass.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentClassProperty =
            DependencyProperty.Register("CurrentClass", typeof(ObservableCollection<Student>), typeof(MainWindow), new PropertyMetadata(new ObservableCollection<Student>()));



        public MainWindow()
        {
            InitializeComponent();
            InitClasses();
            this.DataContext = this;
        }

        private void InitClasses()
        {
            Class1 = new ObservableCollection<Student>();
            Class2 = new ObservableCollection<Student>();
            Class3 = new ObservableCollection<Student>();
            Class4 = new ObservableCollection<Student>();
            Class1.Add(new Student("Mehmetcan", "Sinir"));
            Class2.Add(new Student("Verena", "Gfüllner"));
        }

        private void RibbonButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            string tag = (string)b.Tag;            
            switch(tag)
            {
                case "firstClass":
                    this.CurrentClass = Class1;
                    break;
                case "secondClass":
                    this.CurrentClass = Class2;
                    break;
                
            }
        }

        private void StudentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
