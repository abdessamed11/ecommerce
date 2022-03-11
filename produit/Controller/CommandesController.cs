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
    public class CommandesController : ControllerBase
    {
        private readonly ICommandeRepository commandeRepository;

        public CommandesController(ICommandeRepository commandeRepository)
        {
            this.commandeRepository = commandeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Commande>> GetCommandes()
        {
            return await commandeRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Commande>> GetCommandes(int id)
        {
            return await commandeRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Commande>> PostCommandes([FromBody] Commande commande)
        {
            var newCommande = await commandeRepository.Create(commande);
            return CreatedAtAction(nameof(GetCommandes), new { id = newCommande.Id }, newCommande);
        }

        [HttpPut]
        public async Task<ActionResult<Commande>> PutCommandes(int id, [FromBody] Commande commande)
        {
            if (id != commande.Id)
            {
                return BadRequest();
            }
            await commandeRepository.Update(commande);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Commande>> Delete(int id)
        {
            var CommandeToDelete = await commandeRepository.Get(id);
            if (CommandeToDelete == null)
                return NotFound();

            await commandeRepository.Delete(CommandeToDelete.Id);
            return NoContent();

        }

    }
}
