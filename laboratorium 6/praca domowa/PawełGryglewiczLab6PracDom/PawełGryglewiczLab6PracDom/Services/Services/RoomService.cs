using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PawełGryglewiczLab6PracDom.Models;
using PawełGryglewiczLab6PracDom.Models.Dtos.RoomDto;
using PawełGryglewiczLab6PracDom.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Services.Services
{
    public class RoomService : IRoomService
    {
        /// <summary>
        /// Referencja do bazy danych
        /// </summary>
        private DatabaseContext _context;

        /// <summary>
        /// Referencja do mappera
        /// </summary>
        private IMapper _mapper;

        public RoomService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<RoomDtoForGetResponses> GetAll()
        {
            //Pobranie sal z bazy danych
            var rooms = _context.Rooms.Include(r => r.Building).Include(r => r.Lessons).ToList();

            //Mapowanie na dto
            var roomsDto = _mapper.Map<List<RoomDtoForGetResponses>>(rooms);
            return roomsDto;
        }

        public RoomDtoForGetResponses GetById(int id)
        {
            try
            {
                //Odczyt pokoju z bazy danych
                var room = _context.Rooms.Where(r => r.Id == id).Include(r => r.Building).Include(r => r.Lessons).Single();

                //Mapowanie na dto
                var roomDto = _mapper.Map<RoomDtoForGetResponses>(room);
                return roomDto;
            }
            catch (InvalidOperationException e)
            {
                return null;
            }
        }

        public RoomDtoForGetResponses GetByNumber(char category, int buildingNumber, int roomNumber)
        {
            //Sprawdzenie czy istnieje wybrany budynek
            if (!(_context.Buildings.Any(b => b.Category == category && b.Number == buildingNumber)))
            {
                return null;
            }

            //Odczyt id wybranego budynku
            int buildingId = _context.Buildings.Where(b => b.Category == category && b.Number == buildingNumber).Single().Id;

            //Sprawdzenie czy istnieje wybrana sala w danym budynku
            if (!(_context.Rooms.Where(r => r.BuildingId == buildingId).Any(r => r.Number == roomNumber)))
            {
                return null;
            }

            //Odczyt sali z bazy danych
            var room = _context.Rooms.Where(r => r.BuildingId == buildingId && r.Number == roomNumber).Include(r => r.Building).Include(r => r.Lessons).Single();

            //Mapowanie na dto
            var roomDto = _mapper.Map<RoomDtoForGetResponses>(room);
            return roomDto;
        }

        public List<RoomDtoForGetResponses> GetByBuilding(char category, int buildingNumber)
        {
            //Sprawdzenie czy istnieje wybrany budynek
            if (!(_context.Buildings.Any(b => b.Category == category && b.Number == buildingNumber)))
            {
                return null;
            }

            //Odczyt wybranego budynku z bazy danych
            var building = _context.Buildings.Where(b => b.Category == category && b.Number == buildingNumber).Include(b => b.Rooms).ThenInclude(r => r.Lessons).Single();

            //Odczyt sal w danym budynku
            var rooms = building.Rooms;

            //Mapowanie na dto
            var roomDto = _mapper.Map<List<RoomDtoForGetResponses>>(rooms);
            return roomDto;
        }

        public bool DeleteById(int id)
        {
            try
            {
                //Odczyt pokoju z bazy danych
                Room room = _context.Rooms.Where(r => r.Id == id).Single();

                //Usunięcie sali z bazy danych
                _context.Rooms.Remove(room);
                _context.SaveChanges();
                return true;


            }
            catch (InvalidOperationException e)
            {
                return false;
            }
        }

        public bool DeleteByNumber(char category, int buildingNumber, int roomNumber)
        {
            //Sprawdzenie czy istnieje wybrany budynek
            if (!(_context.Buildings.Any(b => b.Category == category && b.Number == buildingNumber)))
            {
                return false;
            }

            //Odczyt wybranego budynku z bazy danych
            int buildingId = _context.Buildings.Where(b => b.Category == category && b.Number == buildingNumber).Single().Id;

            try
            {
                //Odczyt sali z bazy danych
                Room room = _context.Rooms.Where(r => r.BuildingId == buildingId && r.Number == roomNumber).Single();

                //Usunięcie sali z bazy danych
                _context.Rooms.Remove(room);
                _context.SaveChanges();
                return true;
            }
            catch (InvalidOperationException e)
            {
                return false;
            }

        }

        public int PutById(int id, RoomDtoForPostPutResponses roomDto)
        {
            try
            {
                //Odczyt edytowanego obiektu
                Room entity = _context.Rooms.Where(r => r.Id == id).Single();

                //Sprawdzenie czy budynek, do którego przypisywana jest sala ,istnieje
                if (!(_context.Buildings.Any(b => b.Id == roomDto.BuildingId)))
                {
                    return -2;
                }

                //Sprawdzenie czy numer sali jest poprawny
                if (roomDto.Number < 1)
                {
                    return -5;
                }

                //Sprawdzenie czy liczba miejsc jest poprawna
                if (roomDto.NumberOfPlaces < 2)
                {
                    return -6;
                }

                //Sprawdzenie czy numer sali jest unikalny w danym budynku
                if (_context.Rooms.Where(r => r.BuildingId == roomDto.BuildingId).Any(r => r.Number == roomDto.Number))
                {
                    var suspectedDuplicate = _context.Rooms.Where(r => r.BuildingId == roomDto.BuildingId && r.Number == roomDto.Number).SingleOrDefault();
                    //Sprawdzenie czy powtarzające się dane należa do edytowanego obiektu
                    if (suspectedDuplicate.Id != id)
                    {
                        return -3;
                    }
                }

                //Sprawdzenie czy piętro, na którym jest sala, istnieje
                if (_context.Buildings.Where(b => b.Id == roomDto.BuildingId).Single().NumberOfFloors < roomDto.FloorNumber || roomDto.FloorNumber < -1)
                {
                    return -4;
                }

                //Mapowanie odpowiedzi klienta na obiekt modelu
                Room room = _mapper.Map<Room>(roomDto);

                //Uzupełnienie zmodyfikowanego obiektu o odpowiednie ID
                room.Id = entity.Id;

                //Zapis zmienionych danych do bazy
                _context.Entry(entity).CurrentValues.SetValues(room);
                _context.SaveChanges();
                return 0;

            }
            catch (InvalidOperationException e)
            {
                return -1;
            }
        }

        public int PutByNumber(char category, int buildingNumber, int roomNumber, RoomDtoForPostPutResponses roomDto)
        {
            //Sprawdzenie czy istnieje wybrany budynek
            if (!(_context.Buildings.Any(b => b.Category == category && b.Number == buildingNumber)))
            {
                return -1;
            }

            //Odczyt wybranego budynku z bazy danych
            int buildingId = _context.Buildings.Where(b => b.Category == category && b.Number == buildingNumber).Single().Id;

            try
            {
                //Odczyt sali z bazy danych
                Room entity = _context.Rooms.Where(r => r.BuildingId == buildingId && r.Number == roomNumber).Single();

                //Sprawdzenie czy budynek, do którego przypisywana jest sala, istnieje
                if (!_context.Buildings.Any(b => b.Id == roomDto.BuildingId))
                {
                    return -2;
                }

                //Sprawdzenie czy numer sali jest poprawny
                if (roomDto.Number < 1)
                {
                    return -5;
                }

                //Sprawdzenie czy liczba miejsc jest poprawna
                if (roomDto.NumberOfPlaces < 2)
                {
                    return -6;
                }

                //Sprawdzenie czy numer sali jest unikalny w danym budynku
                if (_context.Rooms.Where(r => r.BuildingId == roomDto.BuildingId).Any(r => r.Number == roomDto.Number))
                {
                    var suspectedDuplicate = _context.Rooms.Where(r => r.BuildingId == roomDto.BuildingId && r.Number == roomDto.Number).SingleOrDefault();
                    //Sprawdzenie czy powtarzające się dane należa do edytowanego obiektu
                    if (suspectedDuplicate.Id != entity.Id)
                    {
                        return -3;
                    }
                }

                //Sprawdzenie czy piętro, na którym jest sala, istnieje
                if (_context.Buildings.Where(b => b.Id == roomDto.BuildingId).Single().NumberOfFloors < roomDto.FloorNumber || roomDto.FloorNumber < -1)
                {
                    return -4;
                }

                //Mapowanie odpowiedzi klienta na obiekt modelu
                Room room = _mapper.Map<Room>(roomDto);

                //Uzupełnienie zmodyfikowanego obiektu o odpowiednie ID
                room.Id = entity.Id;

                //Zapis zmienionych danych do bazy
                _context.Entry(entity).CurrentValues.SetValues(room);
                _context.SaveChanges();
                return 0;


            }
            catch (InvalidOperationException e)
            {
                return -1;
            }
        }

        public int Post(RoomDtoForPostPutResponses roomDto)
        {
            //Sprawdzenie czy budynek, do którego przypisywana jest sala, istnieje
            if (!_context.Buildings.Any(b => b.Id == roomDto.BuildingId))
            {
                return -2;
            }

            //Sprawdzenie czy numer sali jest poprawny
            if (roomDto.Number < 1)
            {
                return -5;
            }

            //Sprawdzenie czy liczba miejsc jest poprawna
            if(roomDto.NumberOfPlaces < 2)
            {
                return -6;
            }

            //Sprawdzenie czy numer sali jest unikalny w danym budynku
            if (_context.Rooms.Where(r => r.BuildingId == roomDto.BuildingId).Any(r => r.Number == roomDto.Number))
            {
                return -3;
            }

            //Sprawdzenie czy piętro, na którym jest sala, istnieje
            if (_context.Buildings.Where(b => b.Id == roomDto.BuildingId).Single().NumberOfFloors < roomDto.FloorNumber || roomDto.FloorNumber < -1)
            {
                return -4;
            }

            //Mapowanie odpowiedzi klienta na obiekt modelu
            Room room = _mapper.Map<Room>(roomDto);

            //Zapis do bazy danych
            _context.Add(room);
            _context.SaveChanges();
            return 0;

        }
    }
}
