using System.Threading.Tasks;
using CarServiceClients.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarServiceClients.Pages.ServiceList
{
    public class UpsertEmployeeModel : PageModel
    {
        private ApplicationDbContext _db;

        public UpsertEmployeeModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            //TODO: poskracać IFy
            Employee = new Employee();
            if (id == null)
            {
                //create
                return Page();
            }

            //update
            Employee = await _db.Employee.FirstOrDefaultAsync(u => u.EmployeeID == id);
            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Employee.EmployeeID == 0)
                {
                    _db.Employee.Add(Employee);
                }
                else
                {
                    _db.Employee.Update(Employee);
                }

                await _db.SaveChangesAsync();

                return RedirectToPage("IndexEmployees");
            }
            return RedirectToPage();
        }
    }
}