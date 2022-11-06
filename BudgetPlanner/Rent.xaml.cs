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
    /// Interaction logic for Rent.xaml
    /// </summary>
    public partial class Rent : Window
    {
        public static double RentRepay { get; set; }
        public Rent()
        {
            InitializeComponent();
        }

        private void Renting_TextChanged(object sender, TextChangedEventArgs e)
        {
            double rentP;

            while (!double.TryParse(Renting.Text, out rentP))
            {
                MessageBox.Show("Please enter a valid number");
                return;
            }
            
            RentRepay = rentP;

        }
        public static double RRepay()
        {
            return RentRepay;
        }

        private void CToCar_Click(object sender, RoutedEventArgs e)
        {
            if (Renting.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please fill out all the boxes");
                return;
            }
            Car C = new Car();
            C.Show();
            this.Close();
        }

        private void NContToTotal_Click(object sender, RoutedEventArgs e)
        {
            if (Renting.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please fill out all the boxes");
                return;
            }
            ViewExpenses VE = new ViewExpenses();
            VE.Show();
            this.Close();
        }
    }
}
