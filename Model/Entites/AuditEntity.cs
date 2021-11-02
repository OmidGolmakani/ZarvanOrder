using System;
using ZarvanOrder.Interfaces.Entites;

namespace ZarvanOrder.Model.Entites
{
    public abstract class AuditDeleteEntity<T>: DeleteEntity, IAuditEntity
    {
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string LastModifiedBy { get; set; }

    }
}
