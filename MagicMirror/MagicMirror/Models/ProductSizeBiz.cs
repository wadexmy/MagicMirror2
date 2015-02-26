using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MagicMirror.Models
{
    public class ProductSizeBiz : EntityBase
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

        private int? rowIndex;
        [JsonProperty("rowIndex", NullValueHandling = NullValueHandling.Ignore)]
        public int? RowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
                OnPropertyChanged("RowIndex");
            }
        }

        private int? columnIndex;
        [JsonProperty("columnIndex", NullValueHandling = NullValueHandling.Ignore)]
        public int? ColumnIndex
        {
            get
            {
                return columnIndex;
            }
            set
            {
                columnIndex = value;
                OnPropertyChanged("ColumnIndex");
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

        private string productSizeGroupname;
        [JsonProperty("productSizeGroupname", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductSizeGroupName
        {
            get
            {
                return productSizeGroupname;
            }
            set
            {
                productSizeGroupname = value;
                OnPropertyChanged("ProductSizeGroupName");
            }
        }
    }
}
