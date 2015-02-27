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
            this.DataContext = Global.prodectViewModel.CurrentProduct;

            lbSelProducts.ItemsSource = Global.prodectViewModel.TryingOnProducts;

            menuButtons.btnBuy.Visibility = Visibility.Visible;
            Global.prodectViewModel.tryingOnProductsChanged += prodectViewModel_tryingOnProductsChanged;
        }

        #region ===顾客评价===

        private void btnLike_Click(object sender, RoutedEventArgs e)
        {
            Global.prodectViewModel.CurrentProduct.LikeCount++;
        }
        private void btnDislike_Click(object sender, RoutedEventArgs e)
        {
            Global.prodectViewModel.CurrentProduct.DislikeCount++;
        }

        #endregion

        private void prodectViewModel_tryingOnProductsChanged(ProductBiz addedProduct)
        {
            for (int i = 0; i < Global.prodectViewModel.TryingOnProducts.Count; i++)
            {
                if (Global.prodectViewModel.TryingOnProducts[i].Id == addedProduct.Id)
                {
                    Global.prodectViewModel.CurrentIndex = i;
                    lbSelProducts.SelectedIndex = i;
                }
            }
        }

        private void lbProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductBiz selProduct=Global.prodectViewModel.TryingOnProducts[lbSelProducts.SelectedIndex];
            this.DataContext = selProduct;
            IList<SkuBiz> selProductSkus = dataservice.GetProductSkus(selProduct.Id);
            if (selProductSkus != null && selProductSkus.Count > 0) {
                //颜色
                List<string> colors = (from q in selProductSkus select q.ProductColorId).Distinct().ToList();
                if (colors != null && colors.Count > 0) {
                    List<ProductColorBiz> productColors = new List<ProductColorBiz>();
                    for (int i = 0; i < colors.Count; i++)
                    {
                        productColors.Add(dataservice.GetProductColor(colors[i]));
                    }
                    lbProductColors.ItemsSource = productColors;
                }
                
                //大小
                List<string> sizeCodes = (from q in selProductSkus select q.ProductSizeCode).Distinct().ToList();
                if (sizeCodes != null && sizeCodes.Count > 0)
                {
                    List<ProductSizeBiz> productSizes = new List<ProductSizeBiz>();
                    for (int i = 0; i < sizeCodes.Count; i++)
                    {
                        IList<ProductSizeBiz> productSizeBizs = dataservice.GetProductSize(sizeCodes[i]);
                        if (productSizeBizs != null)
                        {
                            productSizes.Add(productSizeBizs[0]);
                        }
                    }
                    lbProductSizes.ItemsSource = productSizes;
                }
               
                //推荐
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
