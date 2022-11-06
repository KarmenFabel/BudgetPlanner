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
    /// Interaction logic for ViewExpenses.xaml
    /// </summary>
    public partial class ViewExpenses : Window
    {
        public ViewExpenses()
        {
            InitializeComponent();
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {

            if (TotalExpenses() > (0.75 * Window1.MonthlyNetIncome()))
            {
                MessageBox.Show("WARNING! Your total expenses are more than 75% of your income");
                return;
            }
            ExpensesAll EA = new ExpensesAll();
            EA.Show();
            this.Close();
        }

        public static double TotalExpenses()
        {
            double sum = 0;
            
            //for loop to determine the value of the array elements together
            for(var i = 0; i < MonExp.MonthlyExp.Length; i++)
            {
                sum += MonExp.MonthlyExp[i];
            }
            double totalExpense = sum +Rent.RRepay() + Buy.BuyProperty() + Car.BuyCar();

            return totalExpense;
        }
        private void NO_Click(object sender, RoutedEventArgs e)
        {
            SavingQuestion SQ = new SavingQuestion();
            SQ.Show();
            this.Close();
        } 
    }
}
