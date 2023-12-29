using Application.Abstractions;
using Application.Contracts;
using AutoMapper;
using Domain.RepositoryInterface.COMMON_DB;
using Domain.RepositoryInterface.OCS;
using Infrastructure;
using Infrastructure.Persistence.Context.COMMON_DB;
using Infrastructure.Persistence.Context.EAMS;
using Infrastructure.Persistence.Context.OCS;
using Infrastructure.Persistence.RepositoryImplementation.COMMON_DB;
using Infrastructure.Persistence.RepositoryImplementation.OCS;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            var config = new MapperConfiguration(conf => { conf.AddProfile<ApplicationMapperProfile>(); });
            var mapper = config.CreateMapper();

            //var configuration = new ConfigurationBuilder()
            //    .AddUserSecrets("13dbbe33-848b-44c1-a160-90bd5c48ef74",true)
            //    .Build();

            services.AddDbContext<OcsDevV31Context>(options => { options.UseSqlServer(ConfigurationManager.ConnectionStrings["OCS"].ToString()); });
            services.AddDbContext<EamsDevV31Context>(options => { options.UseSqlServer(ConfigurationManager.ConnectionStrings["EAMS"].ToString()); });
            services.AddDbContext<CommonDbDevV31Context>(options => { options.UseSqlServer(ConfigurationManager.ConnectionStrings["COMMON_DB"].ToString()); });
            services.AddSingleton<IMapper>(mapper);
            services.AddTransient<IAutoReminderService, AutoReminderService>();
            return services;
        }
    }
}
