using System;
using System.Collections.Generic;
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
            // Info from https://www.globalpetrolprices.com/electricity_prices/

            Dictionary<string, float> energyCost = new Dictionary<string, float>
            {
                { "Riga", 0.171f },
                { "Madrid", 0.228f },
                { "London", 0.274f },
                { "New York", 0.153f }
            };

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
                    if (powerId.Text == null || powerId.Text.Trim().Equals("")) showRes(kwattCalc(sunHours, 250), cityId.Text, energyCost[cityId.Text]);
                    else showRes(kwattCalc(sunHours, Int32.Parse(powerId.Text)), cityId.Text, energyCost[cityId.Text]);
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

        public void showRes(float kwatt, string city, float energyCost)
        {
            resultId.Text += "\n\n\n You will produce " + Math.Round(kwatt, 2) + " kilowatt per day and save " + Math.Round(kwatt * energyCost, 2) + 
                " USD in " + cityId.Text + " if you are using the solar panels";
        }

    }
}
