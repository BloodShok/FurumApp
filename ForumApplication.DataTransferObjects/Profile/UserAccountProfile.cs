using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumApplication.DataTransferObjects.AccountDto;
using ForumApplication.DataTransferObjects.BaseDtoItems;
using ForumApplication.Domain.Entitys;

namespace ForumApplication.DataTransferObjects.Profile
{
    public class UserAccountProfile : AutoMapper.Profile
    {
        public UserAccountProfile()
        {
            CreateMap<UserAccount, UserAccountInfoDto>()
                .ForMember(x => x.UserProfile, opt => opt.MapFrom(x => x.UserProfile));


            CreateMap<UserAccount, TableAccountInfoDto>();



            CreateMap<CreateAccountDto, UserAccount>()
                .ForMember(x => x.IsActive, opt => opt.UseValue(true))
                .ForPath(x => x.UserProfile, opt => opt.MapFrom(x => new UserProfile()))
                .ForPath(x => x.UserProfile.BirthDay, opt => opt.MapFrom(x => new DateTime(2000, 1, 1)))
                .ForPath(x => x.UserProfile.DateRegistration, opt => opt.MapFrom(x => DateTime.Now));
            

            CreateMap<UserAccount, UserNameIdDto>();

            CreateMap<UserProfile, UserProfileInfoDto>();



            CreateMap<TableCreateAccountDto, UserAccount>()
                .ForPath(x => x.UserProfile.BirthDay, opt => opt.MapFrom(val => val.BirthDay))
                .ForPath(x => x.UserProfile.DateRegistration, opt => opt.MapFrom(val => val.DateRegistration))
                .ForPath(x => x.UserProfile.Gender, opt => opt.MapFrom(val => val.Gender))
                .ForPath(x => x.UserProfile.Location, opt => opt.MapFrom(val => val.Location))
                .ForPath(x => x.UserProfile.Image, opt => opt.MapFrom(val => val.Image))
                .ForPath(x => x.UserProfile.DateRegistration, opt => opt.MapFrom(x => DateTime.Now))
                .ForPath(x => x.UserProfile.SomeInformation, opt => opt.MapFrom(val => val.SomeInformation));

            CreateMap<TableUpdateAccountDto, UserAccount>()
                .ForPath(x => x.UserProfile.BirthDay, opt => opt.MapFrom(val => val.BirthDay))
                .ForPath(x => x.UserProfile.DateRegistration, opt => opt.MapFrom(val => val.DateRegistration))
                .ForPath(x => x.UserProfile.Gender, opt => opt.MapFrom(val => val.Gender))
                .ForPath(x => x.UserProfile.Location, opt => opt.MapFrom(val => val.Location))
                .ForPath(x => x.UserProfile.Image, opt => opt.MapFrom(val => val.Image))
                .ForPath(x => x.UserProfile.SomeInformation, opt => opt.MapFrom(val => val.SomeInformation));


            CreateMap<UpdateUserProfileDto, UserProfile>();



        }
    }
}
