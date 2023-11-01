﻿using AcortURL.Data;
using AcortURL.Entities;
using AcortURL.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;
using AcortURL.Models.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace AcortURL.Controllers
{

    [ApiController]
    [Route(template: "api/[controller]")]
    [Authorize]

    public class URLController : ControllerBase
    {
        private UrlsShortenerContext _UrlContext;

        public URLController(UrlsShortenerContext UrlContext)
        {
            _UrlContext = UrlContext;
        }


        [HttpGet("get")]
        public IActionResult GetURLs()
        {
            return Ok(_UrlContext.Urls.ToList());
        }


        [HttpGet("get/{url}")]
        public IActionResult GetURL(string url)
        {
            var urlEntity = _UrlContext.Urls.FirstOrDefault(u => u.UrlCorta == url);

            if (urlEntity == null)
            {
                return NotFound("La URL no existe");
            }
            else
            {
                urlEntity.Visitas++;
                // Mueve el SaveChanges aquí para asegurarte de que se guarde la visita
                _UrlContext.SaveChanges();

                // Redirige al usuario después de incrementar el contador de visitas
                return Redirect(urlEntity.Url);
            }
        }


        [HttpPost("post")]
        public IActionResult CreateURL([FromQuery] URLForCreationDto newUrl)
        {
            var existingURL= _UrlContext.Urls.FirstOrDefault(u => u.Url == newUrl.Url);
            if (existingURL != null)
            {
                return Conflict("La URL ya existe en la base de datos.");
            }
            else { 
            string shortUrl = GenerarShortURL.GenerarShortUrl();

            var urlEntity = new URL()
            {
                Nombre = newUrl.Nombre,
                Url = newUrl.Url,
                UrlCorta = shortUrl,
                Visitas=0,
               
            };
                
            var categoria = new CategoriasURL()
                {
                    NombreCategoria = newUrl.Categoria,
                    URLs = new System.Collections.Generic.List<URL>()
                    {
                        urlEntity
                    }
                };
            _UrlContext.CategoriasURL.Add(categoria);
            _UrlContext.Urls.Add(urlEntity);
            _UrlContext.SaveChanges();

                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                };

                string jsonResponse = JsonSerializer.Serialize(urlEntity, options);

                return Redirect(newUrl.Url);
            }
        }
    }
}



