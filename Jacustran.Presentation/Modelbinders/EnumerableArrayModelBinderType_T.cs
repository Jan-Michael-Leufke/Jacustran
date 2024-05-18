using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Xml.Linq;


namespace Jacustran.Presentation.Modelbinders;
public class EnumerableArrayModelBinderType<TElement> : IModelBinder
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

public class EnumerableModelBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (context.Metadata.IsCollectionType)
        {
            var elementType = context.Metadata.ModelType.GenericTypeArguments[0];

            var modelType = typeof(EnumerableArrayModelBinderType<>).MakeGenericType(elementType);

            return (IModelBinder)Activator.CreateInstance(modelType)!;
        }

        return null;
    }
}



//public class ComplexModelBinderType<TElement> : IModelBinder
//{
//    public Task BindModelAsync(ModelBindingContext bindingContext)
//    {

//        if (!bindingContext.ModelMetadata.IsComplexType)
//        {
//            bindingContext.Result = ModelBindingResult.Failed();
//            return Task.CompletedTask;
//        }

//        var propertyNamesAndTypes = bindingContext.ModelMetadata.ModelType.GetProperties().Select(p => new { p.Name, p.PropertyType } );


//        List<ValueProviderResult> values = new();

//        foreach (var name in propertyNamesAndTypes.Select(x => x.Name))
//        {
//            var valueProviderResult = bindingContext.ValueProvider.GetValue(name);

//            if (!string.IsNullOrEmpty(valueProviderResult.ToString()))
//            {
//                values.Add(valueProviderResult);
//            }
//        }

//        if (values.Count != propertyNamesAndTypes.Count())
//        {
//            bindingContext.Result = ModelBindingResult.Failed();
//            return Task.CompletedTask;
//        }

//        if(values.Count == 0)
//        {
//            bindingContext.Result = ModelBindingResult.Success(null);
//            return Task.CompletedTask;
//        }

//        foreach (var item in propertyNamesAndTypes.Select(x => x.PropertyType))
//        {

//        }

//        var converter = TypeDescriptor.GetConverter(typeof(TElement));

//        var values = value.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
//            .Select(v => converter.ConvertFromString(v.Trim()))
//            .ToArray();

//        var typedValues = Array.CreateInstance(typeof(TElement), values.Length);

//        values.CopyTo(typedValues, 0);

//        bindingContext.Model = typedValues;

//        bindingContext.Result = ModelBindingResult.Success(bindingContext.Model);

//        return Task.CompletedTask;
//    }
//}

