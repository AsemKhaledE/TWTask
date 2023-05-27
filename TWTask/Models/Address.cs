namespace TWTask.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int EmployeeId { get; set; }
        public Employees? Employee { get; set; }
    }
}
