using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Dan_XLV_Mladjan_Mrksic.Archive;

namespace Dan_XLV_Mladjan_Mrksic.Model
{
    class ProductModel
    {
        ArchiveTool logger = new ArchiveTool();
        public List<Product> GetAllProducts()
        {
            try
            {
                using (WarehouseEntities context = new WarehouseEntities())
                {
                    List<Product> products = new List<Product>();
                    products = (from p in context.Products select p).ToList();
                    return products;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public Product GetProduct(string ProductCode)
        {
            try
            {
                using (WarehouseEntities context = new WarehouseEntities())
                {
                    Product pr = new Product();
                    pr = (from p in context.Products where p.ProductCode == ProductCode select p).FirstOrDefault();
                    return pr;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public void DeleteProduct (int ProductID)
        {
            try
            {
                using (WarehouseEntities context = new WarehouseEntities())
                {
                    Product pr = (from p in context.Products where p.ProductID == ProductID select p).FirstOrDefault();
                    context.Products.Remove(pr);

                    logger.WriteToFile(DateTime.Now + "/ Removed product named " + pr.ProductName + " ,code " + pr.ProductCode + ".");

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public Product AddProduct (Product productToAdd)
        {
            try
            {
                using (WarehouseEntities context = new WarehouseEntities())
                {
                    Product newProduct = new Product();
                    newProduct.ProductName = productToAdd.ProductName;
                    newProduct.ProductCode = productToAdd.ProductCode;
                    newProduct.ProductAmmount = 0;
                    newProduct.Price = productToAdd.Price;
                    newProduct.InStock = "NO";

                    context.Products.Add(newProduct);
                    context.SaveChanges();

                    logger.WriteToFile(DateTime.Now + "/ Added new product named " + productToAdd.ProductName + " ,code " + productToAdd.ProductCode + ".");

                    return newProduct;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public Product UpdateProduct (Product product)
        {
            try
            {
                using (WarehouseEntities context = new WarehouseEntities())
                {
                    Product productToUpdate = (from p in context.Products where p.ProductID == product.ProductID select p).FirstOrDefault();
                    productToUpdate.ProductName = product.ProductName;
                    productToUpdate.ProductCode = product.ProductCode;
                    productToUpdate.Price = product.Price;                 
                    if (product.ProductAmmount > 100 || product.ProductAmmount <1)
                    {
                        productToUpdate.InStock = "NO";
                        productToUpdate.ProductAmmount = 0;
                    }
                    else
                    {
                        productToUpdate.InStock = "YES";
                        productToUpdate.ProductAmmount = product.ProductAmmount;
                    }
                    context.SaveChanges();

                    logger.WriteToFile(DateTime.Now + "/ Updated product named " + productToUpdate.ProductName + " ,code " + productToUpdate.ProductCode + " to " + product.ProductName + " ,code " + product.ProductCode + ". Ammount is " + product.ProductAmmount + ".");

                    return product;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
    }
}
