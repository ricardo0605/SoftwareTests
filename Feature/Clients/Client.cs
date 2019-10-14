using Feature.Core;
using FluentValidation;
using System;

namespace Feature.Clients
{
    public class Client : Entity
    {
        public string FirstName { get; set; }
        public string LasName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public Client()
        {
        }

        public Client(Guid id,
                      string firstName,
                      string lastName,
                      DateTime birthdate,
                      string email,
                      bool isActive)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LasName = lastName;
            this.Birthdate = birthdate;
            this.Email = email;
            this.IsActive = IsActive;
        }

        public string FullName()
        {
            return $"{FirstName} {LasName}";
        }

        public bool IsEspecial()
        {
            return CreatedAt < DateTime.Now.AddYears(-3) && IsActive;
        }

        public void Inactivate()
        {
            IsActive = default(bool);
        }

        public override bool IsValid()
        {
            ValidationResult = new ClientValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class ClientValidation : AbstractValidator<Client>
    {
        public ClientValidation()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);

            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .MaximumLength(50).WithMessage("Please provide a first name with maximum of 50 characters");

            RuleFor(c => c.LasName)
                .NotEmpty().WithMessage("Last name is required")
                .MaximumLength(50).WithMessage("Please provide the last name with maximum of 50 characters");

            RuleFor(c => c.Birthdate)
                .NotEmpty()
                .Must(HaveMiniumAge)
                .WithMessage("The client must have more than 18 years old");

            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Please provide a valid email address");
        }

        private bool HaveMiniumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }
    }
}
