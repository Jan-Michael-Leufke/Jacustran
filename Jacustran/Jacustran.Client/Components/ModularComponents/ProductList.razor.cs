
using Jacustran.Domain.Entity.Entities;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Jacustran.Client.Components.ModularComponents;

public partial class ProductList
{
    [Inject]
    HttpClient client { get; set; } = default!;  

    private static List<Product> _products = new List<Product>();
   

    protected override async Task OnInitializedAsync()
    {
        var response = await client.GetFromJsonAsync<List<Product>>("api/products");

        if(response != null) _products = response;
        
    }

}   