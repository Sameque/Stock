using System;

namespace Entities.Base
{
    public abstract class BaseEntity
    {

        public BaseEntity()
        {
            Deleted = false;
            Created = DateTime.Now;
            Updated = DateTime.Now;
        }

        public int Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
