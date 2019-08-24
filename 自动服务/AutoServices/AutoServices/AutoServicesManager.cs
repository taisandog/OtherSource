using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Threading;

namespace AutoServices
{
    public class AutoServicesManager
    {
        /// <summary>
        /// �Զ����еķ���
        /// </summary>
        /// <param name="tick">ִ�м��(����)</param>
        public AutoServicesManager(int tick) 
        {
            _tick = tick;
            
            
        }

        List<ServicesBase> _lstServices = new List<ServicesBase>();
        Thread _thd;
        public AutoServicesManager() :this(60*1000)
        {
           
        }
        /// <summary>
        /// ��Ҫִ�еķ���
        /// </summary>
        public List<ServicesBase> Services
        {
            get { return _lstServices; }
        }

        private int _tick=1000;
        /// <summary>
        /// ִ�м��
        /// </summary>
        public int Tick
        {
            get { return _tick; }
            set { _tick = value; }
        }

        /// <summary>
        /// ��ʼ������
        /// </summary>
        public void Init() 
        {
            CollectServices();
        }


        /// <summary>
        /// �����߳�
        /// </summary>
        private void ThreadServices() 
        {
            while (_isRunning)
            {
                foreach (ServicesBase ser in _lstServices)
                {
                    try
                    {
                        ser.RunService();
                        
                    }
                    catch (Exception ex)
                    {
                        //��¼��־
                    }
                }
                Thread.Sleep(_tick);
            }
        }
        protected bool _isRunning = false;
        /// <summary>
        /// �Ƿ�����ִ��
        /// </summary>
        public virtual bool IsRunning
        {
            get
            {
                return _isRunning;
            }
        }
        /// <summary>
        /// �����Զ�����
        /// </summary>
        public void Start() 
        {
            foreach (ServicesBase ser in _lstServices) 
            {
                try
                {
                    ser.Start();
                    _thd.Start();
                }
                catch (Exception ex) 
                {
                    //��¼��־
                }
            }
            _isRunning = true;

            _thd = new Thread(new ThreadStart(ThreadServices));
            _thd.Start();
        }

        /// <summary>
        /// ֹͣ�Զ�����
        /// </summary>
        public void Stop()
        {
            if (_thd == null) 
            {
                return;
            }
            _isRunning = false;
            _thd.Abort();
            Thread.Sleep(100);
            foreach (ServicesBase ser in _lstServices)
            {
                try
                {
                    ser.Stop();
                }
                catch (Exception ex)
                {
                    //��¼��־
                }
            }
        }

        /// <summary>
        /// �ռ�����
        /// </summary>
        private void CollectServices() 
        {
            Assembly[] allAss = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly ass in allAss) 
            {
                Type objType = ass.GetType(ass.GetName().Name+".AutoServicesInfo");
                if (objType == null) 
                {
                    continue;
                }
                CollTypeServices(objType);
            }
        }

        /// <summary>
        /// �ռ����͵ķ���
        /// </summary>
        /// <param name="objType"></param>
        private void CollTypeServices(Type objType) 
        {
            object obj=Activator.CreateInstance(objType);
            PropertyInfo[] pInfos = objType.GetProperties();
            foreach (PropertyInfo pinfo in pInfos) 
            {
                if (pinfo.PropertyType.IsSubclassOf(typeof(ServicesBase)) && pinfo.CanRead) 
                {

                    ServicesBase ser = pinfo.GetValue(obj, new object[] { }) as ServicesBase;
                    
                    if (ser != null)
                    {
                        _lstServices.Add(ser);
                    }
                }
            }
        }

        ~AutoServicesManager() 
        {
            Stop();
        }
    }
}
