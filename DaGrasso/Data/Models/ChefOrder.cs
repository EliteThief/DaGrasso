using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaGrasso.Data.Models
{
    public class ChefOrder
    {
        public Order Order { get; set; }
        public bool IsAccepted { get; set; } = false;
        public bool IsDone { get; set; } = false;
    }
}
