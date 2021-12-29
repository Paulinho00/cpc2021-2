using AutoMapper;
using PawełGryglewiczLab6PracDom.Models;
using PawełGryglewiczLab6PracDom.Models.Dtos;
using PawełGryglewiczLab6PracDom.Models.Dtos.Faculty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Services
{
    public class FacultyService : IFacultyService
    {
        /// <summary>
        /// Referencja do bazy danych
        /// </summary>
        private readonly DatabaseContext _context;

        /// <summary>
        /// Referencja do mappera
        /// </summary>
        private readonly IMapper _mapper;

        public FacultyService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool DeleteById(int id)
        {
            try
            {
                Faculty faculty = _context.Faculties.Where(f => f.Id == id).Single();
                //Usunięcie z bazy danych
                _context.Faculties.Remove(faculty);
                _context.SaveChanges();
                return true;
            } catch(InvalidOperationException e)
            {
                return false;
            }
        }

        public List<FacultyDtoForGetResponse> GetAll()
        {
            //Pobranie listy wydziałów
            var faculties = _context.Faculties.OrderBy(f => f.Number).ToList();

            //Mapowanie listy na DTO
            var facultiesDto = new GetAllFacultiesDtoResponse { Faculties = _mapper.Map<List<FacultyDtoForGetResponse>>(faculties) };
            return facultiesDto.Faculties;
        }

        public FacultyDtoForGetResponse GetById(int id)
        {
            try
            {
                //Pobranie wydziału z bazy danych
                Faculty faculty = _context.Faculties.Where(f => f.Id == id).Single();

                //Mapowanie na DTO
                var facultyDto = (FacultyDtoForGetResponse)_mapper.Map<FacultyDtoForGetResponse>(faculty);
                return facultyDto;
            }
            catch(InvalidOperationException e)
            {
                return null;
            }
        }

        public bool Post(FacultyDtoForPostPutResponse facultyDto)
        {
            //Sprawdzenie czy dane nie powtarzają się
            if (_context.Faculties.Any(f => f.Number == facultyDto.Number) || _context.Faculties.Any(f => f.FullName.Equals(facultyDto.FullName)))
            {
                return false;
            }
            //Mapowanie na DTO
            var faculty = (Faculty)_mapper.Map<Faculty>(facultyDto);

            //Zapis obiektu do bazy danych
            _context.Faculties.Add(faculty);
            _context.SaveChanges();
            return true;
        }

        public bool Put(int id, FacultyDtoForPostPutResponse facultyDto)
        {
            try
            {
                //Sprawdzenie czy dane nie powtarzają się
                if (_context.Faculties.Any(f => f.Number == facultyDto.Number) || _context.Faculties.Any(f => f.FullName.Equals(facultyDto.FullName)))
                {
                    return false;
                }

                Faculty entity = _context.Faculties.Where(f => f.Id == id).Single();

                //Mapowanie odpowiedzi klienta na obiekt modelu
                Faculty faculty = (Faculty)_mapper.Map<Faculty>(facultyDto);

                //Uzupełnienie zmodyfikowanego obiektu o odpowiednie ID
                faculty.Id = entity.Id;

                //Zapis zmienionych danych do bazy
                _context.Entry(entity).CurrentValues.SetValues(faculty);
                _context.SaveChanges();
                return true;
            }
            catch (InvalidOperationException e)
            {
                return false;
            }

        }
    }
}
