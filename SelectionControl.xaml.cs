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

namespace Практическая5
{
    /// <summary>
    /// Логика взаимодействия для SelectionControl.xaml
    /// </summary>
    public partial class SelectionControl : UserControl
    {
        Punct punct;

        public SelectionControl(Punct punct)
        {
            InitializeComponent();

            this.punct = punct;
            SelectedCheckBox.IsChecked = punct.selected;
            NameLabel.Content = punct.name;
            PunctImage.Source = new BitmapImage(new Uri(punct.image, UriKind.Relative));
        }

        private void SelectedCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            punct.selected = true;
        }

        private void SelectedCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            punct.selected = false;
        }
    }
}
