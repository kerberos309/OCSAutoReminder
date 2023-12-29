using Domain.Entities.OCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterface.OCS
{
    public interface IFilingRepository
    {
        int AddFiling(FilingEntity filingEntity);
        IEnumerable<FilingEntity> GetAllFiling();
        IEnumerable<FilingEntity> FindFiling(Expression<Func<FilingEntity,bool>> expression);
        int UpdateFiling(FilingEntity filingEntity);
        int DeleteFiling(FilingEntity filingEntity);
    }
}
