using System.Threading.Tasks;
using CarServiceClients.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarServiceClients.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Employee.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var employeeFromDb = await _db.Employee.FirstOrDefaultAsync(u => u.EmployeeID == id);
            if (employeeFromDb == null)
            {
                return Json(new { success = false, message = "Błąd podczas usuwania" });
            }
            _db.Employee.Remove(employeeFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Klient został usunięty" });
        }
    }
}
