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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        
        public static double Income { get; private set; }
        public static double IncomeTax { get; private set; }
        
      
        public Window1()
        {
            InitializeComponent();
        }

        //Save user input for gross income
        private void gross_Income_TextChanged(object sender, TextChangedEventArgs e)
        {
            double income;
            //Does not allow anything other than a number, gives out a warning number
            while (!double.TryParse(gross_Income.Text, out income))
            {
                MessageBox.Show("Please enter a valid number");
                return;
            }
            Income = income;
        }
        //Save user input for income tax
        private void tax_reduction_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double tax;
                //Does not allow anything other than a number, gives out a warning number
                while (!double.TryParse(tax_reduction.Text, out tax))
                {
                    MessageBox.Show("Please enter a valid number");
                    return;
                }

                IncomeTax = tax / 100;
            }
            //Exception handling
            catch(DivideByZeroException)
            {
                MessageBox.Show("Cannot divide by zero. Please try again");
                return;
            }
        }
        //Calculates monthly income after tax
        public static double MonthlyNetIncome()
        {
            //tax amount that 
            double taxDeducted;
             
            //Defining global variable taxDeducted
            taxDeducted = (Income * IncomeTax);

            //Defining global variable netIncome
           double  netIncome = Income - taxDeducted;
            return netIncome;

        }

        private void ContinueMonthlyEx_Click(object sender, RoutedEventArgs e)
        {
            //On click to continue if and else statements to make sure all boxes are filled and not empty
            if(gross_Income.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please fill out all the boxes");
                return;
            }
            else if (tax_reduction.Text.Trim() ==String.Empty)
            {
                MessageBox.Show("Please fill out all the boxes");
                return;
            }
            //opens next window and closes current one
            MonExp MonE = new MonExp();
            MonE.Show();
            this.Close();
        }
    }
}
