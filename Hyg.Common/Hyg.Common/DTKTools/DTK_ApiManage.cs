﻿/*===================================Copyright© 2020 xxx Ltd. All rights reserved.==============================

文件类名 : DTK_ApiManage.cs
创建人员 : Mr.Hu
创建时间 : 2020-09-18 10:21:48 
备注说明 : 

 =====================================End=======================================================*/
using Hyg.Common.DTKTools.DTKRequest;
using Hyg.Common.DTKTools.DTKResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hyg.Common.OtherTools;
using Hyg.Common.Model;
using Hyg.Common.DTKTools.DTKModel;

namespace Hyg.Common.DTKTools
{
    /// <summary>
    /// DTK_ApiManage
    /// </summary>
    public class DTK_ApiManage
    {
        #region 接口地址
        string api_get_good_details = CommonCacheConfig.dtk_api_host + "api/goods/get-goods-details";//获取商品详情
        string api_super_category = CommonCacheConfig.dtk_api_host + "api/category/get-super-category";//超级分类
        string api_top100 = CommonCacheConfig.dtk_api_host + "api/category/get-top100";//热搜记录
        string api_ranking_list = CommonCacheConfig.dtk_api_host + "api/goods/get-ranking-list";//各大榜单
        string api_privilege_link = CommonCacheConfig.dtk_api_host + "api/tb-service/get-privilege-link";//高效转链
        string api_super_goods = CommonCacheConfig.dtk_api_host + "api/goods/list-super-goods";//超级搜索
        string api_get_dtk_search_goods = CommonCacheConfig.dtk_api_host + "api/goods/get-dtk-search-goods";//获取大淘客商品
        string api_op_goods_list = CommonCacheConfig.dtk_api_host + "api/goods/nine/op-goods-list";//9.9包邮精选
        string api_search_suggestion = CommonCacheConfig.dtk_api_host + "api/goods/search-suggestion";//联想词
        string api_activity_catalogue = CommonCacheConfig.dtk_api_host + "api/goods/activity/catalogue";//热门活动
        string api_activity_goodlist = CommonCacheConfig.dtk_api_host + "api/goods/activity/goods-list";//活动商品
        string api_topic_catalogue = CommonCacheConfig.dtk_api_host + "api/goods/topic/catalogue";//精选专辑
        string api_topic_goodlist = CommonCacheConfig.dtk_api_host + "api/goods/topic/goods-list";//专辑商品列表
        string api_tb_topic_list = CommonCacheConfig.dtk_api_host + "api/category/get-tb-topic-list";//官方活动推广
        string api_tb_service_list = CommonCacheConfig.dtk_api_host + "api/tb-service/get-tb-service";//联盟搜索
        string api_parse_content = CommonCacheConfig.dtk_api_host + "api/tb-service/parse-content";//淘客万能解析
        string api_order_data = CommonCacheConfig.dtk_api_host + "api/tb-service/get-order-details";//淘宝客订单数据
        string api_get_collection_list = CommonCacheConfig.dtk_api_host + "api/goods/get-collection-list";//我的收藏
        string api_get_livematerial = CommonCacheConfig.dtk_api_host + "api/goods/liveMaterial-goods-list";//直播好货
        string api_get_explosivegoods = CommonCacheConfig.dtk_api_host + "api/goods/explosive-goods-list";//每日爆品推荐
        string api_get_history_low_price_good= CommonCacheConfig.dtk_api_host + "api/goods/get-history-low-price-list";//历史最低价商品
        #endregion

        string dtk_appkey = "", dtk_appsecret = "";
        public DTK_ApiManage(string d_appkey, string d_appsecret)
        {
            this.dtk_appkey = d_appkey;
            this.dtk_appsecret = d_appsecret;
        }

        #region 获取商品详情
        public DTK_Get_Good_DetailsResponse GetGoodDetail(DTK_Get_Good_DetailsRequest dTK_Get_Good_DetailsRequest)
        {
            DTK_Get_Good_DetailsResponse dTK_Get_Good_DetailsResponse = null;
            try
            {
                string resultContent = GeneralApiParam(api_get_good_details, dTK_Get_Good_DetailsRequest.ModelToUriParam());
                dTK_Get_Good_DetailsResponse = resultContent.ToJsonObject<DTK_Get_Good_DetailsResponse>();
            }
            catch (Exception ex)
            {
                LogHelper.WriteException("GetGoodDetail", ex);
            }
            return dTK_Get_Good_DetailsResponse;
        }
        #endregion

