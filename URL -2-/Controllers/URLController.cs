using AcortURL.Data;
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
using URL__2_.Models.Models.Enum;
using URL__2_.Services;

namespace AcortURL.Controllers
{

    [ApiController]
    [Route(template: "api/[controller]")]
    [Authorize]

    public class URLController : ControllerBase
    {
        
        private UrlServices _UrlServices;

        public URLController(UrlServices urlservices)
        {
            _UrlServices = urlservices;
        }


        [HttpGet("get")]
        public IActionResult GetURLs()
        {
            return Ok(_UrlServices.getAll());
        }


        [HttpGet("get/{url}")]
        [AllowAnonymous]
        public IActionResult GetURL(string url)
        {
            return _UrlServices.GetUrlByShortUrl(url);
        }


        [HttpPost("post")]
        public IActionResult CreateURL([FromQuery] URLForCreationDto newUrl)
        {
            return _UrlServices.CreateUrl(newUrl);
        }


        [HttpGet("api/url/getAllByCategories")]
        public IActionResult getAllbyCategories(Categoria categorias)
        {
            var categoria = _UrlServices.GetUrlsByCategory(categorias);
            if (categoria == null)
            {
                return Ok("No hay urls con esa categoria");
            }else
            {
                return Ok(categoria);
            }
        }
    }

}
    

    




