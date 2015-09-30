using System;
using Sample.Core.Interface;
using NLog.Interface;
using NLog;

namespace Sample.Core.Logging
{
    public class NLogService:INLogService
    {
        private readonly ILogger _log;

        public NLogService()
        {
            _log = new LoggerAdapter(LogManager.GetCurrentClassLogger());
        }

        public bool IsDebugEnable
        {
            get { return _log.IsDebugEnabled; }
        }

        public bool IsErrorEnable
        {
            get { return _log.IsErrorEnabled; }
        }

        public bool IsFatalEnable
        {
            get { return _log.IsFatalEnabled; }
        }

        public bool IsInfoEnable
        {
            get { return _log.IsInfoEnabled; }
        }

        public bool IsTraceEnable
        {
            get { return _log.IsTraceEnabled; }
        }

        public bool IsWarnEnable
        {
            get { return _log.IsWarnEnabled; }
        }

        #region Debug
        public void Debug(string message)
        {
            if (IsDebugEnable)
                _log.Debug(message);
        }

        public void Debug(Exception exception)
        {
            if (IsDebugEnable)
                _log.Debug(exception);
        }

        public void Debug(string mesage, Exception exception)
        {
            if (IsDebugEnable)
                _log.Debug(mesage, exception);
        }

        public void Debug(string format, params object[] args)
        {
            if (IsDebugEnable)
                _log.Debug(format, args);
        } 
        #endregion

        #region Error
        public void Error(string message)
        {
            if (IsErrorEnable)
                _log.Error(message);
        }

        public void Error(Exception exception)
        {
            if (IsErrorEnable)
                _log.Error(exception);
        }

        public void Error(string mesage, Exception exception)
        {
            if (IsErrorEnable)
                _log.Error(mesage, exception);
        }

        public void Error(string format, params object[] args)
        {
            if (IsErrorEnable)
                _log.Error(format, args);
        }

        #endregion

        #region Fatal
        public void Fatal(string message)
        {
            if (IsFatalEnable)
                _log.Fatal(message);
        }

        public void Fatal(Exception exception)
        {
            if (IsFatalEnable)
                _log.Fatal(exception);
        }

        public void Fatal(string mesage, Exception exception)
        {
            if (IsFatalEnable)
                _log.Fatal(mesage, exception);
        }

        public void Fatal(string format, params object[] args)
        {
            if (IsFatalEnable)
                _log.Fatal(format, args);
        } 
        #endregion

        #region Info
        public void Info(string message)
        {
            if (IsFatalEnable)
                _log.Info(message);
        }

        public void Info(Exception exception)
        {
            if (IsFatalEnable)
                _log.Info(exception);
        }

        public void Info(string mesage, Exception exception)
        {
            if (IsFatalEnable)
                _log.Info(mesage, exception);
        }

        public void Info(string format, params object[] args)
        {
            if (IsFatalEnable)
                _log.Info(format, args);
        } 
        #endregion

        #region Trace
        public void Trace(string message)
        {
            if (IsTraceEnable)
                _log.Trace(message);
        }

        public void Trace(Exception exception)
        {
            if (IsTraceEnable)
                _log.Trace(exception);
        }

        public void Trace(string mesage, Exception exception)
        {
            if (IsTraceEnable)
                _log.Trace(mesage, exception);
        }

        public void Trace(string format, params object[] args)
        {
            if (IsTraceEnable)
                _log.Trace(format, args);
        } 
        #endregion

        #region Warn
        public void Warn(string message)
        {
            if (IsWarnEnable)
                _log.Trace(message);
        }

        public void Warn(Exception exception)
        {
            if (IsWarnEnable)
                _log.Trace(exception);
        }

        public void Warn(string mesage, Exception exception)
        {
            if (IsWarnEnable)
                _log.Trace(mesage, exception);
        }

        public void Warn(string format, params object[] args)
        {
            if (IsWarnEnable)
                _log.Trace(format, args);
        } 
        #endregion
    }
}
