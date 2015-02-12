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

            this.DataContext = Global.prodectViewModel.CurrentProduct;
            lbSelProducts.ItemsSource = Global.prodectViewModel.TryingOnProducts;
            productImages.Source = new BitmapImage(new Uri(Global.tryingOnProductImage));
            menuButtons.btnBuy.Visibility = Visibility.Visible;

            Global.prodectViewModel.tryingOnProductsChanged += new ProductViewModel.TryingOnProductsChanged(prodectViewModel_tryingOnProductsChanged);
        }

        void prodectViewModel_tryingOnProductsChanged(Models.ProductBiz addedProduct)
        {
            for (int i = 0; i < Global.prodectViewModel.TryingOnProducts.Count; i++)
            {
                if (Global.prodectViewModel.TryingOnProducts[i].Id == addedProduct.Id
                    && Global.prodectViewModel.CurrentIndex != i)
                {
                    Global.prodectViewModel.CurrentIndex = i;
                    this.DataContext = Global.prodectViewModel.CurrentProduct;
                }
            }    
        }

        private void lbProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Global.MainFrame.GoBack();
        }
    }
}
