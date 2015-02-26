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
        public DataService(): this("mirrordev", "mirrordev")
        { 

        }

        public DataService(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
            userKey = GetUserKey(userName, password);
        }

        private string userName = "mirrordev";

        private string password = "mirrordev";

        private string userKey = "0623c7dd-b414-4a6e-b34e-2e1f1623348c";

        public string GetUserKey(string username, string password)
        {
            string userKey = this.userKey;
            var request = new ApiRequest()
            {
                //api地址前不带“/”在服务器地址后加上
                ApiPath = "api/security/login",
                ServerAddress = Global.ServerAddressUrl,
                Method = Method.Post,
                Param = new
                {
                    businessModuleCode = "HDW",
                    accountType = "EMPLOYEE",
                    username = username,
                    password = password,
                }
            };
            var response = ApiHelper.Execute<string>(request, false).Result;
            if (response.Success)
            {
                userKey = response.Context;
            }
            return userKey;
        }

        /// <summary>
        /// 获取首页显示的产品
        /// </summary>
        /// <param name="PicturesCount"></param>
        /// <returns></returns>
        public IList<ProductBiz> GetFirstPageProducts(int PicturesCount)
        {
            var request = new ApiRequest()
            {
                ApiPath = "api/product/list",
                ServerAddress = Global.ServerAddressUrl,
                Method = Method.Post,
                AppKey = userKey,
                Param = new
                {
                    isPageable = true,
                    recordsPerPage = PicturesCount
                }
            };
            var response = ApiHelper.Execute<ListResponse<ProductBiz>>(request, false).Result;
            return response.Success ? response.Context.Data : null;
        }

        public IList<ProductColorBiz> GetProductColors()
        {
            var request = new ApiRequest()
            {
                ApiPath = "api/productColor/list",
                ServerAddress = Global.ServerAddressUrl,
                Method = Method.Post,
                AppKey = userKey,
                Param = new
                {
                    isPageable = false
                }
            };
            var response = ApiHelper.Execute<ListResponse<ProductColorBiz>>(request, false).Result;
            return response.Success ? response.Context.Data : null;
        }

        public SkuBiz GetSkuByProductId(string productId) {
            var request = new ApiRequest()
            {
                ApiPath = string.Format("api/sku/getById/{0}", productId),
                ServerAddress = Global.ServerAddressUrl,
                Method = Method.Get,
                AppKey = userKey,
            };
            var response = ApiHelper.Execute<SkuBiz>(request, false).Result;
            return response.Success ? response.Context: null;
        }


        public IList<SkuBiz> GetProductSkus(int PicturesCount)
        {
            var request = new ApiRequest()
            {
                ApiPath = "api/sku/list",
                ServerAddress = Global.ServerAddressUrl,
                Method = Method.Post,
                AppKey = userKey,
                Param = new
                {
                    isPageable = true,
                    recordsPerPage = PicturesCount
                }
            };
            var response = ApiHelper.Execute<ListResponse<SkuBiz>>(request, false).Result;
            return response.Success ? response.Context.Data : null;
        }

        public IList<SkuBiz> GetProductSkus()
        {
            var request = new ApiRequest()
            {
                ApiPath = "api/sku/list",
                ServerAddress = Global.ServerAddressUrl,
                Method = Method.Post,
                AppKey = userKey,
                Param = new
                {
                    isPageable = false
                }
            };
            var response = ApiHelper.Execute<ListResponse<SkuBiz>>(request, false).Result;
            return response.Success ? response.Context.Data : null;
        }
        

    }
}
