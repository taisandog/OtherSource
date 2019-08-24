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
        private static Management_View_GoodsShelf_Storage _View_GoodsShelf_Storage = new Management_View_GoodsShelf_Storage();
    
        public static Management_View_GoodsShelf_Storage View_GoodsShelf_Storage
        {
            get
            {
                return _View_GoodsShelf_Storage;
            }
        }
    }

    /// <summary>
    ///  
    /// </summary>
    public partial class Management_View_GoodsShelf_Storage : BQLEntityTableHandle
    {
        private BQLEntityParamHandle _storageName = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle StorageName
        {
            get
            {
                return _storageName;
            }
         }
        private BQLEntityParamHandle _goodShelf = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle GoodShelf
        {
            get
            {
                return _goodShelf;
            }
         }
        private BQLEntityParamHandle _id = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle Id
        {
            get
            {
                return _id;
            }
         }



		/// <summary>
        /// ��ʼ���������Ϣ
        /// </summary>
        /// <param name="parent">������Ϣ</param>
        /// <param name="propertyName">������</param>
        public Management_View_GoodsShelf_Storage(BQLEntityTableHandle parent,string propertyName) 
        :this(typeof(ManagementLib.View_GoodsShelf_Storage),parent,propertyName)
        {
			
        }
        /// <summary>
        /// ��ʼ���������Ϣ
        /// </summary>
        /// <param name="parent">������Ϣ</param>
        /// <param name="propertyName">������</param>
        public Management_View_GoodsShelf_Storage(Type entityType,BQLEntityTableHandle parent,string propertyName) 
        :base(entityType,parent,propertyName)
        {
            _storageName=CreateProperty("StorageName");
            _goodShelf=CreateProperty("GoodShelf");
            _id=CreateProperty("Id");

        }
        
        /// <summary>
        /// ��ʼ���������Ϣ
        /// </summary>
        public Management_View_GoodsShelf_Storage() 
            :this(null,null)
        {
        }
    }
}
