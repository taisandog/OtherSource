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
    public partial class BarCodeGauge: Buffalo.DB.CommBase.BusinessBases.ThinModelBase
    {
        ///<summary>
        ///
        ///</summary>
        protected int? _id;

        /// <summary>
        ///
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
        ///�û��Զ���������ͷ
        ///</summary>
        protected string _customCode;

        /// <summary>
        ///�û��Զ���������ͷ
        ///</summary>
        public string CustomCode
        {
            get
            {
                return _customCode;
            }
            set
            {
                _customCode=value;
                OnPropertyUpdated("CustomCode");
            }
        }
        ///<summary>
        ///�Ƿ���Ч
        ///</summary>
        protected bool? _state;

        /// <summary>
        ///�Ƿ���Ч
        ///</summary>
        public bool? State
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
        ///�����ˮ��
        ///</summary>
        protected int? _maxSerialnumber;

        /// <summary>
        ///�����ˮ��
        ///</summary>
        public int? MaxSerialnumber
        {
            get
            {
                return _maxSerialnumber;
            }
            set
            {
                _maxSerialnumber=value;
                OnPropertyUpdated("MaxSerialnumber");
            }
        }




        private static ModelContext<BarCodeGauge> _____baseContext=new ModelContext<BarCodeGauge>();
        /// <summary>
        /// ��ȡ��ѯ������
        /// </summary>
        /// <returns></returns>
        public static ModelContext<BarCodeGauge> GetContext() 
        {
            return _____baseContext;
        }

    }
}
