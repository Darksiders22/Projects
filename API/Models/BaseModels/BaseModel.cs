using Models.Interfaces;
using System;

namespace Models.BaseModels
{
    public class BaseModel : IBaseModel, IAuditInfo
    {

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}