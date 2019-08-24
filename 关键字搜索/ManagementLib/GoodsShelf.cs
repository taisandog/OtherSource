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
    public partial class GoodsShelf: Buffalo.DB.CommBase.BusinessBases.ThinModelBase
    {
        ///<summary>
        ///����ID,�Զ�����
        ///</summary>
        protected int? _id;

        /// <summary>
        ///����ID,�Զ�����
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
        ///���ܺ���
        ///</summary>
        protected string _goodShelf;

        /// <summary>
        ///���ܺ���
        ///</summary>
        public string GoodShelf
        {
            get
            {
                return _goodShelf;
            }
            set
            {
                _goodShelf=value;
                OnPropertyUpdated("GoodShelf");
            }
        }
        ///<summary>
        ///�����ֿ�
        ///</summary>
        protected int? _storageId;

        /// <summary>
        ///�����ֿ�
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


        /// <summary>
        /// 
        /// </summary>
        protected Storage _belongStorage_StorageId_Id;

        /// <summary>
        /// 
        /// </summary>
        public Storage BelongStorage_StorageId_Id
        {
            get
            {
               if (_belongStorage_StorageId_Id == null)
               {
                   FillParent("BelongStorage_StorageId_Id");
               }
               return _belongStorage_StorageId_Id;
            }
            set
            {
               _belongStorage_StorageId_Id = value;
               OnPropertyUpdated("BelongStorage_StorageId_Id");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected List<SampleGressionRecode> _lstSampleGressionRecodeId_GoodShelfId;

        /// <summary>
        /// 
        /// </summary>
        public List<SampleGressionRecode> LstSampleGressionRecodeId_GoodShelfId
        {
            get
            {
               if (_lstSampleGressionRecodeId_GoodShelfId == null)
               {
                   FillChild("LstSampleGressionRecodeId_GoodShelfId");
               }
               return _lstSampleGressionRecodeId_GoodShelfId;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected List<OutRecode> _lstOutRecodeId_GoodShelfId;

        /// <summary>
        /// 
        /// </summary>
        public List<OutRecode> LstOutRecodeId_GoodShelfId
        {
            get
            {
               if (_lstOutRecodeId_GoodShelfId == null)
               {
                   FillChild("LstOutRecodeId_GoodShelfId");
               }
               return _lstOutRecodeId_GoodShelfId;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected List<GoodsLocation> _lstGoodsLocationId_GoodsShelfId;

        /// <summary>
        /// 
        /// </summary>
        public List<GoodsLocation> LstGoodsLocationId_GoodsShelfId
        {
            get
            {
               if (_lstGoodsLocationId_GoodsShelfId == null)
               {
                   FillChild("LstGoodsLocationId_GoodsShelfId");
               }
               return _lstGoodsLocationId_GoodsShelfId;
            }
        }


        private static ModelContext<GoodsShelf> _____baseContext=new ModelContext<GoodsShelf>();
        /// <summary>
        /// ��ȡ��ѯ������
        /// </summary>
        /// <returns></returns>
        public static ModelContext<GoodsShelf> GetContext() 
        {
            return _____baseContext;
        }

    }
}
