using ForumApplication.DataLayer.Repository.CustomRepository;
using ForumApplication.ProfileDto.Mapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.ProfileDto.ObjectsDto
{
    enum SortedParametrs
    {
        DataCreatedNewUp,
        DataCreatedNewDown,
        CountOfMessAscending,
        CountOfMessagesDescending

    }
    class ListForumDto
    {
        DbContext _context;
        ForumDtoMapper dtoMapper;
        public ListForumDto(DbContext context)
        {
            _context = context;
            dtoMapper = new ForumDtoMapper();
        }

        public  IList<ForumDto> GetForumDto()
        {
            ForumRepository ForumRepo = new ForumRepository(_context);
            var AllForumEntitys = ForumRepo.GetAllIncludeReferences();

            return dtoMapper.CreateListForumDto(AllForumEntitys);           
        }
    }
}
