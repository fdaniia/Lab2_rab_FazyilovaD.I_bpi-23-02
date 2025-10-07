using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Lab2_rab_FazyilovaD.I_bpi_23_02
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
        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double result = 0;
                if (Radio1.IsChecked == true)
                {
                    var func = new Function1
                    {
                        A = ParseDouble(R1TextA.Text),
                        F = ParseDouble(R1ComboF.Text)
                    };
                    result = func.Calculate();
                }
                else if (Radio2.IsChecked == true)
                {
                    var func = new Function2
                    {
                        A = ParseDouble(R2TextA.Text),
                        B = ParseDouble(R2TextB.Text),
                        F = ParseDouble(R2ComboF.Text)
                    };
                    result = func.Calculate();
                }
                else if (Radio3.IsChecked == true)
                {
                    var func = new Function3
                    {
                        A = ParseDouble(R3TextA.Text),
                        B = ParseDouble(R3TextB.Text),
                        C = ParseDouble(((ComboBoxItem)R3ComboC.SelectedItem).Content.ToString()),
                        D = ParseDouble(((ComboBoxItem)R3ComboD.SelectedItem).Content.ToString())
                    };
                    result = func.Calculate();
                }
                else if (Radio4.IsChecked == true)
                {
                    var func = new Function4
                    {
                        A = ParseDouble(R4TextA.Text),
                        D = ParseDouble(R4TextD.Text),
                        C = ParseDouble(((ComboBoxItem)R4ComboC.SelectedItem).Content.ToString())
                    };
                    result = func.Calculate();
                }
                else if (Radio5.IsChecked == true)
                {
                    var func = new Function5
                    {
                        X = ParseDouble(R5TextX.Text),
                        Y = ParseDouble(R5TextY.Text),
                        N = ParseDouble(R5ComboN.Text),
                        K = ParseDouble(R5ComboK.Text)
                    };
                    result = func.Calculate();
                }
                else { MessageBox.Show("выберите формулу"); return; }
                this.Title = "ответ:" + result.ToString("F4");
            }
            catch (Exception ex) { MessageBox.Show($"ошибка: {ex.Message}"); }
        }
        private double ParseDouble(string text)
        {
            return double.Parse(text.Replace(',', '.'), CultureInfo.InvariantCulture);
        }
    }
}
