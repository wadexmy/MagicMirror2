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
    /// AllProductsControl.xaml 的交互逻辑
    /// </summary>
    public partial class AllProductsControl : UserControl
    {
        PageViewModel viewModel;
        public AllProductsControl()
        {
            InitializeComponent();

            viewModel = new PageViewModel();
            this.DataContext = viewModel;
        }
        
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductBiz selProduct=viewModel.ProductBizList[lbProducts.SelectedIndex];
            Global.MainFrame.Navigate(new Uri("/Views/ProductDetailControl.xaml", UriKind.Relative), selProduct);
            Global.MainFrame.Navigated += MainFrame_Navigated;
        }

        void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            Global.productViewModel.AddProduct(e.ExtraData as ProductBiz);
            Global.MainFrame.Navigated -= MainFrame_Navigated;
        }
    }
}
