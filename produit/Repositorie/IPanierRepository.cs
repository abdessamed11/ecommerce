using produit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace produit.Repositorie
{
   public interface IPanierRepository
    {
        Task<IEnumerable<Panier>> Get();
        Task<Panier> Get(int id);
        Task<Panier> Create(Panier panier);
        Task Update(Panier panier);
        Task Delete(int id);
    }
}
