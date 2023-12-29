using Domain.Entities.OCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterface.OCS
{
    public interface ISystemLogsRepository
    {
        int AddSystemLogs(SystemLogsEntity systemLogsEntity);
        int UpdateSystemLogs(SystemLogsEntity systemLogsEntity);
        int DeleteSystemLogs(SystemLogsEntity systemLogsEntity);
        IEnumerable<SystemLogsEntity> GetAllSystemLogs();
        IEnumerable<SystemLogsEntity> FindSystemLogs(Expression<Func<SystemLogsEntity,bool>> expression);
    }
}
