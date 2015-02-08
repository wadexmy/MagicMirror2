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
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("disable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disable { get; set; }

        [JsonProperty("useProductColor", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UseProductColor { get; set; }

        [JsonProperty("useProductSize", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UseProductSize { get; set; }

        [JsonProperty("customPropertyValue01Id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue01Id { get; set; }

        [JsonProperty("customPropertyValue01Code", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue01Code { get; set; }

        [JsonProperty("customPropertyValue01Name", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue01Name { get; set; }

        [JsonProperty("customPropertyValue02Id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue02Id { get; set; }

        [JsonProperty("customPropertyValue02Code", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue02Code { get; set; }

        [JsonProperty("customPropertyValue02Name", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue02Name { get; set; }

        [JsonProperty("customPropertyValue03Id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue03Id { get; set; }

        [JsonProperty("customPropertyValue03Code", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue03Code { get; set; }

        [JsonProperty("customPropertyValue03Name", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue03Name { get; set; }

        [JsonProperty("customPropertyValue04Id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue04Id { get; set; }

        [JsonProperty("customPropertyValue04Code", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue04Code { get; set; }

        [JsonProperty("customPropertyValue04Name", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue04Name { get; set; }

        [JsonProperty("customPropertyValue05Id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue05Id { get; set; }

        [JsonProperty("customPropertyValue05Code", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue05Code { get; set; }

        [JsonProperty("customPropertyValue05Name", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue05Name { get; set; }

        [JsonProperty("customPropertyValue06Id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue06Id { get; set; }

        [JsonProperty("customPropertyValue06Code", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue06Code { get; set; }

        [JsonProperty("customPropertyValue06Name", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue06Name { get; set; }

        [JsonProperty("customPropertyValue07Id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue07Id { get; set; }

        [JsonProperty("customPropertyValue07Code", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue07Code { get; set; }

        [JsonProperty("customPropertyValue07Name", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue07Name { get; set; }

        [JsonProperty("customPropertyValue08Id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue08Id { get; set; }

        [JsonProperty("customPropertyValue08Code", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue08Code { get; set; }

        [JsonProperty("customPropertyValue08Name", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue08Name { get; set; }

        [JsonProperty("customPropertyValue09Id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue09Id { get; set; }

        [JsonProperty("customPropertyValue09Code", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue09Code { get; set; }

        [JsonProperty("customPropertyValue09Name", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue09Name { get; set; }

        [JsonProperty("customPropertyValue10Id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue10Id { get; set; }

        [JsonProperty("customPropertyValue10Code", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue10Code { get; set; }

        [JsonProperty("customPropertyValue10Name", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomPropertyValue10Name { get; set; }

        [JsonProperty("productSizeGroupId", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductSizeGroupId { get; set; }

        [JsonProperty("productSizeGroupCode", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductSizeGroupCode { get; set; }

        [JsonProperty("productSizeGroupName", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductSizeGroupName { get; set; }

        [JsonProperty("retailPrice", NullValueHandling = NullValueHandling.Ignore)]
        public decimal RetailPrice { get; set; }
    }
}
