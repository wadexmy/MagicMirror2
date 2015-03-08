using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MagicMirror.Models
{
    public class SkuInfoBiz : EntityBase
    {
        //FieldComment(name = "product_id", description = "商品ID")
        private String productId;
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

        //FieldComment(name = "product_code", description = "商品编码")
        private String productCode;
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

        //FieldComment(name = "product_name", description = "商品名称")
        private String productName;
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

        //FieldComment(name = "product_disable", description = "是否已停用？")
        private bool productDisable;
        [JsonProperty("productDisable", NullValueHandling = NullValueHandling.Ignore)]
        public bool ProductDisable
        {
            get
            {
                return productDisable;
            }
            set
            {
                productDisable = value;
                OnPropertyChanged("ProductDisable");
            }
        }

        //FieldComment(name = "use_product_color", description = "是否启用颜色？")
        private bool useProductColor;
        [JsonProperty("useProductColor", NullValueHandling = NullValueHandling.Ignore)]
        public bool UseProductColor
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

        //FieldComment(name = "use_product_size", description = "是否启用尺码？")
        private bool useProductSize;
        [JsonProperty("useProductSize", NullValueHandling = NullValueHandling.Ignore)]
        public bool UseProductSize
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

        //FieldComment(name = "custom_property_value_01_id", description = "自定义属性值01 ID")
        private String customPropertyValue01Id;
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

        //FieldComment(name = "custom_property_value_01_code", description = "自定义属性值01 编码")
        private String customPropertyValue01Code;
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

        //FieldComment(name = "custom_property_value_01_name", description = "自定义属性值01 名称")
        private String customPropertyValue01Name;
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

        //FieldComment(name = "custom_property_value_02_id", description = "自定义属性值02 ID")
        private String customPropertyValue02Id;
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

        //FieldComment(name = "custom_property_value_02_code", description = "自定义属性值02 编码")
        private String customPropertyValue02Code;
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

        //FieldComment(name = "custom_property_value_02_name", description = "自定义属性值02 名称")
        private String customPropertyValue02Name;
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

        //FieldComment(name = "custom_property_value_03_id", description = "自定义属性值03 ID")
        private String customPropertyValue03Id;
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

        //FieldComment(name = "custom_property_value_03_code", description = "自定义属性值03 编码")
        private String customPropertyValue03Code;
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

        //FieldComment(name = "custom_property_value_03_name", description = "自定义属性值03 名称")
        private String customPropertyValue03Name;
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

        //FieldComment(name = "custom_property_value_04_id", description = "自定义属性值04 ID")
        private String customPropertyValue04Id;
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

        //FieldComment(name = "custom_property_value_04_code", description = "自定义属性值04 编码")
        private String customPropertyValue04Code;
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

        //FieldComment(name = "custom_property_value_04_name", description = "自定义属性值04 名称")
        private String customPropertyValue04Name;
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

        //FieldComment(name = "custom_property_value_05_id", description = "自定义属性值05 ID")
        private String customPropertyValue05Id;
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

        //FieldComment(name = "custom_property_value_05_code", description = "自定义属性值05 编码")
        private String customPropertyValue05Code;
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

        //FieldComment(name = "custom_property_value_05_name", description = "自定义属性值05 名称")
        private String customPropertyValue05Name;
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
                OnPropertyChanged("CustomPropertyValue05Name");
            }
        }

        //FieldComment(name = "custom_property_value_06_id", description = "自定义属性值06 ID")
        private String customPropertyValue06Id;
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

        //FieldComment(name = "custom_property_value_06_code", description = "自定义属性值06 编码")
        private String customPropertyValue06Code;
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

        //FieldComment(name = "custom_property_value_06_name", description = "自定义属性值06 名称")
        private String customPropertyValue06Name;
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

        //FieldComment(name = "custom_property_value_07_id", description = "自定义属性值07 ID")
        private String customPropertyValue07Id;
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

        //FieldComment(name = "custom_property_value_07_code", description = "自定义属性值07 编码")
        private String customPropertyValue07Code;
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

        //FieldComment(name = "custom_property_value_07_name", description = "自定义属性值07 名称")
        private String customPropertyValue07Name;
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

        //FieldComment(name = "custom_property_value_08_id", description = "自定义属性值08 ID")
        private String customPropertyValue08Id;
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

        //FieldComment(name = "custom_property_value_08_code", description = "自定义属性值08 编码")
        private String customPropertyValue08Code;
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

        //FieldComment(name = "custom_property_value_08_name", description = "自定义属性值08 名称")
        private String customPropertyValue08Name;
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

        //FieldComment(name = "custom_property_value_09_id", description = "自定义属性值09 ID")
        private String customPropertyValue09Id;
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

        //FieldComment(name = "custom_property_value_09_code", description = "自定义属性值09 编码")
        private String customPropertyValue09Code;
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

        //FieldComment(name = "custom_property_value_09_name", description = "自定义属性值09 名称")
        private String customPropertyValue09Name;
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

        //FieldComment(name = "custom_property_value_10_id", description = "自定义属性值10 ID")
        private String customPropertyValue10Id;
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

        //FieldComment(name = "custom_property_value_10_code", description = "自定义属性值10 编码")
        private String customPropertyValue10Code;
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

        //FieldComment(name = "custom_property_value_10_name", description = "自定义属性值10 名称")
        private String customPropertyValue10Name;
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

        //FieldComment(description = "自定义字段01 值")
        private String customFieldValue01;
        [JsonProperty("customFieldValue01", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomFieldValue01
        {
            get
            {
                return customFieldValue01;
            }
            set
            {
                customFieldValue01 = value;
                OnPropertyChanged("CustomFieldValue01");
            }
        }

        //FieldComment(description = "自定义字段02 值")
        private String customFieldValue02;
        [JsonProperty("customFieldValue02", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomFieldValue02
        {
            get
            {
                return customFieldValue02;
            }
            set
            {
                customFieldValue02 = value;
                OnPropertyChanged("CustomFieldValue02");
            }
        }

        //FieldComment(description = "自定义字段03 值")
        private String customFieldValue03;
        [JsonProperty("customFieldValue03", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomFieldValue03
        {
            get
            {
                return customFieldValue03;
            }
            set
            {
                customFieldValue03 = value;
                OnPropertyChanged("CustomFieldValue03");
            }
        }

        //FieldComment(description = "自定义字段04 值")
        private String customFieldValue04;
        [JsonProperty("customFieldValue04", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomFieldValue04
        {
            get
            {
                return customFieldValue04;
            }
            set
            {
                customFieldValue04 = value;
                OnPropertyChanged("CustomFieldValue04");
            }
        }

        //FieldComment(description = "自定义字段05 值")
        private String customFieldValue05;
        [JsonProperty("customFieldValue05", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomFieldValue05
        {
            get
            {
                return customFieldValue05;
            }
            set
            {
                customFieldValue05 = value;
                OnPropertyChanged("CustomFieldValue05");
            }
        }

        //FieldComment(description = "自定义字段06 值")
        private String customFieldValue06;
        [JsonProperty("customFieldValue06", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomFieldValue06
        {
            get
            {
                return customFieldValue06;
            }
            set
            {
                customFieldValue06 = value;
                OnPropertyChanged("CustomFieldValue06");
            }
        }

        //FieldComment(description = "自定义字段07 值")
        private String customFieldValue07;
        [JsonProperty("customFieldValue07", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomFieldValue07
        {
            get
            {
                return customFieldValue07;
            }
            set
            {
                customFieldValue07 = value;
                OnPropertyChanged("CustomFieldValue07");
            }
        }

        //FieldComment(description = "自定义字段08 值")
        private String customFieldValue08;
        [JsonProperty("customFieldValue08", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomFieldValue08
        {
            get
            {
                return customFieldValue08;
            }
            set
            {
                customFieldValue08 = value;
                OnPropertyChanged("CustomFieldValue08");
            }
        }

        //FieldComment(description = "自定义字段09 值")
        private String customFieldValue09;
        [JsonProperty("customFieldValue09", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomFieldValue09
        {
            get
            {
                return customFieldValue09;
            }
            set
            {
                customFieldValue09 = value;
                OnPropertyChanged("CustomFieldValue09");
            }
        }

        //FieldComment(description = "自定义字段10 值")
        private String customFieldValue10;
        [JsonProperty("customFieldValue10", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomFieldValue10
        {
            get
            {
                return customFieldValue10;
            }
            set
            {
                customFieldValue10 = value;
                OnPropertyChanged("CustomFieldValue10");
            }
        }

        //FieldComment(name = "product_retail_price", description = "商品建议零售价")
        private decimal productRetailPrice = 0;
        [JsonProperty("productRetailPrice", NullValueHandling = NullValueHandling.Ignore)]
        public decimal ProductRetailPrice
        {
            get
            {
                return productRetailPrice;
            }
            set
            {
                productRetailPrice = value;
                OnPropertyChanged("ProductRetailPrice");
            }
        }

        //FieldComment(name = "barcode", description = "条码")
        private String barcode;
        [JsonProperty("barcode", NullValueHandling = NullValueHandling.Ignore)]
        public string Barcode
        {
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

        //FieldComment(name = "sku_name", description = "名称")
        private String skuName;
        [JsonProperty("skuName", NullValueHandling = NullValueHandling.Ignore)]
        public string SkuName
        {
            get
            {
                return skuName;
            }
            set
            {
                skuName = value;
                OnPropertyChanged("SkuName");
            }
        }

        //FieldComment(name = "sku_disable", description = "是否已停用？")
        private bool skuDisable;
        [JsonProperty("skuDisable", NullValueHandling = NullValueHandling.Ignore)]
        public bool SkuDisable
        {
            get
            {
                return skuDisable;
            }
            set
            {
                skuDisable = value;
                OnPropertyChanged("SkuDisable");
            }
        }

        //FieldComment(name = "product_color_id", description = "颜色ID")
        private String productColorId;
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

        //FieldComment(name = "product_color_code", description = "颜色编码")
        private String productColorCode;
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

        //FieldComment(name = "product_color_name", description = "颜色名称")
        private String productColorName;
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

        //FieldComment(name = "product_size_group_id", description = "尺码组ID")
        private String productSizeGroupId;
        [JsonProperty("productSizeGroupId", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductSizeGroupId
        {
            get
            {
                return productId;
            }
            set
            {
                productId = value;
                OnPropertyChanged("ProductSizeGroupId");
            }
        }

        //FieldComment(name = "product_size_group_code", description = "尺码组编码")
        private String productSizeGroupCode;
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

        //FieldComment(name = "product_size_group_name", description = "尺码组名称")
        private String productSizeGroupName;
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

        //FieldComment(name = "product_size_id", description = "尺码ID")
        private String productSizeId;
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

        //FieldComment(name = "product_size_code", description = "尺码编码")
        private String productSizeCode;
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

        //FieldComment(name = "product_size_name", description = "尺码名称")
        private String productSizeName;
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

        //FieldComment(name = "sku_retail_price", description = "条码建议零售价")
        private decimal skuRetailPrice = 0;
        [JsonProperty("skuRetailPrice", NullValueHandling = NullValueHandling.Ignore)]
        public decimal SkuRetailPrice
        {
            get
            {
                return skuRetailPrice;
            }
            set
            {
                skuRetailPrice = value;
                OnPropertyChanged("SkuRetailPrice");
            }
        }

        //FieldComment(name = "is_hot", description = "是否热卖款？")
        private bool isHot;
        [JsonProperty("isHot", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsHot
        {
            get
            {
                return isHot;
            }
            set
            {
                isHot = value;
                OnPropertyChanged("IsHot");
            }
        }

        //FieldComment(name = "is_promote", description = "是否促销款？")
        private bool isPromote;
        [JsonProperty("isPromote", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsPromote
        {
            get
            {
                return isPromote;
            }
            set
            {
                isPromote = value;
                OnPropertyChanged("IsPromote");
            }
        }

        //FieldComment(name = "like_count", description = "Like计数")
        private int likeCount;
        [JsonProperty("likeCount", NullValueHandling = NullValueHandling.Ignore)]
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

        //FieldComment(name = "online_sales_url_01", description = "网店地址01")
        private String onlineSalesUrl01;
        [JsonProperty("onlineSalesUrl01", NullValueHandling = NullValueHandling.Ignore)]
        public string OnlineSalesUrl01
        {
            get
            {
                return onlineSalesUrl01;
            }
            set
            {
                onlineSalesUrl01 = value;
                OnPropertyChanged("OnlineSalesUrl01");
            }
        }

        //FieldComment(name = "online_sales_url_02", description = "网店地址02")
        private String onlineSalesUrl02;
        [JsonProperty("onlineSalesUrl02", NullValueHandling = NullValueHandling.Ignore)]
        public string OnlineSalesUrl02
        {
            get
            {
                return onlineSalesUrl02;
            }
            set
            {
                onlineSalesUrl02 = value;
                OnPropertyChanged("OnlineSalesUrl02");
            }
        }

        //FieldComment(name = "image_path", description = "商品标题图片地址")
        private String imagePath;
        [JsonProperty("imagePath", NullValueHandling = NullValueHandling.Ignore)]
        public string ImagePath
        {
            get
            {
                return imagePath;
            }
            set
            {
                imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }

        //FieldComment(name = "image_thumbnail_path", description = "商品标题缩略图片地址")
        private String imageThumbnailPath;
        [JsonProperty("imageThumbnailPath", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageThumbnailPath
        {
            get
            {
                return imageThumbnailPath;
            }
            set
            {
                imageThumbnailPath = value;
                OnPropertyChanged("ImageThumbnailPath");
            }
        }

    }
}
