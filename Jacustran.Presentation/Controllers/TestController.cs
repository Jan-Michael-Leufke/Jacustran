using Jacustran.Presentation.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Buffers;
using System.Text;

namespace Jacustran.Presentation.Controllers;

[Route("api/Test")]
public class TestController(ISender sender, IMapper mapper) : ApiController(sender, mapper)
{
    [HttpPost("{id:int}")]
    public async Task<IActionResult> PostIt(Something something)
    {
        StringBuilder sb = new StringBuilder();
        byte[] buffer = ArrayPool<byte>.Shared.Rent(4096);

        while (true)
        {
            var bytesRemaining = await Request.Body.ReadAsync(buffer, 0, buffer.Length);
            if (bytesRemaining == 0) break;


            var endcodedString = Encoding.UTF8.GetString(buffer, 0, bytesRemaining);
            sb.Append(endcodedString);
        }


        ArrayPool<byte>.Shared.Return(buffer);

        var entireRequestBody = sb.ToString();

        List<string> BodyList = new(entireRequestBody.Split("\n"));


        return Ok(something);
    }
}


public class Something
{
    [FromBody]
    public string Name { get; set; } = "dude";

    [FromRoute]
    public int Id { get; set; } = 444;  

}
