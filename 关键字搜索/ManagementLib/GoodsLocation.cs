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
    public partial class GoodsLocation: Buffalo.DB.CommBase.BusinessBases.ThinModelBase
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
        ///��λ����
        ///</summary>
        protected string _locationCode;

        /// <summary>
        ///��λ����
        ///</summary>
        public string LocationCode
        {
            get
            {
                return _locationCode;
            }
            set
            {
                _locationCode=value;
                OnPropertyUpdated("LocationCode");
            }
        }
        ///<summary>
        ///���
        ///</summary>
        protected string _boxNum;

        /// <summary>
        ///���
        ///</summary>
        public string BoxNum
        {
            get
            {
                return _boxNum;
            }
            set
            {
                _boxNum=value;
                OnPropertyUpdated("BoxNum");
            }
        }
        ///<summary>
        ///����ID
        ///</summary>
        protected int? _goodsShelfId;

        /// <summary>
        ///����ID
        ///</summary>
        public int? GoodsShelfId
        {
            get
            {
                return _goodsShelfId;
            }
            set
            {
                _goodsShelfId=value;
                OnPropertyUpdated("GoodsShelfId");
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
        ///<summary>
        ///��ע
        ///</summary>
        protected string _remark;

        /// <summary>
        ///��ע
        ///</summary>
        public string Remark
        {
            get
            {
                return _remark;
            }
            set
            {
                _remark=value;
                OnPropertyUpdated("Remark");
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
        protected GoodsShelf _belongGoodsShelf_GoodsShelfId_Id;

        /// <summary>
        /// 
        /// </summary>
        public GoodsShelf BelongGoodsShelf_GoodsShelfId_Id
        {
            get
            {
               if (_belongGoodsShelf_GoodsShelfId_Id == null)
               {
                   FillParent("BelongGoodsShelf_GoodsShelfId_Id");
               }
               return _belongGoodsShelf_GoodsShelfId_Id;
            }
            set
            {
               _belongGoodsShelf_GoodsShelfId_Id = value;
               OnPropertyUpdated("BelongGoodsShelf_GoodsShelfId_Id");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected List<SampleGression> _lstSampleGressionId_GoodLocationId;

        /// <summary>
        /// 
        /// </summary>
        public List<SampleGression> LstSampleGressionId_GoodLocationId
        {
            get
            {
               if (_lstSampleGressionId_GoodLocationId == null)
               {
                   FillChild("LstSampleGressionId_GoodLocationId");
               }
               return _lstSampleGressionId_GoodLocationId;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected List<OutRecode> _lstOutRecodeId_GoodLocationId;

        /// <summary>
        /// 
        /// </summary>
        public List<OutRecode> LstOutRecodeId_GoodLocationId
        {
            get
            {
               if (_lstOutRecodeId_GoodLocationId == null)
               {
                   FillChild("LstOutRecodeId_GoodLocationId");
               }
               return _lstOutRecodeId_GoodLocationId;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected List<SampleGressionRecode> _lstSampleGressionRecodeId_GoodLocationId;

        /// <summary>
        /// 
        /// </summary>
        public List<SampleGressionRecode> LstSampleGressionRecodeId_GoodLocationId
        {
            get
            {
               if (_lstSampleGressionRecodeId_GoodLocationId == null)
               {
                   FillChild("LstSampleGressionRecodeId_GoodLocationId");
               }
               return _lstSampleGressionRecodeId_GoodLocationId;
            }
        }


        private static ModelContext<GoodsLocation> _____baseContext=new ModelContext<GoodsLocation>();
        /// <summary>
        /// ��ȡ��ѯ������
        /// </summary>
        /// <returns></returns>
        public static ModelContext<GoodsLocation> GetContext() 
        {
            return _____baseContext;
        }

    }
}
