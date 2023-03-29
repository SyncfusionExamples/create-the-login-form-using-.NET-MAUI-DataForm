using Syncfusion.Maui.DataForm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm
{
    public class LoginFormModel
    {
        [Display(Prompt = "example@mail.com", Name = "Email")]
        [EmailAddress(ErrorMessage = "Enter your email - example@mail.com")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter the password")]
        public string Password { get; set; }
    }
}
