using Microsoft.EntityFrameworkCore;
using produit.Data;
using produit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace produit.Repositorie
{
    public class CommandeRepository : ICommandeRepository
    {
        private readonly ApplicationDbContext _context;
        public CommandeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Commande> Create(Commande commande)
        {
            _context.commandes.Add(commande);
            await _context.SaveChangesAsync();
            return commande;
        }

        public async Task Delete(int id)
        {
            var CommandeToDelete = await _context.commandes.FindAsync(id);
            _context.commandes.Remove(CommandeToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Commande>> Get()
        {
            return await _context.commandes.ToListAsync();
        }

        public async Task<Commande> Get(int id)
        {
            return await _context.commandes.FindAsync(id);
        }

        public async Task Update(Commande commande)
        {
            _context.Entry(commande).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
