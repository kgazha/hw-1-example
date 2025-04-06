using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HomeWorkExample.Controllers;

[Route("/[controller]/[action]")]
public abstract class ApiController : Controller
{
    private IMediator? _mediator;

    protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}