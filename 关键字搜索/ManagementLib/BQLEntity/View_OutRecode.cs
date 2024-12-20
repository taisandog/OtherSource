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
        private static Management_View_OutRecode _View_OutRecode = new Management_View_OutRecode();
    
        public static Management_View_OutRecode View_OutRecode
        {
            get
            {
                return _View_OutRecode;
            }
        }
    }

    /// <summary>
    ///  
    /// </summary>
    public partial class Management_View_OutRecode : BQLEntityTableHandle
    {
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
        private BQLEntityParamHandle _sampleBarCode = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle SampleBarCode
        {
            get
            {
                return _sampleBarCode;
            }
         }
        private BQLEntityParamHandle _storageId = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle StorageId
        {
            get
            {
                return _storageId;
            }
         }
        private BQLEntityParamHandle _goodShelfId = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle GoodShelfId
        {
            get
            {
                return _goodShelfId;
            }
         }
        private BQLEntityParamHandle _goodLocationId = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle GoodLocationId
        {
            get
            {
                return _goodLocationId;
            }
         }
        private BQLEntityParamHandle _outTime = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle OutTime
        {
            get
            {
                return _outTime;
            }
         }
        private BQLEntityParamHandle _userId = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle UserId
        {
            get
            {
                return _userId;
            }
         }
        private BQLEntityParamHandle _projectName = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle ProjectName
        {
            get
            {
                return _projectName;
            }
         }
        private BQLEntityParamHandle _projectId = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle ProjectId
        {
            get
            {
                return _projectId;
            }
         }
        private BQLEntityParamHandle _crudeSample = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle CrudeSample
        {
            get
            {
                return _crudeSample;
            }
         }
        private BQLEntityParamHandle _yiYouSample = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle YiYouSample
        {
            get
            {
                return _yiYouSample;
            }
         }
        private BQLEntityParamHandle _replaceNumber = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle ReplaceNumber
        {
            get
            {
                return _replaceNumber;
            }
         }
        private BQLEntityParamHandle _sampleNumber = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle SampleNumber
        {
            get
            {
                return _sampleNumber;
            }
         }
        private BQLEntityParamHandle _analysis = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle Analysis
        {
            get
            {
                return _analysis;
            }
         }
        private BQLEntityParamHandle _samplingTerrace = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle SamplingTerrace
        {
            get
            {
                return _samplingTerrace;
            }
         }
        private BQLEntityParamHandle _samplingUser = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle SamplingUser
        {
            get
            {
                return _samplingUser;
            }
         }
        private BQLEntityParamHandle _duplicateSample = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle DuplicateSample
        {
            get
            {
                return _duplicateSample;
            }
         }
        private BQLEntityParamHandle _samplingTime = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle SamplingTime
        {
            get
            {
                return _samplingTime;
            }
         }
        private BQLEntityParamHandle _sampleName = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle SampleName
        {
            get
            {
                return _sampleName;
            }
         }
        private BQLEntityParamHandle _sampleLocation = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle SampleLocation
        {
            get
            {
                return _sampleLocation;
            }
         }
        private BQLEntityParamHandle _sampledescribe = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle Sampledescribe
        {
            get
            {
                return _sampledescribe;
            }
         }
        private BQLEntityParamHandle _depth = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle Depth
        {
            get
            {
                return _depth;
            }
         }
        private BQLEntityParamHandle _dailyoutput = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle Dailyoutput
        {
            get
            {
                return _dailyoutput;
            }
         }
        private BQLEntityParamHandle _lithology = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle Lithology
        {
            get
            {
                return _lithology;
            }
         }
        private BQLEntityParamHandle _gradation_all = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle Gradation_all
        {
            get
            {
                return _gradation_all;
            }
         }
        private BQLEntityParamHandle _gradation_group = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle Gradation_group
        {
            get
            {
                return _gradation_group;
            }
         }
        private BQLEntityParamHandle _gradation_part = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle Gradation_part
        {
            get
            {
                return _gradation_part;
            }
         }
        private BQLEntityParamHandle _containingWater = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle ContainingWater
        {
            get
            {
                return _containingWater;
            }
         }
        private BQLEntityParamHandle _density = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle Density
        {
            get
            {
                return _density;
            }
         }
        private BQLEntityParamHandle _viscosity = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle Viscosity
        {
            get
            {
                return _viscosity;
            }
         }
        private BQLEntityParamHandle _sulfur = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle Sulfur
        {
            get
            {
                return _sulfur;
            }
         }
        private BQLEntityParamHandle _ripeDepe = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle RipeDepe
        {
            get
            {
                return _ripeDepe;
            }
         }
        private BQLEntityParamHandle _addDose = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle AddDose
        {
            get
            {
                return _addDose;
            }
         }
        private BQLEntityParamHandle _pipeInfo = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle PipeInfo
        {
            get
            {
                return _pipeInfo;
            }
         }
        private BQLEntityParamHandle _transmitTime = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle TransmitTime
        {
            get
            {
                return _transmitTime;
            }
         }
        private BQLEntityParamHandle _sampleCode = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle SampleCode
        {
            get
            {
                return _sampleCode;
            }
         }
        private BQLEntityParamHandle _printState = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle PrintState
        {
            get
            {
                return _printState;
            }
         }
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
        private BQLEntityParamHandle _userName = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle UserName
        {
            get
            {
                return _userName;
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
        private BQLEntityParamHandle _locationCode = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle LocationCode
        {
            get
            {
                return _locationCode;
            }
         }
        private BQLEntityParamHandle _boreholeTime = null;
        /// <summary>
        /// 
        /// </summary>
        public BQLEntityParamHandle BoreholeTime
        {
            get
            {
                return _boreholeTime;
            }
         }



		/// <summary>
        /// 初始化本类的信息
        /// </summary>
        /// <param name="parent">父表信息</param>
        /// <param name="propertyName">属性名</param>
        public Management_View_OutRecode(BQLEntityTableHandle parent,string propertyName) 
        :this(typeof(ManagementLib.View_OutRecode),parent,propertyName)
        {
			
        }
        /// <summary>
        /// 初始化本类的信息
        /// </summary>
        /// <param name="parent">父表信息</param>
        /// <param name="propertyName">属性名</param>
        public Management_View_OutRecode(Type entityType,BQLEntityTableHandle parent,string propertyName) 
        :base(entityType,parent,propertyName)
        {
            _id=CreateProperty("Id");
            _sampleBarCode=CreateProperty("SampleBarCode");
            _storageId=CreateProperty("StorageId");
            _goodShelfId=CreateProperty("GoodShelfId");
            _goodLocationId=CreateProperty("GoodLocationId");
            _outTime=CreateProperty("OutTime");
            _userId=CreateProperty("UserId");
            _projectName=CreateProperty("ProjectName");
            _projectId=CreateProperty("ProjectId");
            _crudeSample=CreateProperty("CrudeSample");
            _yiYouSample=CreateProperty("YiYouSample");
            _replaceNumber=CreateProperty("ReplaceNumber");
            _sampleNumber=CreateProperty("SampleNumber");
            _analysis=CreateProperty("Analysis");
            _samplingTerrace=CreateProperty("SamplingTerrace");
            _samplingUser=CreateProperty("SamplingUser");
            _duplicateSample=CreateProperty("DuplicateSample");
            _samplingTime=CreateProperty("SamplingTime");
            _sampleName=CreateProperty("SampleName");
            _sampleLocation=CreateProperty("SampleLocation");
            _sampledescribe=CreateProperty("Sampledescribe");
            _depth=CreateProperty("Depth");
            _dailyoutput=CreateProperty("Dailyoutput");
            _lithology=CreateProperty("Lithology");
            _gradation_all=CreateProperty("Gradation_all");
            _gradation_group=CreateProperty("Gradation_group");
            _gradation_part=CreateProperty("Gradation_part");
            _containingWater=CreateProperty("ContainingWater");
            _density=CreateProperty("Density");
            _viscosity=CreateProperty("Viscosity");
            _sulfur=CreateProperty("Sulfur");
            _ripeDepe=CreateProperty("RipeDepe");
            _addDose=CreateProperty("AddDose");
            _pipeInfo=CreateProperty("PipeInfo");
            _transmitTime=CreateProperty("TransmitTime");
            _sampleCode=CreateProperty("SampleCode");
            _printState=CreateProperty("PrintState");
            _storageName=CreateProperty("StorageName");
            _userName=CreateProperty("UserName");
            _goodShelf=CreateProperty("GoodShelf");
            _locationCode=CreateProperty("LocationCode");
            _boreholeTime=CreateProperty("BoreholeTime");

        }
        
        /// <summary>
        /// 初始化本类的信息
        /// </summary>
        public Management_View_OutRecode() 
            :this(null,null)
        {
        }
    }
}
