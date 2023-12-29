using AutoMapper;
using Domain.Entities.OCS;
using Domain.RepositoryInterface.OCS;
using Domain.Shared;
using Infrastructure.Persistence.Context.OCS;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.RepositoryImplementation.OCS
{
    public class MatrixAccessRepository : IMatrixAccessRepository
    {
        private readonly IMapper _mapper;
        private readonly OcsDevV31Context _dbContext;
        public MatrixAccessRepository(OcsDevV31Context dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public int AddMatrixAccess(MatrixAccessEntity matrixAccess)
        {
            throw new NotImplementedException();
        }

        public int DeleteMatrixAccess(MatrixAccessEntity matrixAccess)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MatrixAccessEntity> FindMatrixAccess(Expression<Func<MatrixAccessEntity, bool>> expression)
        {
            var newExpression = expression.ReplaceParameter<MatrixAccessEntity, MatrixAccess>();
            return _mapper.Map<IEnumerable<MatrixAccess>, IEnumerable<MatrixAccessEntity>>(_dbContext.Set<MatrixAccess>().AsNoTracking().Where(newExpression).AsEnumerable());
            //List<MatrixAccessEntity> returnData = new List<MatrixAccessEntity>();
            //var newExpression = expression.ReplaceParameter<MatrixAccessEntity, MatrixAccess>();
            //using (var dbContext = new OcsDevV31Context())
            //{
            //    returnData = _mapper.Map<List<MatrixAccess>, List<MatrixAccessEntity>>(dbContext.MatrixAccesses.Where(newExpression).ToList());
            //}
            //return returnData;
        }

        public IEnumerable<MatrixAccessEntity> GetAllMatrixAccess()
        {
            List<MatrixAccessEntity> returnData = new List<MatrixAccessEntity>();
            using (var dbContext = new OcsDevV31Context())
            {
                returnData = _mapper.Map<List<MatrixAccess>, List<MatrixAccessEntity>>(dbContext.MatrixAccesses.ToList());
            }
            return returnData;
        }

        public string GetAutoReminderDay(int entityId, int matrixId)
        {
            return _dbContext.Set<MatrixAccess>().AsNoTracking()
                .Join(_dbContext.Set<MatrixForm>().AsNoTracking(), ma => ma.FormId, mf => mf.FormId, (ma, mf) => new { ma, mf })
                .Join(_dbContext.Set<MatrixEntity>().AsNoTracking(), mamf => mamf.ma.EntityId, me => me.EntityId, (mamf, me) => new { mamf, me })
                .Where(x => x.mamf.ma.EntityId == entityId && x.mamf.ma.MatrixId == matrixId)
                .OrderBy(x => x.mamf.ma.FormId)
                .Select(x => x.mamf.ma.IdValue)
                .FirstOrDefault() ?? string.Empty;
            //using (var dbContext = new OcsDevV31Context())
            //{
            //    name = dbContext.MatrixAccesses
            //            .Join(dbContext.MatrixForms, ma => ma.FormId, mf => mf.FormId, (ma, mf) => new { ma, mf })
            //            .Join(dbContext.MatrixEntities, mamf => mamf.ma.EntityId, me => me.EntityId, (mamf, me) => new { mamf, me })
            //            .Where(x => x.mamf.ma.EntityId == entityId && x.mamf.ma.MatrixId == matrixId)
            //            .OrderBy(x => x.mamf.ma.FormId)
            //            .Select(x => x.mamf.ma.IdValue)
            //            .FirstOrDefault() ?? string.Empty;
            //}
        }

        public int UpdateMatrixAccess(MatrixAccessEntity matrixAccess)
        {
            throw new NotImplementedException();
        }
    }
}
