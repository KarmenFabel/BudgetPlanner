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
    /// Interaction logic for BuyorRent.xaml
    /// </summary>
    public partial class BuyorRent : Window
    {
       public static int i;
        
       
        public BuyorRent()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //compares this button to 1 for if and else statement in final expenses
            i = 1;
            //opens next window and closes current one
            Rent R = new Rent();
            R.Show();
            this.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //compares this button to 2 for if and else statement in final expenses
            i = 2;
            //opens next window and closes current one
            Buy B = new Buy();
            B.Show();
            this.Close();

        }
    }
}
