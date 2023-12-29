using Domain.Entities.OCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterface.OCS
{
    public interface IMatrixEntityRepository
    {
        int AddMatrixEntity(MatrixEntityEntity matrixEntity);
        IEnumerable<MatrixEntityEntity> GetAllMatrixEntity();
        IEnumerable<MatrixEntityEntity> FindMatrixEntity(Expression<Func<MatrixEntityEntity,bool>> expression);
        int UpdateMatrixEntity(MatrixEntityEntity matrixEntity);
        int DeleteMatrixEntity(MatrixEntityEntity matrixEntity);
    }
}
