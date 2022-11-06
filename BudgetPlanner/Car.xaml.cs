using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BudgetPlanner
{
    /// <summary>
    /// Interaction logic for Car.xaml
    /// </summary>
    public partial class Car : Window
    {
        public static double CarDeposit { get; set; }
        public static string CarModelAndMake { get; set; }
        public static double CarPrice { get; set; }
        public static double CarIntrest { get; set; }
       
        public Car()
        {
            InitializeComponent();
        }

        private void ModelandMake_TextChanged(object sender, TextChangedEventArgs e)
        {
            string CMAM;
            CMAM = ModelandMake.Text;
            CarModelAndMake = CMAM;
        }
       
        private void InterestRate_TextChanged(object sender, TextChangedEventArgs e)
        {
            double intrest;
            
            while (!double.TryParse(InterestRate.Text, out intrest))
            {
                MessageBox.Show("Please enter a valid number");
                return;
            }
            CarIntrest = intrest;
        }
        // Asks user to insert information of the house they want to buy
        public static double BuyCar()
        {
                //Interest rate is given in persentage so dividing by 100 will give a usable decibel for further use
                double CarInterestRate = CarIntrest / 100;


                //works out the montly car repayment of the user
                double loanAmount = CarPrice - CarDeposit;
                double rateOfInterest = CarInterestRate / 12;
                //the number 60 is found by working out the amount of time to pay off the car (5 years * 12)
                //CarMonthRepay = (rateOfInterest * loanAmount) / (1 - Math.Pow(1 + rateOfInterest, 60 * -1));
                //shorten the equation to make it more readable
                double CarMonthRepay = (rateOfInterest * loanAmount) / (1 - Math.Pow(1 + rateOfInterest, (-60)));
  
            return CarMonthRepay;
        }

        private void ContToExp_Click(object sender, RoutedEventArgs e)
        {
            ViewExpenses VE = new ViewExpenses();
            VE.Show();
            this.Close();
        }

        private void deposit_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            double dep;
            
            while (!double.TryParse(deposit.Text, out dep))
            {
                MessageBox.Show("Please enter a valid number");
                return;
            }
            CarDeposit = dep;
        }

        private void price_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            double CP;
            
            while (!double.TryParse(price.Text, out CP))
            {
                MessageBox.Show("Please enter a valid number");
                return;
            }
            CarPrice = CP;
        }
    }
}
