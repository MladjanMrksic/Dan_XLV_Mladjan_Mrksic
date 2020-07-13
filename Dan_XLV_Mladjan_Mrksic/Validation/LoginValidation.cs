using Dan_XLV_Mladjan_Mrksic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dan_XLV_Mladjan_Mrksic.Validation
{
    /// <summary>
    /// A login validation method that opens new windows depending on login credentials
    /// </summary>
    class LoginValidation
    {
        public void Login (string username, string password, MainWindow main)
        {
            //For these credentials, manager view is opened
            if (username == "Man2019" && password == "Man2019")
            {
                ManagerView mv = new ManagerView();
                main.Close();
                mv.Show();
            }
            //For these credentials, stockpiler view is opened
            else if (username == "Mag2019" && password == "Mag2019")
            {
                StockpilerView sv = new StockpilerView();
                main.Close();
                sv.Show();
            }
            //If no credentials match the input, the user is notified
            else
            {
                MessageBox.Show("Incorrect Username or Password.\nPlease try again.","Incorrect credentials",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
