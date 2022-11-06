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
    /// Interaction logic for SavingQuestion.xaml
    /// </summary>
    public partial class SavingQuestion : Window
    {
        public SavingQuestion()
        {
            InitializeComponent();
        }

        private void No_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            Savings s = new Savings();
            s.Show();
            this.Close();
        }
    }
}
