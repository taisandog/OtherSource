using System;
using System.Collections.Generic;
using System.Text;

namespace AutoServices
{
    public abstract class ServicesBase
    {
        /// <summary>
        /// ��������
        /// </summary>
        public virtual string ServiceName
        {
            get { return ""; } 
        }
        /// <summary>
        /// �״ο�������
        /// </summary>
        /// <returns></returns>
        public virtual bool Start() 
        {
            return true;
        }
        /// <summary>
        /// ǿ�ƽ���
        /// </summary>
        /// <returns></returns>
        public virtual bool Stop() 
        {
            return true;
        }
        /// <summary>
        /// ÿ��һ��ʱ��ִ��
        /// </summary>
        /// <returns></returns>
        public virtual bool RunService() 
        {
            _isRunning = true;
            bool isRun=RunContext();
            _isRunning = false;
            if (isRun)
            {
                _lastAliveTime = DateTime.Now;
            }
            return true;
        }

        /// <summary>
        /// ��Ҫ��ʱִ�е�����
        /// </summary>
        /// <returns></returns>
        protected virtual bool RunContext() 
        {
            return false;
        }

        protected bool _isRunning=false;
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


        protected DateTime _lastAliveTime;

        /// <summary>
        /// ���ʱ��
        /// </summary>
        public virtual DateTime LastAliveTime 
        {
            get { return _lastAliveTime; }
            
        }
    }
}
