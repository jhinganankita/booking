using System.ComponentModel.DataAnnotations;

namespace BookingSystem.ViewModels
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "User name is required")]
        [MaxLength(250, ErrorMessage = "User name cannot be greater than 250 characters")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [MaxLength(20, ErrorMessage = "FirstName cannot be greater than 20 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        [MaxLength(20, ErrorMessage = "LastName cannot be greater than 20 characters")]
        public string LastName { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}