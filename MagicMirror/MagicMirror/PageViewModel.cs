using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using System.ComponentModel;
using MagicMirror.Models;
using MagicMirror.Net;

namespace MagicMirror
{
    public class PageViewModel : INotifyPropertyChanged
    {
        DataService dataservie;
        public PageViewModel() {
            dataservie = new DataService();

            ListResponse<ProductBiz> CurrentPageResult = dataservie.GetCurrentPageProducts(PageSize, CurrentPage+1);
            PageCount = CurrentPageResult.TotalPages;

            ProductBizList = CurrentPageResult.Data.ToList();
        }

        private int pageCol = 3;
        /// <summary>
        /// 每一页显示的列数
        /// </summary>
        public int PageCol {
            get {
                return pageCol;
            }
            set {
                pageCol = value;
                OnPropertyChanged("PageCol");
                OnPropertyChanged("PageSize");
            }
        }

        private int pageRow = 4;
        /// <summary>
        /// 每一页显示的行数
        /// </summary>
        public int PageRow {
            get
            {
                return pageRow;
            }
            set
            {
                pageRow = value;
                OnPropertyChanged("PageRow");
                OnPropertyChanged("PageSize");
            }
        }

        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize {
            get
            {
                return PageCol * PageRow;
            }
        }

        private int currentPage = 0;
        /// <summary>
        /// 当前所在页索引
        /// </summary>
        public int CurrentPage {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        private int pageCount = 0;
        /// <summary>
        /// 页数
        /// </summary>
        public int PageCount
        {
            get
            {
                return pageCount;
            }
            set
            {
                pageCount = value;
                OnPropertyChanged("PageCount");
            }
        }

        private List<ProductBiz> productBizList;

        public List<ProductBiz> ProductBizList
        {
            get {
                return productBizList;
            }
            set {
                productBizList = value;
                for (int i = 0; i < productBizList.Count; i++)
                {
                    productBizList[i].Picture=Global.ProductDemoImages[i];
                }
                OnPropertyChanged("ProductBizList");
            }
        }

        private ICommand prePageCommand;

        /// <summary>
        /// 上一页
        /// </summary>
        public ICommand PrePageCommand
        {
            get
            {
                if (prePageCommand == null)
                    prePageCommand = new DelegateCommand(
                        () =>
                        {
                            CurrentPage--;
                            ProductBizList = dataservie.GetCurrentPageProducts(PageSize, CurrentPage + 1).Data.ToList();
                        },
                        () =>
                        {
                            return CurrentPage > 0;
                        });
                return prePageCommand;
            }
        }

        private ICommand nextPageCommand;

        /// <summary>
        /// 下一页
        /// </summary>
        public ICommand NextPageCommand
        {
            get
            {
                if (nextPageCommand == null)
                    nextPageCommand = new DelegateCommand(
                        () =>
                        {
                            CurrentPage++;
                            ProductBizList = dataservie.GetCurrentPageProducts(PageSize, CurrentPage + 1).Data.ToList();
                        },
                        () =>
                        {
                            return CurrentPage < PageCount - 1;
                        });
                return nextPageCommand;
            }
        }

        private ICommand gotoPageCommand;

        /// <summary>
        /// 跳转页面
        /// </summary>
        public ICommand GotoPageCommand
        {
            get
            {
                if (gotoPageCommand == null)
                    gotoPageCommand = new DelegateCommand<string>(
                        (pram) =>
                        {
                            int page = int.Parse(pram);
                            if (page - 1 != CurrentPage && page >= 1 && page <= PageCount)
                            {
                                CurrentPage = page - 1;
                                ProductBizList = dataservie.GetCurrentPageProducts(PageSize, CurrentPage + 1).Data.ToList();
                            }
                        },
                        (pram) =>
                        {
                            return true;
                        });
                return gotoPageCommand;
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
