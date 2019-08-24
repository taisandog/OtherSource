using System;
using System.Data;
using System.Configuration;
using Buffalo.DB.EntityInfos;
using Buffalo.DB.BQLCommon;
using Buffalo.DB.BQLCommon.BQLConditionCommon;
using Buffalo.DB.PropertyAttributes;
namespace ManagementLib.BQLEntity
{

    public partial class Management
    {
        private static Management_Users _Users = new Management_Users();
    
        public static Management_Users Users
        {
            get
            {
                return _Users;
            }
        }
    }

    /// <summary>
    ///  
    /// </summary>
    public partial class Management_Users : BQLEntityTableHandle
    {
        private BQLEntityParamHandle _id = null;
        /// <summary>
        /// ����ID���Զ�����
        /// </summary>
        public BQLEntityParamHandle Id
        {
            get
            {
                return _id;
            }
         }
        private BQLEntityParamHandle _userID = null;
        /// <summary>
        /// �û���¼���˺�
        /// </summary>
        public BQLEntityParamHandle UserID
        {
            get
            {
                return _userID;
            }
         }
        private BQLEntityParamHandle _userName = null;
        /// <summary>
        /// �û���ʵ����
        /// </summary>
        public BQLEntityParamHandle UserName
        {
            get
            {
                return _userName;
            }
         }
        private BQLEntityParamHandle _userPwd = null;
        /// <summary>
        /// �û���¼����
        /// </summary>
        public BQLEntityParamHandle UserPwd
        {
            get
            {
                return _userPwd;
            }
         }
        private BQLEntityParamHandle _storageId = null;
        /// <summary>
        /// �ֿ��ID
        /// </summary>
        public BQLEntityParamHandle StorageId
        {
            get
            {
                return _storageId;
            }
         }
        private BQLEntityParamHandle _authority = null;
        /// <summary>
        /// Ȩ��(1Ϊϵͳ����Ա��2Ϊ��ͨ�û�)
        /// </summary>
        public BQLEntityParamHandle Authority
        {
            get
            {
                return _authority;
            }
         }
        private BQLEntityParamHandle _isEnable = null;
        /// <summary>
        /// �˵�¼�˺��Ƿ����(0Ϊ������,1Ϊ����)
        /// </summary>
        public BQLEntityParamHandle IsEnable
        {
            get
            {
                return _isEnable;
            }
         }
        private BQLEntityParamHandle _classId = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle ClassId
        {
            get
            {
                return _classId;
            }
         }

        /// <summary>
        /// 
        /// </summary>
        public Management_Users BelongUsers_Id_Id
        {
            get
            {
               return new Management_Users(this,"BelongUsers_Id_Id");
            }
         }


		/// <summary>
        /// ��ʼ���������Ϣ
        /// </summary>
        /// <param name="parent">������Ϣ</param>
        /// <param name="propertyName">������</param>
        public Management_Users(BQLEntityTableHandle parent,string propertyName) 
        :this(typeof(ManagementLib.Users),parent,propertyName)
        {
			
        }
        /// <summary>
        /// ��ʼ���������Ϣ
        /// </summary>
        /// <param name="parent">������Ϣ</param>
        /// <param name="propertyName">������</param>
        public Management_Users(Type entityType,BQLEntityTableHandle parent,string propertyName) 
        :base(entityType,parent,propertyName)
        {
            _id=CreateProperty("Id");
            _userID=CreateProperty("UserID");
            _userName=CreateProperty("UserName");
            _userPwd=CreateProperty("UserPwd");
            _storageId=CreateProperty("StorageId");
            _authority=CreateProperty("Authority");
            _isEnable=CreateProperty("IsEnable");
            _classId=CreateProperty("ClassId");

        }
        
        /// <summary>
        /// ��ʼ���������Ϣ
        /// </summary>
        public Management_Users() 
            :this(null,null)
        {
        }
    }
}
