using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reviefy.API.Services;

namespace Reviefy.API.Pages
{
    public class ContactUs : PageModel
    {
        public void OnGet()
        {

        }
        
        public async Task<IActionResult> OnPostSendMessage(string name, string email,
            string subject, string message)
        {
            var emailService = new EmailService();
            await emailService.SendEmailAsync("maniaclord@bk.ru", subject, $"{email} \n {name}\n" + message);
            return RedirectToPage("./Index");
        }
    }
}