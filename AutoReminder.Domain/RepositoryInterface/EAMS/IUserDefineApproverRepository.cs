using Domain.Entities.EAMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterface.EAMS
{
    public interface IUserDefineApproverRepository
    {
        int AddUserDefineApprover(UserDefineApproverEntity userDefineApproverEntity);
        IEnumerable<UserDefineApproverEntity> FindUserDefineApprover(Expression<Func<UserDefineApproverEntity,bool>> expression);
        IEnumerable<UserDefineApproverEntity> GetAllUserDefineApprover();
        int UpdateUserDefineApprover(UserDefineApproverEntity userDefineApproverEntity);
        int DeleteUserDefineApprover(UserDefineApproverEntity userDefineApproverEntity);
    }
}
