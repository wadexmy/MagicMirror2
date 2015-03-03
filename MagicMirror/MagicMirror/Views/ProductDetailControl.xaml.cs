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
using MagicMirror.Models;

namespace MagicMirror.Views
{
    /// <summary>
    /// ProductDetailControl.xaml 的交互逻辑
    /// </summary>
    public partial class ProductDetailControl : UserControl
    {
        private DataService dataservice;

        public ProductDetailControl()
        {
            InitializeComponent();
            dataservice = new DataService();
            menuButtons.btnTrying.Visibility = Visibility.Visible;
            menuButtons.btnBuy.Visibility = Visibility.Visible;

            Global.productViewModel.tryingOnProductsAdded += prodectViewModel_tryingOnProductsChanged;
        }

        private void prodectViewModel_tryingOnProductsChanged(ProductBiz addedProduct)
        {
            for (int i = 0; i < Global.productViewModel.TryingOnProducts.Count; i++)
            {
                if (Global.productViewModel.TryingOnProducts[i].Id == addedProduct.Id)
                {
                    Global.productViewModel.CurrentIndex = i;

                    this.DataContext = Global.productViewModel.CurrentProduct;

                    IList<SkuBiz> selProductSkus = dataservice.GetProductSkus(Global.productViewModel.CurrentProduct.Id);
                    if (selProductSkus != null && selProductSkus.Count > 0)
                    {
                        lbProductColors.ItemsSource = dataservice.GetProductColors(selProductSkus);
                        lbProductSizes.ItemsSource = dataservice.GetProductSizes(selProductSkus);
                        IList<ProductBiz> relatedProducts = dataservice.GetRelatedProducts(Global.productViewModel.CurrentProduct);
                        if (relatedProducts != null && relatedProducts.Count > 0)
                        {
                            IList<ProductBiz> relShowProduct = relatedProducts.Skip(relatedProducts.Count - Global.ProductDemoImages.Count).ToList();
                            for (int j = 0; j < relShowProduct.Count; j++)
                            {
                                relShowProduct[j].ImageUrl = Global.ProductDemoImages[j];
                                lbMatchedProoducts.ItemsSource = relShowProduct;
                            }
                        }
                    }
                }
            }
        }
    }
}
