using AutoMapper;
using CourseLibrary.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseLibrary.API.Profiles
{
    public class AuthorsProfile: Profile
    {

        public AuthorsProfile()
        {
            CreateMap<Entities.Author, Models.AuthorDto>()
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                 .ForMember(
                dest => dest.age,
                opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()));
        }
        
    }
}
