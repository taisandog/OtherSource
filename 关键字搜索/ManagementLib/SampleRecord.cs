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
    public partial class SampleRecord: Buffalo.DB.CommBase.BusinessBases.ThinModelBase
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
        ///ȡ����ID(��User���id��Ӧ)
        ///</summary>
        protected int? _s_userId;

        /// <summary>
        ///ȡ����ID(��User���id��Ӧ)
        ///</summary>
        public int? S_userId
        {
            get
            {
                return _s_userId;
            }
            set
            {
                _s_userId=value;
                OnPropertyUpdated("S_userId");
            }
        }
        ///<summary>
        ///��Ʒ���(��SampleInfo���sampleCode��Ӧ)
        ///</summary>
        protected string _sampleCode;

        /// <summary>
        ///��Ʒ���(��SampleInfo���sampleCode��Ӧ)
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
        ///ȡ����ע
        ///</summary>
        protected string _s_remark;

        /// <summary>
        ///ȡ����ע
        ///</summary>
        public string S_remark
        {
            get
            {
                return _s_remark;
            }
            set
            {
                _s_remark=value;
                OnPropertyUpdated("S_remark");
            }
        }
        ///<summary>
        ///ȡ��ʱ��(ϵͳ�Զ����ɣ�ʹ��ʱ��)
        ///</summary>
        protected DateTime? _employTime;

        /// <summary>
        ///ȡ��ʱ��(ϵͳ�Զ����ɣ�ʹ��ʱ��)
        ///</summary>
        public DateTime? EmployTime
        {
            get
            {
                return _employTime;
            }
            set
            {
                _employTime=value;
                OnPropertyUpdated("EmployTime");
            }
        }
        ///<summary>
        ///��Ʒ������ǹ黹(1Ϊ���,0Ϊ�黹)
        ///</summary>
        protected int? _recordType;

        /// <summary>
        ///��Ʒ������ǹ黹(1Ϊ���,0Ϊ�黹)
        ///</summary>
        public int? RecordType
        {
            get
            {
                return _recordType;
            }
            set
            {
                _recordType=value;
                OnPropertyUpdated("RecordType");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        protected Users _belongUsers_S_userId_Id;

        /// <summary>
        /// 
        /// </summary>
        public Users BelongUsers_S_userId_Id
        {
            get
            {
               if (_belongUsers_S_userId_Id == null)
               {
                   FillParent("BelongUsers_S_userId_Id");
               }
               return _belongUsers_S_userId_Id;
            }
            set
            {
               _belongUsers_S_userId_Id = value;
               OnPropertyUpdated("BelongUsers_S_userId_Id");
            }
        }


        private static ModelContext<SampleRecord> _____baseContext=new ModelContext<SampleRecord>();
        /// <summary>
        /// ��ȡ��ѯ������
        /// </summary>
        /// <returns></returns>
        public static ModelContext<SampleRecord> GetContext() 
        {
            return _____baseContext;
        }

    }
}
