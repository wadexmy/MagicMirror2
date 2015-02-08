using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MagicMirror.Models;
using MagicMirror.Net;

namespace MagicMirror
{
    public class DataService
    {

        public IList<ProductBiz> GetFirstPageProducts(int PicturesCount)
        {
            var request = new ApiRequest()
            {
                //api地址前不带“/”在服务器地址后加上
                ApiPath = "api/product/list",
                ServerAddress = Global.ServerAddressUrl,
                Method = Method.Post,
                AppKey = "",
                Param = new
                {
                    isPageable = true,
                    recordsPerPage = PicturesCount
                }
            };
            var response = ApiHelper.Execute<ListResponse<ProductBiz>>(request, false).Result;
            return response.Success ? response.Context.Data : null;
        }
    }
}
