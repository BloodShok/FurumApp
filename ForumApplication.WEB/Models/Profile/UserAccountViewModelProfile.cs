using ForumApplication.DataTransferObjects;

namespace ForumApplication.WEB.Models.Profile
{
    public class UserAccountViewModelProfile : AutoMapper.Profile
    {
        public UserAccountViewModelProfile()
        {
            CreateMap<UserAccountInfoDto, UserAccountsInfoViewModel>()
                .ForMember(AccView => AccView.Location, opt => opt.MapFrom(AccDto => AccDto.UserProfile.Location))
                .ForMember(AccView => AccView.AttachedPicture, opt => opt.MapFrom(AccDto => AccDto.UserProfile.AttachedPicture))
                .ForMember(AccView => AccView.BirthDay, opt => opt.MapFrom(AccDto => AccDto.UserProfile.BirthDay))
                .ForMember(AccView => AccView.Gender, opt => opt.MapFrom(AccDto => AccDto.UserProfile.Gender))
                .ForMember(AccView => AccView.SomeInformation, opt => opt.MapFrom(AccDto => AccDto.UserProfile.SomeInformation));

            CreateMap<CreateAccountViewModel, CreateAccountDto>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Login));

            CreateMap<UserNameIdDto, UserNameIdDto>();
        }
    }
}