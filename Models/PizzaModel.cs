using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Joe_s_Pizza.Models
{
    [Table("tblPizza")]
    public class PizzaModel
    {
        [Key]
        public int Pno { get; set; }

        public string Image { get; set; }
        public string PizzaName { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
    }
}