using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace WpfBMI
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            tbHeight.Focus();
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            bool a = IsTextAllowed(tbHeight.Text);
            bool b = IsTextAllowed(tbWeight.Text);
            if (!a || !b)
            {
                MessageBox.Show("請輸入數字");
                tbHeight.Text = "";
                tbWeight.Text = "";
                return;
            }

            double bmi = 0.0;
            string result = string.Empty;

            bmi = Convert.ToDouble(tbWeight.Text) / (Convert.ToDouble(tbHeight.Text) * Convert.ToDouble(tbHeight.Text));

            bmi = Math.Round(bmi * 10000);

            if (bmi < 18.5)
                result = "你太輕了吧";
            else if (18.5 <= bmi && bmi < 24.0)
                result = "正常，繼續保持";
            else if (24.0 >= bmi)
                result = "痾... 該減肥了吧";
            else
                result = "你是不是哪裡有問題?";

            txtResult.Text = "你的BMI為" + bmi + "\n" + result;
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }

        private void btnReset_Click_(object sender, RoutedEventArgs e)
        {
            tbWeight.Text = "";
            tbHeight.Text = "";
            txtResult.Text = "";
            tbHeight.Focus();
        }
    }
}
