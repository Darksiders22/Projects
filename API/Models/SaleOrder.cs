using Models.BaseModels;
using System;
using System.Collections.Generic;

namespace Models
{
    public class SaleOrder : BaseModel
    {
        public int Quantity { get; set; }
        public DateTime DateOfSale { get; set; }
        public string Note { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual Product Product { get; set; }
    }
}