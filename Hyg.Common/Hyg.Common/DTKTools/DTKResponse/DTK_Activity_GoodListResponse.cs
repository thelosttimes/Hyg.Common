﻿/*===================================Copyright© 2020 xxx Ltd. All rights reserved.==============================

文件类名 : DTK_Activity_GoodListResponse.cs
创建人员 : Mr.Hu
创建时间 : 2020-09-18 9:41:14 
备注说明 : 活动商品列表

 =====================================End=======================================================*/
using Hyg.Common.DTKTools.DTKModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hyg.Common.DTKTools.DTKResponse
{
    /// <summary>
    /// 活动商品列表
    /// </summary>
    public class DTK_Activity_GoodListResponse:CommonResponseBase
    {
        public DTK_Activity_GoodListResult data { get; set; }
    }
}
