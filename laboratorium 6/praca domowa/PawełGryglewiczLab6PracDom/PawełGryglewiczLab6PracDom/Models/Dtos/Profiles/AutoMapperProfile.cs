using AutoMapper;
using PawełGryglewiczLab6PracDom.Models.Dtos.BuildingDto;
using PawełGryglewiczLab6PracDom.Models.Dtos.FacultyDto;
using PawełGryglewiczLab6PracDom.Models.Dtos.RoomDto;
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
            RoomMaps();
        }

        private void FacultyMaps()
        {
            CreateMap<Faculty, FacultyDtoForGetResponse>();
            CreateMap<Faculty, FacultyDtoForPostPutResponse>();
            CreateMap<FacultyDtoForPostPutResponse, Faculty>();
        }

        private void BuildingMaps()
        {
            CreateMap<Building, BuildingDtoForGetResponse>();
            CreateMap<BuildingDtoForPostPutResponse, Building>();
            CreateMap<Building, BuildingDtoForFacultyDto>();
            CreateMap<Building, BuildingDtoForRoomDto>();
        }

        private void RoomMaps()
        {
            CreateMap<Room, RoomDtoForGetResponses>();
            CreateMap<RoomDtoForPostPutResponses, Room>();
            CreateMap<Room, RoomDtoForBuildingDto>();
        }


    }
}
