using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

namespace FirstResponsiveWebAppElliott.Models
{
    public class AgeFinderModel
    {
        [Required(ErrorMessage = "Please enter your name.")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Please enter your birth year.")]
        public DateTime BirthYear { get; set; }
        public int? AgeThisYear()
        {
            int age = DateTime.Now.Year - BirthYear.Year;
            if (BirthYear.Date > DateTime.Now.AddYears(-age)) age--;
			return age;
        }

    }
}
