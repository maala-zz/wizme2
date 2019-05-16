using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wizme.Services;
using AutoMapper;
using Wizme.Models;

namespace Wizme.Controllers
{
    [Route("api/spaces")]
    public class SpacesController : Controller
    {
        private ISpaceServices _SpaceService;
        public SpacesController(ISpaceServices spaceServices)
        {
            _SpaceService = spaceServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet()]
        public IActionResult GetAllSpaces()
        {
            var spaces = _SpaceService.GetAllSpaces();
            var spacesDto = Mapper.Map<IEnumerable<SpaceDto>>(spaces);
            return new JsonResult(spacesDto);
        }
        [HttpGet("{id}")]
        public IActionResult GetSpace(Guid id)
        {
            var space = _SpaceService.GetSpace(id);
            if (space == null) return NotFound();
            var spaceDto = Mapper.Map<SpaceDto>(space);
            return new JsonResult( spaceDto );
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSpace(Guid id)
        {
            var space = _SpaceService.GetSpace(id);
            if (space == null)
                return NotFound();
            _SpaceService.DeleteSpace(space);
            if (!_SpaceService.Save())
                throw new Exception("can't delete the Space, try again later!");
            return NoContent();
        }
    }
}