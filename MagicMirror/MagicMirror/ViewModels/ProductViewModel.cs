﻿using System;
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
        public delegate void TryingOnProductsAdded(ProductBiz addedProduct);
        public delegate void TryingOnProductsRemoveded();

        public delegate void TryingOnMutiProductsAdded(List<ProductBiz> addedProducts);

        public event TryingOnProductsAdded tryingOnProductsAdded;
        public event TryingOnMutiProductsAdded tryingOnMutiProductsAdded;
        public event TryingOnProductsRemoveded tryingOnProductsRemoved;
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
                else {
                    CurrentProduct = null;
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
            if (tryingOnProductsAdded != null) {
                tryingOnProductsAdded(product);
            }
        }

        public void AddProducts(List<ProductBiz> products)
        {
            if(products==null) return;
            List<ProductBiz> vildProducts=new List<ProductBiz>();
            foreach (var product in products)
            {
                ProductBiz hasProduct = TryingOnProducts.SingleOrDefault(p=>p.Id==product.Id);
                if (hasProduct == null) {
                    vildProducts.Add(product);
                    TryingOnProducts.Add(product);
                }
            }
            if (tryingOnMutiProductsAdded != null)
            {
                tryingOnMutiProductsAdded(vildProducts);
            }
        }

        public void RemoveProduct(string Id) {
            int selIndex = 0;
            foreach (var item in TryingOnProducts)
            {
                if (item.Id == Id)
                {
                    TryingOnProducts.Remove(item);
                    break;
                }
                selIndex++;
            }
            //当前删除的也是被选择的
            if(currentIndex==selIndex){
                if (TryingOnProducts.Count > selIndex)
                    currentIndex = selIndex;
                else
                    currentIndex = selIndex - 1;
            }
            else{
                if(selIndex<currentIndex){
                    currentIndex = currentIndex - 1;
                }
            }
            if (tryingOnProductsRemoved != null)
            {
                tryingOnProductsRemoved();
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
