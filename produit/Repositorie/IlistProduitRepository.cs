using produit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace produit.Repositorie
{
    public interface IlistProduitRepository
    {
        Task<IEnumerable<ListProduit>> Get();
        Task<ListProduit> Get(int id);
        Task<ListProduit> Create(ListProduit listProduit);
        Task Update(ListProduit listProduit);
        Task Delete(int id);
    }
}
