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
                if (Radio1.IsChecked == true)
                {
                    double a = Convert.ToDouble(R1TextA.Text);
                    double f = Convert.ToDouble(R1ComboF.Text);
                    this.Title = "ответ: " + Math.Sin(f * a).ToString("F");
                }
                else if (Radio2.IsChecked == true)
                {
                    double a = Convert.ToDouble(R2TextA.Text);
                    double b = Convert.ToDouble(R2TextB.Text);
                    double f = Convert.ToDouble(R2ComboF.Text);
                    this.Title = "ответ: " + (Math.Cos(f * a) + Math.Sin(f * b)).ToString("F");
                }
                else if (Radio3.IsChecked == true)
                {
                    double a = Convert.ToDouble(R3TextA.Text);
                    double b = Convert.ToDouble(R3TextB.Text);
                    double c = Convert.ToDouble(R3ComboC.Text);
                    double d = Convert.ToDouble(R3ComboD.Text);
                    this.Title = "ответ: " + (c * a * a + d * b * b).ToString("F");
                }
                else if (Radio4.IsChecked = true)
                {
                    double a = Convert.ToDouble(R4TextA.Text);
                    double d = Convert.ToDouble(R4TextD.Text);
                    double c = Convert.ToDouble(R4ComboC.Text);
                    double res = 1;
                    for (int i = 0; i < d; i++)
                    {
                        res = res * (c + a) + 1;
                    }
                    this.Title = "ответ: " + res.ToString("F");
                }
                else if (Radio5.IsChecked == true)
                {
                    double x = Convert.ToDouble(R5TextX.Text);
                    double y = Convert.ToDouble(R5TextY.Text);
                    double n = Convert.ToDouble(R5ComboN.Text);
                    double k = Convert.ToDouble(R5ComboK.Text);
                    this.Title = "ответ: " + x.ToString("F")
                }
                else { MessageBox.Show("выберите формулу"); }
            }
            catch (Exception ex) { MessageBox.Show("ошибка {ex.Message}"); }
        }
    }
    private double ParseDouble(string text)
        {
            return double.Parse(text.Replace(',', '.'), CultureInfo.InvariantCulture);
        }
    } }
