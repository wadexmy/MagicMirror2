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
using System.Collections.ObjectModel;

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

            viewModel.currentPageChanged += new PageViewModel.CurrentPageChanged(viewModel_currentPageChanged);
            viewModel_currentPageChanged(0);
        }

        ObservableCollection<string> switchPageIndexs = new ObservableCollection<string>();

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

        //页数显示：0，和尾页始终显示，中间只显示当前页前后各两页
        private void viewModel_currentPageChanged(int CurrentPage)
        {
            switchPageIndexs.Clear();
            int selIndex = 0;
            if (viewModel.PageCount <= 7)//小于7页一字排开
            {
                for (int i = 0; i < viewModel.PageCount; i++)
                {
                    switchPageIndexs.Add((i + 1).ToString());
                }
                selIndex = CurrentPage;
            }
            else
            {
                if (CurrentPage < 4)
                {
                    switchPageIndexs.Add("1");
                    switchPageIndexs.Add("2");
                    switchPageIndexs.Add("3");
                    if (CurrentPage == 3)
                    {
                        switchPageIndexs.Add("4");
                    }
                    switchPageIndexs.Add("...");
                    switchPageIndexs.Add((viewModel.PageCount - 2).ToString());
                    switchPageIndexs.Add((viewModel.PageCount - 1).ToString());
                    switchPageIndexs.Add(viewModel.PageCount.ToString());
                    selIndex = CurrentPage;
                }
                else if (CurrentPage > viewModel.PageCount - 5)
                {
                    switchPageIndexs.Add("1");
                    switchPageIndexs.Add("2");
                    switchPageIndexs.Add("3");
                    switchPageIndexs.Add("...");

                    if (CurrentPage == viewModel.PageCount - 4)
                    {
                        switchPageIndexs.Add((viewModel.PageCount - 3).ToString());
                    }
                    
                    switchPageIndexs.Add((viewModel.PageCount - 2).ToString());
                    switchPageIndexs.Add((viewModel.PageCount - 1).ToString());
                    switchPageIndexs.Add(viewModel.PageCount.ToString());
                    selIndex = 8 - (viewModel.PageCount - CurrentPage);
                }
                else
                {
                    switchPageIndexs.Add("1");
                    switchPageIndexs.Add("...");
                    switchPageIndexs.Add((CurrentPage - 1).ToString());
                    switchPageIndexs.Add((CurrentPage).ToString());
                    switchPageIndexs.Add((CurrentPage + 1).ToString());
                    switchPageIndexs.Add((CurrentPage + 2).ToString());
                    switchPageIndexs.Add((CurrentPage + 3).ToString());
                    switchPageIndexs.Add("...");
                    switchPageIndexs.Add(viewModel.PageCount.ToString());
                    selIndex = 4;
                }
            }

            lbPages.ItemsSource = switchPageIndexs;
        }
    }
}
