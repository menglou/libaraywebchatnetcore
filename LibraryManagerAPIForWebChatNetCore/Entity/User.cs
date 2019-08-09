using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
   public class User
    {
        //ID, CreateTime, CreateBy, UpdateTime, UpdateBy, OpenId, Seesion_Key, NickName, HeadImag, Province, City, Gender

        public Guid ID { get; set; }
        public string CreateTime { get; set; }
        public string CreateBy { get; set; }
        public string UpdateTime { get; set; }
        public string UpdateBy { get; set; }
        public string OpenId { get; set; }
        public string Seesion_Key { get; set; }
        public string NickName { get; set; }
        public string HeadImag { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
    }
}
