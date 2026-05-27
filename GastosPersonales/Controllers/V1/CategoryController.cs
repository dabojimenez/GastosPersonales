using GastosPersonales.Data;
using GastosPersonales.DTOs;
using GastosPersonales.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GastosPersonales.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(
            ApplicationDbContext context
            )
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategories([FromQuery] PaginacionDTO paginacionDTO)
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
