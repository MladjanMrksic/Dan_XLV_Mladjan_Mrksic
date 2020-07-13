using Dan_XLV_Mladjan_Mrksic.Command;
using Dan_XLV_Mladjan_Mrksic.Model;
using Dan_XLV_Mladjan_Mrksic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Dan_XLV_Mladjan_Mrksic.ViewModel
{
    class AddProductViewModel : ViewModelBase
    {
        AddProductView apv;
        ProductModel productModel = new ProductModel();

        public AddProductViewModel(AddProductView view)
        {
            apv = view;
            product = new Product();
        }

        private Product product;
        public Product Product
        {
            get { return product; }
            set { product = value; OnPropertyChanged("Product"); }
        }

        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }
        private void SaveExecute()
        {
            try
            {
                ManagerView mv = new ManagerView();
                productModel.AddProduct(Product);
                apv.Close();
                mv.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString());
            }
        }
        private bool CanSaveExecute()
        {
            if (String.IsNullOrEmpty(product.ProductName) || String.IsNullOrEmpty(product.ProductCode) || String.IsNullOrEmpty(Convert.ToString(product.Price)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
