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
    public class ListProduitsController : ControllerBase
    {
        private readonly IlistProduitRepository listProduitRepository;

        public ListProduitsController(IlistProduitRepository ilistProduitRepository)
        {
            this.listProduitRepository = ilistProduitRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ListProduit>> GetListProduit()
        {
            return await listProduitRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ListProduit>> GetListProduit(int id)
        {
            return await listProduitRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<ListProduit>> PostListProduit([FromBody] ListProduit listProduit)
        {
            var newListProduit = await listProduitRepository.Create(listProduit);
            return CreatedAtAction(nameof(GetListProduit), new { id = newListProduit.Id }, newListProduit);
        }

        [HttpPut]
        public async Task<ActionResult<ListProduit>> PutListProduit(int id, [FromBody] ListProduit listProduit)
        {
            if (id != listProduit.Id)
            {
                return BadRequest();
            }
            await listProduitRepository.Update(listProduit);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ListProduit>> Delete(int id)
        {
            var ListProduitToDelete = await listProduitRepository.Get(id);
            if (ListProduitToDelete == null)
                return NotFound();

            await listProduitRepository.Delete(ListProduitToDelete.Id);
            return NoContent();

        }
    }
}
