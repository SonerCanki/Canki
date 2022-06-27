using Canki.Core.Entity;

namespace Canki.Model.Entities
{
    public class User:CoreEntity
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
