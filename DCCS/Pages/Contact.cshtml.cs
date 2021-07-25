using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DCCS.Pages
{
    [AllowAnonymous]
    public class ContactModel : PageModel
    {
        private readonly IEmailSender _emailSender;

        public ContactModel(IEmailSender emailSender)
        {
            this._emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public string Name { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            public string Subject { get; set; }

            [Required]
            public string Message { get; set; }

            public override string ToString()
            {
                return MakeParagraph("[Name]") +
                    MakeParagraph(this.Name) +
                    MakeParagraph("[Email]") +
                    MakeParagraph(this.Email) +
                    MakeParagraph("[Subject]") +
                    MakeParagraph(this.Subject) +
                    MakeParagraph("[Message]") +
                    MakeParagraph(this.Message, true);
            }

            private static string MakeParagraph(string text, bool multipleLines = false)
            {
                return multipleLines
                    ? $"<textarea>{text}</textarea>"
                    : $"<p>{text}</p>";
            }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _emailSender.SendEmailAsync(
                "dccs.org@gmail.com",
                "Website Contact Message: " + Input.Email,
                Input.ToString());

            ModelState.AddModelError(string.Empty, "Message was sent. We will get back to you soon.");
            return Page();
        }
    }
}
