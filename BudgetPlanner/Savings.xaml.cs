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
    /// Interaction logic for Savings.xaml
    /// </summary>
    public partial class Savings : Window
    {
        public static double TotalSavings { get; set; }
        public static double TotalTime { get; set; }
        public static double TotalInterest { get; set; }
        
        
        public Savings()
        {
            InitializeComponent();
        }

        private void SavingAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            double Saving;

            while (!double.TryParse(SavingAmount.Text, out Saving))
            {
                MessageBox.Show("Please enter a valid number");
                return;
            }
            TotalSavings= Saving;
        }

        private void Time_TextChanged(object sender, TextChangedEventArgs e)
        {
            double tme;

            while (!double.TryParse(Time.Text, out tme))
            {
                MessageBox.Show("Please enter a valid number");
                return;
            }
            TotalTime = tme*12;
        }

        private void Interest_TextChanged(object sender, TextChangedEventArgs e)
        {
            double Intr;

            while (!double.TryParse(Time.Text, out Intr))
            {
                MessageBox.Show("Please enter a valid number");
                return;
            }
            TotalInterest = Intr;
        }

        private static string TSavings()
        {
           
            double FirstPart =(Math.Pow(1 + (TotalInterest/12),(12*TotalTime))-1);
            double SecondPart = TotalInterest / 12;
            double ThirdPart = FirstPart / SecondPart;
            double MI = TotalSavings / ThirdPart;
           string MonthlyInstallments = "You would need to save R:"+ MI;
            return MonthlyInstallments;


    }

        private void SavingsShow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            
            if (SavingAmount.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please fill out all the boxes");
                return;
            }
            else if (Time.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please fill out all the boxes");
                return;
            }
            else if (Interest.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please fill out all the boxes");
                return;
            }

            SavingsOutp.Items.Add(new ListViewItem { Content = TSavings() });

        }

        private void AllEx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //SavingsOutp.Items.Add(MonthlyInstallments);
        }
    }
}
