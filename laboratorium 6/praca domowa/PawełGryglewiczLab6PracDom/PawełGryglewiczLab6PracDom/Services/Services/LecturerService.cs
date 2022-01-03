using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PawełGryglewiczLab6PracDom.Models;
using PawełGryglewiczLab6PracDom.Models.Dtos.LecturerDto;
using PawełGryglewiczLab6PracDom.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Services.Services
{
    public class LecturerService : ILecturerService
    {
        /// <summary>
        /// Referencja do bazy danych
        /// </summary>
        private DatabaseContext _context;

        /// <summary>
        /// Referencja do mappera
        /// </summary>
        private IMapper _mapper;

        public LecturerService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<LecturerDtoForGetResponses> GetAll()
        {
            //Pobranie prowadzących z bazy danych
            var lecturers = _context.Lecturers.Include(l => l.Faculty).ToList();

            //Mapowanie na dto
            var lecturerDto = _mapper.Map<List<LecturerDtoForGetResponses>>(lecturers);

            return lecturerDto;
        }

        public LecturerDtoForGetResponses GetById(int id)
        {
            try
            {
                //Pobranie prowadzącego z bazy danych
                var lecturer = _context.Lecturers.Where(l => l.Id == id).Include(l => l.Faculty).Single();

                //Mapowanie na dto
                var lecturerDto = _mapper.Map<LecturerDtoForGetResponses>(lecturer);

                return lecturerDto;
            }
            catch (InvalidOperationException e)
            {
                return null;
            }
        }

        public List<LecturerDtoForGetResponses> GetByFacultyId(int facultyId)
        {
            //Sprawdzenie czy istnieje wydział o podanym id
            if (_context.Faculties.Any(f => f.Id == facultyId))
            {
                //Pobranie prowadzących z bazy danych
                var lecturers = _context.Lecturers.Where(l => l.FacultyId == facultyId).Include(l => l.Faculty).ToList();

                //Mapowanie na dto
                var lecturersDto = _mapper.Map<List<LecturerDtoForGetResponses>>(lecturers);

                return lecturersDto;
            }
            else
            {
                return null;
            }
        }

        public List<LecturerDtoForGetResponses> GetByFacultyNumber(int facultyNumber)
        {
            //Sprawdzenie czy istnieje wydział o danym numerze
            if (_context.Faculties.Any(f => f.Number == facultyNumber))
            {
                //Pobranie id wybranego wydziału
                int facultyId = _context.Faculties.Where(f => f.Number == facultyNumber).Single().Id;

                //Pobranie prowadzących z bazy danych
                var lecturers = _context.Lecturers.Where(l => l.FacultyId == facultyId).Include(l => l.Faculty).ToList();

                //Mapowanie na dto
                var lecturersDto = _mapper.Map<List<LecturerDtoForGetResponses>>(lecturers);

                return lecturersDto;
            }
            else
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                //Pobranie prowadzącego z bazy danych
                var lecturer = _context.Lecturers.Where(l => l.Id == id).Include(l => l.Faculty).Single();

                //Usunięcie prowadzącego z bazy danych
                _context.Lecturers.Remove(lecturer);
                _context.SaveChanges();
                return true;

            }
            catch (InvalidOperationException e)
            {
                return false;
            }
        }

        public int Put(int id, LecturerDtoForPostPutResponses lecturerDto)
        {
            try
            {
                //Pobranie prowadzącego z bazy danych
                var entity = _context.Lecturers.Where(l => l.Id == id).Single();

                //Sprawdzenie czy długość numeru pesel jest odpowiednia i czy zawiera tylko liczby
                if (lecturerDto.Pesel.Length != 11 || !lecturerDto.Pesel.All(char.IsDigit))
                {
                    return -1;
                }

                //Sprawdzenie czy pesel nie powtarza się
                if (_context.Lecturers.Any(l => l.Pesel.Equals(lecturerDto.Pesel)))
                {
                    var potentialDuplicate = _context.Lecturers.Where(l => l.Pesel.Equals(lecturerDto.Pesel)).Single();
                    if (potentialDuplicate.Id != id)
                    {
                        return -4;
                    }
                }
                else if (_context.Students.Any(s => s.Pesel.Equals(lecturerDto.Pesel)))
                {
                    return -4;
                }

                

                //Sprawdzenie czy wydział do którego należy prowadzący istnieje
                if (!_context.Faculties.Any(f => f.Id == lecturerDto.FacultyId))
                {
                    return -2;
                }

                

                //Mapowanie na model
                var lecturer = _mapper.Map<Lecturer>(lecturerDto);

                //Uzupełnienie zmodyfikowanego obiektu o id
                lecturer.Id = id;

                //Zapis zmienionych danych do bazy
                _context.Entry(entity).CurrentValues.SetValues(lecturer);
                _context.SaveChanges();
                return 0;

            }
            catch (InvalidOperationException e)
            {
                return -3;
            }
        }

        public int Post(LecturerDtoForPostPutResponses lecturerDto)
        {
            //Sprawdzenie czy długość numeru pesel jest odpowiednia i czy zawiera tylko liczby
            if (lecturerDto.Pesel.Length != 11 || !lecturerDto.Pesel.All(char.IsDigit))
            {
                return -1;
            }

            //Sprawdzenie czy pesel nie powtarza się
            if (_context.Lecturers.Any(l => l.Pesel.Equals(lecturerDto.Pesel)) || _context.Students.Any(s => s.Pesel.Equals(lecturerDto.Pesel)))
            {
                return -4;
            }

            //Sprawdzenie czy wydział do którego należy prowadzący istniej
            if (!_context.Faculties.Any(f => f.Id == lecturerDto.FacultyId))
            {
                return -2;
            }

            //Mapowanie na model
            var lecturer = _mapper.Map<Lecturer>(lecturerDto);

            //Dodanie prowadzącego do bazy danych
            _context.Add(lecturer);
            _context.SaveChanges();
            return 0;
        }
    }
}
