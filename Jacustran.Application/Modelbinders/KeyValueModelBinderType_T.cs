using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;

namespace Jacustran.Application.Modelbinders;


public class KeyValueModelBinderType_T<TElement> : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext.ModelMetadata.ModelType != typeof(IDictionary<string, TElement>))
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

        IDictionary<string, TElement> modelDict = new Dictionary<string, TElement>();

        var values = value.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var item in values)
        {
            var keyValuePair = item.Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries);

            if (keyValuePair.Length != 2) continue;

            modelDict.Add(keyValuePair[0], (TElement)converter.ConvertFromString(keyValuePair[1])!);
        }

        bindingContext.Model = modelDict;

        bindingContext.Result = ModelBindingResult.Success(bindingContext.Model);

        return Task.CompletedTask;
    }
}
