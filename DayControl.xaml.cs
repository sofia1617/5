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
    /// Логика взаимодействия для DayControl.xaml
    /// </summary>
    public partial class DayControl : UserControl
    {
        public DayControl(DateTime date, DaySelect daySelect = null)
        {
            InitializeComponent();

            Day.Content = date.Day;

            if (daySelect != null && daySelect.puncts.Count > 0)
            {
                Punct punct = daySelect.puncts[0];
                DayImage.Source = new BitmapImage(new Uri(punct.image, UriKind.Relative));
            }
        }
    }
}
