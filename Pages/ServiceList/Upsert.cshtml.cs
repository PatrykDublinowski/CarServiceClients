using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarServiceClients.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarServiceClients.Pages.ServiceList
{
    public class UpsertModel : PageModel
    {
        private ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Service Service { get; set; }
        
        public IEnumerable<Client> ListOfClients { get; set; }
        public IEnumerable<Employee> ListOfEmployees { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            ListOfClients   = await _db.Client.ToListAsync();
            ListOfEmployees = await _db.Employee.ToListAsync();

            //TODO: poskracać IFy
            Service = new Service();
            if (id == null)
            {
                //create
               return Page();
            }

            //update
            Service = await _db.Service.FirstOrDefaultAsync(u => u.ServiceID == id);
            if (Service == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Service.ServiceID == 0)
                {
                    Service.CreateDate   = System.DateTime.Now;
                    Service.LastEditDate = System.DateTime.Now;

                    _db.Service.Add(Service);
                }
                else
                {
                    Service.LastEditDate = System.DateTime.Now;
                    _db.Service.Update(Service);
                }

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            //sprawdzam co dzieje się z modelem, ze się nie waliduje
            var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
            return RedirectToPage();
        }
    }
}