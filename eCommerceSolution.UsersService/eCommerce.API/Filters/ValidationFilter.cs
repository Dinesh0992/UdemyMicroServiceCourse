using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using FluentValidation;
using FluentValidation.Results;

namespace eCommerce.API.Filters
{
    public class ValidationFilter<T> : IAsyncActionFilter where T : class
    {
        private readonly IValidator<T> _validator;

        public ValidationFilter(IValidator<T> validator)
        {
            _validator = validator;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var argument = context.ActionArguments.Values.OfType<T>().FirstOrDefault();
            if (argument == null)
            {
                context.Result = new BadRequestObjectResult(new { Message = "Invalid request data" });
                return;
            }

            ValidationResult validationResult = await _validator.ValidateAsync(argument);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => new
                {
                    Field = error.PropertyName,
                    Message = error.ErrorMessage
                });

                context.Result = new BadRequestObjectResult(new { Errors = errors });
                return;
            }

            await next();
        }
    }
}
