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
    public class UserCoverageRepository : IUserCoverageRepository
    {
        private readonly IMapper _mapper;
        private readonly CommonDbDevV31Context _dbContext;
        public UserCoverageRepository(CommonDbDevV31Context dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public int AddUserCoverage(UserCoverageEntity userCoverageEntity)
        {
            throw new NotImplementedException();
        }

        public int DeleteUserCoverage(UserCoverageEntity userCoverageEntity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserCoverageEntity> FindUserCoverage(Expression<Func<UserCoverageEntity, bool>> expression)
        {
            var newExpression = expression.ReplaceParameter<UserCoverageEntity, UserCoverage>();
            return _mapper.Map<IEnumerable<UserCoverage>,IEnumerable<UserCoverageEntity>>(_dbContext.Set<UserCoverage>().AsNoTracking().Where(newExpression).AsEnumerable());
            //List<UserCoverageEntity> returnData = new List<UserCoverageEntity>();
            //var newExpression = expression.ReplaceParameter<UserCoverageEntity, UserCoverage>();
            //using (var dbContext = new CommonDbDevV31Context())
            //{
            //    dbContext.Set<UserCoverage>().AsNoTracking();
            //    returnData = _mapper.Map<List<UserCoverage>, List<UserCoverageEntity>>(dbContext.UserCoverages.Where(newExpression).AsEnumerable().ToList());
            //}
            //return returnData;
        }

        public IEnumerable<UserCoverageEntity> GetAllUserCoverage()
        {
            List<UserCoverageEntity> returnData = new List<UserCoverageEntity>();
            using (var dbContext = new CommonDbDevV31Context())
            {
                returnData = _mapper.Map<List<UserCoverage>, List<UserCoverageEntity>>(dbContext.UserCoverages.AsEnumerable().ToList());
            }
            return returnData;
        }

        public int UpdateUserCoverage(UserCoverageEntity userCoverageEntity)
        {
            throw new NotImplementedException();
        }
    }
}
