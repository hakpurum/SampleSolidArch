using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sample.Business.Interfaces;
using Sample.Core.Enums;
using Sample.Core.Interface;
using Sample.Entities.Concrete;
using Sample.Mvc.Infrastructure;
using Sample.Mvc.Models;

namespace Sample.Mvc.Controllers
{
    public class UserGroupController : GenericController<UserGroup, UserGroupViewModel>
    {
        private readonly IUserGroupService _userGroupService;
        public UserGroupController(IUserGroupService userGroupService) : base(userGroupService)
        {
            _userGroupService = userGroupService;
        }

        // GET: UserGroup
        public ActionResult Index()
        {
            var result = _userGroupService.GetList();

            if (result.ResultCode == (int)ResultStatusCode.OK)
            {
                return View(new UserGroupListViewModel
                {
                    UserGroups = result.ResultObject.OrderBy(o => o.CreatedDate).ToList()
                });
            }

            SetAlertMessage(result);
            return View(new UserGroupListViewModel());
        }

       
    }
}