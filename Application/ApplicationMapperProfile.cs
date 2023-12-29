using AutoMapper;
using Domain.Entities.COMMON_DB;
using Domain.Entities.OCS;
using Infrastructure.Persistence.Context.COMMON_DB;
using Infrastructure.Persistence.Context.OCS;

namespace Application
{
    public class ApplicationMapperProfile:Profile
    {
        public ApplicationMapperProfile()
        {
            //ocs
            CreateMap<MatrixFormEntity, MatrixForm>().ReverseMap();
            CreateMap<MatrixAccessEntity, MatrixAccess>().ReverseMap();
            CreateMap<MatrixEntityEntity, MatrixEntity>().ReverseMap();
            CreateMap<FilingEntity, Filing>().ReverseMap();
            CreateMap<ClearanceHeaderEntity, ClearanceHeader>().ReverseMap();
            CreateMap<ClearanceFormStatusEntity, ClearanceFormStatus>().ReverseMap();
            CreateMap<EmailNotificationEntity, EmailNotification>().ReverseMap();
            CreateMap<SystemLogsEntity, SystemLog>().ReverseMap();
            CreateMap<DebuggerLogsEntity, DebuggerLog>().ReverseMap();
            //common_db
            CreateMap<UserProfileEntity, UserProfile>().ReverseMap();
            CreateMap<UserEmailEntity, UserEmail>().ReverseMap();
            CreateMap<UserCoverageEntity, UserCoverage>().ReverseMap();
            //eams
            CreateMap<Domain.Entities.EAMS.UserProfileEntity, Infrastructure.Persistence.Context.EAMS.UserProfile>().ReverseMap();
            CreateMap<Domain.Entities.EAMS.UserDefineApproverEntity, Infrastructure.Persistence.Context.EAMS.UserDefineApprover>().ReverseMap();
        }
    }
}
