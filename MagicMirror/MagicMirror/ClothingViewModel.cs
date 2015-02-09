using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MagicMirror.Models;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace MagicMirror
{
    public class ClothingViewModel
    {
        public ClothingViewModel()
        {
            Clothings = new ObservableCollection<ProductBiz>();
            CurrentIndex = -1;
        }

        /// <summary>
        /// Fitting Room墨镜中显示的所有衣服
        /// </summary>
        public ObservableCollection<ProductBiz> Clothings;
        /// <summary>
        /// 当前顾客正在试穿的服装索引
        /// </summary>
        public int CurrentIndex;

        public ProductBiz CurrentClothing
        {
            get
            {
                if (CurrentIndex != -1 && Clothings.Count != 0)
                {

                    return Clothings[CurrentIndex];
                }
                return null;
            }
        }
    }
}
