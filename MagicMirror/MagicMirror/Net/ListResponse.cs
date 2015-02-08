using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MagicMirror.Net
{
    public class ListResponse<T> where T : class
    {
        [JsonProperty("isPageable")]
        public bool IsPageable { get; set; }

        [JsonProperty("recordsPerPage")]
        public int RecordsPerPage { get; set; }

        [JsonProperty("currentPage")]
        public int CurrentPage { get; set; }

        [JsonProperty("totalRecords")]
        public int TotalRecords { get; set; }

        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }

        [JsonProperty("data")]
        public IList<T> Data { get; set; }
    }
}
