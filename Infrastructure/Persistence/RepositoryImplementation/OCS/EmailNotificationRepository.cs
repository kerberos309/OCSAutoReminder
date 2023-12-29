using AutoMapper;
using Domain.Entities.OCS;
using Domain.RepositoryInterface.OCS;
using Infrastructure.Persistence.Context.COMMON_DB;
using Infrastructure.Persistence.Context.OCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.RepositoryImplementation.OCS
{
    public class EmailNotificationRepository : IEmailNotificationRepository
    {
        private readonly IMapper _mapper;
        private readonly OcsDevV31Context _dbContext;
        public EmailNotificationRepository(OcsDevV31Context dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public int AddEmailNotification(EmailNotificationEntity emailNotificationEntity)
        {
            _dbContext.EmailNotifications.Add(_mapper.Map<EmailNotificationEntity, EmailNotification>(emailNotificationEntity));
            return _dbContext.SaveChanges();
            //int returnData = 0;
            //using (var dbContext = new OcsDevV31Context())
            //{
            //    dbContext.EmailNotifications.Add(_mapper.Map<EmailNotificationEntity, EmailNotification>(emailNotificationEntity));
            //    returnData = dbContext.SaveChanges();
            //}
            //return returnData;
        }

        public int DeleteEmailNotifcation(EmailNotificationEntity emailNotificationEntity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmailNotificationEntity> FindEmailNotification(Expression<Func<EmailNotificationEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmailNotificationEntity> GetAllEmailNotification()
        {
            throw new NotImplementedException();
        }

        public int UpdateEmailNotification(EmailNotificationEntity emailNotificationEntity)
        {
            throw new NotImplementedException();
        }
    }
}
