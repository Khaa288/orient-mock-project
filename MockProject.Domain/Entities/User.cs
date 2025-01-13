namespace MockProject.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
