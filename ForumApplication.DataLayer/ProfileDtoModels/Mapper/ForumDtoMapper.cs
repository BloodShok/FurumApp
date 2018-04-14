using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ForumApplication.DataLayer.ProfileDtoModels.QueryObjects;
using ForumApplication.Domain.Entitys;

namespace ForumApplication.DataLayer.ProfileDtoModels.Mapper
{
    public class ForumDtoMapper
    {
        public ForumDto SelectForumDto(Forum ForumBase)
        {
            return AutoMapper.Mapper.Map<Forum, ForumDto>(ForumBase);
        }
    }
}
