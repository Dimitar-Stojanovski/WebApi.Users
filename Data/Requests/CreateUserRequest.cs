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
            RuleFor(x => x.UserName).NotEmpty().NotNull().Length(3,20).WithMessage("UserName cannot exceed 15 characters or be null or empty");
            
            RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage("FirstName cannot be null or empty")
                .Must(x => !Regex.IsMatch(x, @"[0-9]")).WithMessage("FirstName cannot contain numbers");

            RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage("LastName cannot be null or empty")
                .Must(x => !Regex.IsMatch(x, @"[0-9]")).WithMessage("LastName cannot contain numbers");

            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password Cannot be null or empty")
                .Length(8, 12).WithMessage("Password must contain between 8 and 12 characters");

            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is required");
                //.Must(x => Regex.IsMatch(x, @"^\+(?:[0-9]●?){6,14}[0-9]$")).WithMessage("Must contain a plus sign");

           
        }
    }
}
