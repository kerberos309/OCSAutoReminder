using AutoMapper;
using Domain.Entities.OCS;
using Domain.RepositoryInterface.OCS;
using Domain.Shared;
using Infrastructure.Persistence.Context.OCS;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MatrixFormEntity = Domain.Entities.OCS.MatrixFormEntity;

namespace Infrastructure.Persistence.RepositoryImplementation.OCS
{
    public class MatrixFormRepository : IMatrixFormRepository
    {
        private readonly IMapper _mapper;
        private readonly OcsDevV31Context _dbContext;
        public MatrixFormRepository(OcsDevV31Context dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public int AddMatrixForm(MatrixFormEntity matrixForm)
        {
            throw new NotImplementedException();
        }

        public int DeleteMatrixForm(MatrixFormEntity matrixForm)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MatrixFormEntity> FindMatrixForm(Expression<Func<MatrixFormEntity, bool>> expression)
        {
            var newExpression = expression.ReplaceParameter<MatrixFormEntity, MatrixForm>();
            return _mapper.Map<IEnumerable<MatrixForm>, IEnumerable<MatrixFormEntity>>(_dbContext.Set<MatrixForm>().AsNoTracking().Where(newExpression).AsEnumerable());
            //List<MatrixFormEntity> returnData = new List<MatrixFormEntity>();
            //var newExpression = expression.ReplaceParameter<MatrixFormEntity, MatrixForm>();
            //using (var dbContext = new OcsDevV31Context())
            //{
            //    returnData = _mapper.Map<List<MatrixForm>, List<MatrixFormEntity>>(dbContext.MatrixForms.Where(newExpression).ToList());
            //}
            //return returnData;
        }

        public IEnumerable<MatrixFormEntity> GetAllMatrixForm()
        {
            List<MatrixFormEntity> returnData = new List<MatrixFormEntity>();
            using (var dbContext = new OcsDevV31Context())
            {
                returnData = _mapper.Map<List<MatrixForm>, List<MatrixFormEntity>>(dbContext.MatrixForms.ToList());
            }
            return returnData;
        }

        public int UpdateMatrixForm(MatrixFormEntity matrixForm)
        {
            throw new NotImplementedException();
        }
    }
}
