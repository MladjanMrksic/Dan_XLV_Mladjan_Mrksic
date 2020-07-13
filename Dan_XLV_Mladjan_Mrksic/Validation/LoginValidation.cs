using Dan_XLV_Mladjan_Mrksic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dan_XLV_Mladjan_Mrksic.Validation
{
    class LoginValidation
    {
        public void Login (string username, string password, MainWindow main)
        {
            if (username == "Man2019" && password == "Man2019")
            {
                ManagerView mv = new ManagerView();
                main.Close();
                mv.Show();
            }
            else if (username == "Mag2019" && password == "Mag2019")
            {
                StockpilerView sv = new StockpilerView();
                main.Close();
                sv.Show();
            }
            else
            {
                MessageBox.Show("Incorrect Username or Password.\nPlease try again.","Incorrect credentials",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
