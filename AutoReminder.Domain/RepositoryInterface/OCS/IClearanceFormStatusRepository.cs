using Domain.Entities.OCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterface.OCS
{
    public interface IClearanceFormStatusRepository
    {
        int AddClearanceFormStatus(ClearanceFormStatusEntity clearanceFormStatusEntity);
        IEnumerable<ClearanceFormStatusEntity> GetAllClearanceFormStatus();
        IEnumerable<ClearanceFormStatusEntity> FindClearanceFormStatus(Expression<Func<ClearanceFormStatusEntity,bool>> expression);
        int UpdateClearanceFormStatus(ClearanceFormStatusEntity clearanceFormStatusEntity);
        int DeleteClearanceFormStatus(ClearanceFormStatusEntity clearanceFormStatusEntity);

    }
}
