using AcortURL.Data;
using AcortURL.Entities;
using AcortURL.Helpers;
using AcortURL.Models;
using Microsoft.AspNetCore.Mvc;
using AcortURL.Models.Enum;
using System.Security.Cryptography.X509Certificates;
using AcortURL.Models.Dtos;
using URL__2_.Models.Models.Enum;

namespace URL__2_.Services
{
    public class UrlServices
    {
        private UrlsShortenerContext _urlContext;
        public UrlServices(UrlsShortenerContext context)
        {
            _urlContext = context;
        }
        public IEnumerable<URL> getAll()
        {
            return _urlContext.Urls.ToList();
        }

        public IActionResult GetUrlByShortUrl(string urlCorta)
        {
            var urlEntity = _urlContext.Urls.FirstOrDefault(u => u.UrlCorta == urlCorta);

            if (urlEntity == null)
            {
                return new NotFoundObjectResult("La URL no existe");
            }
            else
            {
                urlEntity.Visitas++;
                _urlContext.SaveChanges();
                return new RedirectResult(urlEntity.Url);
            }
        }

        public IActionResult CreateUrl(URLForCreationDto newUrl)
        {
            var existingUrl = _urlContext.Urls.FirstOrDefault(u => u.Url == newUrl.Url);
            if (existingUrl != null)
            {
                return new ConflictObjectResult("La URL ya existe en la base de datos.");
            }

            string shortUrl = GenerarShortURL.GenerarShortUrl();

            var urlEntity = new URL()
            {
                Nombre = newUrl.Nombre,
                Url = newUrl.Url,
                UrlCorta = shortUrl,
                Visitas = 0,
                Categorias = newUrl.Categorias,
            };

            _urlContext.Urls.Add(urlEntity);
            _urlContext.SaveChanges();

            return new RedirectResult(newUrl.Url);
        }

        public IEnumerable<URL> GetUrlsByCategory(Categoria categorias)
        {
            var urls = _urlContext.Urls.Where(u => u.Categorias == categorias).ToList();
            if (urls == null)
            {
                return null;
            }
            else
            {
                return urls;
            }
        }
    }
}