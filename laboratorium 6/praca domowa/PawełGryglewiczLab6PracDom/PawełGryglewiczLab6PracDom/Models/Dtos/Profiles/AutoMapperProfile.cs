﻿using AutoMapper;
using PawełGryglewiczLab6PracDom.Models.Dtos.BuildingDto;
using PawełGryglewiczLab6PracDom.Models.Dtos.FacultyDto;
using PawełGryglewiczLab6PracDom.Models.Dtos.LecturerDto;
using PawełGryglewiczLab6PracDom.Models.Dtos.LessonDto;
using PawełGryglewiczLab6PracDom.Models.Dtos.RoomDto;
using PawełGryglewiczLab6PracDom.Models.Dtos.StudentDto;
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
            LecturerMaps();
            StudentMaps();
            LessonMaps();
        }

        private void FacultyMaps()
        {
            CreateMap<Faculty, FacultyDtoForGetResponse>();
            CreateMap<Faculty, FacultyDtoForPostPutResponse>();
            CreateMap<FacultyDtoForPostPutResponse, Faculty>();
            CreateMap<Faculty, FacultyDtoForLecturerStudentBuildingDtos>();
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

        private void LecturerMaps()
        {
            CreateMap<Lecturer, LecturerDtoForGetResponses>();
            CreateMap<LecturerDtoForPostPutResponses, Lecturer>();
            CreateMap<Lecturer, LecturerDtoForFacultyDto>();
            CreateMap<Lecturer, LecturerDtoForLessonDto>();
        }

        private void StudentMaps()
        {
            CreateMap<Student, StudentDtoForGetResponses>();
            CreateMap<StudentDtoForPostPutResponses, Student>();
            CreateMap<Student, StudentDtoForFacultyLessonDtos>();
        }

        private void LessonMaps()
        {
            CreateMap<Lesson, LessonDtoForGetResponses>();
            CreateMap<LessonDtoForPostPutResponses, Lesson>();
            CreateMap<Lesson, LessonDtoForRoomStudentDtos>();
        }
    }
}
