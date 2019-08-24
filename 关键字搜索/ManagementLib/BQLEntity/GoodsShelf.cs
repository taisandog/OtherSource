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
        private static Management_GoodsShelf _GoodsShelf = new Management_GoodsShelf();
    
        public static Management_GoodsShelf GoodsShelf
        {
            get
            {
                return _GoodsShelf;
            }
        }
    }

    /// <summary>
    ///  
    /// </summary>
    public partial class Management_GoodsShelf : BQLEntityTableHandle
    {
        private BQLEntityParamHandle _id = null;
        /// <summary>
        /// ����ID,�Զ�����
        /// </summary>
        public BQLEntityParamHandle Id
        {
            get
            {
                return _id;
            }
         }
        private BQLEntityParamHandle _goodShelf = null;
        /// <summary>
        /// ���ܺ���
        /// </summary>
        public BQLEntityParamHandle GoodShelf
        {
            get
            {
                return _goodShelf;
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
        /// ��ʼ���������Ϣ
        /// </summary>
        /// <param name="parent">������Ϣ</param>
        /// <param name="propertyName">������</param>
        public Management_GoodsShelf(BQLEntityTableHandle parent,string propertyName) 
        :this(typeof(ManagementLib.GoodsShelf),parent,propertyName)
        {
			
        }
        /// <summary>
        /// ��ʼ���������Ϣ
        /// </summary>
        /// <param name="parent">������Ϣ</param>
        /// <param name="propertyName">������</param>
        public Management_GoodsShelf(Type entityType,BQLEntityTableHandle parent,string propertyName) 
        :base(entityType,parent,propertyName)
        {
            _id=CreateProperty("Id");
            _goodShelf=CreateProperty("GoodShelf");
            _storageId=CreateProperty("StorageId");

        }
        
        /// <summary>
        /// ��ʼ���������Ϣ
        /// </summary>
        public Management_GoodsShelf() 
            :this(null,null)
        {
        }
    }
}
