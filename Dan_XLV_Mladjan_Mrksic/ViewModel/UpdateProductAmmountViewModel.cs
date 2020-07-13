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
    class UpdateProductAmmountViewModel : ViewModelBase
    {
        UpdateProductAmmountView upav;
        ProductModel productModel = new ProductModel();

        public UpdateProductAmmountViewModel(UpdateProductAmmountView view, Product p)
        {
            upav = view;
            Product = p;
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
                productModel.UpdateProduct(Product);
                upav.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString());
            }
        }
        private bool CanSaveExecute()
        {
            if (product.ProductAmmount<0 || product.ProductAmmount > 100)
            {
                MessageBox.Show("You can only stockpile 100 units of any product.", "Insufficient storage space", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                product.ProductAmmount = 0;
                upav.txtAmmount.Clear();
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }
        private void CloseExecute()
        {
            try
            {
                upav.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.Message.ToString());
            }
        }
        private bool CanCloseExecute()
        {
            return true;
        }
    }
}
