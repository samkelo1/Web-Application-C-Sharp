using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using coderush.Data;
using coderush.Models;
using coderush.Models.SyncfusionViewModels;
using Microsoft.AspNetCore.Authorization;
using coderush.Models.ManageViewModels;

namespace coderush.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Locations")]
    public class MapController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MapController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Areas> Items = await _context.Areas.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }


        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            List<Locations> Items = _context.Locations.Where(s => s.AreaId == id).ToList();

            return Ok(Items);
        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<Locations> payload)
        {
            Locations locations = payload.value;
            _context.Locations.Add(locations);
            _context.SaveChanges();
            return Ok(locations);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<Locations> payload)
        {
            Locations locations = payload.value;
            _context.Locations.Update(locations);
            _context.SaveChanges();
            return Ok(locations);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<Locations> payload)
        {
            Locations locations = _context.Locations
                .Where(x => x.LocationId == (int)payload.key)
                .FirstOrDefault();
            _context.Locations.Remove(locations);
            _context.SaveChanges();
            return Ok(locations);

        }

        //GET AReas
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAreaById(int id)
        {
            List<Areas> Items = _context.Areas.Where(s => s.AreaID == id).ToList();

            return Ok(Items);
        }
    }
}