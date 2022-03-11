using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace produit.Models
{
    public class Image
    {
        public int Id { get; set; }
        [NotMapped]
        public IFormFile FileProduit { get; set; }

        //[ForeignKey("ProduitId")]
        //public int ProduitId { get; set; }
        //public Produit Produit { get; set; }

    }
}
