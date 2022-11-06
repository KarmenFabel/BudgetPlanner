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
    /// Interaction logic for ExpensesAll.xaml
    /// </summary>
    public partial class ExpensesAll : Window
    {
        public ExpensesAll()
        {
            InitializeComponent();
        }
        
         public static double Living()
         {
           double Stay;
            if (BuyorRent.i==1)
            {
                Stay = Rent.RRepay();
                
            }
            else
            {
                Stay = Buy.BuyProperty();

            }
            return Stay;

        }

        private void AllEx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
           // list to add the string with the amount of money for when ranking from most to least amount of money 
           FinalExpenses groceries = new FinalExpenses("Groceries are: R", MonExp.MonthlyExp[0]);
           FinalExpenses utilities = new FinalExpenses("Utilities are: R", MonExp.MonthlyExp[1]);
           FinalExpenses travel = new FinalExpenses("Travel is: R", MonExp.MonthlyExp[2]);
           FinalExpenses phone = new FinalExpenses("Phone bill is: R", MonExp.MonthlyExp[3]);
           FinalExpenses car = new FinalExpenses("Car expenses monthly are: R", Car.BuyCar());
           FinalExpenses home = new FinalExpenses("Living expenses monthly are: R", Living());

           //create a list with the objects created
           List<FinalExpenses> expenses = new List<FinalExpenses>() { groceries, utilities, travel, phone, car, home };
           //sort the expenses from least to most 
           expenses.Sort(delegate (FinalExpenses x, FinalExpenses y)
           {
               //compares the expenses to see which is the bigger amount
               return x.Amount.CompareTo(y.Amount);

           });

           //Reverse list to go from Ascending to descending order
           expenses.Reverse();

           // add the string together to  output both description and amount of money
          // Console.WriteLine(String.Join(Environment.NewLine, expenses));
           AllEx.Items.Add(String.Join(Environment.NewLine, expenses));

        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            SavingQuestion SQ = new SavingQuestion();
            SQ.Show();
            this.Close();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void No_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Cont_Click(object sender, RoutedEventArgs e)
        {
            SavingQuestion SQ = new SavingQuestion();
            SQ.Show();
            this.Close();
        }
    }

    // class for list that contains different types of objects
    class FinalExpenses
    {

        public string Description;
        public double Amount;

        public FinalExpenses(string Description, double Amount)
        {
            this.Description = Description;
            this.Amount = Amount;
        }
        // create a string for output 
        public override string ToString()
        {
            return Description + " " + Amount;
        }


    }
}
