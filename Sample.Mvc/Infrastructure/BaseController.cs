using Sample.Core.Common;
using Sample.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample.Mvc.Infrastructure
{
    public class BaseController : Controller
    {
        private static string ErrorMessage(string message)
        {
            return string.Format("<div class='alert alert-danger' role='alert'>{0}</div>", message);
        }
        private static string SuccessMessage(string message)
        {
            return string.Format("<div class='alert alert-success' role='alert'>{0}</div>", message);
        }

        public void SetAlertMessage(string message)
        {
            TempData["ResultMessage"] = message;
            ErrorMessage(message);
        }

        public void SetAlertMessage<T>(Result<T> result)
        {
            var message = result.ResultMessage;
            if ((ResultStatusCode)result.ResultCode != ResultStatusCode.OK)
            {
                TempData["ResultMessage"] = ErrorMessage(message);
            }
            else {
                TempData["ResultMessage"] = SuccessMessage(message);
            }

        }
    }
}