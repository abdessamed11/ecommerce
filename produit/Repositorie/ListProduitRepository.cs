using Microsoft.EntityFrameworkCore;
using produit.Data;
using produit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace produit.Repositorie
{
    public class ListProduitRepository : IlistProduitRepository
    {
        private readonly ApplicationDbContext _context;
        public ListProduitRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ListProduit> Create(ListProduit listProduit)
        {
            _context.listProduits.Add(listProduit);
            await _context.SaveChangesAsync();
            return listProduit;
        }

        public async Task Delete(int id)
        {
            var ProduitToDelete = await _context.listProduits.FindAsync(id);
            _context.listProduits.Remove(ProduitToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ListProduit>> Get()
        {
            return await _context.listProduits.ToListAsync();
        }

        public async Task<ListProduit> Get(int id)
        {
            return await _context.listProduits.FindAsync(id);
        }

        public async Task Update(ListProduit listProduit)
        {
            _context.Entry(listProduit).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
