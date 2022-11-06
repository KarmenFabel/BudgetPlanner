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
    /// Interaction logic for Buy.xaml
    /// </summary>
    public partial class Buy : Window
    {
        public static double PurchasePrice;
        public static double Depost;
        public static int noOfMonths;
        public static double Interest;
        public static double MonthRepay { get; set; }
        public Buy()
        {
            InitializeComponent();
        }
        //Save user input for purchase price of the property
        private void purchasePrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            double pPrice;
            // Does not allow anything other than a number, gives out a warning
            while (!double.TryParse(purchasePrice.Text, out pPrice))
            {
                MessageBox.Show("Please enter a valid number");
                return;
            }
            PurchasePrice = pPrice;
        }
        //Save user input for the deposit
        private void deposit_TextChanged(object sender, TextChangedEventArgs e)
        {
            double dpst;
            // Does not allow anything other than a number, gives out a warning
            while (!double.TryParse(deposit.Text, out dpst))
            {
                MessageBox.Show("Please enter a valid number");
                return;
            }
            
            Depost = dpst/100;
        }
        //Save user input for number of months
        private void deposit_Copy1_TextChanged(object sender, TextChangedEventArgs e)
        {
            int nOM; 
            
            
                //User inserts the number of months they are planning on repaying the property
                while (!int.TryParse(deposit_Copy1.Text, out nOM))
                {
                    MessageBox.Show("Please enter a valid number");
                    return;
                }

                

           
            noOfMonths = nOM;

        }

        public static double BuyProperty()
        {
            
                //Interest rate is given in persentage so deviding by 100 will give a usable decible for further use
                double interestRate = Interest / 100;
                //works out the montly home loan repayment of the user
                double loanAmount = PurchasePrice - Depost;
                double rateOfInterest = interestRate / 12;


                MonthRepay = (rateOfInterest * loanAmount) / (1 - Math.Pow(1 + rateOfInterest, noOfMonths * -1));

            return MonthRepay;
        }
       

        private void ContToCar_Click(object sender, RoutedEventArgs e)
        {
            if (purchasePrice.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please fill out all the boxes");
                return;
            }
            else if (deposit.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please fill out all the boxes");
                return;
            }
            else if (deposit_Copy.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please fill out all the boxes");
                return;
            }
            else if (deposit_Copy1.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please fill out all the boxes");
                return;
            }
            //Do while loop so that the user inputs the correct amount of months
            do
            {
                
                // If statement so that the user is aware of why the code is looping
                if (!(noOfMonths > 240 && noOfMonths < 360))
                {

                    MessageBox.Show("You can only repay within 240-360 months, please try again");
                    return;
                }

            }
            // loop while the noOfMonths is not in between 240 and 350 it loops 
            while (!(noOfMonths > 240 && noOfMonths < 360));

            if (BuyProperty()>(Window1.MonthlyNetIncome()*0.3))
            {
                MessageBox.Show("The monthly home loan repayment is too much!" +
                    " It is unlikely for you to get a home loan for this property");
                return;
            }


            //opens next window and closes current one
            Car car = new Car();
            car.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Do while loop so that the user inputs the correct amount of months
            do
            {

                // If statement so that the user is aware of why the code is looping
                if (!(noOfMonths > 240 && noOfMonths < 360))
                {

                    MessageBox.Show("You can only repay within 240-360 months, please try again");
                    return;
                }

            }
            // loop while the noOfMonths is not in between 240 and 350 it loops 
            while (!(noOfMonths > 240 && noOfMonths < 360));
            if (BuyProperty()>(Window1.MonthlyNetIncome()*0.3))
            {
                MessageBox.Show("The monthly home loan repayment is too much!" +
                    " It is unlikely for you to get a home loan for this property");
                return;
            }
            //opens next window and closes current one
            ViewExpenses VE = new ViewExpenses();
            VE.Show();
            this.Close();
        }

        private void deposit_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {
            double intr;
            // Does not allow anything other than a number, gives out a warning 
            while (!double.TryParse(deposit_Copy.Text, out intr))
            {
                MessageBox.Show("Please enter a valid number");
                return;
            }
            
            Interest = intr;
        }
    }
}
