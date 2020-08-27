using System.Collections.Generic;
using System.Threading.Tasks;
using CarServiceClients.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarServiceClients.Pages.ServiceList
{
    public class IndexEmployeesModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexEmployeesModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Employee> Employees { get; set; }

        public async Task OnGet()
        {
            Employees = await _db.Employee.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var employee = await _db.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            _db.Employee.Remove(employee);
            await _db.SaveChangesAsync();

            return RedirectToPage("IndexEmployees");
        }
    }
}