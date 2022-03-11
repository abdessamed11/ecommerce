using Microsoft.EntityFrameworkCore;
using produit.Data;
using produit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace produit.Repositorie
{
    public class PanierRepository : IPanierRepository
    {
        private readonly ApplicationDbContext _context;
        public PanierRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Panier> Create(Panier panier)
        {
            _context.paniers.Add(panier);
            await _context.SaveChangesAsync();
            return panier;
        }

        public async Task Delete(int id)
        {
            var PanierToDelete = await _context.paniers.FindAsync(id);
            _context.paniers.Remove(PanierToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Panier>> Get()
        {
            return await _context.paniers.ToListAsync();
        }

        public async Task<Panier> Get(int id)
        {
            return await _context.paniers.FindAsync(id);
        }

        public async Task Update(Panier panier)
        {
            _context.Entry(panier).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
