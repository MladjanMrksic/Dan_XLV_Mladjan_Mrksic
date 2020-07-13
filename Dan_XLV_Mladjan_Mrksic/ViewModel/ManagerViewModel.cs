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
    class ManagerViewModel : ViewModelBase
    {
        ManagerView mv;
        ProductModel productModel = new ProductModel();

        public ManagerViewModel(ManagerView view)
        {
            mv = view;
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

        private ICommand deleteProduct;
        public ICommand DeleteProduct
        {
            get
            {
                if (deleteProduct == null)
                {
                    deleteProduct = new RelayCommand(param => DeleteProductExecute(), param => CanDeleteProductExecute());
                }
                return deleteProduct;
            }
        }
        private void DeleteProductExecute()
        {
            productModel.DeleteProduct(product.ProductID);
            Products = productModel.GetAllProducts();
        }
        private bool CanDeleteProductExecute()
        {
            if (product == null)
            {
                return false;
            }
            else if (product.InStock.ToUpper() == "NO")
            {
                return true;
            }
            return false;
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
            mv.Close();
            logout.Show();
        }
        private bool CanLogoutExecute()
        {
            return true;
        }

        private ICommand addProduct;
        public ICommand AddProduct
        {
            get
            {
                if (addProduct == null)
                {
                    addProduct = new RelayCommand(param => AddProductExecute(), param => CanAddProductExecute());
                }
                return addProduct;
            }
        }
        private void AddProductExecute()
        {
            AddProductView add = new AddProductView();
            add.Show();
            Products = productModel.GetAllProducts();
        }
        private bool CanAddProductExecute()
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
            UpdateProductView update = new UpdateProductView(product);
            update.Show();
            Products = productModel.GetAllProducts();
        }
        private bool CanUpdateProductExecute()
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
    }
}
