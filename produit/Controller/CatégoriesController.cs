using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using produit.Models;
using produit.Repositorie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace produit.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatégoriesController : ControllerBase
    {

        private readonly ICatégorieRepository _catégorieRepository ;

        public CatégoriesController(ICatégorieRepository catégorieRepository)
        {
            _catégorieRepository = catégorieRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<Catégorie>> GetCatégories()
        {
            return await _catégorieRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Catégorie>> GetCatégories(int id)
        {
            return await _catégorieRepository.Get(id);
        }

        [HttpPost("addcategorie")]
        public async Task<ActionResult<Catégorie>> PostCatégories([FromForm] Catégorie catégorie, List<IFormFile> image)
        {
            await _catégorieRepository.Create(catégorie,image);

            return Ok(catégorie);
        }

        [HttpPut]
        public async Task<ActionResult<Catégorie>> PutCatégories(int id, [FromBody] Catégorie catégorie)
        {
            if (id != catégorie.Id)
            {
                return BadRequest();
            }
            await _catégorieRepository.Update(catégorie);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Catégorie>> Delete(int id)
        {
            var produitToDelete = await _catégorieRepository.Get(id);
            if (produitToDelete == null)
                return NotFound();

            await _catégorieRepository.Delete(produitToDelete.Id);
            return NoContent();


        }

    }
}
