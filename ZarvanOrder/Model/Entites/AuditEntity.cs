using System;
using ZarvanOrder.Interfaces.Entites;

namespace ZarvanOrder.Model.Entites
{
    public abstract class AuditDeleteEntity<TIdentity> : 
        DeleteEntity,
        IAuditEntity<TIdentity> 
        where TIdentity : struct
    {
        public TIdentity Id { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime? LastModified { get; set; }
        public virtual string LastModifiedBy { get; set; }

    }
}
