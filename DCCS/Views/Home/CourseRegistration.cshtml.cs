using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace DCCS.Views.Home
{
    public class CourseRegistrationModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<CourseRegistrationModel> _logger;
        private readonly IEmailSender _emailSender;

        public CourseRegistrationModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<CourseRegistrationModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Name of Student")]
            public string StudentName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Name of Parent")]
            public string ParentName { get; set; }

            [Required]
            [Display(Name = "Chinese 1")]
            public bool Chinese1Selected { get; set; }
        }

        public Task OnGetAsync()
        {
            this.Input.Email = User.Identity.Name;
            return Task.CompletedTask;
        }

        public IActionResult OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                return Page();
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}