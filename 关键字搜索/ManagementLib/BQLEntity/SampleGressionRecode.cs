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
        private static Management_SampleGressionRecode _SampleGressionRecode = new Management_SampleGressionRecode();
    
        public static Management_SampleGressionRecode SampleGressionRecode
        {
            get
            {
                return _SampleGressionRecode;
            }
        }
    }

    /// <summary>
    ///  
    /// </summary>
    public partial class Management_SampleGressionRecode : BQLEntityTableHandle
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
        /// ��Ʒ����
        /// </summary>
        public BQLEntityParamHandle SampleCode
        {
            get
            {
                return _sampleCode;
            }
         }
        private BQLEntityParamHandle _userId = null;
        /// <summary>
        /// �ƶ��ߵ�ID
        /// </summary>
        public BQLEntityParamHandle UserId
        {
            get
            {
                return _userId;
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
        private BQLEntityParamHandle _recodeTime = null;
        /// <summary>
        /// �ƶ���ʱ��
        /// </summary>
        public BQLEntityParamHandle RecodeTime
        {
            get
            {
                return _recodeTime;
            }
         }
        private BQLEntityParamHandle _remark = null;
        /// <summary>
        /// ��ע˵��
        /// </summary>
        public BQLEntityParamHandle Remark
        {
            get
            {
                return _remark;
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
        public Management_SampleGressionRecode(BQLEntityTableHandle parent,string propertyName) 
        :this(typeof(ManagementLib.SampleGressionRecode),parent,propertyName)
        {
			
        }
        /// <summary>
        /// ��ʼ���������Ϣ
        /// </summary>
        /// <param name="parent">������Ϣ</param>
        /// <param name="propertyName">������</param>
        public Management_SampleGressionRecode(Type entityType,BQLEntityTableHandle parent,string propertyName) 
        :base(entityType,parent,propertyName)
        {
            _id=CreateProperty("Id");
            _sampleCode=CreateProperty("SampleCode");
            _userId=CreateProperty("UserId");
            _storageId=CreateProperty("StorageId");
            _goodShelfId=CreateProperty("GoodShelfId");
            _goodLocationId=CreateProperty("GoodLocationId");
            _recodeTime=CreateProperty("RecodeTime");
            _remark=CreateProperty("Remark");

        }
        
        /// <summary>
        /// ��ʼ���������Ϣ
        /// </summary>
        public Management_SampleGressionRecode() 
            :this(null,null)
        {
        }
    }
}
