using CQRSMediatREF.Db.Command;
using CQRSMediatREF.Db.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace CQRSMediatREF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {

        private readonly IMediator _mediator;        

        public ProductController( IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetById([FromHeader] int Id)
        {
            var response = _mediator.Send(new GetProduct.ById(Id)).GetAwaiter().GetResult();
            return Json(new { response.Product });
        }

        [HttpGet]
        [Route("GetByValue")]
        public IActionResult GetByValue([FromHeader] decimal value)
        {
            var response = _mediator.Send(new GetProduct.GetByValue(value)).GetAwaiter().GetResult();
            return Json(new { response.Product });
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Product product)
        {
            var response = _mediator.Send(new InsertProduct.Command(product)).GetAwaiter().GetResult();            
            return Json(new { response.Product });
        }
    }
}