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
    public class MatrixEntityRepository : IMatrixEntityRepository
    {
        private readonly IMapper _mapper;
        private readonly OcsDevV31Context _dbContext;
        public MatrixEntityRepository(OcsDevV31Context dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public int AddMatrixEntity(MatrixEntityEntity matrixEntity)
        {
            throw new NotImplementedException();
        }

        public int DeleteMatrixEntity(MatrixEntityEntity matrixEntity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MatrixEntityEntity> FindMatrixEntity(Expression<Func<MatrixEntityEntity, bool>> expression)
        {
            var newExpression = expression.ReplaceParameter<MatrixEntityEntity, MatrixEntity>();
            return _mapper.Map<IEnumerable<MatrixEntity>, IEnumerable<MatrixEntityEntity>>(_dbContext.Set<MatrixEntity>().AsNoTracking().Where(newExpression).AsEnumerable());
            //List<MatrixEntityEntity> returnData = new List<MatrixEntityEntity>();
            //var newExpression = expression.ReplaceParameter<MatrixEntityEntity, MatrixEntity>();
            //using (var dbContext = new OcsDevV31Context())
            //{
            //    returnData = _mapper.Map<List<MatrixEntity>, List<MatrixEntityEntity>>(dbContext.MatrixEntities.Where(newExpression).ToList());
            //}
            //return returnData;
        }

        public IEnumerable<MatrixEntityEntity> GetAllMatrixEntity()
        {
            List<MatrixEntityEntity> returnData = new List<MatrixEntityEntity>();
            using (var dbContext = new OcsDevV31Context())
            {
                returnData = _mapper.Map<List<MatrixEntity>, List<MatrixEntityEntity>>(dbContext.MatrixEntities.ToList());
            }
            return returnData;
        }

        public int UpdateMatrixEntity(MatrixEntityEntity matrixEntity)
        {
            throw new NotImplementedException();
        }
    }
}
