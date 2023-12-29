using Domain.Entities.OCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterface.OCS
{
    public interface IDebuggerLogsRepository
    {
        int AddDebuggerLogs(DebuggerLogsEntity debuggerLogsEntity);
    }
}
