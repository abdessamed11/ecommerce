using Microsoft.EntityFrameworkCore;
using produit.Data;
using produit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace produit.Repositorie
{
    public class ImageRepository: IImageRepository
    {
        private readonly ApplicationDbContext _context;
        public ImageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Image> Create(Image image)
        {
            _context.images.Add(image);
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task Delete(int id)
        {
            var ImageToDelete = await _context.images.FindAsync(id);
            _context.images.Remove(ImageToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Image>> Get()
        {
            return await _context.images.ToListAsync();
        }

        public async Task<Image> Get(int id)
        {
            return await _context.images.FindAsync(id);
        }

        public async Task Update(Image image)
        {
            _context.Entry(image).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
 
    }
}
