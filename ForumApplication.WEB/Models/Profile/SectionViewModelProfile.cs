using ForumApplication.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.Profile
{
    public class SectionViewModelProfile : AutoMapper.Profile
    {
        public SectionViewModelProfile()
        {
            CreateMap<SectionViewModel, SectionDto>();
            CreateMap<SectionDto, SectionViewModel>();
        }
    }
}