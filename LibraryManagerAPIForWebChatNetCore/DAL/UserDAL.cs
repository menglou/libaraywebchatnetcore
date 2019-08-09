using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using Common;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DAL
{
   public class UserDAL
    {
        public int InsertUserInfo(User user)
        {
            string sql = "insert into [dbo].[User] (ID,CreateTime,CreateBy,UpdateTime,UpdateBy, OpenId, Seesion_Key, NickName, HeadImag, Province, City, Gender) values ( newid(),getdate(),@CreateBy,getdate(),@UpdateBy,@OpenId,@Seesion_Key,@NickName,@HeadImag,@Province,@City,@Gender)";

            try
            {
                using (SqlConnection coon = ConfigurationManager.SqlConnection())
                {
                    int result = coon.Execute(sql, user);

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
