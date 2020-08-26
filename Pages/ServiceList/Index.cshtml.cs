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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Service> Services { get; set; }


        public async Task OnGet()
        {
            Services = await _db.Service.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var service = await _db.Service.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            _db.Service.Remove(service);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}