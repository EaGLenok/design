using FluentValidation;
using MediatR;

namespace LibraryDesingKey.Application.CQRS.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
{
    public async Task<TResponse> Handle(TRequest req, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
    {
        if (validators.Any())
        {
            var context = new ValidationContext<TRequest>(req);
            var failures = validators.Select(v => v.Validate(context)).SelectMany(r => r.Errors).Where(e => e != null)
                .ToList();
            if (failures.Any()) throw new ValidationException(failures);
        }

        return await next();
    }
}