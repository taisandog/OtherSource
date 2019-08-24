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
    public partial class SampleGressionRecode: Buffalo.DB.CommBase.BusinessBases.ThinModelBase
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
        ///��Ʒ����
        ///</summary>
        protected string _sampleCode;

        /// <summary>
        ///��Ʒ����
        ///</summary>
        public string SampleCode
        {
            get
            {
                return _sampleCode;
            }
            set
            {
                _sampleCode=value;
                OnPropertyUpdated("SampleCode");
            }
        }
        ///<summary>
        ///�ƶ��ߵ�ID
        ///</summary>
        protected int? _userId;

        /// <summary>
        ///�ƶ��ߵ�ID
        ///</summary>
        public int? UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId=value;
                OnPropertyUpdated("UserId");
            }
        }
        ///<summary>
        ///�ֿ�ID
        ///</summary>
        protected int? _storageId;

        /// <summary>
        ///�ֿ�ID
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
        ///����ID
        ///</summary>
        protected int? _goodShelfId;

        /// <summary>
        ///����ID
        ///</summary>
        public int? GoodShelfId
        {
            get
            {
                return _goodShelfId;
            }
            set
            {
                _goodShelfId=value;
                OnPropertyUpdated("GoodShelfId");
            }
        }
        ///<summary>
        ///��λID
        ///</summary>
        protected int? _goodLocationId;

        /// <summary>
        ///��λID
        ///</summary>
        public int? GoodLocationId
        {
            get
            {
                return _goodLocationId;
            }
            set
            {
                _goodLocationId=value;
                OnPropertyUpdated("GoodLocationId");
            }
        }
        ///<summary>
        ///�ƶ���ʱ��
        ///</summary>
        protected DateTime? _recodeTime;

        /// <summary>
        ///�ƶ���ʱ��
        ///</summary>
        public DateTime? RecodeTime
        {
            get
            {
                return _recodeTime;
            }
            set
            {
                _recodeTime=value;
                OnPropertyUpdated("RecodeTime");
            }
        }
        ///<summary>
        ///��ע˵��
        ///</summary>
        protected string _remark;

        /// <summary>
        ///��ע˵��
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
        protected GoodsShelf _belongGoodsShelf_GoodShelfId_Id;

        /// <summary>
        /// 
        /// </summary>
        public GoodsShelf BelongGoodsShelf_GoodShelfId_Id
        {
            get
            {
               if (_belongGoodsShelf_GoodShelfId_Id == null)
               {
                   FillParent("BelongGoodsShelf_GoodShelfId_Id");
               }
               return _belongGoodsShelf_GoodShelfId_Id;
            }
            set
            {
               _belongGoodsShelf_GoodShelfId_Id = value;
               OnPropertyUpdated("BelongGoodsShelf_GoodShelfId_Id");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected GoodsLocation _belongGoodsLocation_GoodLocationId_Id;

        /// <summary>
        /// 
        /// </summary>
        public GoodsLocation BelongGoodsLocation_GoodLocationId_Id
        {
            get
            {
               if (_belongGoodsLocation_GoodLocationId_Id == null)
               {
                   FillParent("BelongGoodsLocation_GoodLocationId_Id");
               }
               return _belongGoodsLocation_GoodLocationId_Id;
            }
            set
            {
               _belongGoodsLocation_GoodLocationId_Id = value;
               OnPropertyUpdated("BelongGoodsLocation_GoodLocationId_Id");
            }
        }


        private static ModelContext<SampleGressionRecode> _____baseContext=new ModelContext<SampleGressionRecode>();
        /// <summary>
        /// ��ȡ��ѯ������
        /// </summary>
        /// <returns></returns>
        public static ModelContext<SampleGressionRecode> GetContext() 
        {
            return _____baseContext;
        }

    }
}
