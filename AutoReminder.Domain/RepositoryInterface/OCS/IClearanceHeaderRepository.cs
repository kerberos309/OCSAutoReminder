using Domain.Entities.OCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterface.OCS
{
    public interface IClearanceHeaderRepository
    {
        int AddCreateHeader(ClearanceHeaderEntity clearanceHeaderEntity);
        IEnumerable<ClearanceHeaderEntity> GetAllClearanceHeader();
        IEnumerable<ClearanceHeaderEntity> FindClearanceHeader(Expression<Func<ClearanceHeaderEntity,bool>> expression);
        int UpdateClearanceHeader(ClearanceHeaderEntity clearanceHeaderEntity);
        int DeleteClearanceHeader(ClearanceHeaderEntity clearanceHeaderEntity);
    }
}
