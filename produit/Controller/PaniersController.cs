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
    public class PaniersController : ControllerBase
    {
        private readonly IPanierRepository _panierRepository;
        public PaniersController(IPanierRepository panierRepository)
        {
            _panierRepository = panierRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Panier>> GetPaniers()
        {
            return await _panierRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Panier>> GetPaniers(int id)
        {
            return await _panierRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Panier>> PostPaniers([FromBody] Panier panier)
        {
            var newPanier = await _panierRepository.Create(panier);
            return CreatedAtAction(nameof(newPanier), new { id = newPanier.Id }, newPanier);
        }

        [HttpPut]
        public async Task<ActionResult<Panier>> PutPaniers(int id, [FromBody] Panier panier)
        {
            if (id != panier.Id)
            {
                return BadRequest();
            }
            await _panierRepository.Update(panier);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Panier>> Delete(int id)
        {
            var PanierToDelete = await _panierRepository.Get(id);
            if (PanierToDelete == null)
                return NotFound();

            await _panierRepository.Delete(PanierToDelete.Id);
            return NoContent();

        }
    }
}
