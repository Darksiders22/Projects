using System;

namespace Models.Interfaces
{
    public interface IAuditInfo
    {
        DateTime CreatedAt { get; set; }
        DateTime? ModifiedAt { get; set; }
        DateTime? DeletedAt { get; set; }
    }
}