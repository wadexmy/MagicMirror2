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
using System.ComponentModel;

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

        private ProductBiz selProduct;

        private List<ProductColorBiz> productColors = new List<ProductColorBiz>();

        private List<ProductSizeBiz> productSizes = new List<ProductSizeBiz>();

        private IList<ProductBiz> relShowProducts = new List<ProductBiz>();

        private void prodectViewModel_tryingOnProductsChanged(ProductBiz addedProduct)
        {
            for (int i = 0; i < Global.productViewModel.TryingOnProducts.Count; i++)
            {
                if (Global.productViewModel.TryingOnProducts[i].Id == addedProduct.Id)
                {
                    Global.productViewModel.CurrentIndex = i;
                    selProduct = Global.productViewModel.CurrentProduct;
                    this.DataContext = selProduct;
                    BackgroundWorker bgw = new BackgroundWorker();
                    bgw.WorkerSupportsCancellation = true;
                    bgw.WorkerReportsProgress = true;
                    bgw.DoWork += new DoWorkEventHandler((s1, e1) =>
                    {
                        IList<SkuBiz> selProductSkus = dataservice.GetProductSkus(selProduct.Id);
                        if (selProductSkus != null && selProductSkus.Count > 0)
                        {
                            productColors = dataservice.GetProductColors(selProductSkus);
                            productSizes = dataservice.GetProductSizes(selProductSkus);
                            IList<ProductBiz> relatedProducts = dataservice.GetRelatedProducts(selProduct);
                            if (relatedProducts != null && relatedProducts.Count > 0)
                            {
                                IList<ProductBiz> relShowProduct = relatedProducts.Skip(relatedProducts.Count - Global.ProductDemoImages.Count).ToList();
                                for (int j = 0; j < relShowProduct.Count; j++)
                                {
                                    relShowProduct[j].ImageUrl = Global.ProductDemoImages[j];
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
            }
        }

        private void lbProductColorSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbProductColors.SelectedIndex != -1 && lbProductSizes.SelectedIndex != -1)
            {
                TryingProductAlertWin tryingWin = new TryingProductAlertWin();
                tryingWin.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                tryingWin.Show();
            }
        }

        private void btnLike_Click(object sender, RoutedEventArgs e)
        {
            bool result = dataservice.LikeProduct(Global.productViewModel.CurrentProduct.Code);
            if (result)
            {
                Global.productViewModel.CurrentProduct.LikeCount++;
            }
        }

        private void lbMatchedProoducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selIndex = lbMatchedProoducts.SelectedIndex;
            if (selIndex < 0) return;
            ProductBiz selProduct = relShowProducts[selIndex];

            MessageBoxResult msgResult = WPFMessageBox.Show("是否将所选商品添加到试穿列表中?", "确认消息", MessageBoxButton.YesNo);

            if (msgResult == MessageBoxResult.Yes)
            {
                Global.productViewModel.AddProduct(selProduct);
            }
        }
    }
}
