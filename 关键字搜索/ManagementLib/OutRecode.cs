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
    public partial class OutRecode: Buffalo.DB.CommBase.BusinessBases.ThinModelBase
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
        ///��Ʒ����(��Ӧ��Ʒ���������������)
        ///</summary>
        protected string _sampleBarCode;

        /// <summary>
        ///��Ʒ����(��Ӧ��Ʒ���������������)
        ///</summary>
        public string SampleBarCode
        {
            get
            {
                return _sampleBarCode;
            }
            set
            {
                _sampleBarCode=value;
                OnPropertyUpdated("SampleBarCode");
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
        ///����ʱ��
        ///</summary>
        protected DateTime? _outTime;

        /// <summary>
        ///����ʱ��
        ///</summary>
        public DateTime? OutTime
        {
            get
            {
                return _outTime;
            }
            set
            {
                _outTime=value;
                OnPropertyUpdated("OutTime");
            }
        }
        ///<summary>
        ///������(�û����ID)
        ///</summary>
        protected int? _userId;

        /// <summary>
        ///������(�û����ID)
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


        /// <summary>
        /// 
        /// </summary>
        protected Users _belongUsers_UserId_Id;

        /// <summary>
        /// 
        /// </summary>
        public Users BelongUsers_UserId_Id
        {
            get
            {
               if (_belongUsers_UserId_Id == null)
               {
                   FillParent("BelongUsers_UserId_Id");
               }
               return _belongUsers_UserId_Id;
            }
            set
            {
               _belongUsers_UserId_Id = value;
               OnPropertyUpdated("BelongUsers_UserId_Id");
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


        private static ModelContext<OutRecode> _____baseContext=new ModelContext<OutRecode>();
        /// <summary>
        /// ��ȡ��ѯ������
        /// </summary>
        /// <returns></returns>
        public static ModelContext<OutRecode> GetContext() 
        {
            return _____baseContext;
        }

    }
}
