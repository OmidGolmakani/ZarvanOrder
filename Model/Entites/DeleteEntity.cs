

using System;
using ZarvanOrder.Interfaces.Entites;

namespace ZarvanOrder.Model.Entites
{
    public abstract class DeleteEntity : IDeleteEntity
    {
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime? DeletedDate { get; set; }
        public virtual string DeletedBy { get; set; }
    }
}
