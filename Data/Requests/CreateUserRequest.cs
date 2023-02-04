using FluentValidation;
using System.Text.RegularExpressions;
using WebApi.Users.Data.Models;

namespace WebApi.Users.Data.Requests
{
    public class CreateUserRequest
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string status { get; set; }
    }

    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.UserName).
                Cascade(CascadeMode.StopOnFirstFailure).
                NotEmpty().
                NotNull().
                Length(3, 20).WithMessage("UserName must be between 3 and 15 characters");
                
            
            RuleFor(x => x.FirstName).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().
                NotEmpty().WithMessage("FirstName cannot be null or empty")
                .Must(x => !Regex.IsMatch(x, @"[0-9]")).WithMessage("FirstName cannot contain numbers");

            RuleFor(x => x.LastName).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().
                 NotEmpty().WithMessage("LastName cannot be null or empty")
                .Must(x => !Regex.IsMatch(x, @"[0-9]")).WithMessage("LastName cannot contain numbers");

            RuleFor(x => x.Password).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().
                 NotEmpty().
                 WithMessage("Password Cannot be null or empty")
                .Length(8, 12).WithMessage("Password must contain between 8 and 12 characters");

            RuleFor(x => x.Phone).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Phone is required");
                //.Must(x => Regex.IsMatch(x, @"^\+(?:[0-9]●?){6,14}[0-9]$")).WithMessage("Must contain a plus sign");

           
        }
    }
}
