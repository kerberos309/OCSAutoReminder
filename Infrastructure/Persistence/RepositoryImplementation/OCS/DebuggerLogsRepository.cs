using AutoMapper;
using Domain.Entities.OCS;
using Domain.RepositoryInterface.OCS;
using Infrastructure.Persistence.Context.OCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.RepositoryImplementation.OCS
{
    public class DebuggerLogsRepository : IDebuggerLogsRepository
    {
        private readonly IMapper _mapper;
        private readonly OcsDevV31Context _dbContext;
        public DebuggerLogsRepository(IMapper mapper,OcsDevV31Context dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public int AddDebuggerLogs(DebuggerLogsEntity debuggerLogsEntity)
        {
            _dbContext.DebuggerLogs.Add(_mapper.Map<DebuggerLogsEntity, DebuggerLog>(debuggerLogsEntity));
            return _dbContext.SaveChanges();
        }
    }
}
