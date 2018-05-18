using AutoMapper;
using ForumApplication.DataTransferObjects;
using ForumApplication.DataTransferObjects.AccountDto;
using ForumApplication.DataTransferObjects.ApiDto;
using ForumApplication.DataTransferObjects.BaseDtoItems;
using ForumApplication.Domain.Entitys;
using ForumApplication.WEB.ApiModel;
using ForumApplication.WEB.Models.AccountViewModel;
using ForumApplication.WEB.Models.AdministratorViewModel;
using System.Linq;

namespace ForumApplication.WEB.Models.Profile
{
    public class UserAccountViewModelProfile : AutoMapper.Profile
    {
        public UserAccountViewModelProfile()
        {

            #region TableMapping
            CreateMap<UserAccountInfoDto, UserAccountsInfoViewModel>()
               .ForMember(AccView => AccView.Location, opt => opt.MapFrom(AccDto => AccDto.UserProfile.Location))
               .ForMember(AccView => AccView.BirthDay, opt => opt.MapFrom(AccDto => AccDto.UserProfile.BirthDay))
               .ForMember(AccView => AccView.Gender, opt => opt.MapFrom(AccDto => AccDto.UserProfile.Gender))
               .ForMember(AccView => AccView.Image, opt => opt.MapFrom(AccDto => AccDto.UserProfile.Image))
               .ForMember(AccView => AccView.RoleName, opt => opt.MapFrom(AccDto => AccDto.Role))
               .ForMember(AccView => AccView.DateRegistration, opt => opt.MapFrom(AccDto => AccDto.UserProfile.DateRegistration))
               .ForMember(AccView => AccView.SomeInformation, opt => opt.MapFrom(AccDto => AccDto.UserProfile.SomeInformation));



            CreateMap<TableAccountInfoDto, TableAccountInfoViewModel>()
                .ForMember(AccView => AccView.Location, opt => opt.MapFrom(AccDto => AccDto.UserProfile.Location))
                .ForMember(AccView => AccView.BirthDay, opt => opt.MapFrom(AccDto => AccDto.UserProfile.BirthDay))
                .ForMember(AccView => AccView.Gender, opt => opt.MapFrom(AccDto => AccDto.UserProfile.Gender))
                .ForMember(AccView => AccView.Image, opt => opt.MapFrom(AccDto => AccDto.UserProfile.Image))
                .ForMember(AccView => AccView.RoleName, opt => opt.MapFrom(AccDto => AccDto.Role))
                .ForMember(AccView => AccView.DateRegistration, opt => opt.MapFrom(AccDto => AccDto.UserProfile.DateRegistration))
                .ForMember(AccView => AccView.SomeInformation, opt => opt.MapFrom(AccDto => AccDto.UserProfile.SomeInformation));


            CreateMap<TableAccountInfoViewModel, TableCreateAccountDto>();
            CreateMap<TableUpdateAccountViewModel, TableUpdateAccountDto>();

            #endregion

            CreateMap<ProfileInfoApiDto, ProfileInfoApiViewModel>()
               .ForMember(AccView => AccView.Location, opt => opt.MapFrom(AccDto => AccDto.UserProfile.Location))
               .ForMember(AccView => AccView.BirthDay, opt => opt.MapFrom(AccDto => AccDto.UserProfile.BirthDay))
               .ForMember(AccView => AccView.Gender, opt => opt.MapFrom(AccDto => AccDto.UserProfile.Gender))
               .ForMember(AccView => AccView.Image, opt => opt.MapFrom(AccDto => AccDto.UserProfile.Image))
               .ForMember(AccView => AccView.Role, opt => opt.MapFrom(AccDto => AccDto.Role))
               .ForMember(AccView => AccView.DateRegistration, opt => opt.MapFrom(AccDto => AccDto.UserProfile.DateRegistration))
               .ForMember(AccView => AccView.SomeInformation, opt => opt.MapFrom(AccDto => AccDto.UserProfile.SomeInformation));

            CreateMap<UpdateUserProfileDto, UpdateUserProfileViewModel>()
                .ForMember(x => x.AccountId, opt => opt.MapFrom(x => x.AccountId));

            CreateMap<CreateAccountViewModel, CreateAccountDto>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Login));

            CreateMap<UserNameIdDto, UserNameIdDto>();
            CreateMap<LoginModelDto, LoginViewModel>();

            
        }
    }
}