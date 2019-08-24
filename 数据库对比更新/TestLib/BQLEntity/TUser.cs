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
        ///�û���
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
        /// ��ʼ���������Ϣ
        /// </summary>
        /// <param name="parent">������Ϣ</param>
        /// <param name="propertyName">������</param>
        public BQL_TUser(BQLEntityTableHandle parent,string propertyName) 
        :this(typeof(TestLib.TUser),parent,propertyName)
        {
			
        }
        /// <summary>
        /// ��ʼ���������Ϣ
        /// </summary>
        /// <param name="parent">������Ϣ</param>
        /// <param name="propertyName">������</param>
        public BQL_TUser(Type entityType,BQLEntityTableHandle parent,string propertyName) 
        :base(entityType,parent,propertyName)
        {
            _userName=CreateProperty("UserName");
            _email=CreateProperty("Email");

        }
        
        /// <summary>
        /// ��ʼ���������Ϣ
        /// </summary>
        public BQL_TUser() 
            :this(null,null)
        {
        }
    }
}
