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
        private static Management_GoodsLocation _GoodsLocation = new Management_GoodsLocation();
    
        public static Management_GoodsLocation GoodsLocation
        {
            get
            {
                return _GoodsLocation;
            }
        }
    }

    /// <summary>
    ///  
    /// </summary>
    public partial class Management_GoodsLocation : BQLEntityTableHandle
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
        private BQLEntityParamHandle _locationCode = null;
        /// <summary>
        /// ��λ����
        /// </summary>
        public BQLEntityParamHandle LocationCode
        {
            get
            {
                return _locationCode;
            }
         }
        private BQLEntityParamHandle _boxNum = null;
        /// <summary>
        /// ���
        /// </summary>
        public BQLEntityParamHandle BoxNum
        {
            get
            {
                return _boxNum;
            }
         }
        private BQLEntityParamHandle _goodsShelfId = null;
        /// <summary>
        /// ����ID
        /// </summary>
        public BQLEntityParamHandle GoodsShelfId
        {
            get
            {
                return _goodsShelfId;
            }
         }
        private BQLEntityParamHandle _storageId = null;
        /// <summary>
        /// �����ֿ�
        /// </summary>
        public BQLEntityParamHandle StorageId
        {
            get
            {
                return _storageId;
            }
         }
        private BQLEntityParamHandle _remark = null;
        /// <summary>
        /// ��ע
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
        public Management_GoodsShelf BelongGoodsShelf_GoodsShelfId_Id
        {
            get
            {
               return new Management_GoodsShelf(this,"BelongGoodsShelf_GoodsShelfId_Id");
            }
         }


		/// <summary>
        /// ��ʼ���������Ϣ
        /// </summary>
        /// <param name="parent">������Ϣ</param>
        /// <param name="propertyName">������</param>
        public Management_GoodsLocation(BQLEntityTableHandle parent,string propertyName) 
        :this(typeof(ManagementLib.GoodsLocation),parent,propertyName)
        {
			
        }
        /// <summary>
        /// ��ʼ���������Ϣ
        /// </summary>
        /// <param name="parent">������Ϣ</param>
        /// <param name="propertyName">������</param>
        public Management_GoodsLocation(Type entityType,BQLEntityTableHandle parent,string propertyName) 
        :base(entityType,parent,propertyName)
        {
            _id=CreateProperty("Id");
            _locationCode=CreateProperty("LocationCode");
            _boxNum=CreateProperty("BoxNum");
            _goodsShelfId=CreateProperty("GoodsShelfId");
            _storageId=CreateProperty("StorageId");
            _remark=CreateProperty("Remark");

        }
        
        /// <summary>
        /// ��ʼ���������Ϣ
        /// </summary>
        public Management_GoodsLocation() 
            :this(null,null)
        {
        }
    }
}
