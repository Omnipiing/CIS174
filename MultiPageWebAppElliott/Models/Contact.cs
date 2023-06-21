using System.ComponentModel.DataAnnotations;

namespace MultiPageWebAppElliott.Models
{
    public class Contact
    {
        public int ContactID { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string? ContactName { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter an address")]
        public string? Address { get; set; }

        public string Notes { get; set; }

    }
}
