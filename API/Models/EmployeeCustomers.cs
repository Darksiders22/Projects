namespace Models
{
    public class EmployeeCustomers
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}