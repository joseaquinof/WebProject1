using System.ComponentModel.DataAnnotations;

namespace WebProject1.Models
{
    public class SelectedMemberModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Email { get; set; }
        
        public string Dob { get; set; }
        public string PhoneNumber { get; set; }

        public string PhotoLarge { get; set; }
    }
}
