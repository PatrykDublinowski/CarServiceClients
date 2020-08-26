using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarServiceClients.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarServiceClients.Controllers
{
    [Route("api/Service")]
    [ApiController]
    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ServiceController(ApplicationDbContext db) 
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll ()
        {
            return Json(new { data = await _db.Service.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var serviceFromDb = await _db.Service.FirstOrDefaultAsync(u => u.Id == id);
            if (serviceFromDb == null)
            {
                return Json(new { success = false, message = "Błąd podczas usuwania" });
            }
            _db.Service.Remove(serviceFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Klient został usunięty" });
        }
    }
}
