using Domain.Entities.OCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterface.OCS
{
    public interface IEmailNotificationRepository
    {
        int AddEmailNotification(EmailNotificationEntity emailNotificationEntity);
        IEnumerable<EmailNotificationEntity> GetAllEmailNotification();
        IEnumerable<EmailNotificationEntity> FindEmailNotification(Expression<Func<EmailNotificationEntity, bool>> expression);
        int UpdateEmailNotification(EmailNotificationEntity emailNotificationEntity);
        int DeleteEmailNotifcation(EmailNotificationEntity emailNotificationEntity);
    }
}
