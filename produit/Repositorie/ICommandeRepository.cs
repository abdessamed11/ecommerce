using produit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace produit.Repositorie
{
    public interface ICommandeRepository
    {
        Task<IEnumerable<Commande>> Get();
        Task<Commande> Get(int id);
        Task<Commande> Create(Commande commande);
        Task Update(Commande commande);
        Task Delete(int id);
    }
}
