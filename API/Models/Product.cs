using Models.BaseModels;
using System.Collections.Generic;

namespace Models
{
    public class Product : BaseModel
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int CurrentQuantity { get; set; }
        public virtual ICollection<SaleOrder> SalesOrders { get; set; }
    }
}