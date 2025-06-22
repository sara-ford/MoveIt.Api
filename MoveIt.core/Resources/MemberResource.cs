namespace MoveIt.Core.Resources
{
    public class MemberResource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateOnly? JoinDate { get; set; }
    }
}
