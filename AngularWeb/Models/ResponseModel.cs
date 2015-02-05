using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamManager.Models
{
    public class ResponseModel
    {
        //状态码：0-正常，1~100-自定义信息，401-登录失效或未登录
        public int state;

        public string msg;

        public object data;
    }
}