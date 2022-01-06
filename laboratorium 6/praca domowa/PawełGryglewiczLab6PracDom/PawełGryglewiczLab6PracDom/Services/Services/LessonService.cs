using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PawełGryglewiczLab6PracDom.Models;
using PawełGryglewiczLab6PracDom.Models.Dtos.LessonDto;
using PawełGryglewiczLab6PracDom.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Services.Services
{
    public class LessonService : ILessonService
    {
        /// <summary>
        /// Referencja do bazy danych
        /// </summary>
        private DatabaseContext _context;

        /// <summary>
        /// Referencja do mappera
        /// </summary>
        private IMapper _mapper;

        public LessonService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<LessonDtoForGetResponses> GetAll()
        {
            //Pobranie wszystkich zajęć z bazy danych
            var lessons = _context.Lessons.Include(l => l.Room).ThenInclude(r => r.Building).Include(l => l.Lecturer).ThenInclude(l => l.Faculty).Include(l => l.Students).ToList();

            //Mapowanie na dto
            var lessonsDto = _mapper.Map<List<LessonDtoForGetResponses>>(lessons);
            return lessonsDto;
        }

        public LessonDtoForGetResponses GetById(int id)
        {
            try
            {
                //Pobranie zajęć z bazy danych
                var lesson = _context.Lessons.Where(l => l.Id == id).Include(l => l.Room).ThenInclude(r => r.Building).Include(l => l.Lecturer).ThenInclude(l => l.Faculty).Include(l => l.Students).Single();

                //Mapowanie na dto
                var lessonDto = _mapper.Map<LessonDtoForGetResponses>(lesson);
                return lessonDto;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public List<LessonDtoForGetResponses> GetByLecturerId(int lecturerId)
        {
            //Sprawdzenie czy dany wykładowca ma przypisane zajęcia
            if(!_context.Lessons.Any(l => l.LecturerId == lecturerId))
            {
                return null;
            }

            //Pobranie zajęć z bazy danych
            var lessons = _context.Lessons.Where(l => l.LecturerId == lecturerId).Include(l => l.Room).ThenInclude(r => r.Building).Include(l => l.Lecturer).ThenInclude(l => l.Faculty).Include(l => l.Students).ToList();

            //Mapowanie na dto
            var lessonsDto = _mapper.Map<List<LessonDtoForGetResponses>>(lessons);
            return lessonsDto;
        }

        public List<LessonDtoForGetResponses> GetByRoomId(int roomId)
        {
            //Sprawdzenie czy dana sala ma przypisane zajęcia
            if (!_context.Lessons.Any(l => l.RoomId == roomId))
            {
                return null;
            }

            //Pobranie zajęć z bazy danych
            var lessons = _context.Lessons.Where(l => l.RoomId == roomId).Include(l => l.Room).ThenInclude(r => r.Building).Include(l => l.Lecturer).ThenInclude(l => l.Faculty).Include(l => l.Students).ToList();

            //Mapowanie na dto
            var lessonsDto = _mapper.Map<List<LessonDtoForGetResponses>>(lessons);
            return lessonsDto;
        }

        public bool Delete(int id)
        {
            try
            {
                //Odczyt zajęć z bazy danych
                var lesson = _context.Lessons.Where(l => l.Id == id).Single();

                //Usunięcie z bazy danych
                _context.Lessons.Remove(lesson);
                _context.SaveChanges();
                return true;
            }
            catch (InvalidOperationException e)
            {
                return false;
            }
        }

        public int Put(int id, LessonDtoForPostPutResponses lessonDto)
        {
            try
            {
                //Odczyt edytowanego zajęcia
                var entity = _context.Lessons.Where(l => l.Id == id).Single();

                //Sprawdzenie czy data zajęć nie jest wcześniejsza niż data dodania
                if (DateTime.Now > lessonDto.Date)
                {
                    return -1;
                }

                //Sprawdzenie czy pole z przedmiotem jest puste
                if (String.IsNullOrWhiteSpace(lessonDto.Subject))
                {
                    return -2;
                }

                //Sprawdzenie czy pzypisany prowadzący istnieje
                if (!_context.Lecturers.Any(l => l.Id == lessonDto.LecturerId))
                {
                    return -3;
                }

                //Sprawdzenie czy prowadzący nie ma już zajęć w tym czasie 
                if (_context.Lessons.Where(l => l.LecturerId == lessonDto.LecturerId).Any(l => l.Date == lessonDto.Date))
                {
                    var potentialConflictingLesson = _context.Lessons.Where(l => l.LecturerId == lessonDto.LecturerId && l.Date == lessonDto.Date).Single();
                    //Sprawdzenie czy konliktujące zajęcia nie są edytowanymi zajęciami
                    if (potentialConflictingLesson.Id != id)
                    {
                        return -4;
                    }
                }

                //Sprawdzenie czy sala przypisana do zajęć istnieje
                if (!_context.Rooms.Any(r => r.Id == lessonDto.RoomId))
                {
                    return -5;
                }

                //Sprawdzenie czy w sali nie ma już zajęć w tym czasie
                if (_context.Lessons.Where(l => l.RoomId == lessonDto.RoomId).Any(l => l.Date == lessonDto.Date))
                {
                    var potentialConflictingLesson = _context.Lessons.Where(l => l.RoomId == lessonDto.RoomId && l.Date == lessonDto.Date).Single();
                    //Sprawdzenie czy konfliktujące zajęcia nie są edytowanymi zajęciami
                    if (potentialConflictingLesson.Id != id)
                    {
                        return -6;
                    }
                }

                //Mapowanie na obiekt modelu
                var lesson = _mapper.Map<Lesson>(lessonDto);

                //Zapisanie zmienionych danych w bazie danych
                _context.Entry(entity).CurrentValues.SetValues(lessonDto);
                _context.SaveChanges();
                return 0;
            }
            catch (InvalidOperationException e)
            {
                return -7;
            }

        }

        public int Post(LessonDtoForPostPutResponses lessonDto)
        {

            //Sprawdzenie czy data zajęć nie jest wcześniejsza niż data dodania
            if (DateTime.Now > lessonDto.Date)
            {
                return -1;
            }

            //Sprawdzenie czy pole z przedmiotem jest puste
            if (String.IsNullOrWhiteSpace(lessonDto.Subject))
            {
                return -2;
            }

            //Sprawdzenie czy pzypisany prowadzący istnieje
            if (!_context.Lecturers.Any(l => l.Id == lessonDto.LecturerId))
            {
                return -3;
            }

            //Sprawdzenie czy prowadzący nie ma już zajęć w tym czasie 
            if (_context.Lessons.Where(l => l.LecturerId == lessonDto.LecturerId).Any(l => l.Date == lessonDto.Date))
            {
                return -4;
            }

            //Sprawdzenie czy sala przypisana do zajęć istnieje
            if (!_context.Rooms.Any(r => r.Id == lessonDto.RoomId))
            {
                return -5;
            }

            //Sprawdzenie czy w sali nie ma już zajęć w tym czasie
            if (_context.Lessons.Where(l => l.RoomId == lessonDto.RoomId).Any(l => l.Date == lessonDto.Date))
            {
                return -6;
            }

            //Mapowanie na obiekt modelu
            var lesson = _mapper.Map<Lesson>(lessonDto);

            //Zapisanie zajęć w bazie danych
            _context.Lessons.Add(lesson);
            _context.SaveChanges();
            return 0;
        }
        

    }
}
