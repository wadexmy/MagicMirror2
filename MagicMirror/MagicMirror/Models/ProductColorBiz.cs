using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MagicMirror.Models
{
    public class ProductColorBiz : EntityBase
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
        private string rgb;
        [JsonProperty("rgb", NullValueHandling = NullValueHandling.Ignore)]
        public string Rgb
        {
            get
            {
                return rgb;
            }
            set
            {
                rgb = value;
                OnPropertyChanged("Rgb");
            }
        }
        
    }
}
