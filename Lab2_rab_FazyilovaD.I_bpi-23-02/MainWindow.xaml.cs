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
            ApplyLightTheme();
        }
        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double result = 0;
                if (Radio1.IsChecked == true)
                {
                    var func = new Function1();
                    func.A = ParseDouble(R1TextA.Text);
                    func.F = ParseDouble(R1ComboF.Text);
                    result = func.Calculate();
                }
                else if (Radio2.IsChecked == true)
                {
                    var func = new Function2();
                    func.A = ParseDouble(R2TextA.Text);
                    func.B = ParseDouble(R2TextB.Text);
                    func.F = ParseDouble(R2ComboF.Text);
                    result = func.Calculate();
                }
                else if (Radio3.IsChecked == true)
                {
                    var func = new Function3();
                    func.A = ParseDouble(R3TextA.Text);
                    func.B = ParseDouble(R3TextB.Text);
                    func.C = ParseInt(((ComboBoxItem)R3ComboC.SelectedItem).Content.ToString());
                    func.D = ParseInt(((ComboBoxItem)R3ComboD.SelectedItem).Content.ToString());
                    result = func.Calculate();
                }
                else if (Radio4.IsChecked == true)
                {
                    var func = new Function4();
                    func.A = ParseDouble(R4TextA.Text);
                    func.D = ParseInt(R4TextD.Text);
                    func.C = ParseDouble(((ComboBoxItem)R4ComboC.SelectedItem).Content.ToString());
                    result = func.Calculate();
                }
                else if (Radio5.IsChecked == true)
                {
                    var func = new Function5();
                    func.X = ParseDouble(R5TextX.Text);
                    func.Y = ParseDouble(R5TextY.Text);
                    func.N = ParseInt(R5TextN.Text);
                    func.K = ParseInt(R5TextK.Text);
                    result = func.Calculate();
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
        private void ApplyLightTheme()
        {
            Resources.MergedDictionaries.Clear();
            var lightTheme = new ResourceDictionary();
            lightTheme.Source = new Uri("Light.xaml", UriKind.Relative);
            Resources.MergedDictionaries.Add(lightTheme);
        }
        private void ApplyDarkTheme()
        {
            Resources.MergedDictionaries.Clear();
            var darkTheme = new ResourceDictionary();
            darkTheme.Source = new Uri("Dark.xaml", UriKind.Relative);
            Resources.MergedDictionaries.Add(darkTheme);
        }
        private void LightTheme_Click(object sender, RoutedEventArgs e)
        {
            ApplyLightTheme();
        }

        private void DarkTheme_Click(object sender, RoutedEventArgs e)
        {
            ApplyDarkTheme();
        }
    }
}
