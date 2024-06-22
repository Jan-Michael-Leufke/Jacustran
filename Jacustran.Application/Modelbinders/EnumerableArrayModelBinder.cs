using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;

namespace Jacustran.Application.Modelbinders;


public class EnumerableArrayModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (!bindingContext.ModelMetadata.IsEnumerableType)
        {
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }

        var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).ToString();

        if (string.IsNullOrEmpty(value))
        {
            bindingContext.Result = ModelBindingResult.Success(null);
            return Task.CompletedTask;
        }

        var elementType = bindingContext.ModelMetadata.ElementType;

        var converter = TypeDescriptor.GetConverter(elementType);

        var values = value.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
            .Select(v => converter.ConvertFromString(v.Trim()))
            .ToArray();

        var typedValues = Array.CreateInstance(elementType, values.Length);

        Array.Copy(values, typedValues, values.Length);

        bindingContext.Model = typedValues;

        bindingContext.Result = ModelBindingResult.Success(bindingContext.Model);

        return Task.CompletedTask;
    }
}