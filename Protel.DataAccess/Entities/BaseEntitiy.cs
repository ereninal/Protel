using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protel.DataAccess.Entities
{
    public class BaseEntitiy
    {
        public Int64 Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }

    }
}
