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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Inventory.ViewModels;
using Inventory.Views;
using Inventory.Models;
using System.Data;
using System.Text.RegularExpressions;

namespace Inventory.Views
{
    /// <summary>
    /// Interaction logic for Product_Inventory.xaml
    /// </summary>
    public partial class Product_Inventory : UserControl
    {
        public Product_Inventory()
        {
           
        }
        private void ProductGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ProductGrid.SelectedItem is Product selectedItem)
            {
                NameTxtBox.Text = selectedItem.ProductName;
                ProdDescTxtBox.Text = selectedItem.ProductDescription;

                QuantityTxtBox.Text = (Convert.ToInt32(selectedItem.Quantity)).ToString();
                PriceTxtBox.Text = (Convert.ToInt32(selectedItem.Price)).ToString();
                ProdTypeTxtBox.Text = selectedItem.ProductType;
                ShptStatusTxtBox.Text = selectedItem.ShipmentStatus;
                var viewModel = DataContext as ProductViewModel;
                if (viewModel != null) 
                { 
                    viewModel.CurrentProduct.Id = selectedItem.Id; 
                }
              
            }
       }


        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        { 
            // Allow only numeric input
            e.Handled = !IsTextAllowed(e.Text); 
        } 
          private static bool IsTextAllowed(string text) 
        { 
            // Regex to match only numeric input 
          return  Regex.IsMatch(text, @"^[0-9]+$"); }
        }
}