        #region 超级分类
        /// <summary>
        /// 超级分类
        /// </summary>
        /// <param name="dTK_Super_CategoryRequest"></param>
        /// <returns></returns>
        public DTK_Super_CategoryResponse GetSuperCategory(DTK_Super_CategoryRequest dTK_Super_CategoryRequest)
        {
            DTK_Super_CategoryResponse dTK_Super_CategoryResponse = null;
            try
            {
                string resultContent = GeneralApiParam(api_super_category, dTK_Super_CategoryRequest.ModelToUriParam());
                dTK_Super_CategoryResponse = resultContent.ToJsonObject<DTK_Super_CategoryResponse>();
            }
            catch (Exception ex)
            {
                LogHelper.WriteException("GetSuperCategory", ex);
            }
            return dTK_Super_CategoryResponse;
        }
        #endregion

        #region 热搜记录
        /// <summary>
        /// 热搜词
        /// </summary>
        /// <param name="dTK_Top100_Request"></param>
        /// <returns></returns>
        public DTK_Top100_Response GetTop100(DTK_Top100_Request dTK_Top100_Request)
        {
            DTK_Top100_Response dTK_Top100_Response = null;
            try
            {
                string resultContent = GeneralApiParam(api_top100, dTK_Top100_Request.ModelToUriParam());
                dTK_Top100_Response = resultContent.ToJsonObject<DTK_Top100_Response>();
            }
            catch (Exception ex)
            {
                LogHelper.WriteException("GetTop100", ex);
            }
            return dTK_Top100_Response;
        }
        #endregion

