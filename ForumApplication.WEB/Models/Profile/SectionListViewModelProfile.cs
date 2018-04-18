using ForumApplication.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.Profile
{
    public class SectionListViewModelProfile : AutoMapper.Profile
    {
        public SectionListViewModelProfile()
        {
            CreateMap<SectionListDto, SectionListViewModel>();
        }
    }
}