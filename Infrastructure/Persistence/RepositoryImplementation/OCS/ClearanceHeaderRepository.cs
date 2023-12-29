using AutoMapper;
using AutoMapper.Execution;
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
    public class ClearanceHeaderRepository : IClearanceHeaderRepository
    {
        private IMapper _mapper;
        private readonly OcsDevV31Context _dbContext;
        public ClearanceHeaderRepository(OcsDevV31Context dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public int AddCreateHeader(ClearanceHeaderEntity clearanceHeaderEntity)
        {
            throw new NotImplementedException();
        }

        public int DeleteClearanceHeader(ClearanceHeaderEntity clearanceHeaderEntity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClearanceHeaderEntity> FindClearanceHeader(Expression<Func<ClearanceHeaderEntity, bool>> expression)
        {
            var newExpression = expression.ReplaceParameter<ClearanceHeaderEntity, ClearanceHeader>();
            return _mapper.Map<IEnumerable<ClearanceHeader>, IEnumerable<ClearanceHeaderEntity>>(_dbContext.Set<ClearanceHeader>().AsNoTracking().Where(newExpression).AsEnumerable());
            //List<ClearanceHeaderEntity> returnData = new List<ClearanceHeaderEntity>();
            //var newExpression = expression.ReplaceParameter<ClearanceHeaderEntity, ClearanceHeader>();
            //using (var dbContext = new OcsDevV31Context())
            //{
            //    dbContext.Set<ClearanceHeader>().AsNoTracking();
            //    returnData = _mapper.Map<List<ClearanceHeader>, List<ClearanceHeaderEntity>>(dbContext.ClearanceHeaders.Where(newExpression).ToList());
            //}
            //return returnData;
        }

        public IEnumerable<ClearanceHeaderEntity> GetAllClearanceHeader()
        {
            List<ClearanceHeaderEntity> returnData = new List<ClearanceHeaderEntity>();
            using (var dbContext = new OcsDevV31Context())
            {
                returnData = _mapper.Map<List<ClearanceHeader>, List<ClearanceHeaderEntity>>(dbContext.ClearanceHeaders.ToList());
            }
            return returnData;
        }

        public int UpdateClearanceHeader(ClearanceHeaderEntity clearanceHeaderEntity)
        {
            throw new NotImplementedException();
        }
    }
}
