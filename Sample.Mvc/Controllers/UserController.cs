using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sample.Mvc.Infrastructure;
using Sample.Entities.Concrete;
using Sample.Mvc.Models;
using Sample.Business.Interfaces;
using Sample.Core.Common;
using Sample.Core.Enums;
using Sample.Core.Extension;

namespace Sample.Mvc.Controllers
{
    public class UserController : GenericController<User, UserViewModel>
    {
        #region Constructor
        
        private readonly IUserService _userService;
        private readonly IUserGroupService _userGroupService;

        public UserController(IUserService userService, IUserGroupService userGroupService)
            : base(userService)
        {
            _userService = userService;
            _userGroupService = userGroupService;
        }

        #endregion

        // GET: User
        public ActionResult Index()
        {
            var result = _userService.GetList();

            if (result.ResultCode == (int)ResultStatusCode.OK)
            {
                return View(new UserListViewModel
                {
                    Users = result.ResultObject.OrderBy(o => o.CreatedDate).ToList()
                });
            }

            SetAlertMessage(result);
            return View(new UserListViewModel());
        }

        public override ActionResult Create()
        {
            var userGroupResult = _userGroupService.GetList();
            if (userGroupResult.ResultCode == (int)ResultStatusCode.OK)
            {
                return View(new UserViewModel
                {
                    UserGroups = _userGroupService.GetList().ResultObject
                });
            }

            return View(new UserViewModel());
        }
        
    }
}