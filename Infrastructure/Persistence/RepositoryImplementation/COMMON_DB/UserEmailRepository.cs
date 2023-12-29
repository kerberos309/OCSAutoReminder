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
    public class UserEmailRepository : IUserEmailRepository
    {
        private readonly IMapper _mapper;
        private readonly CommonDbDevV31Context _dbContext;
        public UserEmailRepository(CommonDbDevV31Context dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public int AddUserEmail(UserEmailEntity userEmailEntity)
        {
            throw new NotImplementedException();
        }

        public int DeleteUserEmail(UserEmailEntity userEmailEntity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEmailEntity> FindUserEmail(Expression<Func<UserEmailEntity, bool>> expression)
        {
            var newExpression = expression.ReplaceParameter<UserEmailEntity, UserEmail>();
            return _mapper.Map<IEnumerable<UserEmail>,IEnumerable<UserEmailEntity>>(_dbContext.Set<UserEmail>().AsNoTracking().Where(newExpression).AsEnumerable());
            //List<UserEmailEntity> returnData = new List<UserEmailEntity>();
            //var newExpression = expression.ReplaceParameter<UserEmailEntity, UserEmail>();
            //using (var dbContext = new CommonDbDevV31Context())
            //{
            //    dbContext.Set<UserEmail>().AsNoTracking();
            //    returnData = _mapper.Map<List<UserEmail>, List<UserEmailEntity>>(dbContext.UserEmails.Where(newExpression).AsEnumerable().ToList());
            //}
            //return returnData;
        }

        public IEnumerable<UserEmailEntity> GetAllUserEmail()
        {
            List<UserEmailEntity> returnData = new List<UserEmailEntity>();
            using (var dbContext = new CommonDbDevV31Context())
            {
                returnData = _mapper.Map<List<UserEmail>, List<UserEmailEntity>>(dbContext.UserEmails.AsEnumerable().ToList());
            }
            return returnData;
        }

        public int UpdateUserEmail(UserEmailEntity userEmailEntity)
        {
            throw new NotImplementedException();
        }
    }
}
