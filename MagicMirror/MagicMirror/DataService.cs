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
        public DataService()
            : this(Global.UserName, Global.Password)
        { 

        }

        public DataService(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
            userKey = GetUserKey(userName, password);
        }

        private string userName = "";

        private string password = "";

        private string userKey = "";

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
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public IList<ProductBiz> GetFirstPageProducts(int recordsPerPage)
        {
            try
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
                        recordsPerPage = recordsPerPage
                    }
                };
                var response = ApiHelper.Execute<ListResponse<ProductBiz>>(request, false).Result;
                return response.Success ? response.Context.Data : null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取首页显示的产品
        /// </summary>
        /// <param name="PicturesCount"></param>
        /// <returns></returns>
        public ListResponse<ProductBiz> GetCurrentPageProducts(int recordsPerPage,int currentPage)
        {
            try
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
                        recordsPerPage = recordsPerPage,
                        currentPage = currentPage
                    }
                };
                var response = ApiHelper.Execute<ListResponse<ProductBiz>>(request, false).Result;
                return response.Success ? response.Context : null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ProductBiz GetProductBizById(string productId) {
            var request = new ApiRequest()
            {
                ApiPath = string.Format("api/product/getById/{0}", productId),
                ServerAddress = Global.ServerAddressUrl,
                Method = Method.Get,
                AppKey = userKey,
            };
            var response = ApiHelper.Execute<ProductBiz>(request, false).Result;
            return response.Success ? response.Context : null;
        }


        /// <summary>
        /// 根据商品ID得到该款号的商品的条码种数
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public IList<SkuBiz> GetProductSkus(string productId) 
        {
            var request = new ApiRequest()
            {
                ApiPath = "api/sku/list",
                ServerAddress = Global.ServerAddressUrl,
                Method = Method.Post,
                AppKey = userKey,
                Param = new
                {
                    isPageable = false,
                    productId = productId
                }
            };
            var response = ApiHelper.Execute<ListResponse<SkuBiz>>(request, false).Result;
            return response.Success ? response.Context.Data : null;
        }

        public List<ProductColorBiz> GetProductColors(IList<SkuBiz> pruductSkus)
        {
            List<ProductColorBiz> productColors = new List<ProductColorBiz>();
            if (pruductSkus != null && pruductSkus.Count > 0)
            {
                List<string> colors = (from q in pruductSkus select q.ProductColorId).Distinct().ToList();
                if (colors != null && colors.Count > 0)
                {
                   
                    for (int i = 0; i < colors.Count; i++)
                    {
                        productColors.Add(GetProductColor(colors[i]));
                    }
                }
            }
            return productColors;
        }

        public List<ProductSizeBiz> GetProductSizes(IList<SkuBiz> pruductSkus)
        {
            List<ProductSizeBiz> productSizes = new List<ProductSizeBiz>();
            if (pruductSkus != null && pruductSkus.Count > 0)
            {
                List<string> sizeCodes = (from q in pruductSkus select q.ProductSizeCode).Distinct().ToList();
                if (sizeCodes != null && sizeCodes.Count > 0)
                {
                    for (int i = 0; i < sizeCodes.Count; i++)
                    {
                        IList<ProductSizeBiz> productSizeBizs = GetProductSize(sizeCodes[i]);
                        if (productSizeBizs != null)
                        {
                            productSizes.Add(productSizeBizs[0]);
                        }
                    }
                }
            }
            return productSizes;
        }

        public IList<ProductBiz> GetRelatedProducts(ProductBiz product)
        {
            var request = new ApiRequest()
            {
                ApiPath = "api/product/list",
                ServerAddress = Global.ServerAddressUrl,
                Method = Method.Post,
                AppKey = userKey,
                Param = new
                {
                    isPageable = false,
                    customPropertyValue04Id = product.CustomPropertyValue04Id,
                    customPropertyValue05Id = product.CustomPropertyValue05Id,
                    customPropertyValue06Id = product.CustomPropertyValue06Id,
                    customPropertyValue08Id = product.CustomPropertyValue08Id
                }
            };
            var response = ApiHelper.Execute<ListResponse<ProductBiz>>(request, false).Result;
            return response.Success ? response.Context.Data : null;
        }

        public ProductColorBiz GetProductColor(string ColorId)
        {
            var request = new ApiRequest()
            {
                ApiPath = string.Format("api/productColor/getById/{0}", ColorId),
                ServerAddress = Global.ServerAddressUrl,
                Method = Method.Get,
                AppKey = userKey,
            };
            var response = ApiHelper.Execute<ProductColorBiz>(request, false).Result;
            return response.Success ? response.Context : null;
        }

        //public ProductSizeBiz GetProductSize(string groupCode,string SizeCode)
        //{
        //    var request = new ApiRequest()
        //    {
        //        ApiPath = string.Format("api/productSize/{0}/getByCode/{1}", groupCode, SizeCode),
        //        ServerAddress = Global.ServerAddressUrl,
        //        Method = Method.Get,
        //        AppKey = userKey,
        //    };
        //    var response = ApiHelper.Execute<ProductSizeBiz>(request, false).Result;
        //    return response.Success ? response.Context : null;
        //}

        public IList<ProductSizeBiz> GetProductSize(string SizeCode)
        {
            var request = new ApiRequest()
            {
                ApiPath = "api/productSize/list",
                ServerAddress = Global.ServerAddressUrl,
                Method = Method.Post,
                AppKey = userKey,
                Param = new
                {
                    isPageable = false,
                    code = SizeCode
                }
            };
            var response = ApiHelper.Execute<ListResponse<ProductSizeBiz>>(request, false).Result;
            return response.Success ? response.Context.Data: null;
        }

        public bool LikeProduct(string productCode)
        {
            var request = new ApiRequest()
            {
                ApiPath = string.Format("api/product/{0}/like", productCode),
                ServerAddress = Global.ServerAddressUrl,
                Method = Method.Post,
                AppKey = userKey,
            };
            var response = ApiHelper.Execute(request, false).Result;
            return response.Success;
        }

        public SkuBiz GetProductByEpc(string epc)
        {
            var request = new ApiRequest()
            {
                ApiPath = string.Format("api/skuTag/getByEPC/{0}", epc),
                ServerAddress = Global.ServerAddressUrl,
                Method = Method.Get,
                AppKey = userKey,
            };
            var response = ApiHelper.Execute<SkuBiz>(request, false).Result;
            return response.Success ? response.Context : null;
        }

        public IList<SkuInfoBiz> GetSkusByEpcList(List<string> epcs)
        {
            try
            {
                var request = new ApiRequest()
                {
                    ApiPath = "api/skuTag/getSkuInfosByEPCList",
                    ServerAddress = Global.ServerAddressUrl,
                    Method = Method.Post,
                    AppKey = userKey,
                    Param = new
                    {
                        isPageable = false,
                        epcs = epcs
                    }
                };
                var response = ApiHelper.Execute<ListResponse<SkuInfoBiz>>(request, false).Result;
                return response.Success ? response.Context.Data : null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
