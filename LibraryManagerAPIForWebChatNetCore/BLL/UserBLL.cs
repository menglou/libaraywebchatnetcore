using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Entity;

namespace BLL
{
   public class UserBLL
    {
        public int InsertUserInfo(User user)
        {
            return new DAL.UserDAL().InsertUserInfo(user);
        }
    }
}
