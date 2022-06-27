using Canki.Common.DTOs.Base;

namespace Canki.Common.DTOs.User
{
    public class UserRequest : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string ImageUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
