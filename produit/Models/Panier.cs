using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace produit.Models
{

    public class Panier
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateCreate { get; set; }
      
    }
}
