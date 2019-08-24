using System;
using System.Data;
using System.Configuration;
using Buffalo.DB.EntityInfos;
using Buffalo.DB.BQLCommon;
using Buffalo.DB.BQLCommon.BQLConditionCommon;
using Buffalo.DB.PropertyAttributes;
namespace TestLib.BQLEntity
{

    public partial class TestDB 
    {
        private static BQL_TUser _TUser = new BQL_TUser();
    
        public static BQL_TUser TUser
        {
            get
            {
                return _TUser;
            }
        }
    }

    /// <summary>
    ///  
    /// </summary>
    public partial class BQL_TUser : TestLib.BQLEntity.BQL_TBase
    {
        private BQLEntityParamHandle _userName = null;
        /// <summary>
        ///用户名
        /// </summary>
        public BQLEntityParamHandle UserName
        {
            get
            {
                return _userName;
            }
         }
        private BQLEntityParamHandle _email = null;
        /// <summary>
        ///EMail
        /// </summary>
        public BQLEntityParamHandle Email
        {
            get
            {
                return _email;
            }
         }



		/// <summary>
        /// 初始化本类的信息
        /// </summary>
        /// <param name="parent">父表信息</param>
        /// <param name="propertyName">属性名</param>
        public BQL_TUser(BQLEntityTableHandle parent,string propertyName) 
        :this(typeof(TestLib.TUser),parent,propertyName)
        {
			
        }
        /// <summary>
        /// 初始化本类的信息
        /// </summary>
        /// <param name="parent">父表信息</param>
        /// <param name="propertyName">属性名</param>
        public BQL_TUser(Type entityType,BQLEntityTableHandle parent,string propertyName) 
        :base(entityType,parent,propertyName)
        {
            _userName=CreateProperty("UserName");
            _email=CreateProperty("Email");

        }
        
        /// <summary>
        /// 初始化本类的信息
        /// </summary>
        public BQL_TUser() 
            :this(null,null)
        {
        }
    }
}
