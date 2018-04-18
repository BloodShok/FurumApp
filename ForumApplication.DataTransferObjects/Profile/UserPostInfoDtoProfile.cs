using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.Profile
{
    public class UserPostInfoDtoProfile : AutoMapper.Profile
    {
        public UserPostInfoDtoProfile()
        {
            CreateMap<User, UserPostInfoDto>();
        }
    }
}
