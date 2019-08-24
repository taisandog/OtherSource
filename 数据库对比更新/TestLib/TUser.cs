using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Buffalo.DB.CommBase;
using Buffalo.Kernel.Defaults;
using Buffalo.DB.PropertyAttributes;
using System.Data;
using Buffalo.DB.CommBase.BusinessBases;
namespace TestLib
{
    public partial class TUser:TBase
    {
        /// <summary>
        /// 用户名
        /// </summary>
        private string _userName;
        /// <summary>
        /// EMail
        /// </summary>
        private string _email;
        /// <summary>
        /// 用户名
        /// </summary>
        public virtual string UserName
        {
            get{ return _userName; }
            set{ _userName=value; }
        }
        /// <summary>
        /// EMail
        /// </summary>
        public virtual string Email
        {
            get{ return _email; }
            set{ _email=value; }
        }
    }
}
