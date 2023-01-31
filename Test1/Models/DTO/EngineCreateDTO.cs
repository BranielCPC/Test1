using Test1.Models.DTO;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Test1.Models.DTO
{
    public class EngineCreateDTO
    {
        // to make validation[Required]
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public bool LastWork { get; set; }
    }
}

