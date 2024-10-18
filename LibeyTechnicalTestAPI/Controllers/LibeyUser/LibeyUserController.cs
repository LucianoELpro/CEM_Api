using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace LibeyTechnicalTestAPI.Controllers.LibeyUser
{
    [ApiController]
    [Route("[controller]")]
    public class LibeyUserController : Controller
    {
        private readonly ILibeyUserAggregate _aggregate;
        public LibeyUserController(ILibeyUserAggregate aggregate)
        {
            _aggregate = aggregate;
        }
        [HttpGet]
        [Route("{documentNumber}")]
        public IActionResult FindResponse(string documentNumber)
        {
            var row = _aggregate.FindResponse(documentNumber);
            return Ok(row);
        }
        [HttpPost("CreateClient")]       
        public IActionResult CreateClient(UserUpdateorCreateCommand command)
        {
             _aggregate.Create(command);
            return Ok(true);
        }

        [HttpGet("GetAllDocumentTypes")]
        public IActionResult GetAllDocumentTypes()
        {
            var list = _aggregate.GetAllDocumentTypes();
            return Ok(list);
        }

        [HttpGet("GetAllRegions")]
        public IActionResult GetAllRegions()
        {
            var list = _aggregate.GetAllRegions();
            return Ok(list);
        }


        [HttpGet("GetProvincesByCode")]     
        public IActionResult GetProvincesByCode(string regionCode)
        {
            var list = _aggregate.GetProvincesByCode(regionCode);
            return Ok(list);
        }

        [HttpGet("GetUbigeosByCode")]
        public IActionResult GetUbigeosByCode(string provinceCode, string regionCode)
        {
            var list = _aggregate.GetUbigeosByCode(provinceCode, regionCode);
            return Ok(list);
        }


        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var list = _aggregate.GetAllUsers();
            return Ok(list);
        }

        [HttpPost("UpdateUser")]
        public IActionResult UpdateUser(UserUpdateorCreateCommand command)
        {
            var list = _aggregate.UpdateUser(command);
            return Ok(list);
        }

        [HttpPost("DeleteUser")]
        public IActionResult DeleteUser(string documentNumber)
        {
            var list = _aggregate.DeleteUser(documentNumber);
            return Ok(list);
        }
        
    }
}