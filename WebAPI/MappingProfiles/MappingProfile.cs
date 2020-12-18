using AutoMapper;

namespace WebAPI.MappingProfiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //CreateMap<User, UserHobbyDto>()
            //    .ForMember(uh => uh.Hobbies, opt => opt.MapFrom(h => h.Hobbies.Select(y => y.Hobby).ToList())).MaxDepth(1);

           
        }
      

    }
}
