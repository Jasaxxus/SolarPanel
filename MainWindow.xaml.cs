using System;
using System.Windows;

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
            switch (cityId.Text)
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
                    errorId.Text = "Choose City";
                    break;
            }
            if (sunHours != 0)
            {
                try
                {
                    if (powerId.Text == null || powerId.Text.Trim().Equals("")) Console.WriteLine(kwattCalc(sunHours, 250));
                    else kwattCalc(sunHours, Int32.Parse(powerId.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }


        public float kwattCalc(float sunHours, int power)
        {
            return (((float.Parse(squareId.Text.Replace('.', ',')) / 1.6f) * power) * sunHours) / 1000;
        }
    }
}
