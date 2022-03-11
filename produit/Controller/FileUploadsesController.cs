using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using produit.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace produit.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadsesController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;

        public FileUploadsesController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        public string Post([FromForm] FileUpload objectFile)
        {
            try
            {

                if (objectFile.files.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\Upload\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + objectFile.files.FileName))
                    {
                        objectFile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return "\\Upload\\" + objectFile.files.FileName;
                    }
                }
                else
                {
                    return "not Uploaded.";
                }
            } catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }


        [HttpGet("{fileName}")]

        public async Task<IActionResult> Get([FromRoute] string fileName)
        {
            string path = _webHostEnvironment.WebRootPath + "\\Upload\\";
            var filePath = path + fileName + ".png";
            if (System.IO.File.Exists(filePath))
            {
                byte[] b = System.IO.File.ReadAllBytes(filePath);
                return File(b, "image/png");
            }
            return null;
        }
    }
}
