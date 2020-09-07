using System.Linq;
using System.Threading.Tasks;
using CarServiceClients.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarServiceClients.Pages.ServiceList
{
    public class UpsertClientModel : PageModel
    {
        private ApplicationDbContext _db;

        public UpsertClientModel(ApplicationDbContext db)
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
            Client = await _db.Client.FirstOrDefaultAsync(u => u.ClientID == id);
            if (Client == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Client.ClientID == 0)
                {
                    _db.Client.Add(Client);
                }
                else
                {
                    _db.Client.Update(Client);
                }

                await _db.SaveChangesAsync();

                return RedirectToPage("IndexClients");
            }
            var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
            return RedirectToPage();
        }
    }
}