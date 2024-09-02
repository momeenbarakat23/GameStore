using System.ComponentModel.DataAnnotations;

namespace store.ModelView
{
    public class RegisterModelView
    {
       
        public string Name { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }

    }
}
