﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MagicMirror.Models;

namespace MagicMirror.Views
{
    /// <summary>
    /// ProductTryingOnControl.xaml 的交互逻辑
    /// </summary>
    public partial class ProductTryingOnControl : UserControl
    {

        public ProductTryingOnControl()
        {
            InitializeComponent();
            this.DataContext = Global.productViewModel.CurrentProduct;

            lbSelProducts.ItemsSource = Global.productViewModel.TryingOnProducts;

            Global.MenuButtonBar.btnBuy.Visibility = Visibility.Visible;

            Global.productViewModel.tryingOnProductsAdded += prodectViewModel_tryingOnProductsChanged;
            Global.productViewModel.tryingOnMutiProductsAdded += productViewModel_tryingOnMutiProductsAdded;
            Global.productViewModel.tryingOnProductsRemoved += productViewModel_tryingOnProductsRemoved;
        }

        private void btnRemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            Global.productViewModel.RemoveProduct((sender as Button).Tag.ToString());
        }

        private void productViewModel_tryingOnProductsRemoved()
        {
            lbSelProducts.ItemsSource = Global.productViewModel.TryingOnProducts;
            lbSelProducts.SelectedIndex = Global.productViewModel.CurrentIndex;
            
            if (Global.productViewModel.TryingOnProducts.Count == 0)
            {
                Global.MainFrame.Navigate(new Uri("/Views/ProductSlideGallery.xaml", UriKind.Relative));   
            }
        }

        #region ===顾客评价===

        private void btnLike_Click(object sender, RoutedEventArgs e)
        {
            bool result = Global.dataservice.LikeProduct(Global.productViewModel.CurrentProduct.Code);
            if (result) {
                Global.productViewModel.CurrentProduct.LikeCount++;
            }
        }

        #endregion

        private void prodectViewModel_tryingOnProductsChanged(ProductBiz product)
        {
            for (int i = 0; i < Global.productViewModel.TryingOnProducts.Count; i++)
            {
                if (Global.productViewModel.TryingOnProducts[i].Id == product.Id)
                {
                    Global.productViewModel.CurrentIndex = i;
                    lbSelProducts.SelectedIndex = i;
                    lbSelProducts.ScrollIntoView(lbSelProducts.SelectedItem);
                }
            }
        }

        private void productViewModel_tryingOnMutiProductsAdded(List<ProductBiz> addedProducts)
        {
            lbSelProducts.SelectedIndex = 0;
        }

        private ProductBiz selProduct;

        private List<ProductColorBiz> productColors = new List<ProductColorBiz>();

        private List<ProductSizeBiz> productSizes = new List<ProductSizeBiz>();

        private IList<ProductBiz> relShowProducts = new List<ProductBiz>();

        private void lbProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbSelProducts.SelectedIndex == -1) {
                this.DataContext = null;
                lbProductColors.ItemsSource = null;
                lbProductSizes.ItemsSource = null;
                lbMatchedProoducts.ItemsSource = null;
                return;
            }
            selProduct=Global.productViewModel.TryingOnProducts[lbSelProducts.SelectedIndex];
            this.DataContext = selProduct;

            BackgroundWorker bgw = new BackgroundWorker();
            bgw.WorkerSupportsCancellation = true;
            bgw.WorkerReportsProgress = true;
            bgw.DoWork += new DoWorkEventHandler((s1, e1) =>
            {
                IList<SkuBiz> selProductSkus = Global.dataservice.GetProductSkus(selProduct.Id);
                if (selProductSkus != null && selProductSkus.Count > 0)
                {
                    productColors = Global.dataservice.GetProductColors(selProductSkus);
                    productSizes = Global.dataservice.GetProductSizes(selProductSkus);
                    //IList<ProductCollocationBiz> relatedProductBizs = Global.dataservice.GetRecommendProducts(selProduct);
                    //if (relatedProductBizs != null && relatedProductBizs.Count == 0) {
                    //    IList<ProductBiz> relShowProduct = new List<ProductBiz>();
                    //    int maxNumber = relShowProduct.Count < Global.ProductDemoImages.Count ? relShowProduct.Count : Global.ProductDemoImages.Count;
                    //    for (int i = 0; i < maxNumber; i++)
                    //    {
                    //        ProductBiz relProduct = ProductBiz.GetProductBiz(relatedProductBizs[i]);
                    //        relProduct.ImagePath = Global.ProductDemoImages[i];
                    //        relShowProduct.Add(relProduct);
                    //    }
                    //    relShowProducts = relShowProduct;
                    //}
                    IList<ProductBiz> relatedProducts = Global.dataservice.GetRelatedProducts(selProduct);
                    if (relatedProducts != null && relatedProducts.Count > 0)
                    {
                        IList<ProductBiz> relShowProduct = relatedProducts.Skip(relatedProducts.Count - Global.ProductDemoImages.Count).ToList();
                        
                        for (int i = 0; i < relShowProduct.Count; i++)
                        {
                            relShowProduct[i].ImagePath = Global.ProductDemoImages[i];
                            relShowProducts = relShowProduct;
                        }
                    }
                }
            });
            bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler((s2, e2) =>
            {
                lbProductColors.ItemsSource = productColors;
                lbProductSizes.ItemsSource = productSizes;
                lbMatchedProoducts.ItemsSource = relShowProducts;
            });
            bgw.RunWorkerAsync();
        }

        private void lbMatchedProoducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selIndex = lbMatchedProoducts.SelectedIndex;
            if (selIndex < 0) return;
            ProductBiz selProduct = relShowProducts[selIndex];

            MessageBoxResult msgResult=WPFMessageBox.Show("是否将所选商品添加到试穿列表中?","确认消息",MessageBoxButton.YesNo);

            if (msgResult == MessageBoxResult.Yes) {
                Global.productViewModel.AddProduct(selProduct);
            }
        }


        private void lbProductColorSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbProductColors.SelectedIndex != -1 && lbProductSizes.SelectedIndex != -1) {
                TryingProductAlertWin tryingWin = new TryingProductAlertWin();
                tryingWin.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                tryingWin.Show();
            }
        }
    }
}
