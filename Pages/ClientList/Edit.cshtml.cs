 using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using CarServiceClients.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarServiceClients.Pages.ClientList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Client Client { get; set; }

        public async Task OnGet(int id)
        {
            Client = await _db.Client.FindAsync(id); 
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var ClientFromDb    = await _db.Client.FindAsync(Client.Id);
                ClientFromDb.Name   = Client.Name;
                ClientFromDb.Car    = Client.Car;
                ClientFromDb.Status = Client.Status;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}