using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;

namespace Jacustran.Presentation.Modelbinders;

public class CollectionModelBinderType<TElement> : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (!bindingContext.ModelMetadata.IsCollectionType)
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

        var converter = TypeDescriptor.GetConverter(typeof(TElement));

        var values = value.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
            .Select(v => converter.ConvertFromString(v.Trim()))
            .ToArray();

        var typedValues = Array.CreateInstance(typeof(TElement), values.Length);

        values.CopyTo(typedValues, 0);

        bindingContext.Model = typedValues;

        bindingContext.Result = ModelBindingResult.Success(bindingContext.Model);

        return Task.CompletedTask;
    }
}

public class CollectionModelBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (context.Metadata.IsCollectionType)
        {
            var elementType = context.Metadata.ModelType.GenericTypeArguments[0];

            var modelType = typeof(CollectionModelBinderType<>).MakeGenericType(elementType);

            return (IModelBinder)Activator.CreateInstance(modelType)!;
        }

        return null;
    }
}
