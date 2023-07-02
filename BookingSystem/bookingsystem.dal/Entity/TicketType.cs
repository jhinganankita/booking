
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.dal.Entity
{
    [Table("TicketType")]
    public class TicketType
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(20, ErrorMessage = "Name cannot be greater than 20 characters")]
        public string Name { get; set; }

    }
}