        #region 各大榜单
        /// <summary>
        /// 各大榜单
        /// </summary>
        /// <param name="dTK_Ranking_ListRequest"></param>
        /// <returns></returns>
        public DTK_Ranking_ListResponse GetRankingList(DTK_Ranking_ListRequest dTK_Ranking_ListRequest)
        {
            DTK_Ranking_ListResponse dTK_Ranking_ListResponse = null;
            try
            {
                string resultContent = GeneralApiParam(api_ranking_list, dTK_Ranking_ListRequest.ModelToUriParam());
                dTK_Ranking_ListResponse = resultContent.ToJsonObject<DTK_Ranking_ListResponse>();
                //转换公用商品信息
                if (dTK_Ranking_ListRequest.IsReturnCommonInfo)
                {
                    dTK_Ranking_ListResponse.CommonGoodInfoList = ConvertCommonGoodInfo(dTK_Ranking_ListResponse.data);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteException("GetRankingList", ex);
            }
            return dTK_Ranking_ListResponse;
        }
        #endregion

        #region 高效转链
        /// <summary>
        /// 高效转链
        /// </summary>
        /// <param name="dTK_Privilege_LinkRequest"></param>
        /// <returns></returns>
        public DTK_Privilege_LinkResponse GetPrivilegeLink(DTK_Privilege_LinkRequest dTK_Privilege_LinkRequest)
        {
            DTK_Privilege_LinkResponse dTK_Privilege_LinkResponse = null;
            try
            {
                string resultContent = GeneralApiParam(api_privilege_link, dTK_Privilege_LinkRequest.ModelToUriParam());
                dTK_Privilege_LinkResponse = resultContent.ToJsonObject<DTK_Privilege_LinkResponse>();

                return dTK_Privilege_LinkResponse;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException("GetPrivilegeLink", ex);
            }
            return dTK_Privilege_LinkResponse;
        }
        #endregion

        #region 超级搜索(大淘客+联盟)
        /// <summary>
        /// 超级搜索包含大淘客和联盟的商品  大淘客商品优先显示
        /// </summary>
        /// <param name="dTK_Super_GoodRequest"></param>
        /// <returns></returns>
        public DTK_Super_GoodResponse GetSuperGood(DTK_Super_GoodRequest dTK_Super_GoodRequest)
        {
            DTK_Super_GoodResponse dTK_Super_GoodResponse = null;
            try
            {
                string resultContent = GeneralApiParam(api_super_goods, dTK_Super_GoodRequest.ModelToUriParam());
                dTK_Super_GoodResponse = resultContent.ToJsonObject<DTK_Super_GoodResponse>();

                //转换公用商品信息
                if (dTK_Super_GoodRequest.IsReturnCommonInfo)
                {
                    dTK_Super_GoodResponse.CommonGoodInfoList = ConvertCommonGoodInfo(dTK_Super_GoodResponse.data.list);
                }

                return dTK_Super_GoodResponse;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException("GetSuperGood", ex);
            }
            return dTK_Super_GoodResponse;
        }
        #endregion

        #region 获取大淘客商品
        /// <summary>
        /// 获取大淘客商品
        /// </summary>
        /// <param name="dTK_Get_Dtk_Search_GoodRequest"></param>
        /// <returns></returns>
        public DTK_Get_dtk_Search_GoodResponse GetDtkSearchGood(DTK_Get_dtk_Search_GoodRequest dTK_Get_Dtk_Search_GoodRequest)
        {
            DTK_Get_dtk_Search_GoodResponse dTK_Super_GoodResponse = null;
            try
            {
                string resultContent = GeneralApiParam(api_get_dtk_search_goods, dTK_Get_Dtk_Search_GoodRequest.ModelToUriParam());
                dTK_Super_GoodResponse = resultContent.ToJsonObject<DTK_Get_dtk_Search_GoodResponse>();

                //转换公用商品信息
                if (dTK_Get_Dtk_Search_GoodRequest.IsReturnCommonInfo)
                {
                    dTK_Super_GoodResponse.CommonGoodInfoList = ConvertCommonGoodInfo(dTK_Super_GoodResponse.data.list);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteException("GetDtkSearchGood", ex);
            }
            return dTK_Super_GoodResponse;
        }
        #endregion

        #region 9.9包邮精选
        /// <summary>
        /// 9.9包邮精选
        /// </summary>
        /// <param name="dTK_OP_ListRequest"></param>
        /// <returns></returns>
        public DTK_OP_ListResponse GetOPGood(DTK_OP_ListRequest dTK_OP_ListRequest)
        {
            DTK_OP_ListResponse dTK_OP_ListResponse = null;
            try
            {
                string resultContent = GeneralApiParam(api_op_goods_list, dTK_OP_ListRequest.ModelToUriParam());
                dTK_OP_ListResponse = resultContent.ToJsonObject<DTK_OP_ListResponse>();

                //转换公用商品信息
                if (dTK_OP_ListRequest.IsReturnCommonInfo)
                {
                    dTK_OP_ListResponse.CommonGoodInfoList = ConvertCommonGoodInfo(dTK_OP_ListResponse.data.list);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteException("GetOPGood", ex);
            }
            return dTK_OP_ListResponse;
        }
        #endregion

        #region 联想词
        /// <summary>
        /// 获取联想词
        /// </summary>
        /// <param name="dTK_Search_SuggestionRequest"></param>
        /// <returns></returns>
        public DTK_Search_SuggestionResponse GetSearchSuggestion(DTK_Search_SuggestionRequest dTK_Search_SuggestionRequest)
        {
            DTK_Search_SuggestionResponse dTK_Search_SuggestionResponse = null;
            try
            {
                string resultContent = GeneralApiParam(api_search_suggestion, dTK_Search_SuggestionRequest.ModelToUriParam());
                dTK_Search_SuggestionResponse = resultContent.ToJsonObject<DTK_Search_SuggestionResponse>();
            }
            catch (Exception ex)
            {
                LogHelper.WriteException("GetSearchSuggestion", ex);
            }
            return dTK_Search_SuggestionResponse;
        }
        #endregion

        #region 热门活动
        /// <summary>
        /// 获取热门活动
        /// </summary>
        /// <param name="dTK_Activity_CatalogueRequest"></param>
        /// <returns></returns>
        public DTK_Activity_CatalogueResponse GetActivityCatalogueList(DTK_Activity_CatalogueRequest dTK_Activity_CatalogueRequest)
        {
            DTK_Activity_CatalogueResponse dTK_Activity_CatalogueResponse = null;
            try
            {
                string resultContent = GeneralApiParam(api_activity_catalogue, dTK_Activity_CatalogueRequest.ModelToUriParam());
                dTK_Activity_CatalogueResponse = resultContent.ToJsonObject<DTK_Activity_CatalogueResponse>();

            }
            catch (Exception ex)
            {
                LogHelper.WriteException("GetSearchSuggestion", ex);
            }
            return dTK_Activity_CatalogueResponse;
        }
        #endregion

        #region 热门活动对应商品
        /// <summary>
        /// 热门活动商品
        /// </summary>
        /// <param name="dTK_Activity_GoodListRequest"></param>
        /// <returns></returns>
        public DTK_Activity_GoodListResponse GetActivityGoodList(DTK_Activity_GoodListRequest dTK_Activity_GoodListRequest)
        {
            DTK_Activity_GoodListResponse dTK_Activity_GoodListResponse = null;
            try
            {
                string resultContent = GeneralApiParam(api_activity_goodlist, dTK_Activity_GoodListRequest.ModelToUriParam());
                dTK_Activity_GoodListResponse = resultContent.ToJsonObject<DTK_Activity_GoodListResponse>();

                //转换公用商品信息
                if (dTK_Activity_GoodListRequest.IsReturnCommonInfo)
                {
                    dTK_Activity_GoodListResponse.CommonGoodInfoList = ConvertCommonGoodInfo(dTK_Activity_GoodListResponse.data.list);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteException("GetActivityGoodList", ex);
            }
            return dTK_Activity_GoodListResponse;
        }
        #endregion

        #region 精选专辑
        /// <summary>
        /// 精选专辑
        /// </summary>
        /// <returns></returns>
        public DTK_Topic_CatalogueResponse GetTopicCatalogue(DTK_Topic_CatalogueRequest dTK_Topic_CatalogueRequest)
        {
            DTK_Topic_CatalogueResponse dTK_Topic_CatalogueResponse = null;
            try
            {
                string resultContent = GeneralApiParam(api_topic_catalogue, dTK_Topic_CatalogueRequest.ModelToUriParam());
                dTK_Topic_CatalogueResponse = resultContent.ToJsonObject<DTK_Topic_CatalogueResponse>();

                return dTK_Topic_CatalogueResponse;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException("GetTopicCatalogue", ex);
            }
            return dTK_Topic_CatalogueResponse;
        }
        #endregion

        #region 专辑商品列表
        public DTK_Topic_GoodListResponse GetTopicGoodList(DTK_Topic_GoodListRequest dTK_Activity_GoodListRequest)
        {
            DTK_Topic_GoodListResponse dTK_Topic_GoodListResponse = null;
            try
            {
                string resultContent = GeneralApiParam(api_topic_goodlist, dTK_Activity_GoodListRequest.ModelToUriParam());
                dTK_Topic_GoodListResponse = resultContent.ToJsonObject<DTK_Topic_GoodListResponse>();

                //转换公用商品信息
                if (dTK_Activity_GoodListRequest.IsReturnCommonInfo)
                {
                    dTK_Topic_GoodListResponse.CommonGoodInfoList = ConvertCommonGoodInfo(dTK_Topic_GoodListResponse.data.list);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteException("GetTopicGoodList", ex);
            }
            return dTK_Topic_GoodListResponse;
        }
        #endregion

        #region 官方活动推广
        public DTK_TB_Topic_ListResponse GettTBTopicList(DTK_TB_Topic_ListRequest dTK_TB_Topic_ListRequest)
        {
            DTK_TB_Topic_ListResponse dTK_TB_Topic_ListResponse = null;
            try
            {
                string resultContent = GeneralApiParam(api_tb_topic_list, dTK_TB_Topic_ListRequest.ModelToUriParam());
                dTK_TB_Topic_ListResponse = resultContent.ToJsonObject<DTK_TB_Topic_ListResponse>();
            }
            catch (Exception ex)
            {
                LogHelper.WriteException("GettTBTopicList", ex);
            }
            return dTK_TB_Topic_ListResponse;
        }
        #endregion

        #region 淘口令万能解析
        public DTK_Parse_ContentResponse GetParseContent(DTK_Parse_ContentRequest dTK_Parse_ContentRequest)
        {
            DTK_Parse_ContentResponse dTK_Parse_ContentResponse = null;
            try
            {
                string resultContent = GeneralApiParam(api_parse_content, dTK_Parse_ContentRequest.ModelToUriParam());
                dTK_Parse_ContentResponse = resultContent.ToJsonObject<DTK_Parse_ContentResponse>();
            }
            catch (Exception ex)
            {
                LogHelper.WriteException("GetParseContent", ex);
            }
            return dTK_Parse_ContentResponse;
        }
        #endregion

        #region 获取订单
        public DTK_Order_DataResponse GetOrderData(DTK_Order_DataRequest dTK_Order_DataRequest)
        {
            DTK_Order_DataResponse dTK_Order_DataResponse = null;
            try
            {
                string resultContent = GeneralApiParam(api_order_data, dTK_Order_DataRequest.ModelToUriParam());
                dTK_Order_DataResponse = resultContent.ToJsonObject<DTK_Order_DataResponse>();
            }
            catch (Exception ex)
            {
                LogHelper.WriteException("GetOrderData", ex);
            }
            return dTK_Order_DataResponse;
        }
        #endregion

        #region 联盟搜索
        public DTK_TB_Service_GoodResponse GetDTK_TBServiceGood(DTK_TB_Service_GoodRequest dTK_TB_Service_GoodRequest)
        {
            DTK_TB_Service_GoodResponse dTK_TB_Service_GoodResponse = null;
            try
            {
                string resultContent = GeneralApiParam(api_tb_service_list, dTK_TB_Service_GoodRequest.ModelToUriParam());
                resultContent = resultContent.Replace("string", "images_detail");
                dTK_TB_Service_GoodResponse = resultContent.ToJsonObject<DTK_TB_Service_GoodResponse>();
            }
            catch (Exception ex)
            {
                LogHelper.WriteException("GetDTK_TBServiceGood", ex);
            }
            return dTK_TB_Service_GoodResponse;
        }
        #endregion

        #region 我的收藏
        public DTK_Get_CollectResponse GetDTK_CollectGood(DTK_Get_CollectRequest dTK_Get_CollectRequest)
        {
            DTK_Get_CollectResponse dTK_Get_CollectResponse = null;
            try
            {
                string resultContent = GeneralApiParam(api_get_collection_list, dTK_Get_CollectRequest.ModelToUriParam());
                dTK_Get_CollectResponse = resultContent.ToJsonObject<DTK_Get_CollectResponse>();
            }
            catch (Exception ex)
            {
                LogHelper.WriteException("GetDTK_CollectGood", ex);
            }
            return dTK_Get_CollectResponse;
        }
        #endregion

        #region 直播好货
        public DTK_LiveMaterialGoodResponse GetDTK_LiveMaterialGood(DTK_LiveMaterialGoodRequest dTK_LiveMaterialGoodRequest)
        {
            DTK_LiveMaterialGoodResponse dTK_LiveMaterialGoodResponse = null;
            try
            {
                string resultContent = GeneralApiParam(api_get_livematerial, dTK_LiveMaterialGoodRequest.ModelToUriParam());
                dTK_LiveMaterialGoodResponse = resultContent.ToJsonObject<DTK_LiveMaterialGoodResponse>();

                //转换公用商品信息
                if (dTK_LiveMaterialGoodRequest.IsReturnCommonInfo)
                {
                    dTK_LiveMaterialGoodResponse.CommonGoodInfoList = ConvertCommonGoodInfo(dTK_LiveMaterialGoodResponse.data.list);
                }

            }
            catch (Exception ex)
            {
                LogHelper.WriteException("GetDTK_LiveMaterialGood", ex);
            }
            return dTK_LiveMaterialGoodResponse;
        }
        #endregion

        #region 每日爆品推荐
        public DTK_Explosive_Goods_ListResponse GetDTK_ExplosiveGoods(DTK_Explosive_Goods_ListRequest dTK_Explosive_Goods_ListRequest)
        {
            DTK_Explosive_Goods_ListResponse dTK_Explosive_Goods_ListResponse = null;
            try
            {
                string resultContent = GeneralApiParam(api_get_explosivegoods, dTK_Explosive_Goods_ListRequest.ModelToUriParam());
                dTK_Explosive_Goods_ListResponse = resultContent.ToJsonObject<DTK_Explosive_Goods_ListResponse>();

                if (!dTK_Explosive_Goods_ListResponse.data.IsEmpty())
                {
                    //转换公用商品信息
                    if (dTK_Explosive_Goods_ListRequest.IsReturnCommonInfo)
                    {
                        dTK_Explosive_Goods_ListResponse.CommonGoodInfoList = ConvertCommonGoodInfo(dTK_Explosive_Goods_ListResponse.data.list);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteException("GetDTK_ExplosiveGoods", ex);
            }
            return dTK_Explosive_Goods_ListResponse;
        }
        #endregion

        #region 获取历史最低价商品
        public DTK_History_Low_Price_ListResponse GetHistoryLowPriceListResponse(DTK_History_Low_Price_ListRequest dTK_History_Low_Price_ListRequest)
        {
            DTK_History_Low_Price_ListResponse dTK_History_Low_Price_ListResponse = null;
            try
            {
                string resultContent = GeneralApiParam(api_get_history_low_price_good, dTK_History_Low_Price_ListRequest.ModelToUriParam());
                dTK_History_Low_Price_ListResponse = resultContent.ToJsonObject<DTK_History_Low_Price_ListResponse>();

                if (!dTK_History_Low_Price_ListResponse.data.IsEmpty())
                {
                    //转换公用商品信息
                    if (dTK_History_Low_Price_ListRequest.IsReturnCommonInfo)
                    {
                        dTK_History_Low_Price_ListResponse.CommonGoodInfoList = ConvertCommonGoodInfo(dTK_History_Low_Price_ListResponse.data.list);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteException("GetHistoryLowPriceListResponse", ex);
            }
            return dTK_History_Low_Price_ListResponse;
        }
        #endregion

        #region 大淘客接口请求签名
        string GeneralApiParam(string api_url, string api_params)
        {
            string resultContent = "";
            try
            {
                api_url = api_url.EndsWith("?") ? api_url : api_url + "?";
                api_params += string.Format("&appKey={0}", this.dtk_appkey);
                api_url += api_params + "&sign=" + makeSign(api_params, this.dtk_appsecret);
                resultContent = AjaxRequest.HttpGet(api_url, "");
            }
            catch (Exception ex)
            {
                LogHelper.WriteException("GeneralApiParam", ex);
            }
            return resultContent;
        }

        string makeSign(string api_params, string app_secret)
        {
            string[] parr = api_params.Split('&');
            Array.Sort(parr);

            string rst = "";
            foreach (string item in parr)
            {
                if (string.IsNullOrEmpty(item)) continue;
                rst += item + "&";
            }
            rst += string.Format("key={0}", app_secret);

            return Md5Helper.Md5(rst);
        }
        #endregion

        #region 公用商品接口转换
        List<CommonGoodInfoEntity> ConvertCommonGoodInfo(object WaitConvertGoodInfoList)
        {
            List<CommonGoodInfoEntity> commonGoodInfoList = new List<CommonGoodInfoEntity>();
            try
            {
                if (WaitConvertGoodInfoList is List<RankingItem>)
                {
                    #region 各大榜单商品转换信息
                    List<RankingItem> rankingItemList = WaitConvertGoodInfoList as List<RankingItem>;
                    foreach (RankingItem item in rankingItemList)
                    {
                        string[] images = new string[] { GetImage(item.mainPic) };
                        commonGoodInfoList.Add(new CommonGoodInfoEntity
                        {
                            skuid = item.goodsId.ToString(),
                            title = item.title,
                            shopId = item.sellerId,
                            shopLogo = item.shopLogo,//"https://wwc.alicdn.com/avatar/getAvatar.do?userId=" + item.sellerId,
                            shopName = item.shopName,
                            coupon_after_price = item.actualPrice.ToString(),
                            coupon_price = item.couponPrice.ToString(),
                            origin_price = item.originalPrice.ToString(),
                            coupon_end_time = item.couponEndTime,
                            coupon_start_time = item.couponStartTime,
                            detail_images = images,
                            images = images,
                            image = GetImage(item.mainPic),
                            month_sales = item.monthSales,
                            TotalCommission = Math.Round((double)(item.actualPrice * item.commissionRate) / 100, 2),
                            PlaformType = 1,
                            afterServiceScore = GetScore(null),
                            logisticsLvyueScore = GetScore(null),
                            userEvaluateScore = GetScore(null),
                            remark = item.desc,
                            coupon_link = item.couponLink
                        });
                    }
                    #endregion
                }
                else if (WaitConvertGoodInfoList is List<SuperGoodItem>)
                {
                    #region 超级搜索(大淘客+联盟)
                    List<SuperGoodItem> superGoodItemList = WaitConvertGoodInfoList as List<SuperGoodItem>;
                    foreach (SuperGoodItem item in superGoodItemList)
                    {
                        string[] images = new string[] { GetImage(item.mainPic) };
                        commonGoodInfoList.Add(new CommonGoodInfoEntity
                        {
                            skuid = item.goodsId.ToString(),
                            title = item.title,
                            shopId = item.sellerId,
                            shopLogo = item.shopLogo,
                            shopName = item.shopName,
                            coupon_after_price = item.actualPrice.ToString(),
                            coupon_price = item.couponPrice.ToString(),
                            origin_price = item.originalPrice.ToString(),
                            coupon_end_time = item.couponEndTime,
                            coupon_start_time = item.couponStartTime,
                            detail_images = images,
                            images = images,
                            image = GetImage(item.mainPic),
                            month_sales = item.monthSales,
                            TotalCommission = Math.Round((double)(item.actualPrice * item.commissionRate) / 100, 2),
                            PlaformType = 1,
                            afterServiceScore = GetScore(item.shipScore.ToString()),
                            logisticsLvyueScore = GetScore(item.serviceScore.ToString()),
                            userEvaluateScore = GetScore(item.descScore.ToString()),
                            remark = item.desc,
                            coupon_link = item.couponLink
                        });
                    }
                    #endregion
                }
                else if (WaitConvertGoodInfoList is List<DTK_SearchGoodItem>)
                {
                    #region 获取大淘客商品
                    List<DTK_SearchGoodItem> dTK_SearchGoodItemList = WaitConvertGoodInfoList as List<DTK_SearchGoodItem>;
                    foreach (DTK_SearchGoodItem item in dTK_SearchGoodItemList)
                    {
                        string[] images = new string[] { GetImage(item.mainPic) };
                        commonGoodInfoList.Add(new CommonGoodInfoEntity
                        {
                            skuid = item.goodsId.ToString(),
                            title = item.title,
                            shopId = item.sellerId,
                            shopLogo = item.shopLogo,
                            shopName = item.shopName,
                            coupon_after_price = item.actualPrice.ToString(),
                            coupon_price = item.couponPrice.ToString(),
                            origin_price = item.originalPrice.ToString(),
                            coupon_end_time = item.couponEndTime,
                            coupon_start_time = item.couponStartTime,
                            detail_images = images,
                            images = images,
                            image = GetImage(item.mainPic),
                            month_sales = item.monthSales,
                            TotalCommission = Math.Round((double)(item.actualPrice * item.commissionRate) / 100, 2),
                            PlaformType = 1,
                            afterServiceScore = GetScore(item.shipScore.ToString()),
                            logisticsLvyueScore = GetScore(item.serviceScore.ToString()),
                            userEvaluateScore = GetScore(item.descScore.ToString()),
                            remark = item.desc,
                            coupon_link = item.couponLink
                        });
                    }
                    #endregion
                }
                else if (WaitConvertGoodInfoList is List<OPGoodItem>)
                {
                    #region 9.9包邮精选
                    List<OPGoodItem> oPGoodItemList = WaitConvertGoodInfoList as List<OPGoodItem>;
                    foreach (OPGoodItem item in oPGoodItemList)
                    {
                        string[] images = new string[] { GetImage(item.mainPic) };
                        commonGoodInfoList.Add(new CommonGoodInfoEntity
                        {
                            skuid = item.goodsId.ToString(),
                            title = item.title,
                            shopId = item.sellerId,
                            shopLogo = item.shopLogo,
                            shopName = item.shopName,
                            coupon_after_price = item.actualPrice.ToString(),
                            coupon_price = item.couponPrice.ToString(),
                            origin_price = item.originalPrice.ToString(),
                            coupon_end_time = item.couponEndTime,
                            coupon_start_time = item.couponStartTime,
                            detail_images = images,
                            images = images,
                            image = GetImage(item.mainPic),
                            month_sales = item.monthSales,
                            TotalCommission = Math.Round((double)(item.actualPrice * item.commissionRate) / 100, 2),
                            PlaformType = 1,
                            afterServiceScore = GetScore(item.shipScore.ToString()),
                            logisticsLvyueScore = GetScore(item.serviceScore.ToString()),
                            userEvaluateScore = GetScore(item.descScore.ToString()),
                            remark = item.desc,
                            coupon_link = item.couponLink
                        });
                    }
                    #endregion
                }
                else if (WaitConvertGoodInfoList is List<ActivityGoodItem>)
                {
                    #region 热门活动对应商品
                    List<ActivityGoodItem> activityGoodItemList = WaitConvertGoodInfoList as List<ActivityGoodItem>;
                    foreach (ActivityGoodItem item in activityGoodItemList)
                    {
                        string[] images = new string[] { GetImage(item.mainPic) };
                        commonGoodInfoList.Add(new CommonGoodInfoEntity
                        {
                            skuid = item.goodsId.ToString(),
                            title = item.title,
                            shopId = item.sellerId,
                            shopLogo = item.shopLogo,
                            shopName = item.shopName,
                            coupon_after_price = item.actualPrice.ToString(),
                            coupon_price = item.couponPrice.ToString(),
                            origin_price = item.originalPrice.ToString(),
                            coupon_end_time = item.couponEndTime,
                            coupon_start_time = item.couponStartTime,
                            detail_images = images,
                            images = images,
                            image = GetImage(item.mainPic),
                            month_sales = item.monthSales,
                            TotalCommission = Math.Round((double)(item.actualPrice * item.commissionRate) / 100, 2),
                            PlaformType = 1,
                            afterServiceScore = GetScore(item.shipScore.ToString()),
                            logisticsLvyueScore = GetScore(item.serviceScore.ToString()),
                            userEvaluateScore = GetScore(item.descScore.ToString()),
                            remark = item.desc,
                            coupon_link = item.couponLink
                        });
                    }
                    #endregion
                }
                else if (WaitConvertGoodInfoList is List<TopicGoodItem>)
                {
                    #region 专辑商品列表
                    List<TopicGoodItem> topicGoodItemList = WaitConvertGoodInfoList as List<TopicGoodItem>;
                    foreach (TopicGoodItem item in topicGoodItemList)
                    {
                        string[] images = new string[] { GetImage(item.mainPic) };
                        commonGoodInfoList.Add(new CommonGoodInfoEntity
                        {
                            skuid = item.goodsId.ToString(),
                            title = item.title,
                            shopId = item.sellerId,
                            shopLogo = item.shopLogo,
                            shopName = item.shopName,
                            coupon_after_price = item.actualPrice.ToString(),
                            coupon_price = item.couponPrice.ToString(),
                            origin_price = item.originalPrice.ToString(),
                            coupon_end_time = item.couponEndTime,
                            coupon_start_time = item.couponStartTime,
                            detail_images = images,
                            images = images,
                            image = GetImage(item.mainPic),
                            month_sales = item.monthSales,
                            TotalCommission = Math.Round((double)(item.actualPrice * item.commissionRate) / 100, 2),
                            PlaformType = 1,
                            afterServiceScore = GetScore(item.shipScore.ToString()),
                            logisticsLvyueScore = GetScore(item.serviceScore.ToString()),
                            userEvaluateScore = GetScore(item.descScore.ToString()),
                            remark = item.desc,
                            coupon_link = item.couponLink
                        });
                    }
                    #endregion
                }
                else if (WaitConvertGoodInfoList is List<DTK_LiveMaterialGood>)
                {
                    #region 直播好货商品
                    List<DTK_LiveMaterialGood> DTK_LiveMaterialGoodList = WaitConvertGoodInfoList as List<DTK_LiveMaterialGood>;
                    foreach (DTK_LiveMaterialGood item in DTK_LiveMaterialGoodList)
                    {
                        string[] images = new string[] { GetImage(item.mainPic) };
                        commonGoodInfoList.Add(new CommonGoodInfoEntity
                        {
                            skuid = item.goodsId.ToString(),
                            title = item.title,
                            shopId = item.sellerId,
                            shopLogo = item.shopLogo,
                            shopName = item.shopName,
                            coupon_after_price = item.actualPrice.ToString(),
                            coupon_price = item.couponPrice.ToString(),
                            origin_price = item.originalPrice.ToString(),
                            coupon_end_time = item.couponEndTime,
                            coupon_start_time = item.couponStartTime,
                            detail_images = images,
                            images = images,
                            image = GetImage(item.mainPic),
                            month_sales = item.monthSales,
                            TotalCommission = Math.Round((double)(item.actualPrice * item.commissionRate) / 100, 2),
                            PlaformType = 1,
                            afterServiceScore = GetScore(item.shipScore.ToString()),
                            logisticsLvyueScore = GetScore(item.serviceScore.ToString()),
                            userEvaluateScore = GetScore(item.descScore.ToString()),
                            remark = item.desc,
                            coupon_link = item.couponLink
                        });
                    }
                    #endregion
                }
                else if (WaitConvertGoodInfoList is List<DTK_Explosive_GoodsItem>)
                {
                    List<DTK_Explosive_GoodsItem> DTK_ExplosiveGoodList = WaitConvertGoodInfoList as List<DTK_Explosive_GoodsItem>;
                    foreach (DTK_Explosive_GoodsItem item in DTK_ExplosiveGoodList)
                    {
                        string[] images = new string[] { GetImage(item.mainPic) };
                        commonGoodInfoList.Add(new CommonGoodInfoEntity
                        {
                            skuid = item.goodsId.ToString(),
                            title = item.title,
                            shopId = item.sellerId,
                            shopLogo = item.shopLogo,
                            shopName = item.shopName,
                            coupon_after_price = item.actualPrice.ToString(),
                            coupon_price = item.couponPrice.ToString(),
                            origin_price = item.originalPrice.ToString(),
                            coupon_end_time = item.couponEndTime,
                            coupon_start_time = item.couponStartTime,
                            detail_images = images,
                            images = images,
                            image = GetImage(item.mainPic),
                            month_sales = item.monthSales,
                            TotalCommission = Math.Round((double)(item.actualPrice * item.commissionRate) / 100, 2),
                            PlaformType = 1,
                            afterServiceScore = GetScore(item.shipScore.ToString()),
                            logisticsLvyueScore = GetScore(item.serviceScore.ToString()),
                            userEvaluateScore = GetScore(item.descScore.ToString()),
                            remark = item.desc,
                            coupon_link = item.couponLink
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteException("ConvertCommonGoodInfo", ex);
            }

            return commonGoodInfoList;
        }

        string GetScore(string score)
        {
            if (score == null)
            {
                string[] scoreList = new string[] { "4.8", "4.9", "5.0" };
                return scoreList[new Random().Next(scoreList.Length)];
            }
            else
            {
                decimal scoreValue = 0;

                if (decimal.TryParse(score, out scoreValue))
                {
                    if (scoreValue <= 0)
                        return "低";
                    else if (scoreValue >= 10)
                        return "高";
                    else
                        return score;
                }
                else
                {
                    return score;
                }
            }
        }

        string GetImage(string img)
        {
            if (!img.StartsWith("http"))
            {
                img = "http:" + img;
            }
            return img;
        }
        #endregion
    }
}
