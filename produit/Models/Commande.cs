using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace produit.Models
{
    public class Commande
    {
        [Key]
        public  int Id { get; set;}
        public string Status { get; set; }

        [ForeignKey("IdlistProd")]

        public int IdlistProd { get; set; }
        public ListProduit listProduit { get; set; }
    }
}
