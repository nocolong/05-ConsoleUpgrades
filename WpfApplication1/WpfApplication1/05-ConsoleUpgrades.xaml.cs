using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }

        decimal changeIs;

        private void Changebutton_Click(object sender, RoutedEventArgs e)
        {
            string costBox = CostBox.Text;
            decimal cost = decimal.Parse(costBox);
            string paidBox = PaidBox.Text;
            decimal amount = decimal.Parse(paidBox);
            //Subtract cost from amount given, and store in variable change, then print result
            changeIs = amount - cost;
            ChangeIs.Text = "The customers change is : " + "$" + changeIs;

        }

        private void Billsbutton_Click(object sender, RoutedEventArgs e)
        {
            decimal HundredBills;
            decimal FiftyBills;
            decimal TwentyBills;
            decimal TenBills;
            decimal FiveBills;
            decimal OneBills;

            //Dividing change by 100 gives how many hundred bill/s owed in change
            //Math.Floor rounds the number down, and the m suffix allows the program to read the number as decimal
            HundredBills = Math.Floor(changeIs / 100m);
            /*Modulo (%) op determines remainder of change after divided by 100, then that number is divided
            by 50 to give how many 50 bills are owed in change, if any */
            FiftyBills = Math.Floor((changeIs % 100m) / 50m);
            TwentyBills = Math.Floor(((changeIs % 100m) % 50m) / 20m);
            TenBills = Math.Floor((((changeIs % 100m) % 50m) % 20m) / 10m);
            FiveBills = Math.Floor(((((changeIs % 100m) % 50m) % 20m) % 10m) / 5);
            OneBills = Math.Floor((((((changeIs % 100m) % 50m) % 20m) % 10m) % 5m) / 1);

            BillsBlock.Text = "Hundreds: " + HundredBills;
            BillsBlock.Text = "Fifties: " + FiftyBills;
            BillsBlock.Text = "Twenties: " + TwentyBills;
            BillsBlock.Text = "Tens: " + TenBills;
            BillsBlock.Text = "Fives: " + FiveBills;
            BillsBlock.Text = "Ones: " + OneBills;


        }

        private void CoinsButton_Click(object sender, RoutedEventArgs e)
        {
            decimal Quarters;
            decimal Dimes;
            decimal Nickels;
            decimal Pennies;

            //Modulo op divides change by one and leaves remainder, i.e. 22.5 % 1 gives .5 or 50 cents
            changeIs = changeIs % 1;
            //Gives number of quarters in that remaining change
            Quarters = Math.Floor(changeIs / 0.25m);
            //Modulo op finds how many quarters are in change, leaves remainder, then divide remainder by .1 (10 cents)
            Dimes = Math.Floor((changeIs % 0.25m) / 0.1m);
            Nickels = Math.Floor(((changeIs % 0.25m) % 0.1m) / 0.05m);
            Pennies = Math.Floor((((changeIs % 0.25m) % 0.1m) % 0.05m) / .01m);

            CoinsBlock.Text += "Quarters: " + Quarters;
            CoinsBlock.Text += ", " + "Dimes: " + Dimes;
            CoinsBlock.Text += ", " + "Nickels: " + Nickels;
            CoinsBlock.Text += ", " + "Pennies: " + Pennies;
        }
    }
}
