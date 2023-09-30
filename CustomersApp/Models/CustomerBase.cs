using System.ComponentModel.DataAnnotations;

namespace CustomerApp.Models
{
    public class CustomerBase
    {
        [Required]
        public string? Id { get; set; } = string.Empty;
        public string? Salutation { get; set; } = string.Empty;
        public string? Initials { get; set; } = string.Empty;
        [Display(Name = "First Name")]
        public string? Firstname { get; set; } = string.Empty;
        public string? Firstname_ascii { get; set; } = string.Empty;
        public string? Gender { get; set; } = string.Empty;
        public string? Firstname_country_rank { get; set; } = string.Empty;
        public string? Firstname_country_frequency { get; set; } = string.Empty;
        [Display(Name = "Last Name")]
        public string? Lastname { get; set; } = string.Empty;
        public string? Lastname_ascii { get; set; } = string.Empty;
        public string? Lastname_country_rank { get; set; } = string.Empty;
        public string? Lastname_country_frequency { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"^[_a-z0-9]+(\.[_a-z0-9]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$", ErrorMessage ="Invalid Email Format")]
        public string? Email { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        [Display(Name ="Country Code")]
        public string? Country_code { get; set; } = string.Empty;
        public string? Country_code_alpha { get; set; } = string.Empty;
        public string? Country_name { get; set; } = string.Empty;
        public string? Primary_language_code { get; set; } = string.Empty;
        public string? Primary_language { get; set; } = string.Empty;
        public float? Balance { get; set; } = 0;
        [Display(Name ="Phone Number")]
        public string? Phone_Number { get; set; } = string.Empty;
        public string? Currency { get; set; } = string.Empty;

    }
}
