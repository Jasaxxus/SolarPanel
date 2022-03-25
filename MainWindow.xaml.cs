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

namespace SolarPanel
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml 
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculate(object sender, RoutedEventArgs e)
        {
            float sunHours = 0;
            try
            {
                if(powerId.Text == null || powerId.Text.Trim().Equals(""))
                {
                    switch(cityId.Text)
                    {
                        case "Riga":
                            sunHours = 2.7f;
                            break;                        
                        case "Madrid":
                            sunHours = 3.7f;
                            break;
                        case "London":
                            sunHours = 2.3f;
                            break;
                        case "New York":
                            sunHours = 3.2f;
                            break;
                        default:
                            break;
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
