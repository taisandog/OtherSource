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
        private static Management_OutRecode _OutRecode = new Management_OutRecode();
    
        public static Management_OutRecode OutRecode
        {
            get
            {
                return _OutRecode;
            }
        }
    }

    /// <summary>
    ///  
    /// </summary>
    public partial class Management_OutRecode : BQLEntityTableHandle
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
        private BQLEntityParamHandle _sampleBarCode = null;
        /// <summary>
        /// ��Ʒ����(��Ӧ��Ʒ���������������)
        /// </summary>
        public BQLEntityParamHandle SampleBarCode
        {
            get
            {
                return _sampleBarCode;
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
        private BQLEntityParamHandle _outTime = null;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public BQLEntityParamHandle OutTime
        {
            get
            {
                return _outTime;
            }
         }
        private BQLEntityParamHandle _userId = null;
        /// <summary>
        /// ������(�û����ID)
        /// </summary>
        public BQLEntityParamHandle UserId
        {
            get
            {
                return _userId;
            }
         }

        /// <summary>
        /// 
        /// </summary>
        public Management_Users BelongUsers_UserId_Id
        {
            get
            {
               return new Management_Users(this,"BelongUsers_UserId_Id");
            }
         }
        /// <summary>
        /// 
        /// </summary>
        public Management_Storage BelongStorage_StorageId_Id
        {
            get
            {
               return new Management_Storage(this,"BelongStorage_StorageId_Id");
            }
         }
        /// <summary>
        /// 
        /// </summary>
        public Management_GoodsShelf BelongGoodsShelf_GoodShelfId_Id
        {
            get
            {
               return new Management_GoodsShelf(this,"BelongGoodsShelf_GoodShelfId_Id");
            }
         }
        /// <summary>
        /// 
        /// </summary>
        public Management_GoodsLocation BelongGoodsLocation_GoodLocationId_Id
        {
            get
            {
               return new Management_GoodsLocation(this,"BelongGoodsLocation_GoodLocationId_Id");
            }
         }


		/// <summary>
        /// ��ʼ���������Ϣ
        /// </summary>
        /// <param name="parent">������Ϣ</param>
        /// <param name="propertyName">������</param>
        public Management_OutRecode(BQLEntityTableHandle parent,string propertyName) 
        :this(typeof(ManagementLib.OutRecode),parent,propertyName)
        {
			
        }
        /// <summary>
        /// ��ʼ���������Ϣ
        /// </summary>
        /// <param name="parent">������Ϣ</param>
        /// <param name="propertyName">������</param>
        public Management_OutRecode(Type entityType,BQLEntityTableHandle parent,string propertyName) 
        :base(entityType,parent,propertyName)
        {
            _id=CreateProperty("Id");
            _sampleBarCode=CreateProperty("SampleBarCode");
            _storageId=CreateProperty("StorageId");
            _goodShelfId=CreateProperty("GoodShelfId");
            _goodLocationId=CreateProperty("GoodLocationId");
            _outTime=CreateProperty("OutTime");
            _userId=CreateProperty("UserId");

        }
        
        /// <summary>
        /// ��ʼ���������Ϣ
        /// </summary>
        public Management_OutRecode() 
            :this(null,null)
        {
        }
    }
}
