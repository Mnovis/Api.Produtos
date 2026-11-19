using Api.Produtos.Domain.Entities;
using FluentValidation;

namespace Api.Produtos.Domain.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O Nome é obrigatório")
                .MinimumLength(6).WithMessage("O Nome deve ter no mínimo 6 caracteres.")
                .MaximumLength(50).WithMessage("O Nome deve ter no máximo 50 caracteres.");

            RuleFor(p => p.Preco)
                .NotEmpty().WithMessage("O Preço é obrigatório")
                .GreaterThan(0).WithMessage("O Preço deve ser maior que 0");

            RuleFor(p => p.Quantidade)
                .NotEmpty().WithMessage("A Quantidade é obrigatória")
                .GreaterThanOrEqualTo(0).WithMessage("A Quantidade deve ser maior ou igual a 0");
        }
    }
}
