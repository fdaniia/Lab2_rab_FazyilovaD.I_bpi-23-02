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
        private bool isDarkTheme = false;
        private Color lightComboBoxColor = Colors.PaleGreen;
        private Color darkComboBoxColor = Colors.DarkBlue;
        private Color lightComboBoxHoverColor = Colors.DarkGreen;
        private Color darkComboBoxHoverColor = Colors.Indigo;
        public MainWindow()
        {
            InitializeComponent();
            this.Resources["ComboBoxBackgroundColor"] = Colors.PaleGreen;
            this.Resources["ComboBoxHoverColor"] = Colors.DarkGreen;
            ApplyLightTheme();
        }
        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double result = 0;
                if (Radio1.IsChecked == true)
                {
                    if (string.IsNullOrWhiteSpace(R1TextA.Text) || R1ComboF.SelectedItem == null)
                    {
                        MessageBox.Show("введите все параметры для функции 1");
                        return;
                    }
                    var func = new Function1();
                    func.A = ParseDouble(R1TextA.Text);
                    func.F = ParseDouble(R1ComboF.Text);
                    result = func.Calculate();
                }
                else if (Radio2.IsChecked == true)
                {
                    if (string.IsNullOrWhiteSpace(R2TextA.Text) || string.IsNullOrWhiteSpace(R2TextB.Text) || R2ComboF.SelectedItem == null)
                    {
                        MessageBox.Show("введите все параметры для функции 2");
                        return;
                    }
                    var func = new Function2();
                    func.A = ParseDouble(R2TextA.Text);
                    func.B = ParseDouble(R2TextB.Text);
                    func.F = ParseDouble(R2ComboF.Text);
                    result = func.Calculate();
                }
                else if (Radio3.IsChecked == true)
                {
                    if (R3ComboC.SelectedItem == null || R3ComboD.SelectedItem == null)
                    {
                        MessageBox.Show("выберите все параметры для функции 3");
                        return;
                    }
                    var func = new Function3();
                    func.A = ParseDouble(R3TextA.Text);
                    func.B = ParseDouble(R3TextB.Text);
                    func.C = ParseInt(((ComboBoxItem)R3ComboC.SelectedItem).Content.ToString());
                    func.D = ParseInt(((ComboBoxItem)R3ComboD.SelectedItem).Content.ToString());
                    result = func.Calculate();
                }
                else if (Radio4.IsChecked == true)
                {
                    if (R4ComboC.SelectedItem == null)
                    {
                        MessageBox.Show("выберите параметр C для функции 4");
                        return;
                    }
                    var func = new Function4();
                    func.A = ParseDouble(R4TextA.Text);
                    func.D = ParseInt(R4TextD.Text);
                    func.C = ParseDouble(((ComboBoxItem)R4ComboC.SelectedItem).Content.ToString());
                    result = func.Calculate();
                }
                else if (Radio5.IsChecked == true)
                {
                    if (string.IsNullOrWhiteSpace(R5TextX.Text) || string.IsNullOrWhiteSpace(R5TextY.Text) || string.IsNullOrWhiteSpace(R5TextN.Text) || string.IsNullOrWhiteSpace(R5TextK.Text))
                    {
                        MessageBox.Show("введите все параметры для функции 5");
                        return;
                    }
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
        private void ThemeToggleButton_Click(object sender, RoutedEventArgs e)
        {
            isDarkTheme = !isDarkTheme;
            if (isDarkTheme) ApplyDarkTheme();
            else ApplyLightTheme();
        }
        private void ApplyLightTheme()
        {
            var uri = new Uri("Light.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            this.Resources["ComboBoxBackgroundColor"] = lightComboBoxColor;
            this.Resources["ComboBoxHoverColor"] = lightComboBoxHoverColor;
            ThemeToggleButton.Style = resourceDict["LightButtonStyle"] as Style;
            computeButton.Style = resourceDict["LightButtonStyle"] as Style;
            this.Tag = "Light";
            ThemeToggleButton.Content = "темная тема";
        }
        private void ApplyDarkTheme()
        {
            var uri = new Uri("Dark.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            this.Resources["ComboBoxBackgroundColor"] = darkComboBoxColor;
            this.Resources["ComboBoxHoverColor"] = darkComboBoxHoverColor;
            ThemeToggleButton.Style = resourceDict["DarkButtonStyle"] as Style;
            computeButton.Style = resourceDict["DarkButtonStyle"] as Style;
            ThemeToggleButton.Style = resourceDict["DarkButtonStyle"] as Style;
            this.Tag = "Dark";
            ThemeToggleButton.Content = "светлая тема";
        }
        private void TrigFun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        private void xTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void R1ComboF_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
