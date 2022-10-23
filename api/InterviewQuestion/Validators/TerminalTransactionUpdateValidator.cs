using FluentValidation;
using InterviewQuestion.API.DTOs;

namespace InterviewQuestion.API.Validators
{
    public class TerminalTransactionUpdateValidator : AbstractValidator<TerminalTransactionUpdateDto>
    {
        public TerminalTransactionUpdateValidator()
        {
            RuleFor(x => x.TransactionReference).NotEmpty().WithMessage("Specify session ID");
            RuleFor(x => x.Processor).NotEmpty().Length(5).WithMessage("Specify processor not less than or greater than 6");
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Specify an amount");
            RuleFor(x => x.ResponseCode).NotEmpty().Length(2).WithMessage("Specify response code not less than or greater than 2");
            RuleFor(x => x.AgentName).NotEmpty().WithMessage("Specify agent name");
        }
    }
}
