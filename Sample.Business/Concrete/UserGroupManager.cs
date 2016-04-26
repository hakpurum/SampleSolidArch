using Sample.Business.Interfaces;
using Sample.Core.Interface;
using Sample.Core.Service;
using Sample.DataLayer.Interfaces;
using Sample.Entities.Concrete;

namespace Sample.Business.Concrete
{
    public class UserGroupManager : EntityService<UserGroup>, IUserGroupService
    {
        #region Constructor

        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserGroupDal _userGroupDal;
        private readonly INLogService _nLogService;

        public UserGroupManager(IUnitOfWork unitOfWork, IUserGroupDal userGroupDal, INLogService nLogService)
            : base(unitOfWork, userGroupDal, nLogService)
        {
            _userGroupDal = userGroupDal;
            _nLogService = nLogService;
            _unitOfWork = unitOfWork;
        }

        #endregion

    }
}
