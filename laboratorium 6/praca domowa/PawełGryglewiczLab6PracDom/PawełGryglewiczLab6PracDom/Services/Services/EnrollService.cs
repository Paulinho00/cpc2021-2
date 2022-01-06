using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PawełGryglewiczLab6PracDom.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Services.Services
{
    public class EnrollService : IEnrollService
    {
        /// <summary>
        /// Referencja do bazy danych
        /// </summary>
        private DatabaseContext _context;

        public EnrollService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
        }


        public bool Delete(int studentId, int lessonId)
        {
            try
            {
                //Pobranie studenta z bazy danych
                var student = _context.Students.Where(s => s.Id == studentId).Single();

                //Pobranie zajęć z bazy danych
                var lesson = _context.Lessons.Where(l => l.Id == lessonId).Single();

                //Usunięcie studenta z zajęć
                lesson.Students.Remove(student);
                _context.SaveChanges();
                return true;
            }
            catch (InvalidOperationException e)
            {
                return false;
            }
        }

        public int Post(int studentId, int lessonId)
        {
            try
            {
                //Pobranie studenta z bazy danych
                var student = _context.Students.Where(s => s.Id == studentId).Single();

                //Pobranie zajęć z bazy danych
                var lesson = _context.Lessons.Where(l => l.Id == lessonId).Include(r => r.Room).Single();

                //Sprawdzenie czy student nie jest już zapisany na zajęcia w tym samym czasie
                if (student.Lessons.Any(l => l.Date == lesson.Date))
                {
                    return -1;
                }

                //Pobranie liczby studentów zapisanych na zajęcia
                int numberOfStudents = lesson.Students.Count();

                //Sprawdzenie czy jest wystarczająca liczba miejsc
                if(numberOfStudents+1 > lesson.Room.NumberOfPlaces)
                {
                    return -2;
                }
                
                //Zapis do bazy danych
                lesson.Students.Add(student);
                _context.SaveChanges();
                return 0;

            }
            catch (InvalidOperationException e)
            {
                return -3;
            }
        }

    }
}
