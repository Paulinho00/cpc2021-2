using AutoMapper;
using PawełGryglewiczLab6PracDom.Models.Dtos.Building;
using PawełGryglewiczLab6PracDom.Models.Dtos.Faculty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models.Dtos.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            FacultyMaps();
            BuildingMaps();
        }

        private void FacultyMaps()
        {
            CreateMap<Models.Faculty, FacultyDtoForGetResponse>();
            CreateMap<Models.Faculty, FacultyDtoForPostPutResponse>();
            CreateMap<FacultyDtoForPostPutResponse, Models.Faculty>();
        }

        private void BuildingMaps()
        {
            CreateMap<Models.Building, BuildingDtoForGetResponse>();
            CreateMap<BuildingDtoForPostPutResponse, Models.Building>();
        }


    }
}
