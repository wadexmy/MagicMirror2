using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Windows.Media.Animation;
using MagicMirror.Models;

namespace MagicMirror.Views
{
    /// <summary>
    /// ProductTryingOnControl.xaml 的交互逻辑
    /// </summary>
    public partial class ProductTryingOnControl : UserControl
    {
        private DataService dataservice;

        public ProductTryingOnControl()
        {
            InitializeComponent();
            dataservice = new DataService();
            this.DataContext = Global.productViewModel.CurrentProduct;

            lbSelProducts.ItemsSource = Global.productViewModel.TryingOnProducts;

            menuButtons.btnBuy.Visibility = Visibility.Visible;
            Global.productViewModel.tryingOnProductsChanged += prodectViewModel_tryingOnProductsChanged;
        }

        #region ===顾客评价===

        private void btnLike_Click(object sender, RoutedEventArgs e)
        {
            Global.productViewModel.CurrentProduct.LikeCount++;
        }
        private void btnDislike_Click(object sender, RoutedEventArgs e)
        {
            Global.productViewModel.CurrentProduct.DislikeCount++;
        }

        #endregion

        private void prodectViewModel_tryingOnProductsChanged(ProductBiz addedProduct)
        {
            for (int i = 0; i < Global.productViewModel.TryingOnProducts.Count; i++)
            {
                if (Global.productViewModel.TryingOnProducts[i].Id == addedProduct.Id)
                {
                    Global.productViewModel.CurrentIndex = i;
                    lbSelProducts.SelectedIndex = i;
                }
            }
        }

        private void lbProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductBiz selProduct=Global.productViewModel.TryingOnProducts[lbSelProducts.SelectedIndex];
            this.DataContext = selProduct;

            IList<SkuBiz> selProductSkus = dataservice.GetProductSkus(selProduct.Id);
            if (selProductSkus != null && selProductSkus.Count > 0) {
                lbProductColors.ItemsSource = dataservice.GetProductColors(selProductSkus);
                lbProductSizes.ItemsSource = dataservice.GetProductSizes(selProductSkus);
                IList<ProductBiz> relatedProducts = dataservice.GetRelatedProducts(selProduct);
                if (relatedProducts != null && relatedProducts.Count > 0)
                {
                    IList<ProductBiz> relShowProduct = relatedProducts.Skip(relatedProducts.Count - Global.ProductDemoImages.Count).ToList();
                    for (int i = 0; i < relShowProduct.Count; i++)
                    {
                        relShowProduct[i].Picture = Global.ProductDemoImages[i];
                        lbMatchedProoducts.ItemsSource = relShowProduct;
                    }
                }
            }
        }
    }
}
