using Project_Curd.CustomValidator;
using System.ComponentModel.DataAnnotations;

namespace Project_Curd.Models
{
    public class TeacherModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [SkillsValidate(Allowed= new string[] {"ASP .NET","EF Core","ASP.NET Core","WEB API"},ErrorMessage ="Your skills are invalid")]
        public string? Skills {  get; set; }

        [Range(50,100)]
        public int TotalStudents { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public DateTime AddedOn  { get; set;}
    }
}
