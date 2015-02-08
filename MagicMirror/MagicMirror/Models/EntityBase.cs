using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MagicMirror.Models
{
    public class EntityBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }


        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        //[JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? Created { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        //[JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("modified", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? Modified { get; set; }
    }
}
