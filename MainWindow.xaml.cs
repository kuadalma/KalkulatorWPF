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

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private double result = 0;
        private string operation = "";
        private bool isNewNumber = true;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            if (isNewNumber)
            {
                txtInput.Text = "";
                isNewNumber = false;
            }

            Button button = (Button)sender;
            txtInput.Text += button.Content.ToString();
        }
        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Content.ToString();
            result = double.Parse(txtInput.Text);
            isNewNumber = true;
        }
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtInput.Text, out double number))
            {
                switch (operation)
                {
                    case "+":
                        result += number;
                        break;
                    case "-":
                        result -= number;
                        break;
                    case "*":
                        result *= number;
                        break;
                    case "/":
                        result /= number;
                        break;
                }
                txtInput.Text = result.ToString();
                isNewNumber = true;
            }
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            result = 0;
            operation = "";
            txtInput.Text = "";
            isNewNumber = true;
        }
        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (txtInput.Text.Length > 0)
            {
                txtInput.Text = txtInput.Text.Remove(txtInput.Text.Length - 1);
            }
        }

        private void ChangeSign_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtInput.Text, out double number))
            {
                number *= -1;
                txtInput.Text = number.ToString();
            }
        }

        private void Percentage_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtInput.Text, out double number))
            {
                number *= 0.01;
                txtInput.Text = number.ToString();
            }
        }
    }
}
