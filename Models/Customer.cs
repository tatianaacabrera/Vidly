
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Birthdate")]
        public DateTime? Birthdate { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        [Display(Name = "Membership type")]
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}
