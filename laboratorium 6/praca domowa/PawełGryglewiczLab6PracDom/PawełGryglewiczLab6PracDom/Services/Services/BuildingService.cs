﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PawełGryglewiczLab6PracDom.Models;
using PawełGryglewiczLab6PracDom.Models.Dtos.Building;
using PawełGryglewiczLab6PracDom.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Services.Services
{
    public class BuildingService : IBuildingService
    {
        /// <summary>
        /// Referencja do bazy danych
        /// </summary>
        private readonly DatabaseContext _context;

        /// <summary>
        /// Referencja do mappera
        /// </summary>
        private readonly IMapper _mapper;

        public BuildingService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<BuildingDtoForGetResponse> GetAll()
        {
            //Pobranie budynków z bazy danych
            var buildings = _context.Buildings.Include(b => b.Faculty).OrderBy(b => b.Faculty.Number).ToList();

            //Mapowanie listy na DTO
            var buildingsDto = _mapper.Map<List<BuildingDtoForGetResponse>>(buildings);
            return buildingsDto;
        }

        public List<BuildingDtoForGetResponse> GetByFaculty(int facultyId)
        {
            try
            {
                //Sprawdzenie czy wydział o danym id istnieje
                if (!(_context.Faculties.Any(f => f.Id == facultyId)))
                {
                    return null;
                }

                //Pobranie budynków z bazy danych
                var buildings = _context.Buildings.Include(b => b.Faculty).Where(b => b.Faculty.Id == facultyId).ToList();

                //Mapowanie listy na DTO
                var buildingsDto = _mapper.Map<List<BuildingDtoForGetResponse>>(buildings);
                return buildingsDto;
            }
            catch (InvalidOperationException e)
            {
                return null;
            }
        }

        public BuildingDtoForGetResponse GetByCategoryAndNumber(char category, int number)
        {
            try
            {
                //Pobranie budynku z bazy danych
                var building = _context.Buildings.Include(b => b.Faculty).Where(b => b.Category == category && b.Number == number).Single();

                //Mapowanie listy na DTO
                var buildingDto = _mapper.Map<BuildingDtoForGetResponse>(building);
                return buildingDto;
            }
            catch (InvalidOperationException e)
            {
                return null;
            }
        }

        public BuildingDtoForGetResponse GetById(int id)
        {
            try
            {
                //Pobranie budynku z bazy danych
                var building = _context.Buildings.Include(b => b.Faculty).Where(b => b.Id == id).Single();

                //Mapowanie listy na DTO
                var buildingDto = _mapper.Map<BuildingDtoForGetResponse>(building);
                return buildingDto;

            }
            catch (InvalidOperationException e)
            {
                return null;
            }
        }

        public bool DeleteById(int id)
        {
            try
            {
                //Pobranie budynku z bazy danych
                var building = _context.Buildings.Where(b => b.Id == id).Single();

                //Usunięcie z bazy danych
                _context.Remove(building);
                _context.SaveChanges();
                return true;
            }
            catch (InvalidOperationException e)
            {
                return false;
            }
        }

        public bool DeleteByCategoryAndNumber(char category, int number)
        {
            try
            {
                //Pobranie budynku z bazy danych
                var building = _context.Buildings.Where(b => b.Category == category && b.Number == number).Single();

                //Usunięcie z bazy danych
                _context.Remove(building);
                _context.SaveChanges();
                return true;

            }
            catch (InvalidOperationException e)
            {
                return false;
            }
        }

        public int Put(int id, BuildingDtoForPostPutResponse buildingDto)
        {
            try
            {
                //Pobranie edytowanego budynku z bazy danych
                Building entity = _context.Buildings.Where(b => b.Id == id).Single();

                //Sprawdzenie czy numer w danej kategorii nie powtarza się
                if (_context.Buildings.Where(b => b.Category == buildingDto.Category).Any(b => b.Number == buildingDto.Number))
                {
                    var suspectedDuplicate = _context.Buildings.Where(b => b.Category == buildingDto.Category && b.Number == buildingDto.Number).SingleOrDefault();
                    //Sprawdzenie czy powtarzające się dane należa do edytowanego obiektu
                    if (suspectedDuplicate.Id != id)
                    {
                        return -1;
                    }
                }

                //Sprawdzenie czy podano odpowiedni numer id wydziału
                if (!(_context.Faculties.Any(f => f.Id == buildingDto.FacultyFK)))
                {
                    return -2;
                }

                //Sprawdzenie czy rok jest poprawny
                if (buildingDto.YearOfBuild < 1900 || buildingDto.YearOfBuild > 2021)
                {
                    return -4;
                }

                //Sprawdzenie czy liczba pięter jest poprawna
                if (buildingDto.NumberOfFloors < 1 || buildingDto.NumberOfFloors > 20)
                {
                    return -5;
                }

                //Mapowanie odpowiedzi klienta na obiekt modelu
                Building building = _mapper.Map<Building>(buildingDto);

                //Uzupełnienie zmodyfikowanego obiektu o odpowiednie ID
                building.Id = entity.Id;

                //Zapis zmienionych danych do bazy
                _context.Entry(entity).CurrentValues.SetValues(building);
                _context.SaveChanges();
                return 0;

            }
            catch (InvalidOperationException e)
            {
                return -3;
            }
        }

        public int Post(BuildingDtoForPostPutResponse buildingDto)
        {
            //Sprawdzenie czy dane nie powtarzają się
            if (_context.Buildings.Where(b => b.Category == buildingDto.Category).Any(b => b.Number == buildingDto.Number))
            {
                return -1;
            }

            //Sprawdzenie czy podano odpowiedni numer id wydziału
            if (!(_context.Faculties.Any(f => f.Id == buildingDto.FacultyFK)))
            {
                return -2;
            }

            //Sprawdzenie czy rok jest poprawny
            if (buildingDto.YearOfBuild < 1900 || buildingDto.YearOfBuild > 2021)
            {
                return -4;
            }

            //Sprawdzenie czy liczba pięter jest poprawna
            if(buildingDto.NumberOfFloors < 1 || buildingDto.NumberOfFloors > 20)
            {
                return -5;
            }

            //Mapowanie na obiekt modelu
            var building = _mapper.Map<Building>(buildingDto);

            //Zapis do bazy danych
            _context.Buildings.Add(building);
            _context.SaveChanges();

            return 0;
        }
    }
}
