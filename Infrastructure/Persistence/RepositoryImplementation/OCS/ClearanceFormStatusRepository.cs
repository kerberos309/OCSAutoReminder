using AutoMapper;
using Domain.Entities.OCS;
using Domain.RepositoryInterface.OCS;
using Domain.Shared;
using Infrastructure.Persistence.Context.OCS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.RepositoryImplementation.OCS
{
    public class ClearanceFormStatusRepository : IClearanceFormStatusRepository
    {
        private IMapper _mapper;
        private readonly OcsDevV31Context _dbContext;
        public ClearanceFormStatusRepository(OcsDevV31Context dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public int AddClearanceFormStatus(ClearanceFormStatusEntity clearanceFormStatusEntity)
        {
            throw new NotImplementedException();
        }

        public int DeleteClearanceFormStatus(ClearanceFormStatusEntity clearanceFormStatusEntity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClearanceFormStatusEntity> FindClearanceFormStatus(Expression<Func<ClearanceFormStatusEntity, bool>> expression)
        {
            var newExpression = expression.ReplaceParameter<ClearanceFormStatusEntity, ClearanceFormStatus>();
            return _mapper.Map<IEnumerable<ClearanceFormStatus>, IEnumerable<ClearanceFormStatusEntity>>(_dbContext.Set<ClearanceFormStatus>().AsNoTracking().Where(newExpression).AsEnumerable());
            //List<ClearanceFormStatusEntity> returnData = new List<ClearanceFormStatusEntity>();
            //var newExpression = expression.ReplaceParameter<ClearanceFormStatusEntity, ClearanceFormStatus>();
            //using (var dbContext = new OcsDevV31Context())
            //{
            //    returnData = _mapper.Map<List<ClearanceFormStatus>, List<ClearanceFormStatusEntity>>(dbContext.ClearanceFormStatuses.Where(newExpression).AsEnumerable().ToList());
            //}
            //return returnData;
        }

        public IEnumerable<ClearanceFormStatusEntity> GetAllClearanceFormStatus()
        {
            List<ClearanceFormStatusEntity> returnData = new List<ClearanceFormStatusEntity>();
            using (var dbContext = new OcsDevV31Context())
            {
                returnData = _mapper.Map<List<ClearanceFormStatus>, List<ClearanceFormStatusEntity>>(dbContext.ClearanceFormStatuses.AsEnumerable().ToList());
            }
            return returnData;
        }

        public int UpdateClearanceFormStatus(ClearanceFormStatusEntity clearanceFormStatusEntity)
        {
            _dbContext.ClearanceFormStatuses.Update(_mapper.Map<ClearanceFormStatusEntity,ClearanceFormStatus>(clearanceFormStatusEntity));
            return _dbContext.SaveChanges();
            //int returnData = 0;
            //using (var dbContext = new OcsDevV31Context())
            //{
            //    dbContext.ClearanceFormStatuses.Update(_mapper.Map<ClearanceFormStatusEntity, ClearanceFormStatus>(clearanceFormStatusEntity));
            //    returnData = dbContext.SaveChanges();
            //}
            //return returnData;
        }
    }
}
