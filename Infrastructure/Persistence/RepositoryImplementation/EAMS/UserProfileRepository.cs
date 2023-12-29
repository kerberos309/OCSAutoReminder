using AutoMapper;
using Domain.Entities.EAMS;
using Domain.RepositoryInterface.EAMS;
using Domain.Shared;
using Infrastructure.Persistence.Context.EAMS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.RepositoryImplementation.EAMS
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly IMapper _mapper;
        private readonly EamsDevV31Context _dbContext;
        public UserProfileRepository(EamsDevV31Context dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public int AddUserProfile(UserProfileEntity userProfileEntity)
        {
            throw new NotImplementedException();
        }

        public int DeletedUserProfile(UserProfileEntity userProfileEntity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserProfileEntity> FindUserProfile(Expression<Func<UserProfileEntity, bool>> expression)
        {
            var newExpression = expression.ReplaceParameter<UserProfileEntity, UserProfile>();
            return _mapper.Map<IEnumerable<UserProfile>, IEnumerable<UserProfileEntity>>(_dbContext.Set<UserProfile>().AsNoTracking().Where(newExpression).AsEnumerable());
            //List<UserProfileEntity> returnData = new List<UserProfileEntity>();
            //var newExpression = expression.ReplaceParameter<UserProfileEntity, UserProfile>();
            //using (var dbContext = new EamsDevV31Context())
            //{
            //    returnData = _mapper.Map<List<UserProfile>, List<UserProfileEntity>>(dbContext.UserProfiles.Where(newExpression).AsEnumerable().ToList());
            //}
            //return returnData;
        }

        public IEnumerable<UserProfileEntity> GetAllUserProfile()
        {
            throw new NotImplementedException();
        }

        public int UpdateUserProfile(UserProfileEntity userProfileEntity)
        {
            throw new NotImplementedException();
        }
    }
}
