using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarServiceClients.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarServiceClients.Pages.ClientList
{
    public class UpsertModel : PageModel
    {
        private ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Client Client { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            //TODO: poskracać IFy
            Client = new Client();
            if (id == null)
            {
                //create
               return Page();
            }

            //update
            Client = await _db.Client.FirstOrDefaultAsync(u => u.Id == id);
            if (Client==null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Client.Id == 0)
                {
                    _db.Client.Add(Client);
                }
                else
                {
                    _db.Client.Update(Client);
                }

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}