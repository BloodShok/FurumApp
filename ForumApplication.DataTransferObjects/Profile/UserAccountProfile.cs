using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ForumApplication.Domain.Entitys;

namespace ForumApplication.DataTransferObjects.Profile
{
    public class UserAccountProfile : AutoMapper.Profile
    {
        public UserAccountProfile()
        {
            CreateMap<UserAccount, UserAccountInfoDto>()
                .ForMember(x => x.UserProfile, opt => opt.MapFrom(x => x.UserProfile));

            CreateMap<CreateAccountDto, UserAccount>();

            CreateMap<UserAccount, UserNameIdDto>();
        }
    }
}
