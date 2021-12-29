using PawełGryglewiczLab6PracDom.Models.Dtos.Faculty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models.Dtos
{
    /// <summary>
    /// Klasa odpowiadająca za zwrot odpowiedniego obiektu DTO przy zapytaniu GetAll
    /// </summary>
    public class GetAllFacultiesDtoResponse
    {
        public List<FacultyDtoForGetResponse> Faculties { get; set; }
    }



}
