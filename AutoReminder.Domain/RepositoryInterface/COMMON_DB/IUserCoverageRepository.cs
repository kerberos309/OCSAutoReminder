using Domain.Entities.COMMON_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterface.COMMON_DB
{
    public interface IUserCoverageRepository
    {
        int AddUserCoverage(UserCoverageEntity userCoverageEntity);
        IEnumerable<UserCoverageEntity> FindUserCoverage(Expression<Func<UserCoverageEntity,bool>> expression);
        IEnumerable<UserCoverageEntity> GetAllUserCoverage();
        int UpdateUserCoverage(UserCoverageEntity userCoverageEntity);
        int DeleteUserCoverage(UserCoverageEntity userCoverageEntity);
    }
}
