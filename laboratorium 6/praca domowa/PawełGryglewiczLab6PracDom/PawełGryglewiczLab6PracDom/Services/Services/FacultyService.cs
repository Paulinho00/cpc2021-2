using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
            var faculties = _context.Faculties.Include(f => f.Buildings).OrderBy(f => f.Number).ToList();

            //Mapowanie listy na DTO
            var facultiesDto = _mapper.Map<List<FacultyDtoForGetResponse>>(faculties);
            return facultiesDto;
        }

        public FacultyDtoForGetResponse GetById(int id)
        {
            try
            {
                //Pobranie wydziału z bazy danych
                Faculty faculty = _context.Faculties.Where(f => f.Id == id).Include(f => f.Buildings).Single();

                //Mapowanie na DTO
                var facultyDto = _mapper.Map<FacultyDtoForGetResponse>(faculty);
                return facultyDto;
            }
            catch(InvalidOperationException e)
            {
                return null;
            }
        }

        public int Post(FacultyDtoForPostPutResponse facultyDto)
        {
            //Sprawdzenie czy nazwa wydziału nie powtarza się
            if(_context.Faculties.Any(f => f.FullName.Equals(facultyDto.FullName)))
            {
                return -1;
            }

            //Sprawdzenie czy numer wydziału nie powtarza się
            if (_context.Faculties.Any(f => f.Number == facultyDto.Number))
            {
                return -2;
            }

            //Sprawdzenie czy numer wydziału mieści się w zakresie
            if(facultyDto.Number > 20 || facultyDto.Number < 1)
            {
                return -3;
            }

            //Mapowanie na obiekt modelu
            var faculty = _mapper.Map<Faculty>(facultyDto);

            //Zapis obiektu do bazy danych
            _context.Faculties.Add(faculty);
            _context.SaveChanges();
            return 0;
        }

        public int Put(int id, FacultyDtoForPostPutResponse facultyDto)
        {
            try
            {
                //Pobranie edytowanego wydziału z bazy danych
                Faculty entity = _context.Faculties.Where(f => f.Id == id).Single();

                //Sprawdzenie czy nazwa wydziału nie powtarza się
                if (_context.Faculties.Any(f => f.FullName.Equals(facultyDto.FullName)))
                {
                    var suspectedDuplicate = _context.Faculties.Where(f => f.FullName.Equals(facultyDto.FullName)).SingleOrDefault();
                    //Sprawdzenie czy powtarzające się dane należa do edytowanego obiektu
                    if (suspectedDuplicate.Id != id)
                    {
                        return -1;
                    }
                }

                //Sprawdzenie czy numer wydziału nie powtarza się
                if (_context.Faculties.Any(f => f.Number == facultyDto.Number))
                {
                    var suspectedDuplicate = _context.Faculties.Where(f => f.Number == facultyDto.Number).SingleOrDefault();
                    //Sprawdzenie czy powtarzające się dane należa do edytowanego obiektu
                    if (suspectedDuplicate.Id != id)
                    {
                        return -2;
                    }
                }

                //Sprawdzenie czy numer wydziału mieści się w zakresie
                if (facultyDto.Number > 20 || facultyDto.Number < 1)
                {
                    return -3;
                }

                //Mapowanie odpowiedzi klienta na obiekt modelu
                Faculty faculty = _mapper.Map<Faculty>(facultyDto);

                //Uzupełnienie zmodyfikowanego obiektu o odpowiednie ID
                faculty.Id = entity.Id;

                //Zapis zmienionych danych do bazy
                _context.Entry(entity).CurrentValues.SetValues(faculty);
                _context.SaveChanges();
                return 0;
            }
            catch (InvalidOperationException e)
            {
                return -4;
            }

        }
    }
}
