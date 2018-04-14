using ForumApplication.Domain.Entitys;
using ForumApplication.ProfileDto.ObjectsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.ProfileDto.Mapper
{
    public class ForumDtoMapper
    {
        public ForumDto CreateForumDto(Forum ForumBase)
        {
            return AutoMapper.Mapper.Map<Forum, ForumDto>(ForumBase);
        }

        public IList<ForumDto> CreateListForumDto(IList<Forum> forums)
        {
            return AutoMapper.Mapper.Map<IList<Forum>, IList<ForumDto>>(forums);
        }
    }
}
