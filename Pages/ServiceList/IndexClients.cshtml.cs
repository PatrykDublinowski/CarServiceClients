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
    public class IndexClientsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexClientsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Client> Clients { get; set; }

        public async Task OnGet()
        {
            Clients = await _db.Client.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var client = await _db.Client.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            _db.Client.Remove(client);
            await _db.SaveChangesAsync();

            return RedirectToPage("IndexClients");
        }
    }
}