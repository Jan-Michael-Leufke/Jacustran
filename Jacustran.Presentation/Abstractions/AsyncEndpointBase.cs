using Microsoft.AspNetCore.Mvc;

namespace Jacustran.Presentation.Abstractions;

public static class AsyncEndpointBase
{
    public static class WithRequest<TRequest>
    {
        public abstract class WithResponse<TResponse> : ApiController
        {
            protected WithResponse(ISender sender, IMapper mapper) : base(sender, mapper)
            { }

            public abstract Task<ActionResult<TResponse>> HandleAsync(TRequest request, CancellationToken cancellationToken = default);
        }

        public abstract class WithResponseAsIActionResult : ApiController
        {
            protected WithResponseAsIActionResult(ISender sender, IMapper mapper) : base(sender, mapper)
            { }

            public abstract Task<IActionResult> HandleAsync(TRequest request, CancellationToken cancellationToken = default);
        }

        public abstract class WithoutResponse : ApiController
        {
            protected WithoutResponse(ISender sender, IMapper mapper) : base(sender, mapper)
            { }

            public abstract Task<ActionResult> HandleAsync(TRequest request, CancellationToken cancellationToken = default);
        }
    }

    public static class WithoutRequest
    {
        public abstract class WithResponse<TResponse> : ApiController
        {         
            protected WithResponse(ISender sender, IMapper mapper) : base(sender, mapper)
            { }

            public abstract Task<ActionResult<TResponse>> HandleAsync(CancellationToken cancellationToken = default);
        }

        public abstract class WithResponseAsIActionResult : ApiController
        {
            protected WithResponseAsIActionResult(ISender sender, IMapper mapper) : base(sender, mapper)
            { }

            public abstract Task<IActionResult> HandleAsync(CancellationToken cancellationToken = default);
        }

        public abstract class WithoutResponse : ApiController
        {
            protected WithoutResponse(ISender sender, IMapper mapper) : base(sender, mapper)
            { }

            public abstract Task<ActionResult> HandleAsync(CancellationToken cancellationToken = default);
        }
    }

}
