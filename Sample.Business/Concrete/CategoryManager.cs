

using Sample.Business.Interfaces;
using Sample.Core.Interface;
using Sample.Core.Service;
using Sample.DataLayer.Interfaces;
using Sample.Entities.Concrete;

namespace Sample.Business.Concrete
{
    public class CategoryManager : EntityService<Category>, ICategoryService
    {
        #region Constructor

        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryDal _categoryDal;
        private readonly INLogService _nLogService;

        public CategoryManager(IUnitOfWork unitOfWork, ICategoryDal categoryDal, INLogService nLogService)
            : base(unitOfWork, categoryDal, nLogService)
        {
            _categoryDal = categoryDal;
            _nLogService = nLogService;
            _unitOfWork = unitOfWork;
        }

        #endregion

    }
}
