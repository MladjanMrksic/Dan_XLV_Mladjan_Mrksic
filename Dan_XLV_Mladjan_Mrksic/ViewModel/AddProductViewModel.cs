﻿using Dan_XLV_Mladjan_Mrksic.Command;
using Dan_XLV_Mladjan_Mrksic.Model;
using Dan_XLV_Mladjan_Mrksic.View;
using System;
using System.Windows;
using System.Windows.Input;

namespace Dan_XLV_Mladjan_Mrksic.ViewModel
{
    class AddProductViewModel : ViewModelBase
    {
        AddProductView apv;
        ProductModel productModel = new ProductModel();
        #region Constructor
        public AddProductViewModel(AddProductView view)
        {
            apv = view;
            product = new Product();
        }
        #endregion
        #region Properties
        private Product product;
        public Product Product
        {
            get { return product; }
            set { product = value; OnPropertyChanged("Product"); }
        }
        #endregion
        #region Commands
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
                productModel.AddProduct(Product);
                apv.Close();

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
                apv.Close();
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
        #endregion
    }
}
