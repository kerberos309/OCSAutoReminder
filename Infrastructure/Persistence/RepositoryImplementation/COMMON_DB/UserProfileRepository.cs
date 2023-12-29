using AutoMapper;
using Domain.Entities.COMMON_DB;
using Domain.RepositoryInterface.COMMON_DB;
using Domain.Shared;
using Infrastructure.Persistence.Context.COMMON_DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.RepositoryImplementation.COMMON_DB
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly IMapper _mapper;
        private readonly CommonDbDevV31Context _dbContext;
        public UserProfileRepository(CommonDbDevV31Context dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public int AddUserProfile(UserProfileEntity userProfile)
        {
            throw new NotImplementedException();
        }

        public int DeleteUserProfile(UserProfileEntity userProfile)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserProfileEntity> FindUserProfile(Expression<Func<UserProfileEntity, bool>> expression)
        {
            var newExpression = expression.ReplaceParameter<UserProfileEntity, UserProfile>();
            return _mapper.Map<IEnumerable<UserProfile>, IEnumerable<UserProfileEntity>>(_dbContext.Set<UserProfile>().AsNoTracking().Where(newExpression).AsEnumerable());
        }

        public IEnumerable<UserProfileEntity> GetAllUserProfile()
        {
            List<UserProfileEntity> returnData = new List<UserProfileEntity>();
            using (var dbContext = new CommonDbDevV31Context())
            {
                returnData = _mapper.Map<List<UserProfile>, List<UserProfileEntity>>(dbContext.UserProfiles.ToList());
            }
            return returnData;
        }

        public int UpdateUserProfile(UserProfileEntity userProfile)
        {
            throw new NotImplementedException();
        }
    }
}
