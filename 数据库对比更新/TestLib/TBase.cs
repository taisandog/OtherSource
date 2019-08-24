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
    public partial class TBase:EntityBase
    {
        /// <summary>
        /// ID
        /// </summary>
        private int _id;
        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime _createDate;
        /// <summary>
        /// ID
        /// </summary>
        public virtual int Id
        {
            get{ return _id; }
            set{ _id=value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateDate
        {
            get{ return _createDate; }
            set{ _createDate=value; }
        }
    }
}
