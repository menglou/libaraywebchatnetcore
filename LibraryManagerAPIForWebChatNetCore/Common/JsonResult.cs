using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
   public class JsonResult<T>
    {
        public int Code { get; set; }

        public string Msg { get; set; }


        public T Data { get; set; }
    }
}
