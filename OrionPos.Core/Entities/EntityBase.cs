using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionPos.Core.Entities
{
    public class EntityBase:IEntityBase
    {
        public int Id { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }=DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
