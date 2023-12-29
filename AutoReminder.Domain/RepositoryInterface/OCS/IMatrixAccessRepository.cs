using Domain.Entities.OCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterface.OCS
{
    public interface IMatrixAccessRepository
    {
        IEnumerable<MatrixAccessEntity> GetAllMatrixAccess();
        IEnumerable<MatrixAccessEntity> FindMatrixAccess(Expression<Func<MatrixAccessEntity,bool>> expression);
        int UpdateMatrixAccess(MatrixAccessEntity matrixAccess);
        int AddMatrixAccess(MatrixAccessEntity matrixAccess);
        int DeleteMatrixAccess(MatrixAccessEntity matrixAccess);
        string GetAutoReminderDay(int entityId, int matrixId);
    }
}
