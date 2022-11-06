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
    /// Interaction logic for MonExp.xaml
    /// </summary>
    public partial class MonExp : Window
    {
        //global array of monthly expenses excluding home and car payments
        public static double[] MonthlyExp = new double[5];
        public MonExp()
        {
            InitializeComponent();
        }
        //Save user input for groceries
        private void groceries1_TextChanged(object sender, TextChangedEventArgs e)
        {
            double groceries;
            //Does not allow anything other than a number, gives out a warning number
            while (!double.TryParse(groceries1.Text, out groceries))
            {
                MessageBox.Show("Please enter a valid number");
                return;
            }
            //saves user input to global array
            MonthlyExp[0] = groceries;
        }

        //Save user input for water and lights
        private void water_and_lights_TextChanged(object sender, TextChangedEventArgs e)
        {
            double waterAndlights;
            //Does not allow anything other than a number, gives out a warning number
            while (!double.TryParse(water_and_lights.Text, out waterAndlights))
            {
                MessageBox.Show("Please enter a valid number");
                return;
            }
            //saves user input to global array
            MonthlyExp[1] = waterAndlights;
        }
        //Save user input for travel
        private void travel_TextChanged(object sender, TextChangedEventArgs e)
        {
            double trvl;
            //Does not allow anything other than a number, gives out a warning number
            while (!double.TryParse(travel.Text, out trvl))
            {
                MessageBox.Show("Please enter a valid number");
                return;
            }
            //saves user input to global array
            MonthlyExp[2] = trvl;
        }
        //Save user input for phone budget
        private void groceries1_Copy2_TextChanged(object sender, TextChangedEventArgs e)
        {
            double phne;
            //Does not allow anything other than a number, gives out a warning number
            while (!double.TryParse(Phone.Text, out phne))
            {
                MessageBox.Show("Please enter a valid number");
                return;
            }
            //saves user input to global array
            MonthlyExp[3] = phne;
        }
        //Save user input for Miscellaneous
        private void Miscellaneous_TextChanged(object sender, TextChangedEventArgs e)
        {
            double other;
            //Does not allow anything other than a number, gives out a warning 
            while (!double.TryParse(Miscellaneous.Text, out other))
            {
                MessageBox.Show("Please enter a valid number");
                return;
            }
            //saves user input to global array
            MonthlyExp[4] = other;
        }
        //button to move to the next page
        private void MonExpContinue_Click(object sender, RoutedEventArgs e)
        {
            //On click to continue if and else statements to make
            //sure all boxes are filled and not empty
            if (groceries1.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please fill out all the boxes");
                return;
            }
            else if (water_and_lights.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please fill out all the boxes");
                return;
            }
            else if (travel.Text.Trim() ==String.Empty)
            {
                MessageBox.Show("Please fill out all the boxes");
                return;
            }
            else if (Phone.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please fill out all the boxes");
                return;
            }
            else if (Miscellaneous.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please fill out all the boxes");
                return;
            }
            //opens next window and closes current one
            BuyorRent BOR = new BuyorRent();
            BOR.Show();
            this.Close();
        }
    }
}
