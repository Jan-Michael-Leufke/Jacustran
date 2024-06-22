using Jacustran.Domain.DomainServices;

namespace Jacustran.Domain.Abstractions;

public abstract class ValidatableValueObject<T> : ValueObject<T> where T : ValidatableValueObject<T>
{
    public virtual DomainValidationResult<T> FluentValidate()
    {
        if (!ServiceLocator.IsSet) throw new InvalidOperationException("ServiceLocator not set");

        var validationResult = ServiceLocator.GetService<IValidator<T>>().Validate((T)this);
        
        return validationResult.IsValid ? DomainValidationResult<T>.Success((T)this)
                                        : DomainValidationResult<T>.Failure(new ValidationException(validationResult.Errors));
    }



    protected override abstract bool EqualsCore(T other);
    protected override abstract int GetHashCodeCore();
}
