using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public interface IShowMessage
    {
        bool ShowLog
        {
            get;
        }

        bool ShowError
        {
            get;
        }

        bool ShowWarning
        {
            get;
        }
        void Log(string message);
        void LogError(string message);
        void LogWarning(string message);
    }

