using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.Interface
{
    public interface ILoggingService
    {
        bool IsDebugEnable { get; }
        bool IsErrorEnable { get; }
        bool IsFatalEnable { get; }
        bool IsInfoEnable { get; }
        bool IsTraceEnable { get; }
        bool IsWarnEnable { get; }

        void Debug(string message);
        void Debug(Exception exception);
        void Debug(string mesage , Exception exception);
        void Debug(string format,params object[] args);

        void Error(string message);
        void Error(Exception exception);
        void Error(string mesage, Exception exception);
        void Error(string format, params object[] args);

        void Fatal(string message);
        void Fatal(Exception exception);
        void Fatal(string mesage, Exception exception);
        void Fatal(string format, params object[] args);


        void Info(string message);
        void Info(Exception exception);
        void Info(string mesage, Exception exception);
        void Info(string format, params object[] args);

        void Trace(string message);
        void Trace(Exception exception);
        void Trace(string mesage, Exception exception);
        void Trace(string format, params object[] args);

        void Warn(string message);
        void Warn(Exception exception);
        void Warn(string mesage, Exception exception);
        void Warn(string format, params object[] args);
    
    }
}
