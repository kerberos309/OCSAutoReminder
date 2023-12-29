using AutoMapper;
using Domain.Entities.OCS;
using Domain.RepositoryInterface.OCS;
using Domain.Shared;
using Infrastructure.Persistence.Context.COMMON_DB;
using Infrastructure.Persistence.Context.OCS;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.RepositoryImplementation.OCS
{
    public class FilingRepository : IFilingRepository
    {
        private IMapper _mapper;
        private readonly OcsDevV31Context _dbContext;
        public FilingRepository(OcsDevV31Context dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public int AddFiling(FilingEntity filingEntity)
        {
            throw new NotImplementedException();
        }

        public int DeleteFiling(FilingEntity filingEntity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FilingEntity> FindFiling(Expression<Func<FilingEntity, bool>> expression)
        {
            var newExpression = expression.ReplaceParameter<FilingEntity, Filing>();
            return _mapper.Map<IEnumerable<Filing>, IEnumerable<FilingEntity>>(_dbContext.Set<Filing>().AsNoTracking().Where(newExpression).AsEnumerable());
            //List<FilingEntity> returnData = new List<FilingEntity>();
            //var newExpression = expression.ReplaceParameter<FilingEntity, Filing>();
            //using (var dbContext = new OcsDevV31Context())
            //{
            //    returnData = _mapper.Map<List<Filing>, List<FilingEntity>>(dbContext.Filings.Where(newExpression).ToList());
            //}
            //return returnData;
        }

        public IEnumerable<FilingEntity> GetAllFiling()
        {
            List<FilingEntity> returnData = new List<FilingEntity>();
            using (var dbContext = new OcsDevV31Context())
            {
                returnData = _mapper.Map<List<Filing>, List<FilingEntity>>(dbContext.Filings.ToList());
            }
            return returnData;
        }

        public int UpdateFiling(FilingEntity filingEntity)
        {
            int returnData = 0;
            using (var dbContext = new OcsDevV31Context())
            {
                dbContext.Filings.Update(_mapper.Map<FilingEntity,Filing>(filingEntity));
                returnData = dbContext.SaveChanges();
            }
            return returnData;
        }
    }
}
