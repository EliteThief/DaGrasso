using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DaGrasso.Models;

namespace DaGrasso.Data.Models
{
    public class PizzaTopping
    {
        
        public int PizzaId { get; set; }
        
        public int ToppingId { get; set; }

        public  Pizza Pizza { get; set; }
        
        public  Topping Topping{ get; set; }
    }
}
