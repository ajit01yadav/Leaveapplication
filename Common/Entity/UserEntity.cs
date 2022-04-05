using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UserEntity
{
    [ScaffoldColumn(false)]
    public int UserId { get; set; }

    [Required(ErrorMessage = Validations.User.FirstNameRequired)]
    [RegularExpression(Validations.RegularExpression.NameValidation , ErrorMessage = Validations.User.FirstNameError)]
    [Display(Name = Validations.User.FirstName)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = Validations.User.LastNameRequired)]
    [RegularExpression(Validations.RegularExpression.NameValidation, ErrorMessage = Validations.User.LastNameError)]
    [Display(Name = Validations.User.LastName)]
    public string LastName { get; set; }

    [Required(ErrorMessage = Validations.User.EmailRequired)]
    [RegularExpression(Validations.RegularExpression.EmailValidation, ErrorMessage = Validations.User.EmailError)]
    [Display(Name = Validations.User.Email)]
    public string Email { get; set; }

    [Required(ErrorMessage = Validations.User.PasswordRequired)]
    [Display(Name = Validations.User.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Please select role")]
    [Display(Name = Validations.User.Role)]
    public int RoleID { get; set; }

    public string RoleName { get; set; }

    [Required(ErrorMessage = Validations.User.StatusRequired)]
    [Display(Name = Validations.User.Status)]
    public int Status { get; set; }

    public int IsLockedOut { get; set; }
    public int FailedPasswordAttemptCount { get; set; }
    public string UpdateBy { get; set; }
    public string UpdateOn { get; set; }
}
