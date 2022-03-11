using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace produit.Models
{
    
    public class Produit
    {
        [Key]
        [ForeignKey("CatégorieId")]

        public int Id { get; set; }

        public string NameProduit { get; set; } 

        public float PrixProduit { get; set; }

        public int Quantite { get; set; }

        public string ImagePath { get; set; }

        public int CatégorieId { get; set; }

        public Catégorie catégorie { get; set; }
    }
}
