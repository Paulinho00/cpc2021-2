using PawełGryglewiczLab6PracDom.Models.Dtos.BuildingDto;
using PawełGryglewiczLab6PracDom.Models.Dtos.LecturerDto;
using PawełGryglewiczLab6PracDom.Models.Dtos.StudentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models.Dtos.FacultyDto
{

    /// <summary>
    /// Obiekt DTO klasy Faculty do zapytań GET
    /// </summary>
    public class FacultyDtoForGetResponse
    {
        /// <summary>
        /// Klucz główny
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Numer wydziału
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Pełna nazwa wydziału
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Lista budynków należących do wydziału
        /// </summary>
        public ICollection<BuildingDtoForFacultyDto> Buildings { get; set; }

        /// <summary>
        /// Lista studentów na wydziale
        /// </summary>
        public ICollection<StudentDtoForFacultyDto> Students { get; set; }

        /// <summary>
        /// Lista prowadzących pracujących na wydziale
        /// </summary>
        public ICollection<LecturerDtoForFacultyDto> Lecturers { get; set; }
    }
}
