using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PawełGryglewiczLab6PracDom.Models;
using PawełGryglewiczLab6PracDom.Models.Dtos.StudentDto;
using PawełGryglewiczLab6PracDom.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Services.Services
{

    public class StudentService : IStudentService
    {
        /// <summary>
        /// Referencja do bazy danych
        /// </summary>
        private DatabaseContext _context;

        /// <summary>
        /// Referencja do mappera
        /// </summary>
        private IMapper _mapper;

        public StudentService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<StudentDtoForGetResponses> GetAll()
        {
            //Pobranie studentów z bazy danych
            var students = _context.Students.Include(s => s.Faculty).ToList();

            //Mapowanie na dto
            var studentsDto = _mapper.Map<List<StudentDtoForGetResponses>>(students);
            return studentsDto;
        }

        public StudentDtoForGetResponses GetById(int id)
        {
            try
            {
                //Pobranie studenta z bazy danych
                var student = _context.Students.Where(s => s.Id == id).Include(s => s.Faculty).Single();

                //Mapowanie na dto
                var studentDto = _mapper.Map<StudentDtoForGetResponses>(student);
                return studentDto;
            }
            catch (InvalidOperationException e)
            {
                return null;
            }
        }

        public List<StudentDtoForGetResponses> GetByFacultyId(int facultyId)
        {
            //Sprawdzenie czy istnieje wydział o takim id
            if (_context.Faculties.Any(f => f.Id == facultyId))
            {
                //Pobranie studentów z bazy danych
                var students = _context.Students.Where(s => s.FacultyId == facultyId).Include(s => s.Faculty).ToList();

                //Mapowanie na dto
                var studentsDto = _mapper.Map<List<StudentDtoForGetResponses>>(students);
                return studentsDto;
            }
            else
            {
                return null;
            }
        }

        public List<StudentDtoForGetResponses> GetByFacultyNumber(int facultyNumber)
        {
            //Sprawdzenie czy istnieje wydział o takim numerze
            if (_context.Faculties.Any(f => f.Number == facultyNumber))
            {
                //Pobranie id wydziału
                int facultyId = _context.Faculties.Where(f => f.Number == facultyNumber).Single().Id;

                //Pobranie studentów z bazy danych
                var students = _context.Students.Where(s => s.FacultyId == facultyId).Include(s => s.Faculty).ToList();

                //Mapowanie na dto
                var studentsDto = _mapper.Map<List<StudentDtoForGetResponses>>(students);
                return studentsDto;
            }
            else
            {
                return null;
            }
        }

        public StudentDtoForGetResponses GetByIndex(int index)
        {
            try
            {
                //Pobranie danych studenta
                var student = _context.Students.Where(s => s.Index == index).Include(s => s.Faculty).Single();

                //Mapowanie na dto
                var studentDto = _mapper.Map<StudentDtoForGetResponses>(student);
                return studentDto;
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
                //Pobranie danych studenta
                var student = _context.Students.Where(s => s.Id == id).Single();

                //Usunięcie studenta
                _context.Students.Remove(student);
                _context.SaveChanges();
                return true;
            }
            catch (InvalidOperationException e)
            {
                return false;
            }
        }

        public bool DeleteByIndex(int index)
        {
            try
            {
                //Pobranie danych studenta
                var student = _context.Students.Where(s => s.Index == index).Single();

                //Usunięcie studenta
                _context.Students.Remove(student);
                _context.SaveChanges();
                return true;
            }
            catch (InvalidOperationException e)
            {
                return false;
            }
        }

        public int PutById(int id, StudentDtoForPostPutResponses studentDto)
        {
            try
            {
                //Pobranie danych studenta z bazy danych
                var entity = _context.Students.Where(s => s.Id == id).Single();

                //Sprawdzenie czy długość numeru pesel jest odpowiednia i czy zawiera tylko liczby
                if (studentDto.Pesel.Length != 11 || !studentDto.Pesel.All(char.IsDigit))
                {
                    return -1;
                }

                //Sprawdzenie czy pesel nie powtarza się
                if (_context.Lecturers.Any(l => l.Pesel.Equals(studentDto.Pesel)))
                {
                    return -2;
                }
                else if (_context.Students.Any(s => s.Pesel.Equals(studentDto.Pesel)))
                {
                    var potentialDuplicate = _context.Students.Where(s => s.Pesel.Equals(studentDto.Pesel)).Single();
                    //Sprawdzenie czy duplikat to edytowany obiekt
                    if (potentialDuplicate.Id != id)
                    {
                        return -2;
                    }
                }

                //Sprawdzenie czy indeks jest poprawny
                if (studentDto.Index >= 300000 || studentDto.Index <= 200000)
                {
                    return -3;
                }

                //Sprawdzenie czy indeks jest unikalny
                if (_context.Students.Any(s => s.Index == studentDto.Index))
                {
                    var potentialDuplicate = _context.Students.Where(s => s.Index == studentDto.Index).Single();
                    //Sprawdzenie czy duplikat to edytowany obiekt
                    if (potentialDuplicate.Id != id)
                    {
                        return -4;
                    }
                }

                //Sprawdzenie czy wybrany wydział istnieje
                if (!_context.Faculties.Any(f => f.Id == studentDto.FacultyId))
                {
                    return -5;
                }

                //Mapowanie na obiekt modelu
                var student = _mapper.Map<Student>(studentDto);

                //Uzupełnienie obiektu ze zmodyfikowanymi danymi studenta o odpowiednie Id
                student.Id = id;

                //Zmiana danych studenta w bazie danych
                _context.Entry(entity).CurrentValues.SetValues(student);
                _context.SaveChanges();
                return 0;

            }
            catch (InvalidOperationException e)
            {
                return -6;
            }
        }

        public int PutByIndex(int index, StudentDtoForPostPutResponses studentDto)
        {
            try
            {
                //Pobranie danych studenta z bazy danych
                var entity = _context.Students.Where(s => s.Index == index).Single();

                //Sprawdzenie czy długość numeru pesel jest odpowiednia i czy zawiera tylko liczby
                if (studentDto.Pesel.Length != 11 || !studentDto.Pesel.All(char.IsDigit))
                {
                    return -1;
                }

                //Sprawdzenie czy pesel nie powtarza się
                if (_context.Lecturers.Any(l => l.Pesel.Equals(studentDto.Pesel)))
                {
                    return -2;
                }
                else if (_context.Students.Any(s => s.Pesel.Equals(studentDto.Pesel)))
                {
                    var potentialDuplicate = _context.Students.Where(s => s.Pesel.Equals(studentDto.Pesel)).Single();
                    //Sprawdzenie czy duplikat to edytowany obiekt
                    if (potentialDuplicate.Id != entity.Id)
                    {
                        return -2;
                    }
                }

                //Sprawdzenie czy indeks jest poprawny
                if (studentDto.Index >= 300000 || studentDto.Index <= 200000)
                {
                    return -3;
                }

                //Sprawdzenie czy indeks jest unikalny
                if (_context.Students.Any(s => s.Index == studentDto.Index))
                {
                    var potentialDuplicate = _context.Students.Where(s => s.Index == studentDto.Index).Single();
                    //Sprawdzenie czy duplikat to edytowany obiekt
                    if (potentialDuplicate.Id != entity.Id)
                    {
                        return -4;
                    }
                }

                //Sprawdzenie czy wybrany wydział istnieje
                if (!_context.Faculties.Any(f => f.Id == studentDto.FacultyId))
                {
                    return -5;
                }

                //Mapowanie na obiekt modelu
                var student = _mapper.Map<Student>(studentDto);

                //Uzupełnienie obiektu ze zmodyfikowanymi danymi studenta o odpowiednie Id
                student.Id = entity.Id;

                //Zmiana danych studenta w bazie danych
                _context.Entry(entity).CurrentValues.SetValues(student);
                _context.SaveChanges();
                return 0;

            }
            catch (InvalidOperationException e)
            {
                return -6;
            }
        }

        public int Post(StudentDtoForPostPutResponses studentDto)
        {
            //Sprawdzenie czy długość numeru pesel jest odpowiednia i czy zawiera tylko liczby
            if (studentDto.Pesel.Length != 11 || !studentDto.Pesel.All(char.IsDigit))
            {
                return -1;
            }

            //Sprawdzenie czy pesel nie powtarza się
            if (_context.Lecturers.Any(l => l.Pesel.Equals(studentDto.Pesel)))
            {
                return -2;
            }
            else if (_context.Students.Any(s => s.Pesel.Equals(studentDto.Pesel)))
            {
                return -2;
            }

            //Sprawdzenie czy indeks jest poprawny
            if (studentDto.Index >= 300000 || studentDto.Index <= 200000)
            {
                return -3;
            }

            //Sprawdzenie czy indeks jest unikalny
            if (_context.Students.Any(s => s.Index == studentDto.Index))
            {
                return -4;
            }
            //Sprawdzenie czy wybrany wydział istnieje
            if (!_context.Faculties.Any(f => f.Id == studentDto.FacultyId))
            {
                return -5;
            }

            //Mapowanie na obiekt modelu
            var student = _mapper.Map<Student>(studentDto);

            //Dodanie studenta do bazy danych
            _context.Students.Add(student);
            _context.SaveChanges();
            return 0;
        }

    }
}
