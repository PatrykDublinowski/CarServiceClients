using System;
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

        public async Task<IActionResult> OnGet(int? id)
        {
            //TODO: poskracać IFy
            Service = new Service();
            if (id == null)
            {
                //create
               return Page();
            }

            //update
            Service = await _db.Service.FirstOrDefaultAsync(u => u.Id == id);
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
                if (Service.Id == 0)
                {
                    _db.Service.Add(Service);
                }
                else
                {
                    _db.Service.Update(Service);
                }

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}