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
    public class UserDefineApproverRepository : IUserDefineApproverRepository
    {
        private readonly IMapper _mapper;
        private readonly EamsDevV31Context _dbContext;
        public UserDefineApproverRepository(EamsDevV31Context dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public int AddUserDefineApprover(UserDefineApproverEntity userDefineApproverEntity)
        {
            throw new NotImplementedException();
        }

        public int DeleteUserDefineApprover(UserDefineApproverEntity userDefineApproverEntity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDefineApproverEntity> FindUserDefineApprover(Expression<Func<UserDefineApproverEntity, bool>> expression)
        {
            var newExpression = expression.ReplaceParameter<UserDefineApproverEntity, UserDefineApprover>();
            return _mapper.Map<IEnumerable<UserDefineApprover>, IEnumerable<UserDefineApproverEntity>>(_dbContext.Set<UserDefineApprover>().AsNoTracking().Where(newExpression).AsEnumerable());
            //List<UserDefineApproverEntity> returnData = new List<UserDefineApproverEntity>();
            //var newExpression = expression.ReplaceParameter<UserDefineApproverEntity, UserDefineApprover>();
            //using (var dbContext = new EamsDevV31Context())
            //{
            //    returnData = _mapper.Map<List<UserDefineApprover>, List<UserDefineApproverEntity>>(dbContext.UserDefineApprovers.Where(newExpression).AsEnumerable().ToList());
            //}
            //return returnData;
        }

        public IEnumerable<UserDefineApproverEntity> GetAllUserDefineApprover()
        {
            throw new NotImplementedException();
        }

        public int UpdateUserDefineApprover(UserDefineApproverEntity userDefineApproverEntity)
        {
            throw new NotImplementedException();
        }
    }
}
