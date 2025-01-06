using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.ViewModels;

namespace Inventory.Models
{
    public class Product : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
               
        private int id;
        
        private string productName;
 
        private string productDescription;
   
        private int quantity;
     
        private int price;
       
        private string productType;
      
        private string shipmentStatus;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string ProductName
        {
            get {return productName;}
            set
            {
                productName = value;
                OnPropertyChanged("ProductName");
                
            }
        }

        public string ProductDescription
        {
            get { return productDescription; }
            set
            {
                productDescription = value;
                OnPropertyChanged("ProductDescription");
            }
        }
        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                OnPropertyChanged("Quantity");
            }
        }
        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }
        public string ProductType
        {
            get { return productType; }
            set
            {
                productType = value;
                OnPropertyChanged("ProductType");
            }
        }

        
        public string ShipmentStatus
        {
            get { return shipmentStatus; }
            set
            {
                shipmentStatus = value;
                OnPropertyChanged("ShipmentStatus");
            }
        }

    }
}
