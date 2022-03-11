using produit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace produit.Repositorie
{
    public interface IProduitRepository
    {
        Task<IEnumerable<Produit>> Get();
        Task<Produit> Get(int id);
        //Task<Produit> Create(Produit produit);
        void addProduit(Produit produit);
        Task Update(Produit produit);
        Task Delete(int id);
    }
}
