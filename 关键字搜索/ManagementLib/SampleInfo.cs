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
    public partial class SampleInfo: Buffalo.DB.CommBase.BusinessBases.ThinModelBase
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
        ///��Ŀ����
        ///</summary>
        protected string _projectName;

        /// <summary>
        ///��Ŀ����
        ///</summary>
        public string ProjectName
        {
            get
            {
                return _projectName;
            }
            set
            {
                _projectName=value;
                OnPropertyUpdated("ProjectName");
            }
        }
        ///<summary>
        ///��Ŀ���
        ///</summary>
        protected string _projectId;

        /// <summary>
        ///��Ŀ���
        ///</summary>
        public string ProjectId
        {
            get
            {
                return _projectId;
            }
            set
            {
                _projectId=value;
                OnPropertyUpdated("ProjectId");
            }
        }
        ///<summary>
        ///ԭ����Ʒ
        ///</summary>
        protected string _crudeSample;

        /// <summary>
        ///ԭ����Ʒ
        ///</summary>
        public string CrudeSample
        {
            get
            {
                return _crudeSample;
            }
            set
            {
                _crudeSample=value;
                OnPropertyUpdated("CrudeSample");
            }
        }
        ///<summary>
        ///������Ʒ
        ///</summary>
        protected string _yiYouSample;

        /// <summary>
        ///������Ʒ
        ///</summary>
        public string YiYouSample
        {
            get
            {
                return _yiYouSample;
            }
            set
            {
                _yiYouSample=value;
                OnPropertyUpdated("YiYouSample");
            }
        }
        ///<summary>
        ///������
        ///</summary>
        protected string _replaceNumber;

        /// <summary>
        ///������
        ///</summary>
        public string ReplaceNumber
        {
            get
            {
                return _replaceNumber;
            }
            set
            {
                _replaceNumber=value;
                OnPropertyUpdated("ReplaceNumber");
            }
        }
        ///<summary>
        ///��Ʒ���
        ///</summary>
        protected string _sampleNumber;

        /// <summary>
        ///��Ʒ���
        ///</summary>
        public string SampleNumber
        {
            get
            {
                return _sampleNumber;
            }
            set
            {
                _sampleNumber=value;
                OnPropertyUpdated("SampleNumber");
            }
        }
        ///<summary>
        ///�������
        ///</summary>
        protected string _analysis;

        /// <summary>
        ///�������
        ///</summary>
        public string Analysis
        {
            get
            {
                return _analysis;
            }
            set
            {
                _analysis=value;
                OnPropertyUpdated("Analysis");
            }
        }
        ///<summary>
        ///����ƽ̨
        ///</summary>
        protected string _samplingTerrace;

        /// <summary>
        ///����ƽ̨
        ///</summary>
        public string SamplingTerrace
        {
            get
            {
                return _samplingTerrace;
            }
            set
            {
                _samplingTerrace=value;
                OnPropertyUpdated("SamplingTerrace");
            }
        }
        ///<summary>
        ///������Ա
        ///</summary>
        protected string _samplingUser;

        /// <summary>
        ///������Ա
        ///</summary>
        public string SamplingUser
        {
            get
            {
                return _samplingUser;
            }
            set
            {
                _samplingUser=value;
                OnPropertyUpdated("SamplingUser");
            }
        }
        ///<summary>
        ///ƽ����
        ///</summary>
        protected string _duplicateSample;

        /// <summary>
        ///ƽ����
        ///</summary>
        public string DuplicateSample
        {
            get
            {
                return _duplicateSample;
            }
            set
            {
                _duplicateSample=value;
                OnPropertyUpdated("DuplicateSample");
            }
        }
        ///<summary>
        ///����ʱ��
        ///</summary>
        protected DateTime? _samplingTime;

        /// <summary>
        ///����ʱ��
        ///</summary>
        public DateTime? SamplingTime
        {
            get
            {
                return _samplingTime;
            }
            set
            {
                _samplingTime=value;
                OnPropertyUpdated("SamplingTime");
            }
        }
        ///<summary>
        ///��Ʒ����
        ///</summary>
        protected string _sampleName;

        /// <summary>
        ///��Ʒ����
        ///</summary>
        public string SampleName
        {
            get
            {
                return _sampleName;
            }
            set
            {
                _sampleName=value;
                OnPropertyUpdated("SampleName");
            }
        }
        ///<summary>
        ///����λ��
        ///</summary>
        protected string _sampleLocation;

        /// <summary>
        ///����λ��
        ///</summary>
        public string SampleLocation
        {
            get
            {
                return _sampleLocation;
            }
            set
            {
                _sampleLocation=value;
                OnPropertyUpdated("SampleLocation");
            }
        }
        ///<summary>
        ///��Ʒ����
        ///</summary>
        protected string _sampledescribe;

        /// <summary>
        ///��Ʒ����
        ///</summary>
        public string Sampledescribe
        {
            get
            {
                return _sampledescribe;
            }
            set
            {
                _sampledescribe=value;
                OnPropertyUpdated("Sampledescribe");
            }
        }
        ///<summary>
        ///�꾮ʱ��
        ///</summary>
        protected DateTime? _boreholeTime;

        /// <summary>
        ///�꾮ʱ��
        ///</summary>
        public DateTime? BoreholeTime
        {
            get
            {
                return _boreholeTime;
            }
            set
            {
                _boreholeTime=value;
                OnPropertyUpdated("BoreholeTime");
            }
        }
        ///<summary>
        ///�������
        ///</summary>
        protected string _depth;

        /// <summary>
        ///�������
        ///</summary>
        public string Depth
        {
            get
            {
                return _depth;
            }
            set
            {
                _depth=value;
                OnPropertyUpdated("Depth");
            }
        }
        ///<summary>
        ///�ղ�����Ͱ��
        ///</summary>
        protected string _dailyoutput;

        /// <summary>
        ///�ղ�����Ͱ��
        ///</summary>
        public string Dailyoutput
        {
            get
            {
                return _dailyoutput;
            }
            set
            {
                _dailyoutput=value;
                OnPropertyUpdated("Dailyoutput");
            }
        }
        ///<summary>
        ///����
        ///</summary>
        protected string _lithology;

        /// <summary>
        ///����
        ///</summary>
        public string Lithology
        {
            get
            {
                return _lithology;
            }
            set
            {
                _lithology=value;
                OnPropertyUpdated("Lithology");
            }
        }
        ///<summary>
        ///���ʲ��-ͳ
        ///</summary>
        protected string _gradation_all;

        /// <summary>
        ///���ʲ��-ͳ
        ///</summary>
        public string Gradation_all
        {
            get
            {
                return _gradation_all;
            }
            set
            {
                _gradation_all=value;
                OnPropertyUpdated("Gradation_all");
            }
        }
        ///<summary>
        ///���ʲ��-��
        ///</summary>
        protected string _gradation_group;

        /// <summary>
        ///���ʲ��-��
        ///</summary>
        public string Gradation_group
        {
            get
            {
                return _gradation_group;
            }
            set
            {
                _gradation_group=value;
                OnPropertyUpdated("Gradation_group");
            }
        }
        ///<summary>
        ///���ʲ��-��
        ///</summary>
        protected string _gradation_part;

        /// <summary>
        ///���ʲ��-��
        ///</summary>
        public string Gradation_part
        {
            get
            {
                return _gradation_part;
            }
            set
            {
                _gradation_part=value;
                OnPropertyUpdated("Gradation_part");
            }
        }
        ///<summary>
        ///��ˮ�ʣ�����
        ///</summary>
        protected string _containingWater;

        /// <summary>
        ///��ˮ�ʣ�����
        ///</summary>
        public string ContainingWater
        {
            get
            {
                return _containingWater;
            }
            set
            {
                _containingWater=value;
                OnPropertyUpdated("ContainingWater");
            }
        }
        ///<summary>
        ///�ܶȣ�g/cm3��
        ///</summary>
        protected string _density;

        /// <summary>
        ///�ܶȣ�g/cm3��
        ///</summary>
        public string Density
        {
            get
            {
                return _density;
            }
            set
            {
                _density=value;
                OnPropertyUpdated("Density");
            }
        }
        ///<summary>
        ///ճ��
        ///</summary>
        protected string _viscosity;

        /// <summary>
        ///ճ��
        ///</summary>
        public string Viscosity
        {
            get
            {
                return _viscosity;
            }
            set
            {
                _viscosity=value;
                OnPropertyUpdated("Viscosity");
            }
        }
        ///<summary>
        ///��������%��
        ///</summary>
        protected string _sulfur;

        /// <summary>
        ///��������%��
        ///</summary>
        public string Sulfur
        {
            get
            {
                return _sulfur;
            }
            set
            {
                _sulfur=value;
                OnPropertyUpdated("Sulfur");
            }
        }
        ///<summary>
        ///����ȣ�Ro�ȣ�
        ///</summary>
        protected string _ripeDepe;

        /// <summary>
        ///����ȣ�Ro�ȣ�
        ///</summary>
        public string RipeDepe
        {
            get
            {
                return _ripeDepe;
            }
            set
            {
                _ripeDepe=value;
                OnPropertyUpdated("RipeDepe");
            }
        }
        ///<summary>
        ///��Ӽ�
        ///</summary>
        protected string _addDose;

        /// <summary>
        ///��Ӽ�
        ///</summary>
        public string AddDose
        {
            get
            {
                return _addDose;
            }
            set
            {
                _addDose=value;
                OnPropertyUpdated("AddDose");
            }
        }
        ///<summary>
        ///�ܻ���Ϣ
        ///</summary>
        protected string _pipeInfo;

        /// <summary>
        ///�ܻ���Ϣ
        ///</summary>
        public string PipeInfo
        {
            get
            {
                return _pipeInfo;
            }
            set
            {
                _pipeInfo=value;
                OnPropertyUpdated("PipeInfo");
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
        ///�Ƿ��Ѵ�ӡ
        ///</summary>
        protected bool? _printState;

        /// <summary>
        ///�Ƿ��Ѵ�ӡ
        ///</summary>
        public bool? PrintState
        {
            get
            {
                return _printState;
            }
            set
            {
                _printState=value;
                OnPropertyUpdated("PrintState");
            }
        }
        ///<summary>
        ///����ʱ��
        ///</summary>
        protected DateTime? _transmitTime;

        /// <summary>
        ///����ʱ��
        ///</summary>
        public DateTime? TransmitTime
        {
            get
            {
                return _transmitTime;
            }
            set
            {
                _transmitTime=value;
                OnPropertyUpdated("TransmitTime");
            }
        }
        ///<summary>
        ///�Ƿ�����������(0Ϊ������������1Ϊ����������)
        ///</summary>
        protected bool? _blInStorage;

        /// <summary>
        ///�Ƿ�����������(0Ϊ������������1Ϊ����������)
        ///</summary>
        public bool? BlInStorage
        {
            get
            {
                return _blInStorage;
            }
            set
            {
                _blInStorage=value;
                OnPropertyUpdated("BlInStorage");
            }
        }




        private static ModelContext<SampleInfo> _____baseContext=new ModelContext<SampleInfo>();
        /// <summary>
        /// ��ȡ��ѯ������
        /// </summary>
        /// <returns></returns>
        public static ModelContext<SampleInfo> GetContext() 
        {
            return _____baseContext;
        }

    }
}
