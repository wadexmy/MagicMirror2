using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MagicMirror.Models
{
    public class ProductBiz : EntityBase
    {
        private string code;
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
                OnPropertyChanged("Code");
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

        private string description;
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        private bool? disable;
        [JsonProperty("disable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disable
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

        private bool? useProductColor;
        [JsonProperty("useProductColor", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UseProductColor
        {
            get
            {
                return useProductColor;
            }
            set
            {
                useProductColor = value;
                OnPropertyChanged("UseProductColor");
            }
        }

        private bool? useProductSize;
        [JsonProperty("useProductSize", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UseProductSize
        {
            get
            {
                return useProductSize;
            }
            set
            {
                useProductSize = value;
                OnPropertyChanged("UseProductSize");
            }
        }

        private string customPropertyValue01Id;
        [JsonProperty("customPropertyValue01Id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue01Id
        {
            get
            {
                return customPropertyValue01Id;
            }
            set
            {
                customPropertyValue01Id = value;
                OnPropertyChanged("CustomPropertyValue01Id");
            }
        }

        private string customPropertyValue01Code;
        [JsonProperty("customPropertyValue01Code", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue01Code
        {
            get
            {
                return customPropertyValue01Code;
            }
            set
            {
                customPropertyValue01Code = value;
                OnPropertyChanged("CustomPropertyValue01Code");
            }
        }

        private string customPropertyValue01Name;
        [JsonProperty("customPropertyValue01Name", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue01Name
        {
            get
            {
                return customPropertyValue01Name;
            }
            set
            {
                customPropertyValue01Name = value;
                OnPropertyChanged("CustomPropertyValue01Name");
            }
        }

        private string customPropertyValue02Id;
        [JsonProperty("customPropertyValue02Id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue02Id
        {
            get
            {
                return customPropertyValue02Id;
            }
            set
            {
                customPropertyValue02Id = value;
                OnPropertyChanged("CustomPropertyValue02Id");
            }
        }

        private string customPropertyValue02Code;
        [JsonProperty("customPropertyValue02Code", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue02Code
        {
            get
            {
                return customPropertyValue02Code;
            }
            set
            {
                customPropertyValue02Code = value;
                OnPropertyChanged("CustomPropertyValue02Code");
            }
        }

        private string customPropertyValue02Name;
        [JsonProperty("customPropertyValue02Name", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue02Name
        {
            get
            {
                return customPropertyValue02Name;
            }
            set
            {
                customPropertyValue02Name = value;
                OnPropertyChanged("CustomPropertyValue02Name");
            }
        }

        private string customPropertyValue03Id;
        [JsonProperty("customPropertyValue03Id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue03Id
        {
            get
            {
                return customPropertyValue03Id;
            }
            set
            {
                customPropertyValue03Id = value;
                OnPropertyChanged("CustomPropertyValue03Id");
            }
        }

        private string customPropertyValue03Code;
        [JsonProperty("customPropertyValue03Code", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue03Code
        {
            get
            {
                return customPropertyValue03Code;
            }
            set
            {
                customPropertyValue03Code = value;
                OnPropertyChanged("CustomPropertyValue03Code");
            }
        }

        private string customPropertyValue03Name;
        [JsonProperty("customPropertyValue03Name", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue03Name
        {
            get
            {
                return customPropertyValue03Name;
            }
            set
            {
                customPropertyValue03Name = value;
                OnPropertyChanged("CustomPropertyValue03Name");
            }
        }

        private string customPropertyValue04Id;
        [JsonProperty("customPropertyValue04Id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue04Id
        {
            get
            {
                return customPropertyValue04Id;
            }
            set
            {
                customPropertyValue04Id = value;
                OnPropertyChanged("CustomPropertyValue04Id");
            }
        }

        private string customPropertyValue04Code;
        [JsonProperty("customPropertyValue04Code", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue04Code
        {
            get
            {
                return customPropertyValue04Code;
            }
            set
            {
                customPropertyValue04Code = value;
                OnPropertyChanged("CustomPropertyValue04Code");
            }
        }

        private string customPropertyValue04Name;
        [JsonProperty("customPropertyValue04Name", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue04Name
        {
            get
            {
                return customPropertyValue04Name;
            }
            set
            {
                customPropertyValue04Name = value;
                OnPropertyChanged("CustomPropertyValue04Name");
            }
        }

        private string customPropertyValue05Id;
        [JsonProperty("customPropertyValue05Id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue05Id
        {
            get
            {
                return customPropertyValue05Id;
            }
            set
            {
                customPropertyValue05Id = value;
                OnPropertyChanged("CustomPropertyValue05Id");
            }
        }

        private string customPropertyValue05Code;
        [JsonProperty("customPropertyValue05Code", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue05Code
        {
            get
            {
                return customPropertyValue05Code;
            }
            set
            {
                customPropertyValue05Code = value;
                OnPropertyChanged("CustomPropertyValue05Code");
            }
        }

        private string customPropertyValue05Name;
        [JsonProperty("customPropertyValue05Name", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue05Name
        {
            get
            {
                return customPropertyValue05Name;
            }
            set
            {
                customPropertyValue05Name = value;
                OnPropertyChanged("customPropertyValue05Name");
            }
        }

        private string customPropertyValue06Id;
        [JsonProperty("customPropertyValue06Id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue06Id
        {
            get
            {
                return customPropertyValue06Id;
            }
            set
            {
                customPropertyValue06Id = value;
                OnPropertyChanged("CustomPropertyValue06Id");
            }
        }

        private string customPropertyValue06Code;
        [JsonProperty("customPropertyValue06Code", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue06Code
        {
            get
            {
                return customPropertyValue06Code;
            }
            set
            {
                customPropertyValue06Code = value;
                OnPropertyChanged("CustomPropertyValue06Code");
            }
        }

        private string customPropertyValue06Name;
        [JsonProperty("customPropertyValue06Name", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue06Name
        {
            get
            {
                return customPropertyValue06Name;
            }
            set
            {
                customPropertyValue06Name = value;
                OnPropertyChanged("CustomPropertyValue06Name");
            }
        }

        private string customPropertyValue07Id;
        [JsonProperty("customPropertyValue07Id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue07Id
        {
            get
            {
                return customPropertyValue07Id;
            }
            set
            {
                customPropertyValue07Id = value;
                OnPropertyChanged("CustomPropertyValue07Id");
            }
        }

        private string customPropertyValue07Code;
        [JsonProperty("customPropertyValue07Code", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue07Code
        {
            get
            {
                return customPropertyValue07Code;
            }
            set
            {
                customPropertyValue07Code = value;
                OnPropertyChanged("CustomPropertyValue07Code");
            }
        }

        private string customPropertyValue07Name;
        [JsonProperty("customPropertyValue07Name", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue07Name
        {
            get
            {
                return customPropertyValue07Name;
            }
            set
            {
                customPropertyValue07Name = value;
                OnPropertyChanged("CustomPropertyValue07Name");
            }
        }

        private string customPropertyValue08Id;
        [JsonProperty("customPropertyValue08Id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue08Id
        {
            get
            {
                return customPropertyValue08Id;
            }
            set
            {
                customPropertyValue08Id = value;
                OnPropertyChanged("CustomPropertyValue08Id");
            }
        }

        private string customPropertyValue08Code;
        [JsonProperty("customPropertyValue08Code", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue08Code
        {
            get
            {
                return customPropertyValue08Code;
            }
            set
            {
                customPropertyValue08Code = value;
                OnPropertyChanged("CustomPropertyValue08Code");
            }
        }

        private string customPropertyValue08Name;
        [JsonProperty("customPropertyValue08Name", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue08Name
        {
            get
            {
                return customPropertyValue08Name;
            }
            set
            {
                customPropertyValue08Name = value;
                OnPropertyChanged("CustomPropertyValue08Name");
            }
        }

        private string customPropertyValue09Id;
        [JsonProperty("customPropertyValue09Id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue09Id
        {
            get
            {
                return customPropertyValue09Id;
            }
            set
            {
                customPropertyValue09Id = value;
                OnPropertyChanged("CustomPropertyValue09Id");
            }
        }

        private string customPropertyValue09Code;
        [JsonProperty("customPropertyValue09Code", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue09Code
        {
            get
            {
                return customPropertyValue09Code;
            }
            set
            {
                customPropertyValue09Code = value;
                OnPropertyChanged("CustomPropertyValue09Code");
            }
        }

        private string customPropertyValue09Name;
        [JsonProperty("customPropertyValue09Name", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue09Name
        {
            get
            {
                return customPropertyValue09Name;
            }
            set
            {
                customPropertyValue09Name = value;
                OnPropertyChanged("CustomPropertyValue09Name");
            }
        }

        private string customPropertyValue10Id;
        [JsonProperty("customPropertyValue10Id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue10Id
        {
            get
            {
                return customPropertyValue10Id;
            }
            set
            {
                customPropertyValue10Id = value;
                OnPropertyChanged("CustomPropertyValue10Id");
            }
        }

        private string customPropertyValue10Code;
        [JsonProperty("customPropertyValue10Code", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue10Code
        {
            get
            {
                return customPropertyValue10Code;
            }
            set
            {
                customPropertyValue10Code = value;
                OnPropertyChanged("CustomPropertyValue10Code");
            }
        }

        private string customPropertyValue10Name;
        [JsonProperty("customPropertyValue10Name", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue10Name
        {
            get
            {
                return customPropertyValue10Name;
            }
            set
            {
                customPropertyValue10Name = value;
                OnPropertyChanged("CustomPropertyValue10Name");
            }
        }

        private string productSizeGroupId;
        [JsonProperty("productSizeGroupId", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductSizeGroupId
        {
            get
            {
                return productSizeGroupId;
            }
            set
            {
                productSizeGroupId = value;
                OnPropertyChanged("ProductSizeGroupId");
            }
        }

        private string productSizeGroupCode;
        [JsonProperty("productSizeGroupCode", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductSizeGroupCode
        {
            get
            {
                return productSizeGroupCode;
            }
            set
            {
                productSizeGroupCode = value;
                OnPropertyChanged("ProductSizeGroupCode");
            }
        }

        private string productSizeGroupName;
        [JsonProperty("productSizeGroupName", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductSizeGroupName
        {
            get
            {
                return productSizeGroupName;
            }
            set
            {
                productSizeGroupName = value;
                OnPropertyChanged("ProductSizeGroupName");
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

        private int likeCount = 0;
        public int LikeCount
        {
            get
            {
                return likeCount;
            }
            set
            {
                likeCount = value;
                OnPropertyChanged("LikeCount");
            }
        }

        private int dislikeCount = 0;
        public int DislikeCount
        {
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
    }
}
