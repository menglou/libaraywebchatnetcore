using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common;
using Entity;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using BLL;

namespace LibraryManagerAPIForWebChatNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// 微信里用户登录
        /// </summary>
        /// <param name="code"></param>
        /// <param name="nickName"></param>
        /// <param name="province"></param>
        /// <param name="city"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        [HttpPost]
        public string Login(dynamic obj )
        {

            Common.JsonResult<string> jsonresult = new Common.JsonResult<string>();

            string codes =Convert.ToString(obj.code);
            string appids = ConfigurationManager.GetAppsettings("Appsettings:appid");
            string appscret = ConfigurationManager.GetAppsettings("Appsettings:AppSecret");
            string granttype = ConfigurationManager.GetAppsettings("Appsettings:grant_type");

            string url = string.Format("https://api.weixin.qq.com/sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type={3}", appids, appscret, codes, granttype);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "Post";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // 接收数据
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            WxAuthor wx = Newtonsoft.Json.JsonConvert.DeserializeObject<WxAuthor>(responseFromServer);

            if(wx!=null&&wx.errcode==0)
            {
                User user = new User
                {
                    OpenId = wx.openid,
                    Seesion_Key = wx.session_key,
                    NickName = Convert.ToString(obj.nickName),
                    Province = Convert.ToString(obj.province),
                    City = Convert.ToString(obj.city),
                    Gender = Convert.ToString(obj.gender) == "1" ? "男" : "女",
                };
                //插叙数据库中保存

                int result = new BLL.UserBLL().InsertUserInfo(user);

                if(result==1)
                {
                    jsonresult.Code = 100;
                    jsonresult.Msg = "成功";
                    
                }
                else
                {
                    jsonresult.Code = -1;
                    jsonresult.Msg = "失败";
                }
            }
            else
            {
                jsonresult.Code = -2;
                jsonresult.Msg = "获取信息失败";
            }
            string returnjson = Newtonsoft.Json.JsonConvert.SerializeObject(jsonresult);

            return returnjson;
        }
    }
}