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
                    var func = new Function1();
                    var parameters = new Parameters
                    {
                        A = ParseDouble(R1TextA.Text),
                        F = ParseDouble(R1ComboF.Text)
                    };
                    result = func.Calculate(parameters);
                }
                else if (Radio2.IsChecked == true)
                {
                    var func = new Function2();
                    var parameters = new Parameters
                    {
                        A = ParseDouble(R2TextA.Text),
                        B = ParseDouble(R2TextB.Text),
                        F = ParseDouble(R2ComboF.Text)
                    };
                    result = func.Calculate(parameters);
                }
                else if (Radio3.IsChecked == true)
                {
                    var func = new Function3();
                    var parameters = new Parameters
                    {
                        A = ParseDouble(R3TextA.Text),
                        B = ParseDouble(R3TextB.Text),
                        C = ParseDouble(((ComboBoxItem)R3ComboC.SelectedItem).Content.ToString()),
                        D = ParseInt(((ComboBoxItem)R3ComboD.SelectedItem).Content.ToString())
                    };
                    result = func.Calculate(parameters);
                }
                else if (Radio4.IsChecked == true)
                {
                    var func = new Function4();
                    var parameters = new Parameters
                    {
                        A = ParseDouble(R4TextA.Text),
                        D = ParseInt(R4TextD.Text),
                        C = ParseDouble(((ComboBoxItem)R4ComboC.SelectedItem).Content.ToString())
                    };
                    result = func.Calculate(parameters);
                }
                else if (Radio5.IsChecked == true)
                {
                    var func = new Function5();
                    var parameters = new Parameters
                    {
                        X = ParseDouble(R5TextX.Text),
                        Y = ParseDouble(R5TextY.Text),
                        N = ParseInt(R5ComboN.Text),
                        K = ParseInt(R5ComboK.Text)
                    };
                    result = func.Calculate(parameters);
                }
                else { MessageBox.Show("выберите формулу"); return; }
                this.Title = "ответ: " + result.ToString("F4");
            }
            catch (Exception ex) { MessageBox.Show($"ошибка: {ex.Message}"); }
        }
        private double ParseDouble(string text)
        {
            return double.Parse(text.Replace(',', '.'), CultureInfo.InvariantCulture);
        }
        private int ParseInt(string text)
        {
            return int.Parse(text, CultureInfo.InvariantCulture);
        }
        private void UniversalTextBox_PreviewCheck(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            string newText = textBox.Text.Insert(textBox.SelectionStart, e.Text);
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c) && c != ',' && c != '.' && c != '-')
                {
                    e.Handled = true;
                    return;
                }
            }
            if (e.Text.Contains("-"))
            {
                if (textBox.SelectionStart != 0 || textBox.Text.Contains("-"))
                {
                    e.Handled = true;
                    return;
                }
            }
            if (e.Text == "," || e.Text == ".")
            {
                if (textBox.Text.Contains(",") || textBox.Text.Contains("."))
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        private void UniversalTextBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string text = (string)e.DataObject.GetData(typeof(string));
                if (!IsValidText(text)) e.CancelCommand();
            }
            else
            {
                e.CancelCommand();
            }
        }
        private bool IsValidText(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsDigit(c) && c != ',' && c != '.' && c != '-') return false;                
            }
            if (text.Contains("-"))
            {
                if (text.IndexOf('-') > 0) return false;
            }
            int commaCount = text.Count(c => c == ',');
            int dotCount = text.Count(c => c == '.');
            if (commaCount > 1 || dotCount > 1 || (commaCount == 1 && dotCount == 1)) return false;            
            return true;
        }
    }
}
