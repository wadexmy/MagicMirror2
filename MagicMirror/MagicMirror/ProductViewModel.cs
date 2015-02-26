using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MagicMirror.Models;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MagicMirror
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        public delegate void TryingOnProductsChanged(ProductBiz addedProduct);

        public event TryingOnProductsChanged tryingOnProductsChanged;

        public ProductViewModel()
        {
            TryingOnProducts = new ObservableCollection<ProductBiz>();
            
            CurrentIndex = -1;
        }

        private ObservableCollection<ProductBiz> tryingOnProducts;
        public ObservableCollection<ProductBiz> TryingOnProducts
        {
            get
            {
                return tryingOnProducts;
            }
            set
            {
                tryingOnProducts = value;
                OnPropertyChanged("TryingOnProducts");
            }
        }

        private int currentIndex;
        public int CurrentIndex 
        {
            get {
                return currentIndex;
            }
            set {
                currentIndex = value;
                if (CurrentIndex != -1 && TryingOnProducts.Count != 0)
                {
                    CurrentProduct = TryingOnProducts[CurrentIndex];
                }
                OnPropertyChanged("CurrentIndex");
            }
        }

        private ProductBiz currentProduct;
        public ProductBiz CurrentProduct
        {
            get
            {
                return currentProduct;
            }
            set {
                currentProduct = value;
                OnPropertyChanged("CurrentProduct");
            }
        }

        public void AddProduct(ProductBiz product)
        {
            foreach (var item in TryingOnProducts)
            {
                if (item.Id == product.Id)
                {
                    return;
                }
            }
            TryingOnProducts.Add(product);
            if (tryingOnProductsChanged != null) {
                tryingOnProductsChanged(product);
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
                    new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}
