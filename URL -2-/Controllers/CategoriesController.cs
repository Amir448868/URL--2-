using AcortURL.Data;
using AcortURL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace AcortURL.Controllers
{
    [ApiController]
    [Route(template: "api/[controller]")]
    [Authorize]
    public class CategoriesController: ControllerBase
    {
        private readonly UrlsShortenerContext _UrlContext;

        public CategoriesController(UrlsShortenerContext UrlContext)
        {
            _UrlContext = UrlContext;
        }

        [HttpGet("get/{categories}")]
        public IActionResult GetCategories(string categories)
        {
            var categoryEntity = _UrlContext.CategoriasURL
                .Include(c => c.URLs) // Cargar ansiosamente las URLs
                .FirstOrDefault(u => u.NombreCategoria == categories);

            if (categoryEntity == null)
            {
                return NotFound("La categoría no existe.");
            }
            else
            {
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                };

                string jsonResponse = JsonSerializer.Serialize(categoryEntity, options);

                return Ok(jsonResponse);
            }
        }

    }
}
