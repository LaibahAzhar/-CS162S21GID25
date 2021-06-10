using System;
using System.Collections.Generic;
using System.Text;

namespace dashboard
{
    interface LoginAccess
    {
         string UserName
        {
            get; set;
        }
         string Password
        {
            get; set;
        }
    }
}
