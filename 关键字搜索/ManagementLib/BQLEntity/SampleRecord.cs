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
        private static Management_SampleRecord _SampleRecord = new Management_SampleRecord();
    
        public static Management_SampleRecord SampleRecord
        {
            get
            {
                return _SampleRecord;
            }
        }
    }

    /// <summary>
    ///  
    /// </summary>
    public partial class Management_SampleRecord : BQLEntityTableHandle
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
        private BQLEntityParamHandle _s_userId = null;
        /// <summary>
        /// ȡ����ID(��User���id��Ӧ)
        /// </summary>
        public BQLEntityParamHandle S_userId
        {
            get
            {
                return _s_userId;
            }
         }
        private BQLEntityParamHandle _sampleCode = null;
        /// <summary>
        /// ��Ʒ���(��SampleInfo���sampleCode��Ӧ)
        /// </summary>
        public BQLEntityParamHandle SampleCode
        {
            get
            {
                return _sampleCode;
            }
         }
        private BQLEntityParamHandle _s_remark = null;
        /// <summary>
        /// ȡ����ע
        /// </summary>
        public BQLEntityParamHandle S_remark
        {
            get
            {
                return _s_remark;
            }
         }
        private BQLEntityParamHandle _employTime = null;
        /// <summary>
        /// ȡ��ʱ��(ϵͳ�Զ����ɣ�ʹ��ʱ��)
        /// </summary>
        public BQLEntityParamHandle EmployTime
        {
            get
            {
                return _employTime;
            }
         }
        private BQLEntityParamHandle _recordType = null;
        /// <summary>
        /// ��Ʒ������ǹ黹(1Ϊ���,0Ϊ�黹)
        /// </summary>
        public BQLEntityParamHandle RecordType
        {
            get
            {
                return _recordType;
            }
         }

        /// <summary>
        /// 
        /// </summary>
        public Management_Users BelongUsers_S_userId_Id
        {
            get
            {
               return new Management_Users(this,"BelongUsers_S_userId_Id");
            }
         }


		/// <summary>
        /// ��ʼ���������Ϣ
        /// </summary>
        /// <param name="parent">������Ϣ</param>
        /// <param name="propertyName">������</param>
        public Management_SampleRecord(BQLEntityTableHandle parent,string propertyName) 
        :this(typeof(ManagementLib.SampleRecord),parent,propertyName)
        {
			
        }
        /// <summary>
        /// ��ʼ���������Ϣ
        /// </summary>
        /// <param name="parent">������Ϣ</param>
        /// <param name="propertyName">������</param>
        public Management_SampleRecord(Type entityType,BQLEntityTableHandle parent,string propertyName) 
        :base(entityType,parent,propertyName)
        {
            _id=CreateProperty("Id");
            _s_userId=CreateProperty("S_userId");
            _sampleCode=CreateProperty("SampleCode");
            _s_remark=CreateProperty("S_remark");
            _employTime=CreateProperty("EmployTime");
            _recordType=CreateProperty("RecordType");

        }
        
        /// <summary>
        /// ��ʼ���������Ϣ
        /// </summary>
        public Management_SampleRecord() 
            :this(null,null)
        {
        }
    }
}
