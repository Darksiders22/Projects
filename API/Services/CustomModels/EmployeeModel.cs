namespace Services.CustomModels
{
    using Services.CustomModels.Interfaces;
    using System.ComponentModel.DataAnnotations;

    public class EmployeeModel : ICustomModel
    {
        public int Id { get; set; }
        public string EmployeeNumber { get; set; }

        public string Telephone { get; set; }

        public int BankAccount { get; set; }
        [Required]
        public int PersonId { get; set; }
        [Required]
        public int DepartmentId { get; set; }

    }
}