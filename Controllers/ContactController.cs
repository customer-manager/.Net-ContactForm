using ContactForm.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactForm.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ContactFormModel form)
        {
            if (ModelState.IsValid)
            {
                _context.ContactForms.Add(form);
                _context.SaveChanges();
                return RedirectToAction("Success");
            }
            return View(form);
        }

        public IActionResult Success()
        {
            return View();
        }
        public IActionResult Forms(string formType)
        {
        var forms = _context.ContactForms
        .Where(f => f.Department == formType)
        .ToList();

        return View(forms);
        }

    }
}
