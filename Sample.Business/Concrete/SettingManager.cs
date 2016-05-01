

using Sample.Business.Interfaces;
using Sample.Core.Interface;
using Sample.Core.Service;
using Sample.DataLayer.Interfaces;
using Sample.Entities.Concrete;

namespace Sample.Business.Concrete
{
    public class SettingManager : EntityService<Setting>, ISettingService
    {
        #region Constructor

        private readonly IUnitOfWork _unitOfWork;
        private readonly ISettingDal _settingDal;
        private readonly INLogService _nLogService;

        public SettingManager(IUnitOfWork unitOfWork, ISettingDal settingDal, INLogService nLogService)
            : base(unitOfWork, settingDal, nLogService)
        {
            _settingDal = settingDal;
            _nLogService = nLogService;
            _unitOfWork = unitOfWork;
        }

        #endregion

    }
}
