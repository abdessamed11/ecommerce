using produit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace produit.Repositorie
{
    public interface IImageRepository
    {
        Task<IEnumerable<Image>> Get();
        Task<Image> Get(int id);
        Task<Image> Create(Image image);
        Task Update(Image image);
        Task Delete(int id);
    }
}
