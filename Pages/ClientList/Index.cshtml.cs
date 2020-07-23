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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Client> Clients { get; set; }


        public async Task OnGet()
        {
            Clients = await _db.Client.ToListAsync();
        }
    }
}