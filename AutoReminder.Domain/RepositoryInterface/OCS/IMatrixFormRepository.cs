using Domain.Entities.OCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterface.OCS
{
    public interface IMatrixFormRepository
    {
        IEnumerable<MatrixFormEntity> GetAllMatrixForm();
        IEnumerable<MatrixFormEntity> FindMatrixForm(Expression<Func<MatrixFormEntity,bool>> epxression);
        int UpdateMatrixForm(MatrixFormEntity matrixForm);
        int AddMatrixForm(MatrixFormEntity matrixForm);
        int DeleteMatrixForm(MatrixFormEntity matrixForm);
    }
}
