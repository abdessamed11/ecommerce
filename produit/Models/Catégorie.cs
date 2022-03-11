using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace produit.Models
{
    public class Catégorie
    {
        [Key]
        public int Id { get; set; }

        public string NameCatégorie { get; set; }

        public string ImagePath { get; set; }

    }
}
