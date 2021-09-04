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

namespace CoreExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();
            
            acButton.Click += AcButton_Click1;

        }

        private void AcButton_Click1(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content="0";
        }

        private void operationButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(ResultLabel.Content.ToString(), out lastNumber))
            {
                ResultLabel.Content = "0";
            }
            //MessageBox.Show("Operation Button Clicked");
            if (sender == multiplicationButton)
                selectedOperator = SelectedOperator.Addition;
            if (sender == divisionButton)
                selectedOperator = SelectedOperator.Division;
            if (sender == additionButton)
                selectedOperator = SelectedOperator.Addition;
            if (sender == subtractionButton)
                selectedOperator = SelectedOperator.Subtraction;
        }

        private void equalButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber = 0;
            if(double.TryParse(ResultLabel.Content.ToString(), out newNumber))
            {
                switch(selectedOperator)
                {
                   
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber , newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber , newNumber);
                        break;
                    case SelectedOperator.Mulitplication:
                        result = SimpleMath.Mulitiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Subtract(lastNumber, newNumber);
                        break;
                }
                ResultLabel.Content = result.ToString();
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void pointButton_Click(object sender, RoutedEventArgs e)
        {
            if(ResultLabel.Content.ToString().Contains("."))
            {
                //Do Nothin
            }
            else
            {
                ResultLabel.Content = $"{ ResultLabel.Content}.";
            }
        }

        private void acButton_Click(object sender, RoutedEventArgs e)
        {
            result = 0;
            lastNumber = 0;
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            //get content of the button clicked
            if(ResultLabel.Content.ToString() == "0"){
                ResultLabel.Content = "";
            }
            int selectedValue = int.Parse((sender as Button).Content.ToString());
            ResultLabel.Content = $"{ ResultLabel.Content}"+selectedValue.ToString();
            return;
        }        
    }

    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Mulitplication,
        Division
    }

    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        public static double Subtract(double n1, double n2)
        {
            return n1 - n2;
        }

        public static double Divide(double n1, double n2)
        {
            return n1/ n2;
        }

        public static double Mulitiply(double n1, double n2)
        {
            return n1 * n2;
        }
    }
}
