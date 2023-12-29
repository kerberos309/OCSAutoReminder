using Domain.Entities.EAMS;
using System.Linq.Expressions;

namespace Domain.RepositoryInterface.EAMS
{
    public interface IUserProfileRepository
    {
        int AddUserProfile(UserProfileEntity userProfileEntity);
        IEnumerable<UserProfileEntity> FindUserProfile(Expression<Func<UserProfileEntity, bool>> expression);
        IEnumerable<UserProfileEntity> GetAllUserProfile();
        int UpdateUserProfile(UserProfileEntity userProfileEntity);
        int DeletedUserProfile(UserProfileEntity userProfileEntity);
    }
}
