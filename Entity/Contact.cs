namespace HumanResource.Entity
{
    public class Contact:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string TimeInterval { get; set; }
        public string LinkedIn { get; set; }
        public string GitHub { get; set; }
        public string Comments { get; set; }
    }
}
