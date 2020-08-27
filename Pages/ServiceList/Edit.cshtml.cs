using System.Threading.Tasks;
using CarServiceClients.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarServiceClients.Pages.ServiceList
{
    public class EditModel : PageModel
    {
        //TOOD:na razie nie używane zostawione dla przykładu

        //private ApplicationDbContext _db;

        //public EditModel(ApplicationDbContext db)
        //{
        //    _db = db;
        //}

        //[BindProperty]
        //public Service Service { get; set; }

        //public async Task OnGet(int id)
        //{
        //    Service = await _db.Service.FindAsync(id); 
        //}

        //public async Task<IActionResult> OnPost()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var ServiceFromDb = await _db.Service.FindAsync(Service.ServiceID);
        //        ServiceFromDb.Client = Service.Client;
        //        ServiceFromDb.Client.Cars = Service.Car;
        //        ServiceFromDb.Status = Service.Status;

        //        await _db.SaveChangesAsync();

        //        return RedirectToPage("Index");
        //    }
        //    return RedirectToPage();
        //}
    }
}