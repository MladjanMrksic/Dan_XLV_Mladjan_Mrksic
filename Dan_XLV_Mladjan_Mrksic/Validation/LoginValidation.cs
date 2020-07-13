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
                //Create ManagerView and open it
                main.Close();
            }
            else if (username == "Mag2019" && password == "Mag2019")
            {
                //Create MagacionerView and open it
                main.Close();
            }
            else
            {
                MessageBox.Show("Incorrect Username or Password.\nPlease try again.","Incorrect credentials",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
