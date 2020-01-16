using Models.BaseModels;
using System.Collections.Generic;

namespace Models
{
    public class Customer : BaseModel
    {
        public Customer()
        {
            EmployeeCustomers = new HashSet<EmployeeCustomers>();
        }
        public string AccountNumber { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        public virtual ICollection<EmployeeCustomers> EmployeeCustomers { get; set; }
        public virtual SaleOrder SaleOrder { get; set; }
    }
}