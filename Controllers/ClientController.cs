using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarServiceClients.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarServiceClients.Controllers
{
    [Route("api/Client")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ClientController(ApplicationDbContext db) 
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll ()
        {
            return Json(new { data = await _db.Client.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var clientFromDb = await _db.Client.FirstOrDefaultAsync(u => u.Id == id);
            if (clientFromDb == null)
            {
                return Json(new { success = false, message = "Błąd podczas usuwania" });
            }
            _db.Client.Remove(clientFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Klient został usunięty" });
        }
    }
}
