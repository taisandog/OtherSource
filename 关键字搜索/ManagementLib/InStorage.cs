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
    public partial class InStorage: Buffalo.DB.CommBase.BusinessBases.ThinModelBase
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
        ///��Ʒ������
        ///</summary>
        protected string _sampleCode;

        /// <summary>
        ///��Ʒ������
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
        ///�������ߵ�ID(���û���ID��Ӧ)
        ///</summary>
        protected int? _userId;

        /// <summary>
        ///�������ߵ�ID(���û���ID��Ӧ)
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
        ///�Ƿ��ڲֿ�����(0�ڿ�,1���ڿ�,2��Ʒ���)
        ///</summary>
        protected int? _state;

        /// <summary>
        ///�Ƿ��ڲֿ�����(0�ڿ�,1���ڿ�,2��Ʒ���)
        ///</summary>
        public int? State
        {
            get
            {
                return _state;
            }
            set
            {
                _state=value;
                OnPropertyUpdated("State");
            }
        }
        ///<summary>
        ///���ʱ��(ϵͳ�Զ�����)
        ///</summary>
        protected DateTime? _instorageTime;

        /// <summary>
        ///���ʱ��(ϵͳ�Զ�����)
        ///</summary>
        public DateTime? InstorageTime
        {
            get
            {
                return _instorageTime;
            }
            set
            {
                _instorageTime=value;
                OnPropertyUpdated("InstorageTime");
            }
        }




        private static ModelContext<InStorage> _____baseContext=new ModelContext<InStorage>();
        /// <summary>
        /// ��ȡ��ѯ������
        /// </summary>
        /// <returns></returns>
        public static ModelContext<InStorage> GetContext() 
        {
            return _____baseContext;
        }

    }
}
