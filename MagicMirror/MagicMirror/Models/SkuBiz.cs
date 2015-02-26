using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MagicMirror.Models
{
    public class SkuBiz : EntityBase
    {
        private string barcode;
        [JsonProperty("barcode", NullValueHandling = NullValueHandling.Ignore)]
        public string Barcode {
            get
            {
                return barcode;
            }
            set
            {
                barcode = value;
                OnPropertyChanged("Barcode");
            }
        }

        private string name;
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private bool disable;
        [JsonProperty("disable", NullValueHandling = NullValueHandling.Ignore)]
        public bool Disable
        {
            get
            {
                return disable;
            }
            set
            {
                disable = value;
                OnPropertyChanged("Disable");
            }
        }

        private decimal retailPrice;
        [JsonProperty("retailPrice", NullValueHandling = NullValueHandling.Ignore)]
        public decimal RetailPrice
        {
            get
            {
                return retailPrice;
            }
            set
            {
                retailPrice = value;
                OnPropertyChanged("RetailPrice");
            }
        }

        private string productId;
        [JsonProperty("productId", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductId
        {
            get
            {
                return productId;
            }
            set
            {
                productId = value;
                OnPropertyChanged("ProductId");
            }
        }

        private string productCode;
        [JsonProperty("productCode", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductCode
        {
            get
            {
                return productCode;
            }
            set
            {
                productCode = value;
                OnPropertyChanged("ProductCode");
            }
        }

        private string productName;
        [JsonProperty("productName", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductName
        {
            get
            {
                return productName;
            }
            set
            {
                productName = value;
                OnPropertyChanged("ProductName");
            }
        }

        private string productColorId;
        [JsonProperty("productColorId", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductColorId
        {
            get
            {
                return productColorId;
            }
            set
            {
                productColorId = value;
                OnPropertyChanged("ProductColorId");
            }
        }

        private string productColorCode;
        [JsonProperty("productColorCode", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductColorCode
        {
            get
            {
                return productColorCode;
            }
            set
            {
                productColorCode = value;
                OnPropertyChanged("ProductColorCode");
            }
        }

        private string productColorName;
        [JsonProperty("productColorName", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductColorName
        {
            get
            {
                return productColorName;
            }
            set
            {
                productColorName = value;
                OnPropertyChanged("ProductColorName");
            }
        }

        private string productSizeId;
        [JsonProperty("productSizeId", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductSizeId
        {
            get
            {
                return productSizeId;
            }
            set
            {
                productSizeId = value;
                OnPropertyChanged("ProductSizeId");
            }
        }

        private string productSizeCode;
        [JsonProperty("productSizeCode", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductSizeCode
        {
            get
            {
                return productSizeCode;
            }
            set
            {
                productSizeCode = value;
                OnPropertyChanged("ProductSizeCode");
            }
        }

        private string productSizeName;
        [JsonProperty("productSizeName", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductSizeName
        {
            get
            {
                return productSizeName;
            }
            set
            {
                productSizeName = value;
                OnPropertyChanged("ProductSizeName");
            }
        }

        private string picture;
        public string Picture
        {
            get
            {
                return picture;
            }
            set
            {
                picture = value;
                OnPropertyChanged("Picture");
            }
        }
    }
}
