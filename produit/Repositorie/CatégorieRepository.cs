using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using produit.Data;
using produit.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace produit.Repositorie
{
    public class CatégorieRepository: ICatégorieRepository
    {
        private readonly ApplicationDbContext _context;
        public CatégorieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Catégorie> Create(Catégorie catégorie, List<IFormFile> image)
        {
            foreach (var file in image)
            {
                MemoryStream ms = new();
                await file.CopyToAsync(ms);
                catégorie.ImageCatégorie = ms.ToArray();
                _context.catégories.Add(catégorie);
                await _context.SaveChangesAsync();
            }

            return catégorie;
        }

        public async Task Delete(int id)
        {
            var CatégorieToDelete = await _context.catégories.FindAsync(id);
            _context.catégories.Remove(CatégorieToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Catégorie>> Get()
        {
            return await _context.catégories.ToListAsync();
        }

        public async Task<Catégorie> Get(int id)
        {
            return await _context.catégories.FindAsync(id);
        }

        public async Task Update(Catégorie catégorie)
        {
            _context.Entry(catégorie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
