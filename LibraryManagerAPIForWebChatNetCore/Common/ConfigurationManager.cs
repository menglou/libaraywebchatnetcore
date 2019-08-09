using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Common
{
   public class ConfigurationManager
    {
        public readonly static IConfiguration Configuration;

        static ConfigurationManager()
        {
            // ReloadOnChange = true 当appsettings.json被修改时重新加载
             Configuration = new ConfigurationBuilder()
             .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
             .Build();
        }

        /// <summary>
        ///获取 SqlConnection
        /// </summary>
        /// <returns></returns>
        public static SqlConnection SqlConnection()
        {
            string connectingstring = Configuration.GetConnectionString("SqlServerConection");
            SqlConnection coon = new SqlConnection(connectingstring);
            coon.Open();
            return coon;
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetAppsettings(string key)
        {
            string appsetints = Configuration[key];
            return appsetints;
        }
    }
}
