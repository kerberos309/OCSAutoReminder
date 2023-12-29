using Domain.Entities.COMMON_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterface.COMMON_DB
{
    public interface IUserEmailRepository
    {
        int AddUserEmail(UserEmailEntity userEmailEntity);
        IEnumerable<UserEmailEntity> FindUserEmail(Expression<Func<UserEmailEntity,bool>> expression);
        IEnumerable<UserEmailEntity> GetAllUserEmail();
        int UpdateUserEmail(UserEmailEntity userEmailEntity);
        int DeleteUserEmail(UserEmailEntity userEmailEntity);
    }
}
