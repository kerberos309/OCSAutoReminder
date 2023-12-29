using Domain.Entities.COMMON_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterface.COMMON_DB
{
    public interface IUserProfileRepository
    {
        int AddUserProfile(UserProfileEntity userProfile);
        IEnumerable<UserProfileEntity> GetAllUserProfile();
        IEnumerable<UserProfileEntity> FindUserProfile(Expression<Func<UserProfileEntity,bool>> expression);
        int UpdateUserProfile(UserProfileEntity userProfile);
        int DeleteUserProfile(UserProfileEntity userProfile);
    }
}
