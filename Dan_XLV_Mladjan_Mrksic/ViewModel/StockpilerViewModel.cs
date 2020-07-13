using Dan_XLV_Mladjan_Mrksic.Command;
using Dan_XLV_Mladjan_Mrksic.Model;
using Dan_XLV_Mladjan_Mrksic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dan_XLV_Mladjan_Mrksic.ViewModel
{
    class StockpilerViewModel : ViewModelBase
    {
        StockpilerView sv;
        ProductModel productModel = new ProductModel();

        public StockpilerViewModel(StockpilerView view)
        {
            sv = view;
            Products = productModel.GetAllProducts();
        }
        private List<Product> products;
        public List<Product> Products
        {
            get { return products; }
            set { products = value; OnPropertyChanged("Products"); }
        }

        private Product product;

        public Product Product
        {
            get { return product; }
            set { product = value; OnPropertyChanged("Product"); }
        }


        private ICommand logout;
        public ICommand Logout
        {
            get
            {
                if (logout == null)
                {
                    logout = new RelayCommand(param => LogoutExecute(), param => CanLogoutExecute());
                }
                return logout;
            }
        }
        private void LogoutExecute()
        {
            MainWindow logout = new MainWindow();
            sv.Close();
            logout.Show();
        }
        private bool CanLogoutExecute()
        {
            return true;
        }

        private ICommand refresh;
        public ICommand Refresh
        {
            get
            {
                if (refresh == null)
                {
                    refresh = new RelayCommand(param => RefreshExecute(), param => CanRefreshExecute());
                }
                return refresh;
            }
        }
        private void RefreshExecute()
        {
            Products = productModel.GetAllProducts();
        }
        private bool CanRefreshExecute()
        {
            return true;
        }

        private ICommand updateProduct;
        public ICommand UpdateProduct
        {
            get
            {
                if (updateProduct == null)
                {
                    updateProduct = new RelayCommand(param => UpdateProductExecute(), param => CanUpdateProductExecute());
                }
                return updateProduct;
            }
        }
        private void UpdateProductExecute()
        {
            UpdateProductAmmountView update = new UpdateProductAmmountView(product);
            sv.Close();
            update.Show();
        }
        private bool CanUpdateProductExecute()
        {
            return true;
        }
    }
}
