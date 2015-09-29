
namespace Sample.Core.Common
{
    public class Result<T>
    {
        public T ResultObject { get; set; }
        public string ResultMessage { get; set; }
        public bool ResultStatus { get; set; }
        public int ResultCode { get; set; }
        public void setFalse() { ResultStatus = false; }
        public void setTrue() { ResultStatus = true; }
    }
}
