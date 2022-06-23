using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entitdade não pode ser vazia")

                .NotNull()
                .WithMessage("A entidade não pode ser nula");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome não pode ser vazia")

                .NotNull()
                .WithMessage("O nome não pode ser nulo")

                .MinimumLength(3)
                .WithMessage("O nome deve ter no minímo 3 caracters ")

                .MaximumLength(80)
                .WithMessage("O nome deve ter no máximo 80 caracters");




                

            

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O email não pode ser vazia")


                .NotNull()
                .WithMessage("O email não pode ser nulo")

                .MinimumLength(10)
                .WithMessage("O nome deve ter no minímo 10 caracters ")

                .MaximumLength(180)
                .WithMessage("O nome deve ter no máximo 180 caracters")
                
                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("O email informado não é valido"); 









            RuleFor(x => x.Password)

                .NotEmpty()
                    .WithMessage("A senha não pode ser vazia")


                .NotNull()
                .WithMessage("A senha não pode ser nula")

                .MinimumLength(6)
                .WithMessage("A senha deve ter no minímo 6 caracters ")

                .MaximumLength(30)
                .WithMessage("A senha deve ter no máximo 30 caracters");
            



        }

    }
}
