using AutoMapper;
using Domain.Entities.OCS;
using Domain.RepositoryInterface.OCS;
using Infrastructure.Persistence.Context.OCS;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.RepositoryImplementation.OCS
{
    public class SystemLogsRepository : ISystemLogsRepository
    {
        private readonly IMapper _mapper;
        private readonly OcsDevV31Context _dbContext;
        public SystemLogsRepository(IMapper mapper,OcsDevV31Context dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public int AddSystemLogs(SystemLogsEntity systemLogsEntity)
        {
            _dbContext.SystemLogs.Add(_mapper.Map<SystemLogsEntity,SystemLog>(systemLogsEntity));
            return _dbContext.SaveChanges();
        }

        public int DeleteSystemLogs(SystemLogsEntity systemLogsEntity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SystemLogsEntity> FindSystemLogs(Expression<Func<SystemLogsEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SystemLogsEntity> GetAllSystemLogs()
        {
            throw new NotImplementedException();
        }

        public int UpdateSystemLogs(SystemLogsEntity systemLogsEntity)
        {
            throw new NotImplementedException();
        }
    }
}
