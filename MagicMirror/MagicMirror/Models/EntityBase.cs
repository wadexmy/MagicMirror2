using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel;

namespace MagicMirror.Models
{
    public class EntityBase : INotifyPropertyChanged
    {
        private string id;
        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id {
            get {
                return id;   
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            } 
        }

        private int? version;
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version
        {
            get
            {
                return version;
            }
            set
            {
                version = value;
                OnPropertyChanged("Version");
            }
        }

        private DateTime? created;
        /// <summary>
        /// 创建时间
        /// </summary>
        //[JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? Created
        {
            get
            {
                return created;
            }
            set
            {
                created = value;
                OnPropertyChanged("Created");
            }
        }

        private DateTime? modified;
        /// <summary>
        /// 修改时间
        /// </summary>
        //[JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("modified", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? Modified
        {
            get
            {
                return modified;
            }
            set
            {
                modified = value;
                OnPropertyChanged("Modified");
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
