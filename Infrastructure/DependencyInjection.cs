using Domain.RepositoryInterface.COMMON_DB;
using Domain.RepositoryInterface.OCS;
using Infrastructure.Persistence.Context.COMMON_DB;
using Infrastructure.Persistence.Context.OCS;
using Infrastructure.Persistence.RepositoryImplementation.COMMON_DB;
using Infrastructure.Persistence.RepositoryImplementation.OCS;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //OCS
            services.AddTransient<IMatrixAccessRepository, MatrixAccessRepository>();
            services.AddTransient<IMatrixEntityRepository, MatrixEntityRepository>();
            services.AddTransient<IMatrixFormRepository, MatrixFormRepository>();
            services.AddTransient<IClearanceFormStatusRepository, ClearanceFormStatusRepository>();
            services.AddTransient<IClearanceHeaderRepository, ClearanceHeaderRepository>();
            services.AddTransient<IFilingRepository, FilingRepository>();
            services.AddTransient<IEmailNotificationRepository, EmailNotificationRepository>();
            services.AddTransient<ISystemLogsRepository, SystemLogsRepository>();
            services.AddTransient<IDebuggerLogsRepository, DebuggerLogsRepository>();
            //COMMON_DB
            services.AddTransient<IUserProfileRepository, UserProfileRepository>();
            services.AddTransient<IUserEmailRepository, UserEmailRepository>();
            services.AddTransient<IUserCoverageRepository, UserCoverageRepository>();
            //EAMS
            services.AddTransient<Domain.RepositoryInterface.EAMS.IUserDefineApproverRepository, Infrastructure.Persistence.RepositoryImplementation.EAMS.UserDefineApproverRepository>();
            services.AddTransient<Domain.RepositoryInterface.EAMS.IUserProfileRepository, Infrastructure.Persistence.RepositoryImplementation.EAMS.UserProfileRepository>();

            return services;
        }
    }
}
