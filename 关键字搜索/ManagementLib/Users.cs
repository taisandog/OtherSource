using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Buffalo.DB.CommBase;
using Buffalo.Kernel.Defaults;
using Buffalo.DB.PropertyAttributes;
using Buffalo.DB.CommBase.BusinessBases;
namespace ManagementLib
{
	/// <summary>
    /// 
    /// </summary>
    public partial class Users: Buffalo.DB.CommBase.BusinessBases.ThinModelBase
    {
        ///<summary>
        ///����ID���Զ�����
        ///</summary>
        protected int? _id;

        /// <summary>
        ///����ID���Զ�����
        ///</summary>
        public int? Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id=value;
                OnPropertyUpdated("Id");
            }
        }
        ///<summary>
        ///�û���¼���˺�
        ///</summary>
        protected string _userID;

        /// <summary>
        ///�û���¼���˺�
        ///</summary>
        public string UserID
        {
            get
            {
                return _userID;
            }
            set
            {
                _userID=value;
                OnPropertyUpdated("UserID");
            }
        }
        ///<summary>
        ///�û���ʵ����
        ///</summary>
        protected string _userName;

        /// <summary>
        ///�û���ʵ����
        ///</summary>
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName=value;
                OnPropertyUpdated("UserName");
            }
        }
        ///<summary>
        ///�û���¼����
        ///</summary>
        protected string _userPwd;

        /// <summary>
        ///�û���¼����
        ///</summary>
        public string UserPwd
        {
            get
            {
                return _userPwd;
            }
            set
            {
                _userPwd=value;
                OnPropertyUpdated("UserPwd");
            }
        }
        ///<summary>
        ///�ֿ��ID
        ///</summary>
        protected int? _storageId;

        /// <summary>
        ///�ֿ��ID
        ///</summary>
        public int? StorageId
        {
            get
            {
                return _storageId;
            }
            set
            {
                _storageId=value;
                OnPropertyUpdated("StorageId");
            }
        }
        ///<summary>
        ///Ȩ��(1Ϊϵͳ����Ա��2Ϊ��ͨ�û�)
        ///</summary>
        protected int? _authority;

        /// <summary>
        ///Ȩ��(1Ϊϵͳ����Ա��2Ϊ��ͨ�û�)
        ///</summary>
        public int? Authority
        {
            get
            {
                return _authority;
            }
            set
            {
                _authority=value;
                OnPropertyUpdated("Authority");
            }
        }
        ///<summary>
        ///�˵�¼�˺��Ƿ����(0Ϊ������,1Ϊ����)
        ///</summary>
        protected bool? _isEnable;

        /// <summary>
        ///�˵�¼�˺��Ƿ����(0Ϊ������,1Ϊ����)
        ///</summary>
        public bool? IsEnable
        {
            get
            {
                return _isEnable;
            }
            set
            {
                _isEnable=value;
                OnPropertyUpdated("IsEnable");
            }
        }
        ///<summary>
        ///
        ///</summary>
        protected int? _classId;

        /// <summary>
        ///
        ///</summary>
        public int? ClassId
        {
            get
            {
                return _classId;
            }
            set
            {
                _classId=value;
                OnPropertyUpdated("ClassId");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        protected List<SampleRecord> _lstSampleRecordId_S_userId;

        /// <summary>
        /// 
        /// </summary>
        public List<SampleRecord> LstSampleRecordId_S_userId
        {
            get
            {
               if (_lstSampleRecordId_S_userId == null)
               {
                   FillChild("LstSampleRecordId_S_userId");
               }
               return _lstSampleRecordId_S_userId;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected List<OutRecode> _lstOutRecodeId_UserId;

        /// <summary>
        /// 
        /// </summary>
        public List<OutRecode> LstOutRecodeId_UserId
        {
            get
            {
               if (_lstOutRecodeId_UserId == null)
               {
                   FillChild("LstOutRecodeId_UserId");
               }
               return _lstOutRecodeId_UserId;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected Users _belongUsers_Id_Id;

        /// <summary>
        /// 
        /// </summary>
        public Users BelongUsers_Id_Id
        {
            get
            {
               if (_belongUsers_Id_Id == null)
               {
                   FillParent("BelongUsers_Id_Id");
               }
               return _belongUsers_Id_Id;
            }
            set
            {
               _belongUsers_Id_Id = value;
               OnPropertyUpdated("BelongUsers_Id_Id");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected List<Users> _lstUsersId_Id;

        /// <summary>
        /// 
        /// </summary>
        public List<Users> LstUsersId_Id
        {
            get
            {
               if (_lstUsersId_Id == null)
               {
                   FillChild("LstUsersId_Id");
               }
               return _lstUsersId_Id;
            }
        }


        private static ModelContext<Users> _____baseContext=new ModelContext<Users>();
        /// <summary>
        /// ��ȡ��ѯ������
        /// </summary>
        /// <returns></returns>
        public static ModelContext<Users> GetContext() 
        {
            return _____baseContext;
        }

    }
}
