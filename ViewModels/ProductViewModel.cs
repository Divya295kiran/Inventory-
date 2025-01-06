using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Inventory.Models;
using System.Windows;

using System.Diagnostics;
using System.Windows.Controls;

namespace Inventory.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged 
    {
        private ObservableCollection<Product> productList = new ObservableCollection<Product>();
        private Product currentProduct = new Product();
        private ProductService _productService;        
        public ProductViewModel()
        {
            
            _productService = new ProductService();
           currentProduct = new Product();
            AddCommand = new RelayCommand(AddProduct);
            UpdateCommand = new RelayCommand(UpdateProduct);
            DeleteCommand = new RelayCommand(DeleteProduct);
            LoadData();
           

        }

        public ObservableCollection<Product> ProductList
        {
            get { return productList; }
            set
            {
                productList = value;
               OnPropertyChanged("ProductList");
            }
        }

        public Product CurrentProduct
        {
            get { return currentProduct; }
            set
            {
                currentProduct = value;
                OnPropertyChanged("CurrentProduct");
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        #region SaveOperation
        public void AddProduct()
        {
            
            if (!ValidatingControl())
            {
                return;
            }
            
                int count = _productService.Save(CurrentProduct);
                if (count >= 1 )
                {
                    ClearControl();
                    MessageBox.Show("Product saved successfully!", "Save", MessageBoxButton.OK, MessageBoxImage.Information);
                                       
                }          
            ClearControl();
            LoadData();   
        }
        #endregion 

        #region UpdateOperation
        public void UpdateProduct()
        {
            if (!ValidatingControl())
            {
                return;
            }
            ProductList.Clear();
            if (CurrentProduct.Id != 0)
            {
                int count = _productService.Update(CurrentProduct);
                if (count >= 1)
                {
     
                    MessageBox.Show("Product Updated successfully!", "Save", MessageBoxButton.OK, MessageBoxImage.Information);
                    CurrentProduct.Id = 0;
                    ClearControl();
                }
            }
            LoadData();

        }

        #endregion
        #region DeleteOperation
        public void DeleteProduct()
        {
            int count = _productService.Remove(CurrentProduct.Id);
            if (count >= 1)
            {
                MessageBox.Show("Product Deleted successfully!", "Delete", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearControl();
            }
            LoadData();
        }
        #endregion

        #region  DisplayOperation
        public void LoadData()
        {
            ProductList.Clear();
            ProductList = _productService.GetAll();
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region ClearControl

        private void ClearControl()

        {
            CurrentProduct.ProductName = string.Empty;
            CurrentProduct.ProductDescription = string.Empty;
            CurrentProduct.ProductType = string.Empty;
            CurrentProduct.Quantity = 0;
            CurrentProduct.Price = 0;
            CurrentProduct.ShipmentStatus = string.Empty;
        }

        #endregion

        #region ValidateOperation
        private bool ValidatingControl()
        {
            if(string.IsNullOrEmpty(CurrentProduct.ProductName))
            {
                MessageBox.Show("Please Enter Product Name","Product" ,MessageBoxButton.OK);
                return false;
            }
            if (string.IsNullOrEmpty(CurrentProduct.ProductDescription))
            {
                MessageBox.Show("Please Enter Product Description", "Product", MessageBoxButton.OK);
                return false;
            }

            if (CurrentProduct.Quantity <= 0)
            {
                MessageBox.Show("Quantity must be greater than zero", "Product", MessageBoxButton.OK);
                return false;
            }


            if (CurrentProduct.Price <= 0)
            {
                MessageBox.Show("Price must be greater than zero.", "Product", MessageBoxButton.OK);
                return false;
            }
            
            if (string.IsNullOrEmpty(CurrentProduct.ProductType))
            {
                MessageBox.Show("Please Enter Product Type", "Product", MessageBoxButton.OK);
                return false;
            }
            if (string.IsNullOrEmpty(CurrentProduct.ShipmentStatus))
            {
                MessageBox.Show("Please Enter Shipment Status", "Product", MessageBoxButton.OK);
                return false;
            }

            return true;
        }

        #endregion
    }
}
