using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using produit.ModelAuth;
using produit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace produit.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
            
        }
        public DbSet<Produit> produits { get; set; }
        public DbSet<Catégorie> catégories  { get; set; }
        public DbSet<Commande> commandes { get; set; }
        public DbSet<Panier> paniers { get; set; }
        public DbSet<Image> images { get; set; }
        public DbSet<ListProduit> listProduits { get; set; }
        //public DbSet<User> User { get; set; }
    }
}
