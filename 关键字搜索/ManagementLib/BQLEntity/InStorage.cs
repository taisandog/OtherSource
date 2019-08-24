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
        private static Management_InStorage _InStorage = new Management_InStorage();
    
        public static Management_InStorage InStorage
        {
            get
            {
                return _InStorage;
            }
        }
    }

    /// <summary>
    ///  
    /// </summary>
    public partial class Management_InStorage : BQLEntityTableHandle
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
        private BQLEntityParamHandle _sampleCode = null;
        /// <summary>
        /// ��Ʒ������
        /// </summary>
        public BQLEntityParamHandle SampleCode
        {
            get
            {
                return _sampleCode;
            }
         }
        private BQLEntityParamHandle _storageId = null;
        /// <summary>
        /// �ֿ�ID
        /// </summary>
        public BQLEntityParamHandle StorageId
        {
            get
            {
                return _storageId;
            }
         }
        private BQLEntityParamHandle _goodShelfId = null;
        /// <summary>
        /// ����ID
        /// </summary>
        public BQLEntityParamHandle GoodShelfId
        {
            get
            {
                return _goodShelfId;
            }
         }
        private BQLEntityParamHandle _goodLocationId = null;
        /// <summary>
        /// ��λID
        /// </summary>
        public BQLEntityParamHandle GoodLocationId
        {
            get
            {
                return _goodLocationId;
            }
         }
        private BQLEntityParamHandle _userId = null;
        /// <summary>
        /// �������ߵ�ID(���û���ID��Ӧ)
        /// </summary>
        public BQLEntityParamHandle UserId
        {
            get
            {
                return _userId;
            }
         }
        private BQLEntityParamHandle _state = null;
        /// <summary>
        /// �Ƿ��ڲֿ�����(0�ڿ�,1���ڿ�,2��Ʒ���)
        /// </summary>
        public BQLEntityParamHandle State
        {
            get
            {
                return _state;
            }
         }
        private BQLEntityParamHandle _instorageTime = null;
        /// <summary>
        /// ���ʱ��(ϵͳ�Զ�����)
        /// </summary>
        public BQLEntityParamHandle InstorageTime
        {
            get
            {
                return _instorageTime;
            }
         }



		/// <summary>
        /// ��ʼ���������Ϣ
        /// </summary>
        /// <param name="parent">������Ϣ</param>
        /// <param name="propertyName">������</param>
        public Management_InStorage(BQLEntityTableHandle parent,string propertyName) 
        :this(typeof(ManagementLib.InStorage),parent,propertyName)
        {
			
        }
        /// <summary>
        /// ��ʼ���������Ϣ
        /// </summary>
        /// <param name="parent">������Ϣ</param>
        /// <param name="propertyName">������</param>
        public Management_InStorage(Type entityType,BQLEntityTableHandle parent,string propertyName) 
        :base(entityType,parent,propertyName)
        {
            _id=CreateProperty("Id");
            _sampleCode=CreateProperty("SampleCode");
            _storageId=CreateProperty("StorageId");
            _goodShelfId=CreateProperty("GoodShelfId");
            _goodLocationId=CreateProperty("GoodLocationId");
            _userId=CreateProperty("UserId");
            _state=CreateProperty("State");
            _instorageTime=CreateProperty("InstorageTime");

        }
        
        /// <summary>
        /// ��ʼ���������Ϣ
        /// </summary>
        public Management_InStorage() 
            :this(null,null)
        {
        }
    }
}
