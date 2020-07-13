using Dan_XLV_Mladjan_Mrksic.ViewModel;
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
using System.Windows.Shapes;

namespace Dan_XLV_Mladjan_Mrksic.View
{
    /// <summary>
    /// Interaction logic for UpdateProductAmmountView.xaml
    /// </summary>
    public partial class UpdateProductAmmountView : Window
    {
        public UpdateProductAmmountView(Product product)
        {
            InitializeComponent();
            DataContext = new UpdateProductAmmountViewModel(this, product);
        }
    }
}
