using System.ComponentModel.DataAnnotations;

namespace ToDo.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        [StringLength(15, MinimumLength = 4)]
        public string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password needed to be 6-20 characters long!")]
        public string Password { get; set; }
    }
}