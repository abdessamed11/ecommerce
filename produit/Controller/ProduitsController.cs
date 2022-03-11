using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using produit.Models;
using produit.Repositorie;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace produit.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private readonly IProduitRepository _produitRepository;

        public ProduitsController(IProduitRepository produitRepository, IConfiguration configuration, IWebHostEnvironment env)
        {
            _produitRepository = produitRepository;
            _configuration = configuration;
            _env = env;
        }

        [HttpGet("getall")]
        public async Task<IEnumerable<Produit>> GetProduits()
        {
            return await _produitRepository.Get();
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult<Produit>> GetProduits(int id)
        {

            return await _produitRepository.Get(id);
        }

        //[HttpPost("add")]
        //public async Task<ActionResult<Produit>> PostProduits([FromBody] Produit produit)
        //{
        //    var newProduit = await _produitRepository.Create(produit);
        //    return CreatedAtAction(nameof(GetProduits), new { id = newProduit.Id }, newProduit);
        //}

        [HttpPost("addproduct")]
        public void PostProduits([FromForm] Produit produit, IFormFile image)
        {
            var pathImage = Path.Combine(_env.WebRootPath, "Images", image.FileName);
            var streamImage = new FileStream(pathImage, FileMode.Append);
            image.CopyTo(streamImage);

            var newProduit = new Produit
            {
                Id = produit.Id,
                NameProduit = produit.NameProduit,
                PrixProduit = produit.PrixProduit,
                Quantite = produit.Quantite,
                ImagePath = image.FileName,
                CatégorieId = produit.CatégorieId
            };

            _produitRepository.addProduit(newProduit);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Produit>> PutProduits(int id, [FromBody] Produit produit)
        {
          

            if (id != produit.Id)
            {
                return BadRequest();
            }
            await _produitRepository.Update(produit);
            return Ok(produit);
        }

        [HttpDelete("delete")]
        public async Task<IEnumerable<Produit>> Delete(int id)
        {
            var produitToDelete = await _produitRepository.Get(id);
            if (produitToDelete == null)

                return null;

            await _produitRepository.Delete(produitToDelete.Id);
            return await GetProduits();
        }


        

    }
}
