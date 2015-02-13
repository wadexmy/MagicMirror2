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

namespace MagicMirror.Views
{
    /// <summary>
    /// ProductTryingOnControl.xaml 的交互逻辑
    /// </summary>
    public partial class ProductTryingOnControl : UserControl , INotifyPropertyChanged
    {
        public ProductTryingOnControl()
        {
            InitializeComponent();

            this.DataContext = Global.prodectViewModel.CurrentProduct;

            btnLike.DataContext = this;
            btnDislike.DataContext = this;

            lbSelProducts.ItemsSource = Global.prodectViewModel.TryingOnProducts;

            menuButtons.btnBuy.Visibility = Visibility.Visible;
            Global.prodectViewModel.tryingOnProductsChanged += new ProductViewModel.TryingOnProductsChanged(prodectViewModel_tryingOnProductsChanged);
        }

        #region ===顾客评价===
        
        private int likeCount = 0;
        public int LikeCount {
            get {
                return likeCount;
            }
            set {
                likeCount = value;
                OnPropertyChanged("LikeCount");
            }
        }

        private int dislikeCount = 0;
        public int DislikeCount {
            get
            {
                return dislikeCount;
            }
            set
            {
                dislikeCount = value;
                OnPropertyChanged("DislikeCount");
            }
        }

        #endregion

        private void prodectViewModel_tryingOnProductsChanged(Models.ProductBiz addedProduct)
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
            this.DataContext = Global.prodectViewModel.TryingOnProducts[lbSelProducts.SelectedIndex];
        }

        private void btnLike_Click(object sender, RoutedEventArgs e)
        {
            LikeCount++;
        }
        private void btnDislike_Click(object sender, RoutedEventArgs e)
        {
            DislikeCount++;
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }


    }
}
